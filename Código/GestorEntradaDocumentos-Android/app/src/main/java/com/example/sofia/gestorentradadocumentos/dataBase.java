package com.example.sofia.gestorentradadocumentos;


import android.app.Activity;
import android.app.ProgressDialog;
import android.content.Context;
import android.content.Intent;
import android.database.Cursor;
import android.database.sqlite.SQLiteDatabase;
import android.os.AsyncTask;
import android.util.Log;
import android.widget.LinearLayout;
import android.widget.Toast;

import org.ksoap2.SoapEnvelope;
import org.ksoap2.serialization.SoapObject;
import org.ksoap2.serialization.SoapPrimitive;
import org.ksoap2.serialization.SoapSerializationEnvelope;
import org.ksoap2.transport.HttpTransportSE;

import java.security.MessageDigest;
import java.util.ArrayList;
import java.util.List;
import java.util.concurrent.ExecutionException;
import java.util.concurrent.Semaphore;

public class dataBase {




    public class webServiceGetDepartment extends AsyncTask<String,Integer,Department[]> {
        String NAMESPACE = "http://sgoliver.net/";
        String URL="http://192.168.43.18/ServicioWebSoap/ServicioClientes.asmx";
        String METHOD_NAME= "DepartmentList"; //the webservice method that you want to call
        String SOAP_ACTION = NAMESPACE+METHOD_NAME;
        Boolean resul = true;
        public Department [] listDepartment;





        @Override
        protected Department[] doInBackground(String... params) {

            try {

                SoapObject request = new SoapObject(NAMESPACE, METHOD_NAME);

                SoapSerializationEnvelope envelope = new SoapSerializationEnvelope(SoapEnvelope.VER11);
                envelope.dotNet = true;
                envelope.setOutputSoapObject(request);
                HttpTransportSE androidHttpTransport = new HttpTransportSE(URL);
                androidHttpTransport.call(SOAP_ACTION, envelope);
                SoapObject resSoap =(SoapObject)envelope.getResponse();
                listDepartment = new Department[resSoap.getPropertyCount()];

                for (int i = 0; i < listDepartment.length; i++)
                {
                    SoapObject ic = (SoapObject)resSoap.getProperty(i);

                    Department cli = new Department();
                    cli.id = Integer.parseInt(ic.getProperty(0).toString());
                    cli.department = ic.getProperty(1).toString();
                    cli.code =
                            ic.getProperty(2).toString();

                    listDepartment[i] = cli;

                }

            }
            catch (Exception e)
            {
                Log.d("Excepcion",e.toString());
                resul = false;
            }

            return listDepartment;

        }
    }

    public class webServiceGetProcedures extends AsyncTask<String, Integer, Type[]> {
        String NAMESPACE = "http://sgoliver.net/";
        String URL = "http://192.168.43.18/ServicioWebSoap/ServicioClientes.asmx";
        String METHOD_NAME = "TypeProcedureList"; //the webservice method that you want to call
        String SOAP_ACTION = NAMESPACE + METHOD_NAME;
        Boolean resul = true;
        public Type[] listType;
        private MainActivity context;
        private ProgressDialog dialog;

        public webServiceGetProcedures(){
            this.context = context;
        }

        


        @Override
        protected Type[] doInBackground(String... params) {

            try {

                SoapObject request = new SoapObject (NAMESPACE, METHOD_NAME);

                SoapSerializationEnvelope envelope = new SoapSerializationEnvelope (SoapEnvelope.VER11);
                envelope.dotNet = true;
                envelope.setOutputSoapObject (request);
                HttpTransportSE androidHttpTransport = new HttpTransportSE (URL);
                androidHttpTransport.call (SOAP_ACTION, envelope);
                SoapObject resSoap = (SoapObject) envelope.getResponse ();
                listType = new Type[resSoap.getPropertyCount ()];

                for (int i = 0; i < listType.length; i++) {
                    SoapObject ic = (SoapObject) resSoap.getProperty (i);

                    Type cli = new Type ();
                    cli.id = Integer.parseInt (ic.getProperty (0).toString ());
                    cli.name = ic.getProperty (1).toString ();


                   listType[i] = cli;
                }

            } catch (Exception e) {
                Log.d ("Excepcion", e.toString ());
                resul = false;
            }

            return listType;

        }


    }

    public class webServiceGetTypes extends AsyncTask<String, Integer,Type[]> {
        String NAMESPACE = "http://sgoliver.net/";
        String URL = "http://192.168.43.18/ServicioWebSoap/ServicioClientes.asmx";
        String METHOD_NAME = "TypeIdentifyList"; //the webservice method that you want to call
        String SOAP_ACTION = NAMESPACE + METHOD_NAME;
        Boolean resul = true;
        public Type[] listType;


        @Override
        protected Type[] doInBackground(String... params) {

            try {

                SoapObject request = new SoapObject (NAMESPACE, METHOD_NAME);

                SoapSerializationEnvelope envelope = new SoapSerializationEnvelope (SoapEnvelope.VER11);
                envelope.dotNet = true;
                envelope.setOutputSoapObject (request);
                HttpTransportSE androidHttpTransport = new HttpTransportSE (URL);
                androidHttpTransport.call (SOAP_ACTION, envelope);
                SoapObject resSoap = (SoapObject) envelope.getResponse ();
                listType = new Type[resSoap.getPropertyCount ()];

                for (int i = 0; i < listType.length; i++) {
                    SoapObject ic = (SoapObject) resSoap.getProperty (i);

                    Type cli = new Type ();
                    cli.id = Integer.parseInt (ic.getProperty (0).toString ());
                    cli.name = ic.getProperty (1).toString ();

                    listType[i] = cli;
                }
                Log.d("Information","READY");

            } catch (Exception e) {
                Log.d ("Excepcion", e.toString ());
                resul = false;
            }

            return listType;

        }
    }

    public class webServiceGetCredentials extends AsyncTask<String, Integer, credential[]> {
        String NAMESPACE = "http://sgoliver.net/";
        String URL = "http://192.168.43.18/ServicioWebSoap/ServicioClientes.asmx";
        String METHOD_NAME = "LoginList"; //the webservice method that you want to call
        String SOAP_ACTION = NAMESPACE + METHOD_NAME;
        Boolean resul = true;
        public credential[] listCredential;

        @Override
        protected credential[] doInBackground(String... params) {

            try {

                SoapObject request = new SoapObject (NAMESPACE, METHOD_NAME);

                SoapSerializationEnvelope envelope = new SoapSerializationEnvelope (SoapEnvelope.VER11);
                envelope.dotNet = true;
                envelope.setOutputSoapObject (request);
                HttpTransportSE androidHttpTransport = new HttpTransportSE (URL);
                androidHttpTransport.call (SOAP_ACTION, envelope);
                SoapObject resSoap = (SoapObject) envelope.getResponse ();
                listCredential = new credential[resSoap.getPropertyCount ()];

                for (int i = 0; i < listCredential.length; i++) {
                    SoapObject ic = (SoapObject) resSoap.getProperty (i);

                    credential cli = new credential (Integer.parseInt (ic.getProperty (0).toString ()), ic.getProperty (1).toString ()
                            , ic.getProperty (2).toString (), Integer.parseInt (ic.getProperty (3).toString ()), ic.getProperty (4).toString (), Integer.parseInt (ic.getProperty (5).toString ()));

                    listCredential[i] = cli;
                }

            } catch (Exception e) {
                Log.d ("Excepcion", e.toString ());
                resul = false;
            }

            return listCredential;

        }


    }

    public class webServiceInsertProcedure extends AsyncTask<String,Integer,String> {
        String NAMESPACE = "http://sgoliver.net/";
        String URL="http://192.168.43.18/ServicioWebSoap/ServicioClientes.asmx";
        String METHOD_NAME= "insertProcedure"; //the webservice method that you want to call
        String SOAP_ACTION = NAMESPACE+METHOD_NAME;

        private String date;
        private int departmentId;
        private int typeProcedure;
        private int typeIdentyfy;
        private String identify;
        private int idUser;
        private String details;
        private String name;
        private String contact;
        public MainActivity enter;
        String res;
        public webServiceInsertProcedure(String date,int departmentId,int typeProcedure,int typeIdentyfy,String identify,String name,String contac,int UserId,String details){
            this.date = date;
            this.departmentId = departmentId;
            this.typeProcedure = typeProcedure;
            this.typeIdentyfy=typeIdentyfy;
            this.identify = identify;
            this.idUser = UserId;
            this.details =details;
            this.name = name;
            this.contact = contac;



        }

        private ProgressDialog pdia;

        @Override
        protected void onPreExecute(){
            super.onPreExecute();
            pdia = new ProgressDialog(enter);
            pdia.setMessage("Loading...");
            pdia.show();
        }

        @Override
        protected void onPostExecute(String result){
            super.onPostExecute(result);
            pdia.dismiss();
        }

        @Override
        protected String doInBackground(String... params) {

            String code ="";
            try {

                SoapObject request = new SoapObject(NAMESPACE, METHOD_NAME);
                request.addProperty ("date",date);
                request.addProperty ("departmentID",departmentId);
                request.addProperty ("identify",typeIdentyfy);
                request.addProperty ("idPerson",identify);
                request.addProperty ("typeProcedure",typeProcedure);
                request.addProperty ("detail",details);
                request.addProperty ("userId",idUser);
                request.addProperty("name",name);
                request.addProperty("contact",contact);

                SoapSerializationEnvelope envelope = new SoapSerializationEnvelope (SoapEnvelope.VER11);
                envelope.dotNet = true;
                envelope.setOutputSoapObject (request);
                HttpTransportSE androidHttpTransport = new HttpTransportSE (URL);
                androidHttpTransport.call (SOAP_ACTION, envelope);
                SoapPrimitive response = (SoapPrimitive) envelope.getResponse (); //get the response from your webservice
                code = response.toString ();


            } catch (Exception e) {
                Log.d ("Excepcion", e.toString ());

            }

            return code;
        }

    }


    SQLiteDatabase database;

    public dataBase() {
        database = SQLiteDatabase.openOrCreateDatabase ("data/data/com.example.sofia.gestorentradadocumentos/DBProcedure", null, null);
    }

    public boolean createTable() {
        boolean status = true;
        try {
            database.execSQL ("CREATE TABLE IF NOT EXISTS[typeOfProcedure] (\n" +
                    "\t[idTypeOfProcedure]\tinteger  NOT NULL,\n" +
                    "\t[TypeOfProcedure]\tnvarchar(50) NOT NULL COLLATE NOCASE\n" +
                    "\n" +
                    ")");
            database.execSQL ("CREATE TABLE IF NOT EXISTS [typeOfIdentify] (\n" +
                    "\t[idTypeOfIdentify]\tinteger  NOT NULL,\n" +
                    "\t[TypeOfIdentify]\tnvarchar(50) NOT NULL COLLATE NOCASE\n" +
                    "\n" +
                    ")");
            database.execSQL ("CREATE TABLE IF NOT EXISTS [Department] (\n" +
                    "\t[idDepartment]\tinteger   NOT NULL,\n" +
                    "\t[department]\tnvarchar(50) NOT NULL COLLATE NOCASE,\n" +
                    "\t[code]\tnvarchar(50) NOT NULL COLLATE NOCASE\n" +
                    "\n" +
                    ")");
            database.execSQL ("CREATE TABLE IF NOT EXISTS[logging] (\n" +
                    "\t[idLogging]\tinteger NOT NULL,\n" +
                    "\t[email]\tnvarchar(50) NOT NULL COLLATE NOCASE,\n" +
                    "\t[password]\tnvarchar(300) NOT NULL COLLATE NOCASE\n" +
                    "\n" +
                    ")");
            database.execSQL ("CREATE TABLE IF NOT EXISTS [Plataformers] (\n" +
                    "\t[idPlataformers]\tinteger  NOT NULL,\n" +
                    "\t[name]\tnvarchar(50) NOT NULL COLLATE NOCASE,\n" +
                    "\t[isABoss]\tinteger NOT NULL,\n" +
                    "\t[idLogging]\tinteger NOT NULL\n" +
                    ",\n" +
                    "    FOREIGN KEY ([idLogging])\n" +
                    "        REFERENCES [logging]([idLogging])\n" +
                    ")");

            database.execSQL("CREATE TABLE IF NOT EXISTS [procedure] (\n" +
                    "\t[date]\tnvarchar(50) NOT NULL COLLATE NOCASE,\n" +
                    "\t[idDepartment]\tinteger NOT NULL,\n" +
                    "\t[idTypeOfIdentify]\tinteger NOT NULL,\n" +
                    "\t[Identify]\tnvarchar(50) NOT NULL,\n" +
                    "\t[name]\tnvarchar(50) NOT NULL COLLATE NOCASE,\n" +
                    "\t[contact]\tnvarchar(50) NOT NULL COLLATE NOCASE,\n" +
                    "\t[idTypeOfProcedure]\tinteger NOT NULL,\n" +
                    "\t[details]\tnvarchar(300) NOT NULL COLLATE NOCASE,\n" +
                    "\t[idPlatformers]\tinteger NOT NULL\n" +
                    ",\n" +
                    "    FOREIGN KEY ([idDepartment])\n" +
                    "        REFERENCES [Department]([idDepartment]),\n" +
                    "    FOREIGN KEY ([idPlatformers])\n" +
                    "        REFERENCES [Plataformers]([idPlataformers]),\n" +
                    "    FOREIGN KEY ([idTypeOfIdentify])\n" +
                    "        REFERENCES [typeOfIdentify]([idTypeOfIdentify]),\n" +
                    "    FOREIGN KEY ([idTypeOfProcedure])\n" +
                    "        REFERENCES [typeOfProcedure]([idTypeOfProcedure])\n" +
                    ")");

        } catch (Exception ex) {
            status = false;
        }
        return status;
    }

    public void syncBase(MainActivity main) throws ExecutionException, InterruptedException {
        if (getProcedureSize()>0){
            syncProcedureTable(main);
            database.execSQL("Delete from procedure");
        }
        database.execSQL ("Delete from Plataformers ");
        database.execSQL ("Delete from logging");
        database.execSQL ("Delete from Department");
        database.execSQL ("Delete from typeOfProcedure");
        database.execSQL ("Delete from typeOfIdentify");

        webServiceGetTypes types = new webServiceGetTypes ();
        webServiceGetDepartment department = new webServiceGetDepartment ();
        Department[] listDepartment = department.execute ().get ();
        webServiceGetProcedures procedures = new webServiceGetProcedures ();
        Type[] listProcedures = procedures.execute ().get ();
        Type[] listType = types.execute ().get ();
        webServiceGetCredentials credentials = new webServiceGetCredentials ();
        credential[] listCredentials = credentials.execute ().get ();


        for(int i=0; i<listDepartment.length; i++) {
            database.execSQL ("Insert into Department values(" + listDepartment[i].id + ",'" + listDepartment[i].department + "','" + listDepartment[i].code + "')");
        }

        for (int i=0;i<listProcedures.length;i++){
            database.execSQL ("Insert into typeOfProcedure values(" + listProcedures[i].id + ",'" + listProcedures[i].name + "')");

        }

        for (int i=0;i<listType.length;i++){
            database.execSQL ("Insert into typeOfIdentify values(" + listType[i].id + ",'" + listType[i].name + "')");

        }

        for (int i=0;i<listCredentials.length;i++){
            database.execSQL ("Insert into logging values (" + listCredentials[i].idLoggin + ",'" + listCredentials[i].email + "','"+listCredentials[i].password+"')");
            database.execSQL ("Insert into Plataformers values (" + listCredentials[i].plataformers + ",'" + listCredentials[i].name +
                    "'," + listCredentials[i].isBoss + "," + listCredentials[i].idLoggin + ")");
        }
    }

    public int exist(String email,String password){
        String descryp = encriptyon(password);
        int id = 0;
        Cursor c = database.rawQuery ("Select Plat.idPlataformers from logging log inner join Plataformers Plat\n" +
                "on log.idLogging = Plat.idLogging where email='"+email+ "' and password = '"+descryp+"';",null);
        if (c.getCount ()>0){

            c.moveToFirst();
            id = c.getInt(0);
        }

        return id;
    }

    public List<String> getDepartments (){

        List<String> labels = new ArrayList<String>();

        Cursor getInformation = database.rawQuery ("Select department from Department",null);
        if (getInformation.moveToFirst()) {
            do {
                labels.add(getInformation.getString(0));
            } while (getInformation.moveToNext());
        }

        // closing connection
        getInformation.close();


       return labels;
    }

    public List<String> getProcedures (){

        List<String> labels = new ArrayList<String>();

        Cursor getInformation = database.rawQuery ("Select typeOfProcedure from typeOfProcedure",null);
        if (getInformation.moveToFirst()) {
            do {
                labels.add(getInformation.getString(0));
            } while (getInformation.moveToNext());
        }

        // closing connection
        getInformation.close();


        return labels;
    }


    public int getDepartmentID(String department){

        int id=-1;
        Cursor getInformation = database.rawQuery ("Select idDepartment from Department where department = '"+department+"'",null);

        if(getInformation.getCount() > 0) {

            getInformation.moveToFirst();
            id = getInformation.getInt(0);
        }


        // closing connection
        getInformation.close();


        return id;
    }

    public int getProcedureID(String name){

        int id=-1;
        Cursor getInformation = database.rawQuery ("Select idTypeOfProcedure from typeOfProcedure where typeOfProcedure = '"+name+"'",null);

        if(getInformation.getCount() > 0) {

            getInformation.moveToFirst();
            id = getInformation.getInt(0);
        }


        // closing connection
        getInformation.close();


        return id;
    }

    public String getName (int id){
        String name="";
        Cursor getInformation = database.rawQuery ("Select name from Plataformers where idPlataformers = "+id,null);
        Log.d("SIZE","Tamaño" + getInformation.getCount());
        if(getInformation.getCount() > 0) {

            getInformation.moveToFirst();
            name  = getInformation.getString(0);
        }


        // closing connection
        getInformation.close();


        return name;
    }

    public List<String> getIdentify (){

        List<String> labels = new ArrayList<String>();

        Cursor getInformation = database.rawQuery ("Select typeOfIdentify from typeOfIdentify",null);
        if (getInformation.moveToFirst()) {
            do {
                labels.add(getInformation.getString(0));
            } while (getInformation.moveToNext());
        }

        // closing connection
        getInformation.close();


        return labels;
    }


    public List<String> getPlaformers(){
        List<String> labels = new ArrayList<String>();

        Cursor getInformation = database.rawQuery ("Select name from plataformers  ",null);
        if (getInformation.moveToFirst()) {
            do {
                labels.add(getInformation.getString(0));
            } while (getInformation.moveToNext());
        }

        // closing connection
        getInformation.close();


        return labels;
    }

    public static String encriptyon(String base) {
        try{
            MessageDigest digest = MessageDigest.getInstance("SHA-256");
            byte[] hash = digest.digest(base.getBytes("UTF-8"));
            StringBuffer hexString = new StringBuffer();

            for (int i = 0; i < hash.length; i++) {
                String hex = Integer.toHexString(0xff & hash[i]);
                if(hex.length() == 1) hexString.append('0');
                hexString.append(hex);
            }

            return hexString.toString();
        } catch(Exception ex){
            throw new RuntimeException(ex);
        }
    }

    public void insertProcedure(String finalDate, int departmentID, int TypeIdentification,String personID,String name,String contact,int typeProcedure,String detail,int idPlataformist) {
        Log.d("TESTDATA",personID);
        database.execSQL("Insert into procedure values ('"+finalDate+"',"+
                departmentID+","+TypeIdentification+",'"+personID+"','"+name+"','"+contact
                +"',"+typeProcedure+",'"+detail+"',"+idPlataformist+")");
    }

    public int getProcedureSize(){
        Cursor getInformation = database.rawQuery ("Select* from procedure",null);
        return getInformation.getCount();
    }

    public void syncProcedureTable(MainActivity activity) {
        Cursor getInformation = database.rawQuery("Select* from procedure", null);
        if (getInformation.moveToFirst()) {
            do {
                Log.d("TESTDATA",getInformation.getString(3));

                webServiceInsertProcedure insert = new webServiceInsertProcedure(getInformation.getString(0),
                        getInformation.getInt(1), getInformation.getInt(6),
                        getInformation.getInt(2), getInformation.getString(3), getInformation.getString(4), getInformation.getString(5),
                        getInformation.getInt(8), getInformation.getString(7));
                insert.enter  =activity;
                insert.execute();
            } while (getInformation.moveToNext());
        }
    }
}



