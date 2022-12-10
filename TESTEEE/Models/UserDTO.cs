using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace CadastroAlunos.Core.DTOs
{
    public class UserDTO 
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
    }
}
