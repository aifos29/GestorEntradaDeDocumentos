using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ServicioWebSoap
{
    public class Searchs
    {
        public String date { set; get; }
        public String consecutive { set; get; }
        public String detail { set; get; }
        public String identification { set; get; }
        public String state { set; get; }
        public String type { set; get; }
        public String plataformer { set; get; }

        public Searchs()
        {
            date = "";
            consecutive = "";
            detail = "";
            identification = "";
            state = "";
            type = "";
            plataformer = "";
        }

        public Searchs(String date,String consecutive, String detail, String identification, String state, String type, String plataformer)
        {
            this.date = date;
            this.consecutive = consecutive;
            this.detail = detail;
            this.identification = identification;
            this.state = state;
            this.type = type;
            this.plataformer = plataformer;
        }



    }
}