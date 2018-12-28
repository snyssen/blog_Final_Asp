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