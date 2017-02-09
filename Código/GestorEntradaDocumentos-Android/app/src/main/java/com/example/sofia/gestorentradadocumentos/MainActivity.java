package com.example.sofia.gestorentradadocumentos;

import android.app.Activity;
import android.content.Intent;
import android.content.SharedPreferences;
import android.database.sqlite.SQLiteDatabase;
import android.os.AsyncTask;
import android.preference.PreferenceManager;
import android.support.v7.app.AppCompatActivity;
import android.os.Bundle;
import android.util.Log;
import android.view.View;
import android.view.Window;
import android.widget.Button;
import android.widget.EditText;
import android.widget.Toast;

import org.ksoap2.SoapEnvelope;
import org.ksoap2.serialization.SoapObject;
import org.ksoap2.serialization.SoapPrimitive;
import org.ksoap2.serialization.SoapSerializationEnvelope;
import org.ksoap2.transport.HttpTransportSE;

import java.security.MessageDigest;
import java.util.concurrent.ExecutionException;

public class MainActivity extends Activity {


    private  EditText emailText;
    private  EditText passwordText;
    private Button enter;
    public int idPlataformist;

    public class webServiceLoggin extends AsyncTask<String,Integer,Integer> {

        private String email;
        private String password;
        public Boolean executeResult;


        public webServiceLoggin(String email, String password) {
            this.email = email;
            this.password = password;

        }

        protected Integer doInBackground(String... params) {


            String res;
            String NAMESPACE = getString(R.string.nameSpace);
            String URL = getString(R.string.url);
            String METHOD_NAME = "loginVerification"; //the webservice method that you want to call
            String SOAP_ACTION = NAMESPACE + METHOD_NAME;

            try {

                SoapObject request = new SoapObject (NAMESPACE, METHOD_NAME);
                request.addProperty ("email", email);
                request.addProperty ("password", password);
                SoapSerializationEnvelope envelope = new SoapSerializationEnvelope (SoapEnvelope.VER11);
                envelope.dotNet = true;
                envelope.setOutputSoapObject (request);
                HttpTransportSE androidHttpTransport = new HttpTransportSE (URL);
                androidHttpTransport.call (SOAP_ACTION, envelope);
                SoapPrimitive response = (SoapPrimitive) envelope.getResponse (); //get the response from your webservice
                res = response.toString ();

                if (res.equals ("0")) {
                    idPlataformist=-1;
                } else {
                    idPlataformist = Integer.parseInt (res);
                    Log.d("VALUE",Integer.toString(idPlataformist));
                }


            } catch (Exception e) {
                Log.d ("Excepcion", e.toString ());

            }

            return idPlataformist;
        }

        protected void onPostExecute(Boolean result) {

            if (result)
                executeResult = true;
            else
                executeResult = false;
        }
    }


    @Override

    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_main);


        emailText = (EditText) findViewById(R.id.txtEmail);
        passwordText = (EditText) findViewById( R.id.txtPassword);
        enter = (Button) findViewById(R.id.button);
        enter.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                connection con = new connection ();
                try {
                    Boolean con_result = con.execute().get();
                    if (con_result){
                        loginwithConnection();
                    }
                    else{
                        loginwithoutConnection();

                    }
                } catch (InterruptedException e) {
                    e.printStackTrace();
                } catch (ExecutionException e) {
                    e.printStackTrace();
                }

            }
        });


    }

    private void loginwithConnection() throws ExecutionException, InterruptedException {

        webServiceLoggin loggin = new webServiceLoggin(emailText.getText().toString(),passwordText.getText().toString());
        int output = loggin.execute().get();
        if (output!=-1) {
            dataBase data = new dataBase();
            if (data.createTable()) {
                data.syncBase(MainActivity.this);
                String name = data.getName(output);
                storeCredentials(name, output);

            }

            else{
                Toast.makeText(getApplicationContext(),"No se puede verificar sus datos",Toast.LENGTH_SHORT).show();
            }
        }
        else{
            Toast.makeText(getApplicationContext(), "Las credenciales son incorrectas o no se encuentra autorizado para ingresar", Toast.LENGTH_LONG).show();
        }
    }
    private void loginwithoutConnection(){
        Toast.makeText (getApplicationContext (),"No se pudo conectar con el servidor.Recolectando datos locales",Toast.LENGTH_SHORT).show ();
        dataBase base = new dataBase ();
        int id = base.exist (emailText.getText ().toString (),passwordText.getText ().toString ());
        if (id!=0){
            String name = base.getName (id);
            storeCredentials(name,id);

        }
        else{
            Toast.makeText(getApplicationContext(), "Las credenciales son incorrectas o no se encuentra en el sistema", Toast.LENGTH_LONG).show();
        }
    }

    private void storeCredentials(String name,int id){
        SharedPreferences sharedPref = getSharedPreferences("Credentials", getApplicationContext().MODE_WORLD_WRITEABLE);
        SharedPreferences.Editor editor = sharedPref.edit();
        editor.putString("name", name);
        editor.putInt("id",id);
        editor.commit();
        Intent goMenu = new Intent(getApplicationContext(),Menu.class);
        startActivity(goMenu);
    }


}