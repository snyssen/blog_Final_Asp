using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using Blog_final_Asp.Models;

namespace Blog_final_Asp.ViewModels
{
    public class PostShowViewModel
    {
        /* ===== Affichage ===== */
        public Post Post { get; set; }
        public List<User> Writers { get; set; }
        public List<Comment> Comments { get; set; }

        /* ===== Post de commentaire ===== */
        [Required(ErrorMessage = "Veuillez entrer un titre à votre commentaire")]
        [Display(Name = "Titre")]
        [MaxLength(25, ErrorMessage = "Le titre ne peut pas dépasser les 25 caractères")]
        public string Title { get; set; }
        [Required(ErrorMessage = "Veuillez entrer le corps de votre commentaire")]
        [Display(Name = "Corps")]
        [MaxLength(256, ErrorMessage = "Le corps ne peut pas dépasser les 256 caractères")]
        public string Body { get; set; }
        public int? IDparentComm { get; set; }

        public bool UserIsConnected { get; set; }
    }
}