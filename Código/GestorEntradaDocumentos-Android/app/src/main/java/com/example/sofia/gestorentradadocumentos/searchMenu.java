package com.example.sofia.gestorentradadocumentos;

import android.app.Activity;
import android.content.Context;
import android.content.Intent;
import android.content.SharedPreferences;
import android.graphics.Color;
import android.os.Bundle;
import android.view.View;
import android.widget.Button;
import android.widget.EditText;
import android.widget.TextView;

import org.w3c.dom.Text;

import java.util.concurrent.ExecutionException;

public class searchMenu extends Activity {

    Button department;
    Button date;
    Button code;
    Button plataformer;
    Intent nextScreen;
    TextView welcome;
    TextView showState;
    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_search_menu);
        SharedPreferences sharedPref = getSharedPreferences("Credentials", Context.MODE_WORLD_READABLE);
        String name = sharedPref.getString("name",""); ;
        welcome = (TextView) findViewById (R.id.txtWelcomeMenuSearch);
        welcome.setText ("Bienvenido "+name);
        department = (Button) findViewById(R.id.btnDepartment);
        date = (Button) findViewById(R.id.bntDate);
        code = (Button) findViewById(R.id.btnCode);
        plataformer = (Button) findViewById(R.id.btnPlatformist);
        showState = (TextView) findViewById(R.id.txtConnectionProcedure);
        reviewConnection();
        showState.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                reviewConnection();
            }
        });
        department.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                nextScreen = new Intent(getApplicationContext(),searchDepartment.class);
                startActivity(nextScreen);
            }
        });

        date.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                nextScreen = new Intent(getApplicationContext(),searchDate.class);
                startActivity(nextScreen);
            }
        });

        code.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                nextScreen = new Intent(getApplicationContext(),searchCode.class);
                startActivity(nextScreen);
            }
        });

        plataformer.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                nextScreen = new Intent(getApplicationContext(),searchPlatformer.class);
                startActivity(nextScreen);
            }
        });

    }
    @Override
    public void onBackPressed() {
        Intent goBack = new Intent(getApplicationContext(),Menu.class);
        startActivity(goBack);
    }


    public void reviewConnection(){
        try {
            if (new connection().execute().get()){
                showState.setText("Conectado");
                showState.setTextColor(Color.GREEN);

            }
            else{
                startActivity(new Intent(getApplicationContext(),Menu.class));
                showState.setText("Sin Conexión");
                showState.setTextColor(Color.RED);

            }
        } catch (InterruptedException e) {
            e.printStackTrace();
        } catch (ExecutionException e) {
            e.printStackTrace();
        }
    }
}
