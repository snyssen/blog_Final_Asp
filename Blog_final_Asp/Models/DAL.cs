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
        /*
        public User AddUser(string Login, string Mail, string Password, int Access_lvl, string Profile_pic)
        {
            User user = db.Users.Add(new User { Login = Login, Mail = Mail, Password = Password, Access_lvl = Access_lvl, Profile_pic = Profile_pic });
            db.SaveChanges();
            return user;
        }

        public User AuthUser(string Login, string Password)
        {
            Password = Crypto.SHA256(Password);
            return db.Users.FirstOrDefault(user => user.Login == Login && user.Password == Password);
        }*/

        public void Dispose()
        {
            db.Dispose();
        }
        /*
        public User GetUser(int ID)
        {
            return db.Users.FirstOrDefault(user => user.ID == ID);
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

        public List<User> GetUsers()
        {
            return db.Users.ToList();
        }*/
    }
}