using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using ApiCadastroAlunos.Core.Interfaces;
using ApiCadastroAlunos.Core.Models;
using GeekShopping.Web.Utils;
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

        public async Task<Aluno> Create([FromBody]Aluno aluno)
        {
            var response = await _client.PostAsJson($"{path}/alunos/create", aluno);

            if (response.IsSuccessStatusCode)
                return await response.ReadContentAs<Aluno>();


            throw new Exception("houve algum problema..");
        }

        public async Task<IEnumerable<Aluno>> Get()
        {
            var response = await _client.GetAsync($"{path}/alunos/list");
            return await response.ReadContentAs<IEnumerable<Aluno>>();
        }

        public async Task<Aluno> GetById(int Id)
        {
            var response = await _client.GetAsync($"{path}/alunos/search/{Id}");
            return await response.ReadContentAs<Aluno>();
        } 
        

        public async Task<Aluno> Update([FromBody]Aluno product)
        {
            var response = await _client.PutAsJson($"{path}/set/aluno/{product.Id}", product);

            if (response.IsSuccessStatusCode)
            return await response.ReadContentAs<Aluno>();


            throw new Exception("houve algum problema..");
        }

        public async Task<Aluno> Delete(int id = 4004)
        {
            var response = await _client.DeleteAsync($"{path}/delete/aluno/{id}");

            if (response.IsSuccessStatusCode)
            return await response.ReadContentAs<Aluno>();

            throw new Exception("houve algum problema..");
        }
    }
}
