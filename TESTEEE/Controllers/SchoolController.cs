using System.Threading.Tasks;
using ApiCadastroAlunos.Core.Models;
using GeekShopping.Web.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace GeekShopping.Web.Controllers
{
    public class SchoolController : Controller
    {
        private readonly IProductService _service;

        public SchoolController(IProductService service)
        {
            _service = service;
        }

        [HttpGet("list")]
        public async Task<IActionResult> List()
        {
            var products = await _service.FindAllProducts();
            return Ok(products);
        }


        [HttpPost]
        public async Task<IActionResult> Create([FromBody]Aluno model)
        {
            if (ModelState.IsValid)
            {
                var products = await _service.CreateProduct(model);
                if (products != null)
                {
                    return Ok(model);
                }
            }

            return BadRequest(model);

        } 
        
        
        
        [HttpGet]
         public async Task<IActionResult> Update(int id)
        {
            var result = await _service.FindProductById(id);
            if (result is null)
            return NotFound();

            return View(result);
        }


        [HttpPost]
        public async Task<IActionResult> Update([FromBody]Aluno model)
        {
            if (ModelState.IsValid)
            {
                var products = await _service.UpdateProduct(model);
                if(products != null)
                {
                    return Ok(model);
                }
            }

            return BadRequest(model);
        }



    }
}
