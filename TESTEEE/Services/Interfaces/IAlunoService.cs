using System.Collections.Generic;
using System.Threading.Tasks;
using ApiCadastroAlunos.Core.Models;
using ApiCadastroAlunos.ViewModel;
using CadastroAlunos.Core.DTOs;
using Microsoft.AspNet.Identity.EntityFramework;

namespace ApiCadastroAlunos.Core.Interfaces
{
    public interface IAlunoService
    {
        public Task<IEnumerable<Aluno>> Get(string token);
        public Task<Aluno> Create(Aluno aluno, string token);
        public Task<Aluno> GetById(int id, string token);
        public Task<Aluno> Update(Aluno aluno, string token);
        public Task<Aluno> Delete(int id , string token);
        public Task<UsuarioToken> Login();
    }
}