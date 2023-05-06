using AutoMapper;
using eProdaja.DataBase;
using eProdaja.Model.Requests;
using eProdaja.Model.SearchObjects;

namespace eProdaja.Services {
    public class VrsteProizvodumService :
        BaseCRUDService<Model.VrsteProizvodum , DataBase.VrsteProizvodum , VrsteProizvodumSearchObject, VrsteProizvodumUpsertRequest , VrsteProizvodumUpsertRequest> , IVrsteProizvodumService {

        public VrsteProizvodumService(EProdajaContext context, IMapper mapper) : base(context, mapper) {}
        public override IQueryable<VrsteProizvodum> AddFilter(IQueryable<VrsteProizvodum> query, VrsteProizvodumSearchObject search = null) {
           var filterQuery =  base.AddFilter(query, search);

            if (!string.IsNullOrWhiteSpace(search?.NazivGT)) {
                filterQuery = filterQuery.Where(x => x.Naziv.StartsWith(search.NazivGT));
            }
            return filterQuery;
        }
    }
}
 