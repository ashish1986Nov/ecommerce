using Core.Entity;
using Core.Specifications;

namespace Core.Interfaces
{
    public interface IGenericRepository<T1> where T1 : BaseEntity
    {

        Task<T1> GetByIdAsync(int id);
        Task<IReadOnlyList<T1>> ListAllAsync();

        Task<T1>   GetEntityWithSpec(ISpecification<T1> spec );

        Task<IReadOnlyList<T1>>   ListAsync(ISpecification<T1> spec);

        Task<int> CountAsync(ISpecification<T1> spec);

    }
}
