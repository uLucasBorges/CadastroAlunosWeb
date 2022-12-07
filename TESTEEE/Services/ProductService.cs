using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using ApiCadastroAlunos.Core.Models;
using GeekShopping.Web.Services.Interfaces;
using GeekShopping.Web.Utils;

namespace GeekShopping.Web.Services
{
    public class ProductService : IProductService
    {
        private readonly HttpClient _client;
        public const string path = "api/alunos"; //onde vai ser feita a requisição

        public ProductService(HttpClient client)
        {
            _client = client;
        }

        public async Task<IEnumerable<Aluno>> FindAllProducts()
        {
            var response = await _client.GetAsync($"{path}/list");
            return await response.ReadContentAs<List<Aluno>>();
        }

        public async Task<Aluno> FindProductById(long Id)
        {
            var response = await _client.GetAsync($"{path}/find/{Id}");
            return await response.ReadContentAs<Aluno>();
        }

        public async Task<Aluno> CreateProduct(Aluno product)
        {
            var response = await _client.PostAsJson(path, product);

            if (response.IsSuccessStatusCode)
                return await response.ReadContentAs<Aluno>();


            throw new Exception("houve algum problema..");
        }

        public async Task<Aluno> UpdateProduct(Aluno product)
        {
            var response = await _client.PutAsJson(path, product);

            if (response.IsSuccessStatusCode)
                return await response.ReadContentAs<Aluno>();


            throw new Exception("houve algum problema..");
        }

        public async Task<bool> DeleteProductById(long id)
        {
            var response = await _client.DeleteAsync($"{path}/delete/{id}");

            if (response.IsSuccessStatusCode)
                return await response.ReadContentAs<bool>();

            throw new Exception("houve algum problema..");
        }
    }
}
