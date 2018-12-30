using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Blog_final_Asp.ViewModels
{
    public class PostIndexViewModel
    {
        [Required(ErrorMessage = "Veuillez indiquer le titre du billet")]
        [Display(Name = "Titre")]
        [MaxLength(50, ErrorMessage = "Ce titre est trop long")]
        public string Title { get; set; }
        [Required(ErrorMessage = "Veuillez rentrer le contenu du billet")]
        [Display(Name = "Corps")]
        public string Body { get; set; }
        [Display(Name = "Photo de couverture (optionnelle)")]
        [Blog_final_Asp.Filters.FileExtensions("jpg,png,gif", ErrorMessage = "Veuillez entrer une image au format .jpg, .png ou .gif")]
        public HttpPostedFileBase Picture { get; set; }
    }
}