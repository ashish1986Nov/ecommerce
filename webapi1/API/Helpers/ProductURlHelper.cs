using AutoMapper;
using Core.Entity;
using webapi1.API.DTO;

namespace webapi1.API.Helpers
{
    public class ProductURlHelper : IValueResolver<Product, ProductDto, string>
    {

        public IConfiguration Config { get; }


        public ProductURlHelper(IConfiguration config)
        {
            Config = config;
        }


        public string Resolve(Product source, ProductDto destination, string destMember, ResolutionContext context)
        {

            if (!String.IsNullOrEmpty(source.PictureUrl))
            {

                return Config["ApiURL"] + source.PictureUrl;



            }
            return "NO IMAGE";
        }
    }
}
