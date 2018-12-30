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
        List<User> GetWritersFromPost(int IDpost);
        List<User> GetUsers();
        int AddUser(string Login, string Mail, string Password, int IDaccess_lvl, string Profile_pic);
        User AuthUser(string Login, string Password);
        bool UpdateUser(int IDuser, string Login, string Mail, string Password, int IDaccess_lvl, string Profile_pic);
        bool UpdateUser(int IDuser, string Login, string Mail, string Profile_pic);
        bool UpdateUser(int IDuser, string Login, string Mail);
        bool UpdateUser(int IDuser, string Profile_pic);
        bool UpdateUser(int IDuser, int IDaccess_lvl);
        // ViewUser
        List<ViewUser> GetViewUsers();
        ViewUser GetViewUser(int ID);

        // Posts
        Post GetPost(int ID);
        Post GetPost(string IDstr);
        Post GetPostTitle(string Title);
        List<Post> GetPosts();
        List<Post> GetPosts(int ToLoad, int PageNum);
        int GetPostsNumber();
        int AddPost(string Title, string Body, DateTime date_posted, string Picture = null, DateTime? date_modified = null);
        // Autors
        Autor GetAutor(int ID);
        Autor GetAutor(string IDstr);
        List<Autor> GetAutorsOfPost(int IDpost);
        List<Autor> GetAutors();
        int AddAutor(int IDuser, int IDpost);

        // Comments
        Comment GetComment(int ID);
        Comment GetComment(string IDstr);
        List<Comment> GetCommentsPost(int IDpost);
        List<Comment> GetCommentsPost(string IDpoststr);
        List<Comment> GetComments();
        int AddComment(string Title, string Body, DateTime date_posted, int IDuser, int IDpost, int? IDparentComment = null);
    }
}
