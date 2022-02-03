using Core.Interfaces;
using Infrastucture.Repository;
using Microsoft.AspNetCore.Mvc;
using webapi1.API.Errors;

namespace webapi1.API.Extensions
{
    public static class AddApplicationServiceExtensions
    {

        public static IServiceCollection AddApplicationServices
            (this IServiceCollection serviceCollection)
        {
            serviceCollection.AddScoped<IProductRepository, ProductRepository>();

            serviceCollection.AddScoped(typeof(IGenericRepository<>), (typeof(GenericRepository<>)));

            serviceCollection.Configure<ApiBehaviorOptions>(options =>
            {
                options.InvalidModelStateResponseFactory = actioncontext =>
                {

                    var errors = actioncontext.ModelState.
                    Where(e => e.Value.Errors.Count > 0)
                    .SelectMany(x => x.Value.Errors)
                    .Select(x => x.ErrorMessage).ToArray();

                    var apivalidation = new ApiRequestValidator
                    {
                        Errors = errors

                    };
                    return new BadRequestObjectResult(apivalidation);


                };

            });
            return serviceCollection;

        }

    }
}
