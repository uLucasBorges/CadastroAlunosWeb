using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;


namespace ApiCadastroAlunos.Core.Models
{
    public class Aluno
    {

        public int Id { get; set; }
        public string Nome { get; set; }
        public string Sobrenome { get; set; }
        public string email { get; set; }
        public string celular { get; set; }
        public int ProfessorId { get; set; }
        public string professorNome { get; set; }


    }
}