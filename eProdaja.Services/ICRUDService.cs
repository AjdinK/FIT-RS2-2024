namespace eProdaja.Services {
    public interface ICRUDService<T,TSearch,TInsert , TUpdate> : IService<T , TSearch> where T : class where TSearch : class {
        T Insert(TInsert insert);
        T Update(int id, TUpdate update);
    }
}
