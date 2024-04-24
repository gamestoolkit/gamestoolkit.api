using System.Net;

namespace gamestoolkit.api.ViewModels
{
    public class BaseResponse
    {
        public HttpStatusCode StatusCode { get; set; }

        virtual public object? GetContents() 
        {
            return null;
        }
    }

    public class Response<T> : BaseResponse where T : class
    {
        public T? Content { get; set; }

        public override object? GetContents() => Content;
    }

    public class NoContentResponse : BaseResponse
    {
    }

    #region Contents

    public class CreateResponseContents
    {
        public int Id { get; set; } = 0;
        public string Message { get; set; } = string.Empty;
    }
    #endregion
}
