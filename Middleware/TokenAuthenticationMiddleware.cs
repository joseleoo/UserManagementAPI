using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

namespace UserManagementAPI.Middleware
{
    public class TokenAuthenticationMiddleware
    {
        private readonly RequestDelegate _next;
        private const string AUTH_HEADER = "Authorization";
        private const string VALID_TOKEN = "Bearer mysecrettoken"; // Replace with your real token logic

        public TokenAuthenticationMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            if (!context.Request.Headers.ContainsKey(AUTH_HEADER) ||
                context.Request.Headers[AUTH_HEADER] != VALID_TOKEN)
            {
                context.Response.StatusCode = 401;
                context.Response.ContentType = "application/json";
                await context.Response.WriteAsync("{\"error\": \"Unauthorized\"}");
                return;
            }

            await _next(context);
        }
    }
}