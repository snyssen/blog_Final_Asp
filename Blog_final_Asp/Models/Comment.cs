using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Blog_final_Asp.Models
{
    public class Comment
    {
        public int ID { get; set; }
        [Required(ErrorMessage = "Veuillez entrer un titre à votre commentaire")]
        [Display(Name = "Titre")]
        [MaxLength(25, ErrorMessage = "Le titre ne peut pas dépasser les 25 caractères")]
        public string Title { get; set; }
        [Required(ErrorMessage = "Veuillez entrer le corps de votre commentaire")]
        [Display(Name = "Corps")]
        [MaxLength(256, ErrorMessage = "Le corps ne peut pas dépasser les 256 caractères")]
        public string Body { get; set; }
        [Required]
        public DateTime Date_posted { get; set; }
        [Required]
        public User IDuser { get; set; }
        [Required]
        public Post IDpost { get; set; }
        public Comment IDcomment { get; set; } // nullable
    }
}