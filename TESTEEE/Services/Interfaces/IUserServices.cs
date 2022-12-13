using System.Collections;
using System.Threading.Tasks;
using ApiCadastroAlunos.ViewModel;
using CadastroAlunos.Core.DTOs;
using Microsoft.AspNetCore.Identity;

namespace CadastroAlunos.Core.Interfaces
{
    public interface IUserServices
    {
        Task<ResultViewModel> Login(UserDTO model);
    }
}
