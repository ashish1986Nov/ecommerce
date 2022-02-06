using Core.Entity;
using Core.Interfaces;
using Core.Specifications;
using Infrastucture.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastucture.Repository
{
    public class GenericRepository<T1> : IGenericRepository<T1> where T1 : BaseEntity
    {

        private StoreContext _storeContext;

        public GenericRepository(StoreContext storecontext)
        {

            _storeContext = storecontext;


        }


        public async Task<T1> GetByIdAsync(int id)
        {
            var item = await _storeContext.Set<T1>().FindAsync(id);

            return item;

        }


        public async Task<IReadOnlyList<T1>> ListAllAsync()
        {
            var itemList = await _storeContext.Set<T1>().ToListAsync();

            return itemList;
        }



        public async Task<T1> GetEntityWithSpec(ISpecification<T1> spec)
        {
            return await ApplySpecefication(spec).FirstOrDefaultAsync();
        }

        public async Task<IReadOnlyList<T1>> ListAsync(ISpecification<T1> spec)
        {
            return await ApplySpecefication(spec).ToListAsync();


        }


        private IQueryable<T1> ApplySpecefication(ISpecification<T1> spec)
        {

            return SpeceficationEvaluator<T1>.GetQuery
                    (_storeContext.Set<T1>().AsQueryable(), spec);
        
        }

        public async Task<int> CountAsync(ISpecification<T1> spec)
        {
            return await ApplySpecefication(spec).CountAsync();
        }
    }
}
