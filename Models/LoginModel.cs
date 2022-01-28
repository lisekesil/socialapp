using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace socialapp.Models
{
    public class LoginModel
    {
        [Required(ErrorMessage ="Podaj login")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Podaj hasło")]
        [UIHint("password")]
        public string Password { get; set; }
        public string ReturnUrl { get; set; } = "/";
    }
}
