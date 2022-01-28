using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace socialapp.Models
{
    public class UserModel : IdentityUser
    {
        public UserModel() : base()
        {

        }

        [Required(ErrorMessage = "Musisz podać imię")]
        [MinLength(3, ErrorMessage = "Za krótkie")]
        [MaxLength(30, ErrorMessage = "Za dlugie")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Musisz podać nazwisko")]
        [MinLength(3, ErrorMessage = "Za krótkie")]
        [MaxLength(30, ErrorMessage = "Za dlugie")]
        public string LastName { get; set; }

        public virtual HashSet<PostModel> Posts { get; set; }
        public virtual HashSet<CommentModel> Comments { get; set; }

    }
}
