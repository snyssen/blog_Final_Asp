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
    }
}