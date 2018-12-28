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
    }
}
