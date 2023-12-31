﻿using Forc.WebApi.Dto;
using Microsoft.AspNetCore.Http;
using System.Net;

namespace Forc.WebApi.Middlewares
{
    public class ExceptionHandlingMiddleware
    {
        private readonly RequestDelegate _next;

        public ExceptionHandlingMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext httpContext)
        {
            try
            {
                await _next(httpContext);
            }
            catch (InvalidOperationException ex)
            {
                await HandleExceptionAsync(httpContext, ex.Message, HttpStatusCode.BadRequest);
            }
            catch (Exception ex)
            {
                await HandleExceptionAsync(httpContext, ex.Message, HttpStatusCode.NotFound);
            }
        }

        private async Task HandleExceptionAsync(HttpContext context, string exMsg, HttpStatusCode httpStatusCode)
        {
            HttpResponse response = context.Response;
            response.ContentType = "application/json";
            response.StatusCode = (int)httpStatusCode;
            await response.WriteAsJsonAsync(new ExeptionDto
            {
                StatusCode = response.StatusCode,
                Message = exMsg,
            });
        }
    }
}
