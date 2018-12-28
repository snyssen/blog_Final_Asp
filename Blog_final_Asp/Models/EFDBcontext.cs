using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Blog_final_Asp.Models
{
    public class EFDBcontext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Access_lvl> Access_lvls { get; set; }
        public DbSet<Post> Posts { get; set; }
        public DbSet<Autor> Autors { get; set; }
        public DbSet<Comment> Comments { get; set; }
    }
}