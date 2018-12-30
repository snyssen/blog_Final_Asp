using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Blog_final_Asp.Models
{
    public class ViewUser // Permet de rassembler un utilisateur et son nom de rôle en une seule classe
    {
        public int IDuser { get; set; }
        public string Login { get; set; }
        public string Mail { get; set; }
        public string Password { get; set; }
        public string Access_lvl { get; set; }
        public string Profile_pic { get; set; }
    }
}