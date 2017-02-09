package com.example.sofia.gestorentradadocumentos;

import android.app.Activity;
import android.app.AlertDialog;
import android.content.Context;
import android.content.DialogInterface;
import android.content.Intent;
import android.content.SharedPreferences;
import android.graphics.Color;
import android.graphics.Typeface;
import android.os.AsyncTask;
import android.os.Bundle;
import android.util.Log;
import android.view.Gravity;
import android.view.View;
import android.view.ViewGroup;
import android.widget.AdapterView;
import android.widget.ArrayAdapter;
import android.widget.Button;
import android.widget.Spinner;
import android.widget.TableLayout;
import android.widget.TableRow;
import android.widget.TextView;

import org.ksoap2.SoapEnvelope;
import org.ksoap2.serialization.SoapObject;
import org.ksoap2.serialization.SoapSerializationEnvelope;
import org.ksoap2.transport.HttpTransportSE;
import org.w3c.dom.Text;

import java.util.List;
import java.util.concurrent.ExecutionException;

public class searchPlatformer extends Activity {
    public class webServiceSearchByPlataformist extends AsyncTask<String,Boolean,searchData[]> {
        String name;
        String METHOD_NAME = "searchByPlataformer";
        String SOAP_ACTION = getString(R.string.nameSpace) + METHOD_NAME;
        public searchData [] listData;



        public webServiceSearchByPlataformist(String name){
            this.name = name;
        }
        @Override
        protected searchData[] doInBackground(String... params) {

            try {

                SoapObject request = new SoapObject(getString(R.string.nameSpace), METHOD_NAME);
                request.addProperty("name",name);
                SoapSerializationEnvelope envelope = new SoapSerializationEnvelope(SoapEnvelope.VER11);
                envelope.dotNet = true;
                envelope.setOutputSoapObject(request);
                HttpTransportSE androidHttpTransport = new HttpTransportSE(getString(R.string.url));
                androidHttpTransport.call(SOAP_ACTION, envelope);
                SoapObject resSoap =(SoapObject)envelope.getResponse();
                listData = new searchData[resSoap.getPropertyCount()];

                for (int i = 0; i < listData.length; i++)
                {
                    SoapObject ic = (SoapObject)resSoap.getProperty(i);

                    searchData cli = new searchData(ic.getProperty(0).toString(),ic.getProperty(1).toString(),ic.getProperty(2).toString(),
                            ic.getProperty(3).toString(),ic.getProperty(4).toString(),ic.getProperty(5).toString(),ic.getProperty(6).toString());
                    listData[i] = cli;

                }

            }
            catch (Exception e)
            {
                Log.d("Excepcion",e.toString());

            }

            return listData;
        }
    }
    dataBase dataBase;
    Spinner plataformist;
    Button search;
    TableLayout showInformation;
    TextView errorMessage;
    TextView welcome;
    TextView showState;
    TextView labelShow;
    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_search_platformer);
        labelShow = (TextView)findViewById(R.id.txtSearchResultPlataformer);
        labelShow.setVisibility(View.INVISIBLE);

        dataBase = new dataBase();
        SharedPreferences sharedPref = getSharedPreferences("Credentials", Context.MODE_WORLD_READABLE);
        String name = sharedPref.getString("name",""); ;
        welcome = (TextView) findViewById (R.id.textWelcome);
        welcome.setText ("Bienvenido "+name);
        showState = (TextView)findViewById(R.id.txtConnectionProcedure);

        reviewConnection();
        showState.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                reviewConnection();
            }
        });
        showInformation = (TableLayout) findViewById(R.id.tablePlataformist);
        showInformation.setVisibility(View.INVISIBLE);
        plataformist = (Spinner) findViewById(R.id.spinnerPlatformerSearch);
        loadPlataformersSpinner();
        plataformist.setOnItemSelectedListener(new AdapterView.OnItemSelectedListener() {
            @Override
            public void onItemSelected(AdapterView<?> parent, View view, int position, long id) {
                showInformation.setVisibility(View.INVISIBLE);
                labelShow.setVisibility(View.INVISIBLE);
                errorMessage.setVisibility(View.INVISIBLE);
                showInformation.removeAllViews();
            }

            @Override
            public void onNothingSelected(AdapterView<?> parent) {

            }
        });

        errorMessage = (TextView) findViewById(R.id.txtError);
        errorMessage.setVisibility(View.INVISIBLE);
        search = (Button) findViewById(R.id.btnSearchPlataformer);


        search.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                goSearch();

            }
        });


    }

    private void goSearch(){
        webServiceSearchByPlataformist search = new webServiceSearchByPlataformist(plataformist.getSelectedItem().toString());
        try {
            searchData[] resultList = search.execute().get();
            showInformation.setVisibility(View.INVISIBLE);
            errorMessage.setVisibility(View.INVISIBLE);
            labelShow.setVisibility(View.INVISIBLE);
            showInformation.removeAllViews();
            if (new connection().execute().get()) {
                if (resultList.length != 0) {
                    showInformation.addView(createHeader());
                    for (int i = 0; i < resultList.length; i++) {
                        TableRow headers = new TableRow(searchPlatformer.this);
                        headers.setLayoutParams(new TableLayout.LayoutParams(ViewGroup.LayoutParams.FILL_PARENT, ViewGroup.LayoutParams.WRAP_CONTENT));
                        TableRow.LayoutParams lp = new TableRow.LayoutParams(0, TableRow.LayoutParams.WRAP_CONTENT, 5f);
                        TextView date = new TextView(searchPlatformer.this);
                        date.setText(resultList[i].date);
                        TextView codeTest = new TextView(searchPlatformer.this);
                        codeTest.setText(resultList[i].consecutive);
                        codeTest.setPadding(15, 0, 0, 0);
                        TextView detail = new TextView(searchPlatformer.this);
                        detail.setText(resultList[i].detail);
                        detail.setPadding(15, 0, 0, 0);
                        TextView id = new TextView(searchPlatformer.this);
                        id.setText(resultList[i].identification);
                        id.setPadding(15, 0, 0, 0);
                        TextView status = new TextView(searchPlatformer.this);
                        status.setText(resultList[i].state);
                        status.setPadding(15, 0, 0, 0);
                        TextView typeProcedure = new TextView(searchPlatformer.this);
                        typeProcedure.setText(resultList[i].type);
                        typeProcedure.setPadding(15, 0, 0, 0);
                        TextView plataformer = new TextView(searchPlatformer.this);
                        plataformer.setText(resultList[i].plataformer);
                        plataformer.setPadding(15, 0, 0, 0);
                        headers.addView(date);
                        headers.addView(codeTest);
                        headers.addView(id);
                        headers.addView(status);
                        headers.addView(typeProcedure);
                        headers.addView(plataformer);
                        showInformation.addView(headers);
                    }

                    showInformation.setVisibility(View.VISIBLE);
                    labelShow.setVisibility(View.VISIBLE);
                } else {
                    errorMessage.setVisibility(View.VISIBLE);
                }
            }
            else{
                showErrorConnection();
            }
            } catch (InterruptedException e) {
            showErrorConnection();
        } catch (ExecutionException e) {
            showErrorConnection();
        }

    }

    private void showErrorConnection(){
        AlertDialog.Builder builder = new AlertDialog.Builder(searchPlatformer.this)
                .setMessage("Parece que se perdío la conexión y no se puede realizar la búsqueda")
                .setTitle("Error de Conexión")
                .setPositiveButton("Aceptar", new DialogInterface.OnClickListener() {
                    @Override
                    public void onClick(DialogInterface dialog, int which) {
                        startActivity(new Intent(getApplicationContext(),Menu.class));
                    }
                });
        AlertDialog dialog = builder.create();
        dialog.show();
    }


    private void loadPlataformersSpinner(){
        // Spinner Drop down elements
        List<String> lables = dataBase.getPlaformers ();

        // Creating adapter for spinner
        ArrayAdapter<String> dataAdapter = new ArrayAdapter<String>(this,
                android.R.layout.simple_spinner_item, lables);

        // Drop down layout style - list view with radio button
        dataAdapter
                .setDropDownViewResource(android.R.layout.simple_spinner_dropdown_item);

        // attaching data adapter to spinner
        plataformist.setAdapter(dataAdapter);
    }

    private TableRow createHeader(){
        TableRow headers = new TableRow(com.example.sofia.gestorentradadocumentos.searchPlatformer.this);
        headers.setLayoutParams(new TableLayout.LayoutParams(ViewGroup.LayoutParams.FILL_PARENT, ViewGroup.LayoutParams.WRAP_CONTENT));


        TextView date = new TextView(searchPlatformer.this);
        date.setGravity(Gravity.CENTER);
        date.setText("Fecha");
        date.setTextSize(20);
        date.setTypeface(null, Typeface.BOLD);



        TextView codeTest = new TextView(searchPlatformer.this);
        codeTest.setPadding(15,0,0,0);
        codeTest.setGravity(Gravity.CENTER);
        codeTest.setText("Consecutivo");
        codeTest.setTextSize(20);
        codeTest.setTypeface(null, Typeface.BOLD);

        TextView detail = new TextView(searchPlatformer.this);
        detail.setGravity(Gravity.CENTER);
        detail.setPadding(15,0,0,0);
        detail.setText("Detalle");
        detail.setTextSize(20);
        detail.setTypeface(null, Typeface.BOLD);


        TextView id = new TextView(searchPlatformer.this);
        id.setGravity(Gravity.CENTER);
        id.setPadding(15,0,0,0);
        id.setText("Cédula");
        id.setTextSize(20);
        id.setTypeface(null, Typeface.BOLD);

        TextView status = new TextView(searchPlatformer.this);
        status.setGravity(Gravity.CENTER);
        status.setPadding(15,0,0,0);
        status.setText("Estado");
        status.setTextSize(20);
        status.setTypeface(null, Typeface.BOLD);

        TextView typeProcedure = new TextView(searchPlatformer.this);
        typeProcedure.setGravity(Gravity.CENTER);
        typeProcedure.setPadding(15,0,0,0);
        typeProcedure.setText("Tipo de Procedimiento");
        typeProcedure.setTextSize(20);
        typeProcedure.setTypeface(null, Typeface.BOLD);

        TextView plataformer = new TextView(searchPlatformer.this);
        plataformer.setGravity(Gravity.CENTER);
        plataformer.setPadding(15,0,0,0);
        plataformer.setText("Plataformista");
        plataformer.setTextSize(20);
        plataformer.setTypeface(null, Typeface.BOLD);

        headers.addView(date);
        headers.addView(codeTest);
        headers.addView(id);
        headers.addView(status);
        headers.addView(typeProcedure);
        headers.addView(plataformer);

        return headers;
    }


    public void reviewConnection(){
        try {
            if (new connection().execute().get()){
                showState.setText("CONECTADO");
                showState.setTextColor(Color.GREEN);
            }
            else{
                showState.setText("Sin Conexión");
                showState.setTextColor(Color.RED);
                startActivity(new Intent(getApplicationContext(),Menu.class));
            }
        } catch (InterruptedException e) {
            e.printStackTrace();
        } catch (ExecutionException e) {
            e.printStackTrace();
        }
    }
}
