using Core.Entity;

namespace Core.Specifications
{
    public  class ProductWithTypesAndBrandSpecefications : BaseSpecefication<Product>
    {

        
        public ProductWithTypesAndBrandSpecefications(ProductSpecsParams _productSpecsParams)
            :base ( x=>
                (  String.IsNullOrEmpty(_productSpecsParams.Search) || 
                    x.Name.ToLower().Contains (_productSpecsParams.Search)  ) && 
                    (!_productSpecsParams.BrandId.HasValue || x.ProductBrandId== _productSpecsParams.BrandId) &&
                     (!_productSpecsParams.TypeId.HasValue || x.ProductTypeId == _productSpecsParams.TypeId)
            )



       
        {

            AddIncludes(x => x.ProductBrand);
            AddIncludes(x => x.ProductType);
            AddOrderBy(x => x.Name);

            ApplyPaging((_productSpecsParams.PageSize * (_productSpecsParams.PageIndex - 1)),
                _productSpecsParams.PageSize);


            if (!string.IsNullOrEmpty(_productSpecsParams.Sort))
            {


                switch (_productSpecsParams.Sort)
                {

                    case "priceAsc":
                        AddOrderBy(p => p.Price);
                        break;
                    case "priceDesc":
                        AddOrderByDesceding(p => p.Price);
                        break;
                    default:
                                    AddOrderBy(x => x.Name);

                        break;



                }


            }

        }

        public ProductWithTypesAndBrandSpecefications(int id ) : base(x=>x.Id==id)
        {

            AddIncludes(x => x.ProductBrand);
            AddIncludes(x => x.ProductType);

        }


    }
}
