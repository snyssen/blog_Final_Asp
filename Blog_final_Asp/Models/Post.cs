using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Blog_final_Asp.Models
{
    public class Post
    {
        [Key]
        public int IDpost { get; set; }
        [Required(ErrorMessage = "Veuillez entrer un titre à ce billet.")]
        [Display(Name = "Titre")]
        [MaxLength(50, ErrorMessage = "Le titre ne peut pas dépasser 50 caractères")]
        public string Title { get; set; }
        [Required(ErrorMessage = "Veuillez écrire le contenu du billet.")]
        [Display(Name = "Corps")]
        public string Body { get; set; }
        [Required]
        public DateTime Date_posted { get; set; }
        public DateTime? Date_modified { get; set; }
        [Display(Name = "Photo de couverture")]
        public string Picture { get; set; }

        public virtual ICollection<Autor> Autors { get; set; }
        public virtual ICollection<Comment> Comments { get; set; }
    }
}