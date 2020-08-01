using System.Net;

namespace TodoApp.Domain.Exceptions
{
    public class ErrorCode
    {
        public string Message { get; protected set; }
        public HttpStatusCode HttpStatusCode { get; }
        public ErrorCode(string message, HttpStatusCode httpStatusCode = HttpStatusCode.BadRequest)
        {
            Message = message;
            HttpStatusCode = httpStatusCode;
        }

        public static ErrorCode TestError => new ErrorCode(nameof(TestError), HttpStatusCode.InternalServerError);
    }
}
