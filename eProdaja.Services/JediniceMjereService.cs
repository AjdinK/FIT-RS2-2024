using AutoMapper;
using eProdaja.DataBase;
using eProdaja.Model;
using eProdaja.Model.SearchObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace eProdaja.Services {
    public class JediniceMjereService : BaseService<Model.JediniceMjere, DataBase.JediniceMjere, JediniceMjereSearchObject>,
        IService<Model.JediniceMjere, JediniceMjereSearchObject> {

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

            if (search?.Page.HasValue == true) {

                filterQuery = filterQuery.Take(search.PageSize.Value).Skip(search.Page.Value * search.PageSize.Value);

            }

            return filterQuery;
        }
    }
}




