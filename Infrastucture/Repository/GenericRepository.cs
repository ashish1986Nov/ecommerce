using Core.Entity;
using Core.Interfaces;
using Infrastucture.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
    }
}
