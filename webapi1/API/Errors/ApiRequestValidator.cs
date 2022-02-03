namespace webapi1.API.Errors
{
    public class ApiRequestValidator : ApiResponse
    {
        private static int _statuscode;
        private static string? _message;

        public ApiRequestValidator() : base(400)
        {
        }

        public IEnumerable<string> Errors { get; set; }
    }
}
