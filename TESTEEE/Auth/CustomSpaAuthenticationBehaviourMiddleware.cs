using Configuracao.Web.Etc;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using System.IO;
using System.Threading.Tasks;

namespace Configuracao.Web.Auth
{
    public class CustomSpaAuthenticationBehaviourMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly IResponseClearWrapper _responseClearWrapper = new DefaultResponseClearer();

        public CustomSpaAuthenticationBehaviourMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public CustomSpaAuthenticationBehaviourMiddleware(RequestDelegate next, IResponseClearWrapper responseClearWrapper) :this(next)
        {
            _responseClearWrapper = responseClearWrapper;
        }


        public async Task InvokeAsync(HttpContext context, IConfiguration configuration)
        {
            if (context.User.Identity.IsAuthenticated)
            {
                await _next(context);
                return;
            }

            _responseClearWrapper.Clear(context.Response);

            if (context.Request.Path.StartsWithSegments("/api") || Path.HasExtension(context.Request.Path.Value))
                context.Response.StatusCode = 401;
            else
                context.Response.Redirect(Util.ObterUrlLogin(context, configuration["Services:Login"], "/"));

            await context.Response.CompleteAsync();
        }



    }
}
