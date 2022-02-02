using Core.Entity;
using System.Collections.Generic;

namespace Core.Interfaces
{
    public interface   IProductRepository
    {
        Task<Product ? > GetProductAsync(int id);
        Task<IReadOnlyList<Product>> GetProductListAsync();

        Task<IReadOnlyList<ProductType>> GetProductTypeAsync();

        Task<IReadOnlyList<ProductBrand>> GetProductBrandAsync();

    }
}
