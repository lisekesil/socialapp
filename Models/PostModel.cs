using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace socialapp.Models
{
    public class PostModel
    {
        public int PostId { get; set; }
        [DisplayName("Tresć")]
        public string Content { get; set; }
        public DateTime DateTime { get; set; }
        public int UserId { get; set; }
    }
}
