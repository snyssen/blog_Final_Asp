using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Blog_final_Asp.Models
{
    public class User
    {
        public int ID { get; set; }
        [Required(ErrorMessage = "Veuillez entrer un nom d'utilisateur")]
        public string Login { get; set; }
        [Required(ErrorMessage = "Veuillez entrer une adresse e-mail (valide)")]
        public string Mail { get; set; }
        [Required(ErrorMessage = "Veuillez entrer un mot de passe")]
        public string Password { get; set; }
        [Required]
        public int Access_lvl { get; set; }
    }
}