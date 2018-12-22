using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Blog_final_Asp.Models
{
    public class DAL : IDAL
    {
        private EFDBcontext db;

        public DAL() { db = new EFDBcontext(); }

        public void Dispose()
        {
            db.Dispose();
        }
    }
}