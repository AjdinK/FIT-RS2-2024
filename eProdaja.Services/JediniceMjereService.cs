using AutoMapper;
using eProdaja.DataBase;
using eProdaja.Model.Requests;
using eProdaja.Model.SearchObjects;

namespace eProdaja.Services {
    public class JediniceMjereService : BaseCRUDService<Model.JediniceMjere, DataBase.JediniceMjere, JediniceMjereSearchObject , JediniceMjereUpsertRequest , JediniceMjereUpsertRequest>,
        IJediniceMjereService {

        public JediniceMjereService(EProdajaContext context, IMapper mapper) : base(context, mapper) {
        }

        public override IQueryable<DataBase.JediniceMjere> AddFilter(IQueryable<DataBase.JediniceMjere> query, JediniceMjereSearchObject search = null) {
            var filterQuery =  base.AddFilter(query, search);

            if (!string.IsNullOrWhiteSpace(search?.Naziv)) {

                filterQuery = filterQuery.Where(x => x.Naziv == search.Naziv);
            }

            if (search?.JediniceMjereId.HasValue == true) {

                filterQuery = filterQuery.Where(x => x.JedinicaMjereId == search.JediniceMjereId);

            }

            return filterQuery;
        }
    }
}




