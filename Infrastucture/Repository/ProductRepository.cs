using Core.Entity;
using Core.Interfaces;
using Infrastucture.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastucture.Repository
{
    public class ProductRepository : IProductRepository
    {

        private StoreContext _storeContext;

        public ProductRepository(StoreContext storecontext)
        {

            _storeContext = storecontext;


        }


        public async Task<Product?> GetProductAsync(int id)
        {
            var prod = 
            await _storeContext.Products
            .Include(p=>p.ProductType)
            .Include(p=>p.ProductBrand)
            .FirstOrDefaultAsync(p=>p.Id==id);
            return prod;       
            

        }

        public async Task<IReadOnlyList<ProductBrand>> GetProductBrandAsync()
        {
            var productBrandList = await _storeContext.ProductBrands.ToListAsync();
            return productBrandList;
        }

        public async Task<IReadOnlyList<Product>> GetProductListAsync()
        {
            var productList = await _storeContext.Products.Include(p=>p.ProductType).Include(p => p.ProductBrand)
                .ToListAsync();
            return productList;
        }

        public async Task<IReadOnlyList<ProductType>> GetProductTypeAsync()
        {
            var productList = await _storeContext.ProductTypes.ToListAsync();
            return productList;
        }
    }
}
