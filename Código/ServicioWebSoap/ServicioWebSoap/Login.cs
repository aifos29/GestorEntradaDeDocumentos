using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ServicioWebSoap
{
    public class Login
    {
        public int id { set; get; }
        public String email { set; get; }
        public String password { set; get; }
        public int plataformers { set; get; }
        public String name { set; get; }
        public int isBoss { set; get; }
        public int idLoggin { set; get; }

        public Login(int id, String email, String password, int plat,String name,int boss)
        {
            this.id = id;
            this.email = email;
            this.password = password;
            this.plataformers = plat;
            this.name = name;
            this.isBoss = boss;
            this.idLoggin = id;

        }

        public Login()
        {
            this.id = 0;
            this.email = "";
            this.password = "";
            this.plataformers = 0;
            this.name = "";
            this.isBoss = 0;
            this.idLoggin = 0;
        }
    }
}