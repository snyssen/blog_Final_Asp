using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Blog_final_Asp.Models
{
    public class User
    {
        [Key]
        public int IDuser { get; set; }
        [Required(ErrorMessage = "Veuillez entrer un nom d'utilisateur")]
        [RegularExpression(@"^[a-zA-Z0-9]*$", ErrorMessage = "Le login ne peut contenir que des caractères de type a-z, A-Z ou 0-9")]
        [MaxLength(25, ErrorMessage = "Le login ne peut pas dépasser les 25 caractères")]
        [MinLength(3, ErrorMessage = "Le login doit au moins être composé de 3 caractères")]
        public string Login { get; set; }
        [Required(ErrorMessage = "Veuillez entrer une adresse e-mail (valide)")]
        [RegularExpression(@"\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*", ErrorMessage = "L'adresse mail entrée n'est pas valide")]
        public string Mail { get; set; }
        [Required(ErrorMessage = "Veuillez entrer un mot de passe")]
        // Regex à déplacer dans le ViewModel
        //[RegularExpression(@"^[a-zA-Z0-9]{8,16}$", ErrorMessage ="Le mot de passe doit contenir entre 8 et 16 caractères de type a-z, A-Z ou 0-9")] // Je ne peux pas utiliser directement le regex vu qu'il renverra faux après le hash
        [Display(Name = "Mot de passe")]
        public string Password { get; set; }
        [Required]
        [Display(Name = "Niveau d'accès")]
        public int IDaccess_lvl { get; set; }
        /*
         * Rappel par rapport à l'access_lvl
         * 
         * L'access level (**access_lvl**) définit les droits d'un utilisateur sur le blog
         *   ---
         *  - **Niveau 0** : simple **lecteur** du blog, il peut donc lire tous les posts et les commenter
         *  - **niveau 1** : **auteur**, il peut poster de nouveaux billets et  modifier ou supprimer ses propres billets + droits précédents
         *  - **niveau 2** : **modérateur**, il peut modifier ou supprimer les billets et commentaires des autres + droits précédents
         *  - **niveau 3** : **admin**, il a un accès direct à la base de données pour des opérations CRUD + droits précédents
         *  
         *  - **pas de niveau défini** => l'utilisateur n'est pas connecté, il a le droit de lire tous les billets mais il ne peut poster aucun commentaire
        */
        [Required]
        public string Profile_pic { get; set; }

        public virtual Access_lvl Access_Lvl { get; set; }
        public virtual ICollection<Autor> Autors { get; set; }
        public virtual ICollection<Comment> Comments { get; set; }
    }
}