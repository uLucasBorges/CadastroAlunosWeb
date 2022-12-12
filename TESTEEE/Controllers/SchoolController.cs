using System;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using ApiCadastroAlunos.Core.Interfaces;
using ApiCadastroAlunos.Core.Models;
using CadastroAlunos.Core.DTOs;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using RestSharp;

namespace GeekShopping.Web.Controllers
{
    //[Authorize(Policy = "School")]
    public class SchoolController : Controller
    {
        private readonly IAlunoService _alunoservice;

        public SchoolController(IAlunoService alunoservice)
        {
            _alunoservice = alunoservice;
        }

        [HttpPost("/Log")]
        public async Task<IActionResult> Login([FromBody]UserDTO user)
        {
            var JWT = await _alunoservice.Login(user);

            HttpContext.Response.Cookies.Append("token", JWT.Token, new Microsoft.AspNetCore.Http.CookieOptions
            {
                Expires = DateTime.Now.AddHours(2)
            });

            return Ok(JWT);

        }

        [HttpGet("list")]
        public async Task<IActionResult> List()
        {

          var products = await _alunoservice.Get(this.TokenValue());
          return Ok(products);
            
        }

        
        [HttpGet("ById/{Id}")]
        public async Task<IActionResult> ById(int Id)
        {
            var products = await _alunoservice.GetById(Id , this.TokenValue());
            return Ok(products);
        }


        [HttpPost("create")]
        public async Task<IActionResult> Create([FromBody]Aluno model)
        {
            if (ModelState.IsValid)
            {
                var products = await _alunoservice.Create(model , this.TokenValue());
                if (products != null)
                {
                    return Ok(model);
                }
            }

            return BadRequest(model);

        } 
        
        
        
        [HttpPut("update/{id}")]
         public async Task<IActionResult> Update([FromBody]Aluno aluno)
        {
            var result = await _alunoservice.GetById(aluno.Id , this.TokenValue());
            
            if(result != null)
            {
                await _alunoservice.Update(aluno, this.TokenValue());
                return Ok(result);
            }

            return BadRequest();
        }


        [HttpDelete("delete/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
           
            
                var products = await _alunoservice.Delete(id, this.TokenValue());   
                return Ok(products);

        }


        private string TokenValue()
        {
            var access_token = Request.Cookies.TryGetValue("token", out string str) ? str : null;
            return access_token;
        }

    }
}
