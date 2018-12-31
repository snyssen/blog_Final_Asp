using Blog_final_Asp.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Blog_final_Asp.ViewModels
{
    public class PostSettingsViewModel
    {
        /* ===== Affichage ===== */
        public List<User> Writers { get; set; }
        public string PostPic { get; set; }
        public List<User> Auteurs { get; set; } // Ne contient que les auteurs du site

        /* ===== Post ===== */
            /* --- Modification du post --- */
            [Required]
            public int IDpost { get; set; }
            [Display(Name = "Photo de couverture (Laissez vide pour garder votre photo actuelle)")]
            [Blog_final_Asp.Filters.FileExtensions("jpg,png,gif", ErrorMessage = "Veuillez entrer une image au format .jpg, .png ou .gif")]
            public HttpPostedFileBase Picture { get; set; }
            [Required(ErrorMessage = "Veuillez indiquer le titre du billet")]
            [Display(Name = "Titre")]
            [MaxLength(50, ErrorMessage = "Ce titre est trop long")]
            public string Title { get; set; }
            [Required(ErrorMessage = "Veuillez rentrer le contenu du billet")]
            [Display(Name = "Corps")]
            public string Body { get; set; }

            /* --- Ajout d'un auteur --- */
            public int IDauteur { get; set; }

        /* ===== Vérification d'identité ===== */
        public int LoggedUserID { get; set; }
        public string LoggedUserRole { get; set; }
    }
}