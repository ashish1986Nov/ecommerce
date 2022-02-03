using Core.Entity;

namespace Core.Interfaces
{
    public interface IGenericRepository<T1> where T1 : BaseEntity
    {

        Task<T1> GetByIdAsync(int id);
        Task<IReadOnlyList<T1>> ListAllAsync();

    }
}
