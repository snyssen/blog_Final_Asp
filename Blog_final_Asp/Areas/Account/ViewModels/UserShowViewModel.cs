using Blog_final_Asp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Blog_final_Asp.Areas.Account.ViewModels
{
    public class UserShowViewModel
    {
        public ViewUser User { get; set; }
        public int LoggedUserID { get; set; } // Sera à 0 si l'utilisateur n'est pas connecté
    }
}