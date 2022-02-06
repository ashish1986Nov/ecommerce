using Core.Entity;

namespace Core.Specifications
{
    public  class ProductWithCountSpecefication : BaseSpecefication<Product>
    {

        public ProductWithCountSpecefication(ProductSpecsParams _productSpecsParams) : base(x =>

          (String.IsNullOrEmpty(_productSpecsParams.Search) ||
                    x.Name.ToLower().Contains(_productSpecsParams.Search)) &&
        (!_productSpecsParams.BrandId.HasValue || x.ProductBrandId == _productSpecsParams.BrandId) &&
                 (!_productSpecsParams.TypeId.HasValue || x.ProductTypeId == _productSpecsParams.TypeId)
            )
        { 
        
        
        
        }
    }
}
