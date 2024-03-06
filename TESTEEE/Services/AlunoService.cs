using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using ApiCadastroAlunos.Core.Interfaces;
using ApiCadastroAlunos.Core.Models;
using CadastroAlunos.Core.DTOs;
using GeekShopping.Web.Utils;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace TESTEEE.Services
{
    public class AlunoService : IAlunoService
    {
        private readonly HttpClient _client;
        public const string path = "api"; //onde vai ser feita a requisição

        public AlunoService(HttpClient client)
        {
            _client = client;
        }

        public async Task<Aluno> Create([FromBody]Aluno aluno , string token)
        {

            _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

            var response = await _client.PostAsJson($"{path}/alunos/create", aluno);

            if (response.IsSuccessStatusCode)
                return await response.ReadContentAs<Aluno>();


            throw new Exception("houve algum problema..");
        }

        public async Task<IEnumerable<Aluno>> Get(string token)
        {
            _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
;            var response = await _client.GetAsync($"{path}/alunos/list");
            return await response.ReadContentAs<IEnumerable<Aluno>>();
        }

        public async Task<Aluno> GetById(int Id , string token)
        {
            _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

            var response = await _client.GetAsync($"{path}/alunos/search/{Id}");
            return await response.ReadContentAs<Aluno>();
        } 
        

        public async Task<Aluno> Update([FromBody]Aluno product , string token)
        {
            _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

            var response = await _client.PutAsJson($"{path}/set/aluno/{product.Id}", product);

            if (response.IsSuccessStatusCode)
            return await response.ReadContentAs<Aluno>();


            throw new Exception("houve algum problema..");
        }

        public async Task<Aluno> Delete(int id , string token)
        {
            _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

            var response = await _client.DeleteAsync($"{path}/delete/aluno/{id}");

            if (response.IsSuccessStatusCode)
            return await response.ReadContentAs<Aluno>();

            throw new Exception("houve algum problema..");
        }
            
            public async Task<UsuarioToken> Login()
        {
            var user = new
            {
                name = "",
                email = "",
                password = "",
                confirmPassword = ""
            };

            var response = await _client.PostAsJson($"{path}/Authorize/login", user);

            if (response.IsSuccessStatusCode)
            return await response.ReadContentAs<UsuarioToken>();


            throw new Exception("houve algum problema..");

        }
    }
}
