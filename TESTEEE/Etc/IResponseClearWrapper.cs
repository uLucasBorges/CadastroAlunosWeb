using Microsoft.AspNetCore.Http;

namespace Configuracao.Web.Etc
{
    //para conseguir escrever teste unitario
    public interface IResponseClearWrapper
    {
        void Clear(HttpResponse response);
    }

    public class DefaultResponseClearer : IResponseClearWrapper
    {
        public void Clear(HttpResponse response)
        {
            response.Clear();
        }
    }
}