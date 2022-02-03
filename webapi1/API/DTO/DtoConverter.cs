using Core.Entity;

namespace webapi1.API.DTO
{
    public class DtoConverter
    {


        public static ProductDto DtoCoverterUtilProduct(Product prod)
        {


            var prodDto = new ProductDto();
            prodDto.Name = prod.Name;
            prodDto.Description = prod.Description;
            prodDto.Price = prod.Price;
            prodDto.PictureUrl = prod.PictureUrl;
            prodDto.ProductType = prod.ProductType == null ? null : prod.ProductType.Name;
            prodDto.ProductBrand = prod.ProductBrand == null ? null : prod.ProductBrand.Name;
            return prodDto;

        }


        public static List<ProductDto> DobConvertedProdList(IReadOnlyList<Product> prodList)
        {

            var prodDtoList = prodList.Select(prod => new ProductDto
            {
                Id = prod.Id,
                Name = prod.Name,
                Description = prod.Description,
                Price = prod.Price,
                PictureUrl = prod.PictureUrl,
                ProductType = prod.ProductType == null ? null : prod.ProductType.Name,
                ProductBrand = prod.ProductBrand == null ? null : prod.ProductBrand.Name

            }).ToList();

            return prodDtoList;

        }







    }

}

