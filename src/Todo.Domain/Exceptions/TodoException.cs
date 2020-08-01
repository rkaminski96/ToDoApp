using System;

namespace TodoApp.Domain.Exceptions
{
    public class TodoException : Exception
    {
        public ErrorCode ErrorCode { get; }

        public TodoException(ErrorCode errorCode)
            : this(errorCode, string.Empty) { }

        public TodoException(ErrorCode errorCode, string message)
            : this(errorCode, message, null) { }

        public TodoException(ErrorCode errorCode, string message, Exception innerException)
            : base(message, innerException)
        {
            ErrorCode = errorCode;
        }
    }
}
