using Core.Entity;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Infrastucture.Data
{
    public class StoreContextSeed
    {

        public static async Task SeedAsync(StoreContext context)
        {
            try
            {


                Console.WriteLine("check1");

                if (!context.ProductBrands.Any())
                {


                    var brandsData = File.ReadAllText("../Infrastucture/SeedData/brands.json");
                    var brandJson = JsonSerializer.Deserialize<List<ProductBrand>>(brandsData);

                    foreach (var item in brandJson)
                    {
                        context.ProductBrands.Add(item);

                    }



                }

                if (!context.ProductTypes.Any())
                {


                    var brandsTypeData = File.ReadAllText("../Infrastucture/SeedData/types.json");
                    var BrandTypeJson = JsonSerializer.Deserialize<List<ProductType>>(brandsTypeData);


                    foreach (var item in BrandTypeJson)
                    {
                        context.ProductTypes.Add(item);

                    }


                }

                if (!context.Products.Any())
                {


                    var productData = File.ReadAllText("../Infrastucture/SeedData/products.json");
                    var productDataJson = JsonSerializer.Deserialize<List<Product>>(productData);


                    foreach (var item in productDataJson)
                    {
                        context.Products.Add(item);

                    }


                }


                await context.SaveChangesAsync();

            }
            catch (Exception ex)
            {

               //  var logger = LoggerFactory.<StoreContextSeed>();
            }


        }


    }
}

