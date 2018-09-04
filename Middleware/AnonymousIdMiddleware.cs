using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;

namespace TextEndeavor.Middleware
{
    public class AnonymousIdMiddleware
    {
        private RequestDelegate nextDelegate;

        public AnonymousIdMiddleware(RequestDelegate nextDelegate)
        {
            this.nextDelegate = nextDelegate;
        }

        public async Task Invoke(HttpContext httpContext)
        {
            HandleRequest(httpContext);
            await nextDelegate.Invoke(httpContext);
        }

        public void HandleRequest(HttpContext httpContext)
        {
            // First, see if we have an anonymous ID set in the current session.
            var anonymousId = httpContext.Session.GetString("AnonymousId");
            if (anonymousId == null || anonymousId.Length <= 0)
            {
                // If we don't, make a new one.
                anonymousId = Guid.NewGuid().ToString();
                httpContext.Session.SetString("AnonymousId", anonymousId);
            }

            // Set up our identity with the anonymous ID
            var claims = new List<Claim> {
                new Claim(ClaimTypes.NameIdentifier, anonymousId)
            };
            var claimsIdentity = new ClaimsIdentity(claims, "AnonymousId");
            httpContext.User.AddIdentity(claimsIdentity);
        }
    }

    public static class AnonymousIdMiddlewareExtensionMethods
    {
        public static IApplicationBuilder UseAnonymousId(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<AnonymousIdMiddleware>();
        }
    }
}