using System.Collections.Generic;
using System.Threading.Tasks;
using ApiCadastroAlunos.ViewModel;
using CadastroAlunos.Core.DTOs;
using Microsoft.AspNet.Identity.EntityFramework;

namespace ApiCadastroAlunos.Core.Interfaces
{
    public interface IAlunoService
    {
        public Task<UsuarioToken> Login(UserDTO user);
    }
}