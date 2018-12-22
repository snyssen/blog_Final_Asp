using System;
using System.ComponentModel.DataAnnotations;

namespace Blog_final_Asp.Models
{
    public class Post
    {
        public int ID { get; set; }
        [Required(ErrorMessage = "Veuillez entrer un titre à ce billet.")]
        public string Title { get; set; }
        [Required(ErrorMessage = "Veuillez écrire le contenu du billet.")]
        public string Body { get; set; }
        [Required]
        public DateTime Date_posted { get; set; }
        public DateTime? Date_modified { get; set; }
    }
}