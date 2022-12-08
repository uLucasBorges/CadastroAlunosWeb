using System.Threading.Tasks;
using ApiCadastroAlunos.Core.Interfaces;
using ApiCadastroAlunos.Core.Models;
using Microsoft.AspNetCore.Mvc;

namespace GeekShopping.Web.Controllers
{
    public class SchoolController : Controller
    {
        private readonly IAlunoService _service;

        public SchoolController(IAlunoService service)
        {
            _service = service;
        }

        [HttpGet("list")]
        public async Task<IActionResult> List()
        
        {
            var products = await _service.Get();
            return Ok(products);
        }


        [HttpGet("ById")]
        public async Task<IActionResult> ById(int Id = 4004)
        {
            var products = await _service.GetById(Id);
            return Ok(products);
        }


        [HttpPost("create")]
        public async Task<IActionResult> Create([FromBody]Aluno model)
        {
            if (ModelState.IsValid)
            {
                var products = await _service.Create(model);
                if (products != null)
                {
                    return Ok(model);
                }
            }

            return BadRequest(model);

        } 
        
        
        
        [HttpPut("update")]
         public async Task<IActionResult> Update(int id)
        {
            var result = await _service.GetById(id);
            if (result is null)
            return NotFound();

            return View(result);
        }


        [HttpDelete("delete")]
        public async Task<IActionResult> Delete([FromBody]int id = 4004)
        {
           
            
                var products = await _service.Delete(id);   
                    return Ok(products);

        }



    }
}
