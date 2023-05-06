using AutoMapper;
using eProdaja.DataBase;
using eProdaja.Model.Requests;
using eProdaja.Model.SearchObjects;
using eProdaja.Services.ProductStateMachine;

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
    }
}
