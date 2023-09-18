

using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;

namespace suivi_des_drones.Core.Infrastructure.Web.MiddleWare
{
    public class RedirectIsnotConnectedMiddleWare
    {
        private readonly RequestDelegate _next;

        public RedirectIsnotConnectedMiddleWare(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            var id = context.Session.GetInt32("UserId");
            var IsLoginPage = context.Request.Path.Value?.ToLower().Contains("login");
            if (!id.HasValue && (!IsLoginPage.HasValue || !IsLoginPage.Value))
            {
                context.Response.Redirect("login");
                return;
            }
            await _next.Invoke(context);
        } 
    }

    public static class AuthenticationMiddleWares
    {
        public static IApplicationBuilder UseRedirectIfNotConnected(this IApplicationBuilder app)
        {
            return app.UseMiddleware<RedirectIsnotConnectedMiddleWare>();
        }
    }
}
