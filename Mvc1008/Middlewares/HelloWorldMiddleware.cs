using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;

namespace Mvc1008.Middlewares
{
    public static class HelloWorldMiddlewareExt
    {
        public static void UseHelloWorld(this IApplicationBuilder app)
        {
            _ = app.UseMiddleware<HelloWorldMiddleware>();
        }
    }

    public class HelloWorldMiddleware
    {
        private readonly RequestDelegate _next;

        // "Scoped" SERVICE SHOULDN'T DO CONSTRUCTOR DI!!
        public HelloWorldMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            await context.Response.WriteAsync("Hello");
            await _next(context);
            await context.Response.WriteAsync("World");
        }
    }
}
