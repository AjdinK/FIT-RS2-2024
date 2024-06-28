using eProdaja.Model;
using eProdaja.Model.SearchObject;
using eProdaja.Services.Database;
using MapsterMapper;

namespace eProdaja.Services;

public abstract class BaseService <TModel , TSearch, TEntity> : IService<TModel, TSearch> where TModel : class where TSearch : BaseSearchObject where TEntity : class
{
    protected EProdajaContext _context { get; set; }
    protected IMapper _mapper { get; set; }

    public BaseService(EProdajaContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public PagedList<TModel> GetAll(TSearch search)
    {
        var query = _context.Set<TEntity>().AsQueryable();
        query = AddFilter(query, search);
        var rez = new List<TModel>();
        
        //todo: add the page size and number
        
        rez = _mapper.Map<List<TModel>>(query.ToList());
        var response = new PagedList<TModel>();
        response.Count = query.Count();
        response.Lista = rez;

        return response;
    }

    protected virtual IQueryable<TEntity> AddFilter(IQueryable<TEntity> query, TSearch search)
    {
        return query;
    }

    public TModel GetById(int id)
    {
        var entity = _context.Set<TEntity>().Find(id);
        if (entity is null) throw new Exception("Entity not found");
        
        return _mapper.Map<TModel>(entity);
    }
}