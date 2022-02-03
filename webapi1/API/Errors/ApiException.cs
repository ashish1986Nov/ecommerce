namespace webapi1.API.Errors
{
    public class ApiException : ApiResponse
    {
        public ApiException(int _statuscode, string? _message = null, string? details = null
            ) : base(_statuscode, _message)
        {
            Details = details;
        }

        public string? Details { get; }
    }
}
