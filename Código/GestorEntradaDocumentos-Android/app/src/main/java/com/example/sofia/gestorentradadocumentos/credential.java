package com.example.sofia.gestorentradadocumentos;

/**
 * Created by sofia on 6/1/2017.
 */
public class credential {
    public int idLoggin;
    public String email;
    public String password;
    public int plataformers;
    public String name;
    public int isBoss;

    public credential(int id,String email,String password,int plat,String name,int isBoss){
        this.idLoggin=id;
        this.name=name;
        this.email=email;
        this.password=password;
        this.plataformers=plat;
        this.isBoss = isBoss;
    }

}
