using System.Threading.Tasks;
using ApiCadastroAlunos.Core.Models;
using ApiCadastroAlunos.ViewModel;

namespace ApiCadastroAlunos.Core.Interfaces
{
    public interface IProfessorService
    {
        Task<ResultViewModel> Get();
        Task<ResultViewModel> GetAlunosPorProfessor(int id);
        Task<ResultViewModel> GetById(int id);
        Task<ResultViewModel> Create(Professor professor);


    }
}
