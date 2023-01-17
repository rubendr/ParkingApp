//using Microsoft.AspNetCore.Builder;
//using Microsoft.AspNetCore.Http;
//using System.Threading.Tasks;

namespace ParkingApp
{
    // You may need to install the Microsoft.AspNetCore.Http.Abstractions package into your project
    public class ParkingMiddleware
    {
        private readonly RequestDelegate _next;

        public ParkingMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public Task Invoke(HttpContext httpContext)
        {
            Console.WriteLine(DateTime.Now + ": " + httpContext.Request.Path + " " + httpContext.Request.Method);
            return _next(httpContext);
        }
    }

    // Extension method used to add the middleware to the HTTP request pipeline.
    public static class ParkingMiddlewareExtensions
    {
        public static IApplicationBuilder UseParkingMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<ParkingMiddleware>();
        }
    }
}
