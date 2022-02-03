namespace webapi1.API.Extensions
{
    public static class SwaggerServiceExtensions
    {

        public static IServiceCollection AddSwaggerServiceExtensions
            (this IServiceCollection servicecollection)
        {


            servicecollection.AddSwaggerGen();

            return servicecollection;


        }

        public static IApplicationBuilder UseSwaggerDocumenationExt(this IApplicationBuilder app)
        {

            app.UseSwagger();
            app.UseSwaggerUI();
            return app;

        }
    }





}

