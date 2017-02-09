package com.example.sofia.gestorentradadocumentos;


public class searchData {
    public String date;
    public String consecutive;
    public String detail ;
    public String identification;
    public String state ;
    public String type ;
    public String plataformer ;

    public searchData()
    {
        date = "";
        consecutive = "";
        detail = "";
        identification = "";
        state = "";
        type = "";
        plataformer = "";
    }

    public searchData(String date,String consecutive, String detail, String identification, String state, String type, String plataformer)
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
