using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;

namespace Lab_ASP
{
    // You may need to install the Microsoft.AspNetCore.Http.Abstractions package into your project
    public class TestMiddleware
    {
        private readonly RequestDelegate _next;

        public TestMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext httpContext)
        {
            switch (httpContext.Request.Path.Value)
            {
                case "/hello_world":
                    await httpContext.Response.WriteAsync("Hello, World!");
                    break;

                case "/goodbye_world":
                    await httpContext.Response.WriteAsync("Goodbye, World!");
                    break;

                default:
                    await httpContext.Response.WriteAsync("This is the default middleware case.");
                    break;
            }
        }
    }

    // Extension method used to add the middleware to the HTTP request pipeline.
    public static class TestMiddlewareExtensions
    {
        public static IApplicationBuilder UseTestMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<TestMiddleware>();
        }
    }
}
