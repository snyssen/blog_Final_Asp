using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Helpers;

namespace Blog_final_Asp.Models
{
    public class DAL : IDAL
    {
        private EFDBcontext db;

        public DAL() { db = new EFDBcontext(); }

        public void AddAutor(int IDuser, int IDpost)
        {
            throw new NotImplementedException();
        }

        public void AddComment(string Title, string Body, DateTime date_posted, int IDuser, int IDpost, int? IDcomment = null)
        {
            throw new NotImplementedException();
        }

        public void AddPost(string Title, string Body, DateTime date_posted, string Picture = null, DateTime ? date_modified = null)
        {
            db.Posts.Add(new Post { Title = Title, Body = Body, Date_posted = date_posted, Date_modified = date_modified, Picture = Picture });
            db.SaveChanges();
        }

        public void AddUser(string Login, string Mail, string Password, int IDaccess_lvl, string Profile_pic)
        {
            db.Users.Add(new User { Login = Login, Mail = Mail, Password = Password, IDaccess_lvl = IDaccess_lvl, Profile_pic = Profile_pic });
            db.SaveChanges();
        }

        public User AuthUser(string Login, string Password)
        {
            Password = Crypto.SHA256(Password);
            return db.Users.FirstOrDefault(user => user.Login == Login && user.Password == Password);
        }

        public void Dispose()
        {
            db.Dispose();
        }

        public Access_lvl GetAccess_lvl(int ID)
        {
            return db.Access_lvls.FirstOrDefault(acc => acc.IDaccess_lvl == ID);
        }

        public Autor GetAutor(int ID)
        {
            throw new NotImplementedException();
        }

        public Autor GetAutor(string IDstr)
        {
            throw new NotImplementedException();
        }

        public List<Autor> GetAutors()
        {
            throw new NotImplementedException();
        }

        public List<Autor> GetAutorsPost(int IDpost)
        {
            throw new NotImplementedException();
        }

        public List<Autor> GetAutorsPost(string IDpoststr)
        {
            throw new NotImplementedException();
        }

        public Comment GetComment(int ID)
        {
            throw new NotImplementedException();
        }

        public Comment GetComment(string IDstr)
        {
            throw new NotImplementedException();
        }

        public List<Comment> GetComments()
        {
            throw new NotImplementedException();
        }

        public List<Comment> GetCommentsPost(int IDpost)
        {
            throw new NotImplementedException();
        }

        public List<Comment> GetCommentsPost(string IDpoststr)
        {
            throw new NotImplementedException();
        }

        public Post GetPost(int ID)
        {
            throw new NotImplementedException();
        }

        public Post GetPost(string IDstr)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Récupère les posts TRIES PAR DATE D'AJOUT
        /// </summary>
        /// <returns></returns>
        public List<Post> GetPosts()
        {
            return db.Posts.OrderByDescending(post => post.Date_posted).ToList();
        }

        public Post GetPostTitle(string Title)
        {
            throw new NotImplementedException();
        }

        public User GetUser(int ID)
        {
            return db.Users.FirstOrDefault(user => user.IDuser == ID);
        }

        public User GetUser(string IDstr)
        {
            if (int.TryParse(IDstr, out int ID))
            {
                return this.GetUser(ID);
            }
            else
                return null;
        }

        public User GetUserLogin(string Login)
        {
            return db.Users.FirstOrDefault(user => user.Login == Login);
        }

        public List<User> GetUsers()
        {
            return db.Users.ToList();
        }
    }
}