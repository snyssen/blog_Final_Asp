using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog_final_Asp.Models
{
    interface IDAL : IDisposable
    {
        // Access_lvl
        Access_lvl GetAccess_lvl(int ID);
        // Users
        User GetUser(int ID);
        User GetUser(string IDstr);
        User GetUserLogin(string Login);
        List<User> GetUsers();
        void AddUser(string Login, string Mail, string Password, int IDaccess_lvl, string Profile_pic);
        User AuthUser(string Login, string Password);

        // Posts
        Post GetPost(int ID);
        Post GetPost(string IDstr);
        Post GetPostTitle(string Title);
        List<Post> GetPosts();
        List<Post> GetPosts(int ToLoad, int PageNum);
        int GetPostsNumber();
        void AddPost(string Title, string Body, DateTime date_posted, string Picture = null, DateTime? date_modified = null);
        // Autors
        Autor GetAutor(int ID);
        Autor GetAutor(string IDstr);
        List<Autor> GetAutorsPost(int IDpost);
        List<Autor> GetAutorsPost(string IDpoststr);
        List<Autor> GetAutors();
        void AddAutor(int IDuser, int IDpost);

        // Comments
        Comment GetComment(int ID);
        Comment GetComment(string IDstr);
        List<Comment> GetCommentsPost(int IDpost);
        List<Comment> GetCommentsPost(string IDpoststr);
        List<Comment> GetComments();
        void AddComment(string Title, string Body, DateTime date_posted, int IDuser, int IDpost, int? IDcomment = null);
    }
}
