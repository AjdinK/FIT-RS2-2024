using AutoMapper;
using eProdaja.DataBase;
using eProdaja.Model.SearchObjects;

namespace eProdaja.Services {
    public class BaseService<T, TDb,TSearch> : IService<T , TSearch> where T : class where TDb : class where TSearch : BaseSearchObject {

        public EProdajaContext Context {get;set;}
        public IMapper Mapper { get; set; }

        public BaseService(EProdajaContext context, IMapper mapper) {
            Context = context;
            Mapper = mapper;
        }

        public virtual IEnumerable<T> Get(TSearch search = null) {

            var entity = Context.Set<TDb>().AsQueryable();
            entity = AddFilter(entity, search);

            if (search?.Page.HasValue == true && search?.PageSize.HasValue == true) {
                entity = entity.Take(search.PageSize.Value).Skip(search.Page.Value * search.PageSize.Value);
}

            var list = entity.ToList();
            return Mapper.Map<IList<T>>(list);
        }

        public virtual IQueryable<TDb> AddFilter(IQueryable<TDb> query, TSearch search = null) { return query; }

        public T GetByID(int id) {
            var set = Context.Set<TDb>();   
            var entity = set.Find(id); 
            return Mapper.Map<T>(entity);
        }
    }
}
