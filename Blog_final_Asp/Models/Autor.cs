using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Blog_final_Asp.Models
{
    public class Autor
    {
        [Key]
        public int IDautor { get; set; }
        [Required]
        public int IDuser { get; set; }
        [Required]
        public int IDpost { get; set; }

        public virtual User User { get; set; }
        public virtual Post Post { get; set; }
    }
}