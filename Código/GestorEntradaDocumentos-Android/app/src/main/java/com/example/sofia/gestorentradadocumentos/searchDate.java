
package com.example.sofia.gestorentradadocumentos;
import android.app.Activity;
import android.app.AlertDialog;
import android.app.DatePickerDialog;
import android.content.Context;
import android.content.DialogInterface;
import android.content.Intent;
import android.content.SharedPreferences;
import android.graphics.Color;
import android.graphics.Typeface;
import android.icu.util.Calendar;
import android.os.AsyncTask;
import android.os.Bundle;
import android.util.Log;
import android.view.Gravity;
import android.view.View;
import android.view.ViewGroup;
import android.widget.Button;
import android.widget.DatePicker;
import android.widget.EditText;
import android.widget.TableLayout;
import android.widget.TableRow;
import android.widget.TextView;

import org.ksoap2.SoapEnvelope;
import org.ksoap2.serialization.SoapObject;
import org.ksoap2.serialization.SoapSerializationEnvelope;
import org.ksoap2.transport.HttpTransportSE;
import org.w3c.dom.Text;

import java.text.DateFormat;
import java.text.ParseException;
import java.text.SimpleDateFormat;
import java.util.Date;
import java.util.concurrent.ExecutionException;


public class searchDate extends Activity {


    //Clase asincronica que recupera información
    public class webServiceSearchByDate extends AsyncTask<String,Boolean,searchData[]> {
        String from;
        String to;
        String METHOD_NAME = "searchByDate";
        String SOAP_ACTION = getString(R.string.nameSpace) + METHOD_NAME;
        public searchData [] listData;



        public webServiceSearchByDate(String from,String to)
        {
            this.from = from;
            this.to = to;
        }
        @Override
        protected searchData[] doInBackground(String... params) {

            try {

                SoapObject request = new SoapObject(getString(R.string.nameSpace), METHOD_NAME);
                request.addProperty("from",from);
                request.addProperty("to",to);
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
                Log.d("LISTACANTIDAD",Integer.toString(listData.length));

            }
            catch (Exception e)
            {
                Log.d("Excepcion",e.toString());

            }

            return listData;
        }
    }

    EditText txtFrom;
    EditText txtTo;
    TextView errorMessage;
    Button searchButton;
    TableLayout showInformation;
    private DatePickerDialog changeDate;
    public SimpleDateFormat sdf;
    TextView welcome;
    TextView showState;
    TextView labelShow;
    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_search_date);
        final SharedPreferences sharedPref = getSharedPreferences("Credentials", Context.MODE_WORLD_READABLE);
        String name = sharedPref.getString("name",""); ;
        welcome = (TextView) findViewById (R.id.txtWelcomeDate);
        welcome.setText ("Bienvenido "+name);


        sdf = new SimpleDateFormat("dd-MM-yyyy");

        showState = (TextView) findViewById(R.id.txtConnectionProcedure);
        reviewConnection();
        showState.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                reviewConnection();
            }
        });
        labelShow = (TextView)findViewById(R.id.txtSearchResult);
        labelShow.setVisibility(View.INVISIBLE);
        txtFrom = (EditText) findViewById(R.id.txtFrom);
        txtFrom.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                showInformation.setVisibility(View.INVISIBLE);
                errorMessage.setVisibility(View.INVISIBLE);
                labelShow.setVisibility(View.INVISIBLE);
                openDatePicker(1);
                changeDate.show();
            }
        });
        txtTo = (EditText) findViewById(R.id.txtTo);
        txtTo.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                showInformation.setVisibility(View.INVISIBLE);
                errorMessage.setVisibility(View.INVISIBLE);
                labelShow.setVisibility(View.INVISIBLE);
                openDatePicker(2);
                changeDate.show();
            }
        });
        errorMessage = (TextView) findViewById(R.id.txtError);
        errorMessage.setVisibility(View.INVISIBLE);
        showInformation = (TableLayout) findViewById(R.id.tableDate);
        showInformation.setVisibility(View.INVISIBLE);
        showInformation.removeAllViews();

        searchButton = (Button) findViewById(R.id.btnSearchDate);
        searchButton.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                showInformation.setVisibility(View.INVISIBLE);
                errorMessage.setVisibility(View.INVISIBLE);
                labelShow.setVisibility(View.INVISIBLE);
                if (txtFrom.getText().toString().equals("") || txtTo.getText().toString().equals("")){
                    AlertDialog.Builder builder = new AlertDialog.Builder(searchDate.this)
                            .setMessage("No puede haber fechas vacías")
                            .setTitle("Fechas Vacías")
                            .setPositiveButton("Aceptar",null);
                    AlertDialog dialog = builder.create();
                    dialog.show();
                }
                else{
                    goSearch();
                }
            }
        });



    }

    private void openDatePicker(final int option){
        //Rutina programada para abrir el calendario y asignarle el formato preprogramando
        java.util.Calendar newCalendar = java.util.Calendar.getInstance();
        changeDate = new DatePickerDialog(this, new DatePickerDialog.OnDateSetListener() {

            public void onDateSet(DatePicker view, int year, int monthOfYear, int dayOfMonth) {
                java.util.Calendar newDate = java.util.Calendar.getInstance();
                newDate.set(year, monthOfYear, dayOfMonth);
                if (option==1){
                    txtFrom.setText(sdf.format(newDate.getTime()));
                }
                if (option==2){
                    txtTo.setText(sdf.format(newDate.getTime()));
                }

            }

        },newCalendar.get(java.util.Calendar.YEAR), newCalendar.get(java.util.Calendar.MONTH), newCalendar.get(java.util.Calendar.DAY_OF_MONTH));


    }


    private TableRow createHeader(){
        TableRow headers = new TableRow(com.example.sofia.gestorentradadocumentos.searchDate.this);
        headers.setLayoutParams(new TableLayout.LayoutParams(ViewGroup.LayoutParams.FILL_PARENT, ViewGroup.LayoutParams.WRAP_CONTENT));


        TextView date = new TextView(searchDate.this);
        date.setGravity(Gravity.CENTER);
        date.setText("Fecha");
        date.setTextSize(20);
        date.setTypeface(null, Typeface.BOLD);



        TextView codeTest = new TextView(searchDate.this);
        codeTest.setPadding(15,0,0,0);
        codeTest.setGravity(Gravity.CENTER);
        codeTest.setText("Consecutivo");
        codeTest.setTextSize(20);
        codeTest.setTypeface(null, Typeface.BOLD);

        TextView detail = new TextView(searchDate.this);
        detail.setGravity(Gravity.CENTER);
        detail.setPadding(15,0,0,0);
        detail.setText("Detalle");
        detail.setTextSize(20);
        detail.setTypeface(null, Typeface.BOLD);


        TextView id = new TextView(searchDate.this);
        id.setGravity(Gravity.CENTER);
        id.setPadding(15,0,0,0);
        id.setText("Cédula");
        id.setTextSize(20);
        id.setTypeface(null, Typeface.BOLD);

        TextView status = new TextView(searchDate.this);
        status.setGravity(Gravity.CENTER);
        status.setPadding(15,0,0,0);
        status.setText("Estado");
        status.setTextSize(20);
        status.setTypeface(null, Typeface.BOLD);

        TextView typeProcedure = new TextView(searchDate.this);
        typeProcedure.setGravity(Gravity.CENTER);
        typeProcedure.setPadding(15,0,0,0);
        typeProcedure.setText("Tipo de Procedimiento");
        typeProcedure.setTextSize(20);
        typeProcedure.setTypeface(null, Typeface.BOLD);

        TextView plataformer = new TextView(searchDate.this);
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
    private void goSearch(){
        DateFormat dateFormat = new SimpleDateFormat("yyyy-MM-dd");
        try {
            Date from = sdf.parse(txtFrom.getText().toString());
            Date to = sdf.parse(txtTo.getText().toString());

            if (to.before(from)){
                AlertDialog.Builder builder = new AlertDialog.Builder(searchDate.this)
                        .setMessage("El campo hasta debe de ser menor que hasta")
                        .setTitle("Rango de Fechas Inválido")
                        .setPositiveButton("Aceptar",null);
                AlertDialog dialog = builder.create();
                dialog.show();
            }
            else {
                if (new connection().execute().get()){
                    Log.d("HERE!","Dentro del if");
                    String fromFinal =  dateFormat.format(from);
                    String toFinal = dateFormat.format(to);
                    webServiceSearchByDate search = new webServiceSearchByDate(fromFinal,toFinal);
                    searchData[] resultList = search.execute().get();
                    if (resultList.length>0){
                        labelShow.setVisibility(View.VISIBLE);
                        showInformation.removeAllViews();
                        showInformation.addView(createHeader());
                        for (int i=0;i<resultList.length;i++){
                            TableRow headers = new TableRow(searchDate.this);
                            headers.setLayoutParams(new TableLayout.LayoutParams(ViewGroup.LayoutParams.FILL_PARENT, ViewGroup.LayoutParams.WRAP_CONTENT));
                            TableRow.LayoutParams lp = new TableRow.LayoutParams(0, TableRow.LayoutParams.WRAP_CONTENT, 5f);
                            TextView date = new TextView(searchDate.this);
                            date.setText(resultList[i].date);
                            TextView codeTest = new TextView(searchDate.this);
                            codeTest.setText(resultList[i].consecutive);
                            codeTest.setPadding(15,0,0,0);
                            TextView detail = new TextView(searchDate.this);
                            detail.setText(resultList[i].detail);
                            detail.setPadding(15,0,0,0);
                            TextView id = new TextView(searchDate.this);
                            id.setText(resultList[i].identification);
                            id.setPadding(15,0,0,0);
                            TextView status = new TextView(searchDate.this);
                            status.setText(resultList[i].state);
                            status.setPadding(15,0,0,0);
                            TextView typeProcedure = new TextView(searchDate.this);
                            typeProcedure.setText(resultList[i].type);
                            typeProcedure.setPadding(15,0,0,0);
                            TextView plataformer = new TextView(searchDate.this);
                            plataformer.setText(resultList[i].plataformer);
                            plataformer.setPadding(15,0,0,0);
                            headers.addView(date);
                            headers.addView(codeTest);
                            headers.addView(id);
                            headers.addView(status);
                            headers.addView(typeProcedure);
                            headers.addView(plataformer);
                            showInformation.addView(headers);
                        }

                        showInformation.setVisibility(View.VISIBLE);
                    }
                    else{
                        showInformation.setVisibility(View.INVISIBLE);
                        errorMessage.setVisibility(View.VISIBLE);
                        labelShow.setVisibility(View.INVISIBLE);
                    }
                }
            }

        } catch (ParseException e) {
            showErrorConnection();
        } catch (InterruptedException e) {
            showErrorConnection();
        } catch (ExecutionException e) {
            showErrorConnection();
        }
    }

    public void onBackPressed() {
        Intent goBack = new Intent(getApplicationContext(),searchMenu.class);
        startActivity(goBack);
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

    private void showErrorConnection(){
        AlertDialog.Builder builder = new AlertDialog.Builder(searchDate.this)
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
}

