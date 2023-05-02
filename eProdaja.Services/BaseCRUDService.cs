using AutoMapper;
using eProdaja.DataBase;
using eProdaja.Model.SearchObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eProdaja.Services {
    public class BaseCRUDService<T , TDb , TSearch , TInsert , TUpdate> :
        BaseService <T , TDb , TSearch> , ICRUDService <T, TSearch, TInsert, TUpdate>
        where T : class where TDb : class where TSearch : BaseSearchObject where TInsert : class where TUpdate : class {

        public BaseCRUDService(EProdajaContext context, IMapper mapper) : base(context, mapper) { 
        }
        public virtual T Insert(TInsert insert) {
            //طريقة الاولى 
            //var set = Context.Set<TDb>();
            //TDb entity = Mapper.Map<TDb>(insert);
            //set.Add(entity);
            //Context.SaveChanges();
            //return Mapper.Map<T>(entity);

            //طريقة المتخصرة 
            var entity = Context.Set<TDb>().Add(Mapper.Map<TDb>(insert)).Entity;

            BeforeInsert(insert, entity);

            Context.SaveChanges();
            return Mapper.Map<T>(entity);
        }

        public virtual void BeforeInsert(TInsert insert, TDb entity) { }

        public virtual T Update(int id, TUpdate update) {
            //var set = Context.Set<TDb>();
            //var entity = set.Find(id);

            //if (entity != null)
            //    Mapper.Map(update, entity);
            //else
            //    return null;

            //Context.SaveChanges();
            //return Mapper.Map<T>(entity);

            var entity = Context.Set<TDb>().Find(id);
            if (entity == null) return null;
            Mapper.Map(update, entity);
            Context.SaveChanges();
            return Mapper.Map<T>(entity);
        }

    }
}
