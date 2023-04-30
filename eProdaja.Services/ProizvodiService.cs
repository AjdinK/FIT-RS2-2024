using AutoMapper;
using eProdaja.DataBase;
using eProdaja.Model;
using eProdaja.Model.Requests;
using eProdaja.Model.SearchObjects;
using Microsoft.EntityFrameworkCore.Query.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eProdaja.Services {
    public class ProizvodiService : BaseCRUDService <Model.Proizvodi,DataBase.Proizvodi,ProizvodiSearchObject,ProizvodiInsertRequest,ProizvodiInsertRequest>, IProizvodiService {

        public ProizvodiService(EProdajaContext context, IMapper mapper): base(context,mapper) {
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
