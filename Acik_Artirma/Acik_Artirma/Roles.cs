using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Acik_Artirma
{
    public class Roles
    {
        public class Users
        {
            public int id { get; set; }
            public string username { get; set; }
            public string password { get; set; }
            public string mail { get; set; }
            public string picture { get; set; }
            public int bakiye { get; set; }
            public string ad { get; set; }
            public string soyad { get; set; }
        }

        public class Admins
        {
            public int id { get; set; }
            public string username { get; set; }
            public string password { get; set; }
        }
        
    }
}