using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace POCMultiTenantMVC.Middlewares
{
    public class MissingTenantHandler
    {
        private readonly RequestDelegate _next;
        private readonly string _defaultTenantUrl;

        public MissingTenantHandler(RequestDelegate next, string defaultTenantUrl)
        {
            _next = next;
            _defaultTenantUrl = defaultTenantUrl;
        }

        public async Task Invoke(HttpContext httpContext, ITenantProvider provider)
        {
            if (provider.GetTenant() == null)
            {
                httpContext.Response.Redirect(_defaultTenantUrl);
                return;
            }

            await _next.Invoke(httpContext);
        }
    }
}
