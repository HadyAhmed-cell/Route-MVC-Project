namespace Route.NetBLL.Interfaces
{
    public interface IGenericRepository<T>
    {
        Task<T> Get(int? id);
        Task<IEnumerable<T>> GetAll();

        Task<int> Create(T obj);

        Task<int> Update(T obj);

        Task<int> Delete(T obj);
    }
}

