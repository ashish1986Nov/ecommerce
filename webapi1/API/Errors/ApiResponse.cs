namespace webapi1.API.Errors
{
    public class ApiResponse
    {
        public ApiResponse(int _statuscode, string? _message=null)
        {
            StatusCode = _statuscode;
            Message = _message ?? GetMessage(_statuscode);


        }

        public int StatusCode { get; set; }
        public string? Message { get; set; }

        private string GetMessage(int statusCode)
        {

            return StatusCode switch
            {
                400 => "A bad request , you have made",
                401 => "You are not autorized",
                404 => "Custom ERROR : Resource not found",
                500 => "internal Error,"

            };
        }
    }
}

