using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json.Linq;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Configuracao.Web.Auth
{
    public class CustomJwtDataFormat : ISecureDataFormat<AuthenticationTicket>
    {
        private readonly string _algorithm;
        private readonly TokenValidationParameters _validationParameters;
        private readonly IConfiguration _configuration;
        protected static HttpClient _client;
        private readonly IMemoryCache _memoryCache;
        public CustomJwtDataFormat(string algorithm, TokenValidationParameters validationParameters, IConfiguration configuration)
        {
            _algorithm = algorithm;
            _validationParameters = validationParameters;
            _configuration = configuration;
            _memoryCache = new MemoryCache(new MemoryCacheOptions());
            if (_client == null)
            {
                _client = GetHttpClient();
            }
        }


        public AuthenticationTicket Unprotect(string protectedText, string purpose)
        {
            var handler = new JwtSecurityTokenHandler();
            ClaimsPrincipal principal = null;
            SecurityToken validToken = null;

            try
            {
                principal = handler.ValidateToken(protectedText, this._validationParameters, out validToken);

                var validJwt = validToken as JwtSecurityToken;

                if (validJwt == null)
                {
                    throw new ArgumentException("Invalid JWT");
                }

                if (!validJwt.Header.Alg.Equals(_algorithm, StringComparison.Ordinal))
                {
                    throw new ArgumentException($"Algorithm must be '{_algorithm}'");
                }


            }
            catch (SecurityTokenValidationException)
            {
                return null;
            }
            catch (ArgumentException)
            {
                return null;
            }

            // Retorno para a pipeline que o token foi autenticado
            return new AuthenticationTicket(principal, new AuthenticationProperties(), CookieAuthenticationDefaults.AuthenticationScheme);
        }


        public string Protect(AuthenticationTicket data, string purpose)
        {
            throw new NotImplementedException();
        }

        private async Task<bool> BlacklistValidate(string token)
        {
           
                if (_memoryCache.TryGetValue(token, out bool valor))
                    return valor;

                string url = $"{_configuration["Servicos:ApiCommonUrl"]}/tokens/blacklists/validacao";
                HttpRequestMessage request = new HttpRequestMessage()
                {
                    RequestUri = new Uri(url),
                    Method = HttpMethod.Post
                };

                request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", token);

                HttpResponseMessage response = await _client.SendAsync(request);

                string result = await response.Content.ReadAsStringAsync();


               // aaaaaaaaaaaaaa
                    JObject json = JObject.Parse(result);
                    var exists = json.SelectToken("exists").Value<bool>();
                    _memoryCache.Set(token, exists, TimeSpan.FromSeconds(30));
                    return exists;
                
                
              
        }

        private static HttpClient GetHttpClient()
        {
            HttpClient client = new HttpClient();

            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            return client;
        }

        public string Protect(AuthenticationTicket data)
        {
            throw new NotImplementedException();
        }

        public AuthenticationTicket Unprotect(string protectedText)
        {
            throw new NotImplementedException();
        }
    }
}
