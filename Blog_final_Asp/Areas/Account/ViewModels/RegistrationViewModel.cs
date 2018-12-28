using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Blog_final_Asp.Areas.Account.ViewModels
{
    public class RegistrationViewModel
    {
        [Required(ErrorMessage = "Veuillez entrer un nom d'utilisateur")]
        [RegularExpression(@"^[a-zA-Z0-9]*$", ErrorMessage = "Le login ne peut contenir que des caractères de type a-z, A-Z ou 0-9")]
        [MaxLength(25, ErrorMessage = "Le login ne peut pas dépasser les 25 caractères")]
        [MinLength(3, ErrorMessage = "Le login doit au moins être composé de 3 caractères")]
        public string Login { get; set; }
        [Required(ErrorMessage = "Veuillez entrer un mot de passe")]
        [RegularExpression(@"^[a-zA-Z0-9]{8,16}$", ErrorMessage = "Le mot de passe doit contenir entre 8 et 16 caractères de type a-z, A-Z ou 0-9")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [Required(ErrorMessage = "Veuillez entrer un mot de passe")]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "Les mots de passes doivent être identiques")]
        public string PasswordConf { get; set; }
        [Required(ErrorMessage = "Veuillez entrer une adresse mail")]
        [RegularExpression(@"\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*", ErrorMessage = "L'adresse mail entrée n'est pas valide")]
        public string Mail { get; set; }


        public bool Authenticated { get; set; }
    }
}