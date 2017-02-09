using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ServicioWebSoap
{
    public class Type
    {
        public int ID { get; set; }
        public String TypeName { get; set; }

        public Type()
        {
            this.ID = 0;
            this.TypeName = "";
        }

        public Type(int id, String type)
        {
            this.ID = id;
            this.TypeName = type;
        }
    }
}