using System;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using ApiCadastroAlunos.Core.Interfaces;
using CadastroAlunos.Core.DTOs;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using RestSharp;

namespace GeekShopping.Web.Controllers
{
    public class SchoolController : Controller
    {
        private readonly IAlunoService _alunoservice;

        public SchoolController(IAlunoService alunoservice)
        {
            _alunoservice = alunoservice;
        }

        [HttpPost("/login")]
        public async Task<IActionResult> Login([FromBody]UserDTO user)
        {
            var JWT = await _alunoservice.Login(user);

            HttpContext.Response.Cookies.Append("token", JWT.Token, new Microsoft.AspNetCore.Http.CookieOptions
            {
                Expires = DateTime.Now.AddHours(2)
            });

            return Ok(JWT);

        }


    }
}
