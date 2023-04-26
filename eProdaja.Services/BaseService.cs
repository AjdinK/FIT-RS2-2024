using AutoMapper;
using eProdaja.DataBase;
using System;
using System.Collections.Generic;
using System.Text;

namespace eProdaja.Services {
    public class BaseService<T, TDb,TSearch> : IService<T , TSearch> where T : class where TDb : class where TSearch : class {

        public EProdajaContext Context {get;set;}
        public IMapper Mapper { get; set; }

        public BaseService(EProdajaContext context, IMapper mapper) {
            Context = context;
            Mapper = mapper;
        }

        public IEnumerable<T> Get(TSearch search = null) {

            var entity = Context.Set<TDb>();
            var list = entity.ToList();
            return Mapper.Map<IList<T>>(list);
            
        }

        public T GetByID(int id) {
            var set = Context.Set<TDb>();   
            var entity = set.Find(id); 
            return Mapper.Map<T>(entity);
        }
    }
}
