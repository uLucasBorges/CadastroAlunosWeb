using System.Collections.Generic;
using System.Threading.Tasks;
using ApiCadastroAlunos.Core.Models;

namespace GeekShopping.Web.Services.Interfaces
{
    public interface IProductService
    {
        Task<IEnumerable<Aluno>> FindAllProducts();
        Task<Aluno> FindProductById(long Id);
        Task<Aluno> CreateProduct(Aluno product);
        Task<Aluno> UpdateProduct(Aluno product);
        Task<bool> DeleteProductById(long id);
    }
}
