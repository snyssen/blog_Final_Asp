using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Blog_final_Asp.Models
{
    public class Autor
    {
        public int ID { get; set; }
        [Required]
        public User IDuser { get; set; }
        [Required]
        public Post IDpost { get; set; }
    }
}