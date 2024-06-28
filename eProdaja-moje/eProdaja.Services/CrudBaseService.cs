using eProdaja.Model.SearchObject;
using eProdaja.Services.Database;
using MapsterMapper;

namespace eProdaja.Services;

public abstract class CrudBaseService <TModel , TSearch , TEntity, TInsert , TUpdate> 
    : BaseService<TModel , TSearch , TEntity> where TModel : class where TSearch : BaseSearchObject where TEntity : class
    where TInsert : class where TUpdate : class
{
    protected CrudBaseService(EProdajaContext context, IMapper mapper) : base(context, mapper)
    {
    }
    
    public virtual TModel Insert(TInsert insert)
    {
        var entity = _mapper.Map<TEntity>(insert);
        beforeInsert (entity , insert);
        _context.Set<TEntity>().Add(entity);
        _context.SaveChanges();
        return _mapper.Map<TModel>(entity);
    }

    protected virtual void beforeInsert(TEntity entity, TInsert insert)
    {
    }

    public virtual TModel Update(int id, TUpdate update)
    {
        var entity = _context.Set<TEntity>().Find(id);
        if (entity is null) throw new Exception("Entity not found");
        
        _mapper.Map(update, entity);
        beforeUpdate(entity, update);
        _context.SaveChanges();
        return _mapper.Map<TModel>(entity);
    }

    protected virtual void beforeUpdate(TEntity entity, TUpdate update)
    {
    }

    public virtual TModel Delete(int id)
    {
        var entity = _context.Set<TEntity>().Find(id);
        if (entity is null) throw new Exception("Entity not found");
        _context.Set<TEntity>().Remove(entity);
        _context.SaveChanges();
        return _mapper.Map<TModel>(entity);
    }

}