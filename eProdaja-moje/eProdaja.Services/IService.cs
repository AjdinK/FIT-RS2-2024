using eProdaja.Model;
using eProdaja.Model.SearchObject;

namespace eProdaja.Services;

public interface IService <TModel , TSearch> where TModel : class where TSearch : BaseSearchObject
{
    public PagedList<TModel> GetAll(TSearch search);
    public TModel GetById(int id);
}