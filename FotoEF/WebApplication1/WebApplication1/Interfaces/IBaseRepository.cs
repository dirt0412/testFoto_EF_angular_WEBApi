using System.Collections.Generic;
using System.Threading.Tasks;

namespace WebApplication1.Interfaces
{
    public interface IRepository<T, TEntityId>
       where T : class
    {
        Task<T> GetAsync(TEntityId id);

        Task<IList<T>> GetAsync();

        Task<T> PostAsync(T obj);

        Task<T> PutAsync(T obj);

        Task DeleteAsync(TEntityId id);

        T FindById(TEntityId id);
        Task<T> FindByIdAsync(TEntityId id);
    }
}