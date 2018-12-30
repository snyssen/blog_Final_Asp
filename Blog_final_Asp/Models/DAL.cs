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

        public int AddAutor(int IDuser, int IDpost)
        {
            Autor autor = new Autor { IDuser = IDuser, IDpost = IDpost };
            db.Autors.Add(autor);
            db.SaveChanges();
            return autor.IDautor;
        }

        public int AddComment(string Title, string Body, DateTime date_posted, int IDuser, int IDpost, int? IDparentComment = null)
        {
            Comment comment = new Comment { Title = Title, Body = Body, Date_posted = date_posted, IDuser = IDuser, IDpost = IDpost, IDparentComm = IDparentComment };
            db.Comments.Add(comment);
            db.SaveChanges();
            return comment.IDcomment;
        }

        public int AddPost(string Title, string Body, DateTime date_posted, string Picture = null, DateTime ? date_modified = null)
        {
            Post post = new Post { Title = Title, Body = Body, Date_posted = date_posted, Date_modified = date_modified, Picture = Picture };
            db.Posts.Add(post);
            db.SaveChanges();
            return post.IDpost;
        }

        public int AddUser(string Login, string Mail, string Password, int IDaccess_lvl, string Profile_pic)
        {
            User user = new User { Login = Login, Mail = Mail, Password = Password, IDaccess_lvl = IDaccess_lvl, Profile_pic = Profile_pic };
            db.Users.Add(user);
            db.SaveChanges();
            return user.IDuser;
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

        public List<Autor> GetAutorsOfPost(int IDpost)
        {
            return db.Autors.Where(autor => autor.IDpost == IDpost).ToList();
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
            return db.Comments.Where(comm => comm.IDpost == IDpost).ToList();
        }

        public List<Comment> GetCommentsPost(string IDpoststr)
        {
            if (int.TryParse(IDpoststr, out int ID))
            {
                return this.GetCommentsPost(ID);
            }
            else
                return null;
        }

        public Post GetPost(int ID)
        {
            return db.Posts.FirstOrDefault(post => post.IDpost == ID);
        }

        public Post GetPost(string IDstr)
        {
            if (int.TryParse(IDstr, out int ID))
            {
                return this.GetPost(ID);
            }
            else
                return null;
        }

        /// <summary>
        /// Récupère les posts TRIES PAR DATE D'AJOUT
        /// </summary>
        /// <returns></returns>
        public List<Post> GetPosts()
        {
            return db.Posts.OrderByDescending(post => post.Date_posted).ToList();
        }
        /// <summary>
        /// Récupère le nombre de posts demandés à partir de la page demandée
        /// </summary>
        /// <param name="ToLoad">Nombre de posts par page</param>
        /// <param name="PageNum">Page à charger</param>
        /// <returns></returns>
        public List<Post> GetPosts(int ToLoad, int PageNum)
        {
            int from = ToLoad * (PageNum - 1); // On calcule à partir de combien de posts on doit charger
            return this.GetPosts().Skip(from).Take(ToLoad).ToList();
        }

        public int GetPostsNumber()
        {
            return this.GetPosts().Count;
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

        public ViewUser GetViewUser(int ID)
        {
            User user = this.GetUser(ID);
            if (user == null)
                return null;
            return new ViewUser { IDuser = user.IDuser, Login = user.Login, Mail = user.Mail, Password = user.Password, Profile_pic = user.Profile_pic, Access_lvl = (this.GetAccess_lvl(user.IDaccess_lvl)).Role };
        }

        public List<ViewUser> GetViewUsers()
        {
            List<ViewUser> viewUsers = new List<ViewUser>();
            List<User> users = this.GetUsers();
            foreach (User user in users)
            {
                viewUsers.Add(new ViewUser { IDuser = user.IDuser, Login = user.Login, Mail = user.Mail, Password = user.Password, Profile_pic = user.Profile_pic, Access_lvl = (this.GetAccess_lvl(user.IDaccess_lvl)).Role });
            }
            return viewUsers;
        }

        public List<User> GetWritersFromPost(int IDpost)
        {
            List<User> users = new List<User>();
            List<Autor> autors = this.GetAutorsOfPost(IDpost);
            foreach(Autor autor in autors)
            {
                users.Add(db.Users.Where(user => user.IDuser == autor.IDuser).FirstOrDefault());
            }
            return users;
        }
    }
}