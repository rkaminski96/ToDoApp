using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System;
using System.Net;
using System.Threading.Tasks;
using TodoApp.Domain.Exceptions;

namespace TodoApp.Api.Middleware
{
    public class ExceptionHandlerMiddleware
    {
        private readonly RequestDelegate request;

        public ExceptionHandlerMiddleware(RequestDelegate request)
        {
            this.request = request;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await request(context);
            }
            catch (Exception ex)
            {
                await HandleExceptionAsync(context, ex);
            }
        }

        private Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            var errorCode = nameof(HttpStatusCode.InternalServerError);
            var statusCode = HttpStatusCode.InternalServerError;
            var message = exception.Message;

            if (exception is TodoException todoException)
            {
                statusCode = todoException.ErrorCode.HttpStatusCode;
                errorCode = todoException.ErrorCode.Message;
                message = string.IsNullOrEmpty(todoException.Message) ? errorCode : todoException.Message;
            }

            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)statusCode;
            var responseBody = JsonConvert.SerializeObject(new { errorCode, message });

            return context.Response.WriteAsync(responseBody);
        }
    }
}
