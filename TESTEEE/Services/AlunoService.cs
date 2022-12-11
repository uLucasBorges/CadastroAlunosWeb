using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using ApiCadastroAlunos.Core.Interfaces;
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
            
            public async Task<UsuarioToken> Login(UserDTO user)
        {

            var response = await _client.PostAsJson($"{path}/Authorize/login", user);

            if (response.IsSuccessStatusCode)
            return await response.ReadContentAs<UsuarioToken>();


            throw new Exception("houve algum problema..");

        }
    }
}
