using Blog_final_Asp.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Blog_final_Asp.Areas.Account.ViewModels
{
    public class UserShowViewModel
    {
        /* ===== Affichage ===== */
        public ViewUser ViewUser { get; set; }
        public int LoggedUserID { get; set; } // Sera à 0 si l'utilisateur n'est pas connecté

        /* ===== Modification ===== */
        [Required]
        public int IDuser { get; set; }
        [Required(ErrorMessage = "Veuillez entrer un nom d'utilisateur")]
        [RegularExpression(@"^[a-zA-Z0-9]*$", ErrorMessage = "Le login ne peut contenir que des caractères de type a-z, A-Z ou 0-9")]
        [MaxLength(25, ErrorMessage = "Le login ne peut pas dépasser les 25 caractères")]
        [MinLength(3, ErrorMessage = "Le login doit au moins être composé de 3 caractères")]
        public string Login { get; set; }
        [Required(ErrorMessage = "Veuillez entrer une adresse e-mail (valide)")]
        [RegularExpression(@"\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*", ErrorMessage = "L'adresse mail entrée n'est pas valide")]
        public string Mail { get; set; }
        [Display(Name = "Photo de profil (Laissez vide pour garder votre photo actuelle)")]
        [Blog_final_Asp.Filters.FileExtensions("jpg,png,gif", ErrorMessage = "Veuillez entrer une image au format .jpg, .png ou .gif")]
        public HttpPostedFileBase Picture { get; set; }
        
    }
}