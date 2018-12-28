using Blog_final_Asp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Blog_final_Asp.Areas.Account.ViewModels
{
    public class LoginViewModel
    {
        public User User { get; set; }
        public bool Authenticated { get; set; }
    }
}