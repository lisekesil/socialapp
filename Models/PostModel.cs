using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace socialapp.Models
{
    public class PostModel
    {
        [Key]
        public int PostId { get; set; }
        [DisplayName("Tresć")]
        [Required(ErrorMessage = "Uzupełnij treść posta")]
        [MaxLength(2000, ErrorMessage = "Maksymalna liczba znaków wynosi 2000")]
        public string Content { get; set; }
        [Required]
        public DateTime DateTime { get; set; }
        [Required]
        public string UserId { get; set; }
        public UserModel User { get; set; }
        public virtual HashSet<CommentModel> Comments { get; set; }
    }
}
