using Azure.Core;
using eProdaja.Model;
using eProdaja.Model.Requests;
using eProdaja.Model.SearchObjects;
using eProdaja.Services.Database;
using eProdaja.Services.ProizvodiStateMachine;
using MapsterMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Microsoft.ML;
using Microsoft.ML.Data;
using Microsoft.ML.Trainers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eProdaja.Services
{
    public class ProizvodiService : BaseCRUDService<Model.Proizvodi, ProizvodiSearchObject, Database.Proizvodi, ProizvodiInsertRequest, ProizvodiUpdateRequest>, IProizvodiService
    {
        ILogger<ProizvodiService> _logger;
        public BaseProizvodiState BaseProizvodiState { get; set; }
        public ProizvodiService(EProdajaContext context, IMapper mapper, BaseProizvodiState baseProizvodiState, ILogger<ProizvodiService> logger) 
        : base(context, mapper) { 
            BaseProizvodiState = baseProizvodiState;
            _logger = logger;
        }

        public override IQueryable<Database.Proizvodi> AddFilter(ProizvodiSearchObject search, IQueryable<Database.Proizvodi> query)
        {
            var filteredQuery = base.AddFilter(search, query);

            if(!string.IsNullOrWhiteSpace(search?.FTS))
            {
                filteredQuery = filteredQuery.Where(x => x.Naziv.Contains(search.FTS));
            }

            if (!string.IsNullOrWhiteSpace(search?.Sifra))
            {
                filteredQuery = filteredQuery.Where(x => x.Sifra == search.Sifra);
            }

            return filteredQuery;
        }

        public override Model.Proizvodi Insert(ProizvodiInsertRequest request)
        {
            var state = BaseProizvodiState.CreateState("initial");
            return state.Insert(request);
        }

        public override Model.Proizvodi Update(int id, ProizvodiUpdateRequest request)
        {
            var entity = GetById(id);
            var state = BaseProizvodiState.CreateState(entity.StateMachine);
            return state.Update(id, request);

        }

        public Model.Proizvodi Activate(int id)
        {
            var entity = GetById(id);
            var state = BaseProizvodiState.CreateState(entity.StateMachine);
            return state.Activate(id);
        }

        public Model.Proizvodi Edit(int id)
        {
            var entity = GetById(id);
            var state = BaseProizvodiState.CreateState(entity.StateMachine);
            return state.Edit(id);
        }

        public Model.Proizvodi Hide(int id)
        {
            var entity = GetById(id);
            var state = BaseProizvodiState.CreateState(entity.StateMachine);
            return state.Hide(id);
        }

        public List<string> AllowedActions(int id)
        {
            _logger.LogInformation($"Allowed actions called for: {id}");

            if (id <= 0)
            {
                var state = BaseProizvodiState.CreateState("initial");
                return state.AllowedActions(null);
            }
            else
            {
                var entity = Context.Proizvodis.Find(id);
                var state = BaseProizvodiState.CreateState(entity.StateMachine);
                return state.AllowedActions(entity);
            }
        }

        static MLContext mlContext = null;
        static object isLocked = new object();
        static ITransformer model = null;
        public List<Model.Proizvodi> Recommend(int id)
        {
            if (mlContext == null)
            {

                //train
                lock (isLocked)
                {
                    mlContext = new MLContext();

                    var tmpData = Context.Narudzbes.Include("NarudzbaStavkes").ToList();

                    var data = new List<ProductEntry>();

                    foreach (var item in tmpData)
                    {
                        if (item.NarudzbaStavkes.Count > 1)
                        {
                            var distinctItemId = item.NarudzbaStavkes.Select( y=> y.ProizvodId).Distinct().ToList();

                            distinctItemId.ForEach(y =>
                            {
                                var relatedItems = item.NarudzbaStavkes.Where(z => z.ProizvodId != y);

                                foreach(var z in relatedItems)
                                {
                                    data.Add(new ProductEntry()
                                    {
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
                    // For better results use the following parameters
                    options.NumberOfIterations = 100;
                    options.C = 0.00001;

                    var est = mlContext.Recommendation().Trainers.MatrixFactorization(options);

                    model = est.Fit(traindata);
                }
            }

            var products = Context.Proizvodis.Where(x => x.ProizvodId != id);

            var predictionResult = new List<(Database.Proizvodi, float)>();

            foreach (var product in products)
            {
                var predictionengine = mlContext.Model.CreatePredictionEngine<ProductEntry, Copurchase_prediction>(model);
                var prediction = predictionengine.Predict(
                                         new ProductEntry()
                                         {
                                             ProductID = (uint)id,
                                             CoPurchaseProductID = (uint)product.ProizvodId
                                         });

                predictionResult.Add(new(product, prediction.Score));
            }

            var finalResult = predictionResult.OrderByDescending(x => x.Item2).Select(x => x.Item1).Take(4).ToList();

            return Mapper.Map<List<Model.Proizvodi>>(finalResult);
        }
    }

    public class Copurchase_prediction
    {
        public float Score { get; set; }
    }

    public class ProductEntry
    {
        [KeyType(count: 262111)]
        public uint ProductID { get; set; }

        [KeyType(count: 262111)]
        public uint CoPurchaseProductID { get; set; }

        public float Label { get; set; }
    }
}
