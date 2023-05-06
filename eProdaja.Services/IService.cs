namespace eProdaja.Services {
    public interface IService <T,TSearch> where T : class where TSearch : class {
        IEnumerable<T> Get(TSearch search = null);
        T GetByID(int id);
    }
}
