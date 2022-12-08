using System.ComponentModel.DataAnnotations;

namespace CadastroAlunos.Core.DTOs
{
   
    public class UserDTO 
    {
        public string Name { get; set; }
        [EmailAddress]
        public string Email { get; set; }
        public string Password { get; set; }
        [Compare(nameof(Password), ErrorMessage = "Password mismatch")]
        public string ConfirmPassword { get; set; }


        public UserDTO(string name , string email, string password, string confirmPassword)
        {
            Name = name;
            Email = email;
            Password = password;
            ConfirmPassword = confirmPassword;
        }

    }
}
