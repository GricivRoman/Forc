using ForcWebApi.Dto;
using System.Net;
using System.Text.Json;

namespace ForcWebApi.Middlewares
{
    public class ExceptionHandlingMiddleware
    {
        private readonly RequestDelegate next;
        private readonly ILogger<ExceptionHandlingMiddleware> logger;

        public ExceptionHandlingMiddleware(RequestDelegate next,
            ILogger<ExceptionHandlingMiddleware> logger)
        {
            this.next = next;
            this.logger = logger;
        }

        public async Task InvokeAsync(HttpContext httpContext)
        {
            try
            {
                await next(httpContext);
            }
            catch (Exception ex)
            {
                await HandleExceptionAsync(httpContext, ex.Message, HttpStatusCode.NotFound,"Internal server error");
            }
        }

        private async Task HandleExceptionAsync(HttpContext context, string exMsg, HttpStatusCode httpStatusCode, string message) 
        {
            logger.LogError(exMsg);

            HttpResponse response = context.Response;
            response.ContentType = "application/json";
            response.StatusCode = (int)httpStatusCode;

            ErrorViewModel errorDto = new()
            {
                Message = message,
                StatusCode = (int)httpStatusCode,
            };
            string result = JsonSerializer.Serialize(errorDto);
            await response.WriteAsJsonAsync(result);
        }
    }
}
