using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Blog_final_Asp.Models
{
    public class Comment
    {
        [Key]
        public int IDcomment { get; set; }
        [Required(ErrorMessage = "Veuillez entrer un titre à votre commentaire")]
        [Display(Name = "Titre")]
        [MaxLength(25, ErrorMessage = "Le titre ne peut pas dépasser les 25 caractères")]
        public string Title { get; set; }
        [Required(ErrorMessage = "Veuillez entrer le corps de votre commentaire")]
        [Display(Name = "Corps")]
        [MaxLength(256, ErrorMessage = "Le corps ne peut pas dépasser les 256 caractères")]
        public string Body { get; set; }
        [Required]
        public DateTime Date_posted { get; set; }
        [Required]
        public int IDuser { get; set; }
        [Required]
        public int IDpost { get; set; }
        // nullable; si défini, pointe vers un commentaire auquel celui-ci répond (=> est fils du commentaire ciblé)
        public int? IDparentComm { get; set; }

        [ForeignKey("IDparentComm")] // Self-join
        public virtual Comment ParentComm { get; set; }
        // Voir -> http://blogs.microsoft.co.il/gilf/2011/06/03/how-to-configure-a-self-referencing-entity-in-code-first/
        // Et -> https://stackoverflow.com/questions/11975727/mapping-a-self-join-to-a-collection-in-code-first-entity-framework-4-3
        public virtual Post Post { get; set; }
        public virtual User User { get; set; }
    }
}