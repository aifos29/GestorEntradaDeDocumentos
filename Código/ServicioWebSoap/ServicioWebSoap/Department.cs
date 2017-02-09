using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ServicioWebSoap
{
    public class Department
    {
        public int id {get; set;}
        public String department {get; set;}
        public String code {get; set;}


        public Department(int id, String department, String code)
        {
            this.id = id;
            this.department = department;
            this.code = code;

        }

        public Department()
        {
            this.id = 0;
            this.department = "";
            this.code = "";
        }
    }
}