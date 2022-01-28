using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace socialapp.Models
{
    public class RegisterModel
    {
        [Required(ErrorMessage = "Podaj login")]
        [DataType(DataType.Text)]
        public string Name { get; set; }
        [Required(ErrorMessage = "Podaj imię")]

        [DataType(DataType.Text)]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Podaj nazwisko")]
        [DataType(DataType.Text)]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Podaj hasło")]
        [DataType(DataType.Password)]
        [MinLength(length: 6, ErrorMessage = "Hasło musi być dłuższe niż 6 znaków!")]
        [UIHint("password")]
        public string Password { get; set; }

        [Required(ErrorMessage = "Powtórz hasło")]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "Hasła muszą być takie same!")]
        public string ConfirmPassword { get; set; }

        [Required(ErrorMessage = "Podaj email")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }


        public string ReturnUrl { get; set; } = "/";
    }
}
