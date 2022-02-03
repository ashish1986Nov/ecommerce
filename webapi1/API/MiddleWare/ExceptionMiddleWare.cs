using System.Net;
using System.Text.Json;
using webapi1.API.Errors;

namespace webapi1.API.MiddleWare
{
    public class ExceptionMiddleWare
    {

        public ExceptionMiddleWare(RequestDelegate next, ILogger<ExceptionMiddleWare> ilogger,
            IHostEnvironment env)
        {
            _next = next;
            _iLogger = ilogger;
            _env = env;
        }

        private  RequestDelegate _next { get; }
        private ILogger<ExceptionMiddleWare> _iLogger { get; }
        private IHostEnvironment _env { get; }


        public async Task InvokeAsync(HttpContext context )
        {

            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {

                _iLogger.LogError(ex, ex.Message);
                context.Response.ContentType = "application/json";
                context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;

                var response = _env.IsDevelopment() ?

                    new ApiException(context.Response.StatusCode,
                    ex.Message, ex.StackTrace.ToString()) :
                     new ApiException(context.Response.StatusCode
                    );

                var jsonResponse = JsonSerializer.Serialize(response);
                await context.Response.WriteAsync(jsonResponse);

            }
        
        }
    }
}
 