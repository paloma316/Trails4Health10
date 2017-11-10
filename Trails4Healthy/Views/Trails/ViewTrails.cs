using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;

namespace Trails4Healthy.Views.Trails
{
    // You may need to install the Microsoft.AspNetCore.Http.Abstractions package into your project
    public class ViewTrails
    {
        private readonly RequestDelegate _next;

        public ViewTrails(RequestDelegate next)
        {
            _next = next;
        }

        public Task Invoke(HttpContext httpContext)
        {

            return _next(httpContext);
        }
    }

    // Extension method used to add the middleware to the HTTP request pipeline.
    public static class ViewTrailsExtensions
    {
        public static IApplicationBuilder UseMiddlewareClassTemplate(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<ViewTrails>();
        }
    }
}
