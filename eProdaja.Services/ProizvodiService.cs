using AutoMapper;
using eProdaja.DataBase;
using eProdaja.Model.Requests;
using eProdaja.Model.SearchObjects;
using eProdaja.Services.ProductStateMachine;
using Microsoft.EntityFrameworkCore;
using Microsoft.ML;
using Microsoft.ML.Data;
using Microsoft.ML.Trainers;
using Microsoft.VisualBasic;

namespace eProdaja.Services {
    public class ProizvodiService : BaseCRUDService<Model.Proizvodi, DataBase.Proizvodi, ProizvodiSearchObject, ProizvodiInsertRequest, ProizvodiUpdateRequest>, IProizvodiService {

        public BaseState BaseState { get; set; }
        public ProizvodiService(EProdajaContext context, IMapper mapper, BaseState baseState) : base(context, mapper) {
            BaseState = baseState;
        }

        public override Model.Proizvodi Insert(ProizvodiInsertRequest insert) {
            var state = BaseState.CreateState("initial");
            return state.Insert(insert);
        }
         
        public override Model.Proizvodi Update(int id, ProizvodiUpdateRequest update) {
            var product = Context.Proizvodis.Find(id);
            var state = BaseState.CreateState(product.StateMachine);
            state.CurrentEntity = product;
            state.Update(update);
            return GetByID(id);
        }

        public Model.Proizvodi Activate(int id) {
            var product = Context.Proizvodis.Find(id);
            var state = BaseState.CreateState(product.StateMachine);
            state.CurrentEntity = product;
            state.Activate();
            return GetByID(id);
        }

        public List<string> AllowedActions(int id) {
            var product = Context.Proizvodis.Find(id);
            var state = BaseState.CreateState(product.StateMachine);
            return state.AllowedActions();
        }

        public override IQueryable<DataBase.Proizvodi> AddFilter(IQueryable<DataBase.Proizvodi> query, ProizvodiSearchObject search = null) {
            var filterQuery = base.AddFilter(query, search);
            if (!string.IsNullOrWhiteSpace(search?.Sifra)) {
                filterQuery = filterQuery.Where(x => x.Sifra == search.Sifra);
            }
            if (!string.IsNullOrWhiteSpace(search?.Naziv)) {
                filterQuery = filterQuery.Where(x => x.Naziv.Contains(search.Naziv));
            }
            return filterQuery;
        }

        /*https://github.com/dotnet/machinelearning-samples/
         * tree/main/samples/csharp/getting-started/MatrixFactorization_ProductRecommendation
         */
        static MLContext mlContext = null;
        static ITransformer model = null;
        static object isLocked = new object();
        public List<Model.Proizvodi> Recommend(int id) {

            lock (isLocked) {

                if (mlContext == null) {

                    mlContext = new MLContext();
                    var tmpData = Context.Narudzbes.Include("NarudzbaStavkes").ToList();
                    var data = new List<ProductEntry>();

                    foreach (var x in tmpData) {
                        if (x.NarudzbaStavkes.Count > 1) {
                            var distinctItemId = x.NarudzbaStavkes.Select(y => y.ProizvodId).ToList();
                            distinctItemId.ForEach(y => {
                                var relatedItem = x.NarudzbaStavkes.Where(z => z.ProizvodId != y);
                                foreach (var z in relatedItem) {
                                    data.Add(new ProductEntry() {
                                        ProductID = (uint)y,
                                        CoPurchaseProductID = (uint)z.ProizvodId
                                    });
                                }
                            });
                        }
                    }
                    var traindata = mlContext.Data.LoadFromEnumerable(data);

                    MatrixFactorizationTrainer.Options options = new MatrixFactorizationTrainer.Options();
                    options.MatrixColumnIndexColumnName = nameof(ProductEntry.ProductID);
                    options.MatrixRowIndexColumnName = nameof(ProductEntry.CoPurchaseProductID);
                    options.LabelColumnName = "Label";
                    options.LossFunction = MatrixFactorizationTrainer.LossFunctionType.SquareLossOneClass;
                    options.Alpha = 0.01;
                    options.Lambda = 0.025;
                    options.NumberOfIterations = 100;
                    options.C = 0.00001;

                    var est = mlContext.Recommendation().Trainers.MatrixFactorization(options);
                    model = est.Fit(traindata);
                }

                var predictionResults = new List<Tuple<DataBase.Proizvodi, float>>();
                var allItems = Context.Proizvodis.Where(x => x.ProizvodId != id);
                foreach (var item in allItems) {
                    var predictionEngine = mlContext.Model.
                        CreatePredictionEngine<ProductEntry, Copurchase_prediction>(model);
                    var prediction = predictionEngine.Predict(new ProductEntry() {
                        ProductID = (uint)id,
                        CoPurchaseProductID = (uint)item.ProizvodId
                    });
                    predictionResults.Add(new Tuple<DataBase.Proizvodi, float>(item, prediction.Score));
                }
                var finalList = predictionResults.
                       OrderByDescending(x => x.Item2).
                       Select(x => x.Item1).Take(3).ToList();
                return Mapper.Map<List<Model.Proizvodi>>(finalList);
            }
        }

    }
}
    public class Copurchase_prediction { public float Score { get; set;} }
    public class ProductEntry {
        [KeyType(count: 10)]
        public uint ProductID { get; set; }

        [KeyType(count: 10)]
        public uint CoPurchaseProductID { get; set; }
        public float Label { get; set; }
}

