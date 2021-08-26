using System;
using System.Net;
using System.Text.Json;
using System.Threading.Tasks;
using MicroShoppy.Identity.Application.Extensions;
using Microsoft.AspNetCore.Http;

namespace MicroShoppy.Identity.Api.Middleware
{
    public class ExceptionHandlerMiddleware
    {
        private readonly RequestDelegate _next;

        public ExceptionHandlerMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                var response = context.Response;
                response.ContentType = "application/json";

                response.StatusCode = (int)HttpStatusCode.InternalServerError;

                if (ex.IsDomainException())
                {
                    response.StatusCode = (int)HttpStatusCode.BadRequest;
                }

                if (ex.IsNotFoundDomainException())
                {
                    response.StatusCode = (int)HttpStatusCode.NotFound;
                }

                var result = JsonSerializer.Serialize(new { errors = new { Errors = new[] { ex?.Message } } });
                await response.WriteAsync(result);
            }
        }
    }
}