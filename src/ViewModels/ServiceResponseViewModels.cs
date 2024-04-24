using System.Net;

namespace gamestoolkit.api.ViewModels
{
    public class BaseResponse
    {
        public HttpStatusCode StatusCode { get; set; } = HttpStatusCode.OK;
    }

    public class CreateResponse : BaseResponse
    {
        public int Id { get; set; } = 0;
        public string Message { get; set; } = string.Empty;
    }
    public class NoContentResponse : BaseResponse
    {
    }
}
