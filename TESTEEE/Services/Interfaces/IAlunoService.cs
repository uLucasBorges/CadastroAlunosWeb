using System.Collections.Generic;
using System.Threading.Tasks;
using ApiCadastroAlunos.Core.Models;
using ApiCadastroAlunos.ViewModel;

namespace ApiCadastroAlunos.Core.Interfaces
{
    public interface IAlunoService
    {
        public Task<IEnumerable<Aluno>> Get();
        public Task<Aluno> Create(Aluno aluno);
        public Task<Aluno> GetById(int id);
        public Task<Aluno> Update(Aluno aluno);
        public Task<Aluno> Delete(int id);
    }
}