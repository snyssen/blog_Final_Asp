using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Blog_final_Asp.Models
{
    public class Access_lvl
    {
        [Key]
        public int IDaccess_lvl { get; set; }
        [Required]
        public string Role { get; set; }

        public virtual ICollection<User> Users { get; set; }
    }
}