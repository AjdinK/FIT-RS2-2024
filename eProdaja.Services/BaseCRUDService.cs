using AutoMapper;
using eProdaja.DataBase;
using eProdaja.Model.SearchObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eProdaja.Services {
    public class BaseCRUDService<T , TDb , TSearch , TInsert , TUpdate> : BaseService <T , TDb , TSearch> , ICRUDService <T, TSearch, TInsert, TUpdate> where T : class where TDb : class where TSearch : BaseSearchObject where TInsert : class where TUpdate : class {

        public BaseCRUDService(EProdajaContext context, IMapper mapper) : base(context, mapper) { 
        }

        public T Insert(TInsert insert) {
            var set = Context.Set<TDb>();
            TDb entity = Mapper.Map<TDb>(insert);
            set.Add(entity);
            return Mapper.Map<T>(entity);
        }

        public T Update(int id, TUpdate update) {
            throw new NotImplementedException();
        }
    }
}
