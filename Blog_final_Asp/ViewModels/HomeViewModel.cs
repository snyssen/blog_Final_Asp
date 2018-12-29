using Blog_final_Asp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Blog_final_Asp.ViewModels
{
    public class HomeViewModel
    {
        public List<Post> LoadedPosts { get; set; }
        public int LastPage { get; set; }
        public int PageNum { get; set; }
    }
}