using Blog_final_Asp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Blog_final_Asp.Areas.Account.ViewModels
{
    public class UserSearchViewModel
    {
        public string SearchStr { get; set; }
        public List<User> Users { get; set; }
    }
}