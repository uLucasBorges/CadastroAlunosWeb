using Microsoft.AspNetCore.Http;
using System;

namespace Configuracao.Web
{
    public static class Util
    {
        public static string ObterUrlLogin(HttpContext httpContext, string urlLogin, string basePath)
        {
            UriBuilder uriBuilder = new UriBuilder
            {
                Scheme = httpContext.Request.Scheme,
                Host = httpContext.Request.Host.Host,
                Path = basePath
            };

            if (httpContext.Request.Host.Port.HasValue)
            {
                uriBuilder.Port = httpContext.Request.Host.Port.Value;
            }

            return $"{urlLogin}logout?r={uriBuilder.Uri}";
        }
    }
}
