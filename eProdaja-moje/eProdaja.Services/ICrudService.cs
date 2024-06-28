using eProdaja.Model.SearchObject;

namespace eProdaja.Services;

public interface ICrudService 
    <TModel , TSearch , TInsert , TUpdate> 
    : IService <TModel , TSearch> where TModel : class where TSearch : BaseSearchObject where TInsert : class where TUpdate : class
{
    public TModel Insert(TInsert insert);
    public TModel Update(int id, TUpdate update);
    public TModel Delete (int id);
}