package com.example.sofia.gestorentradadocumentos;

import android.app.Activity;
import android.content.Context;
import android.content.Intent;
import android.content.SharedPreferences;
import android.os.Bundle;
import android.view.View;
import android.widget.Button;
import android.widget.TextView;

public class showCode extends Activity {
    Button backProcedure;
    Button backMenu;
    TextView code;
    TextView welcome;
    TextView message;
    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_show_code);

        SharedPreferences sharedPref = getSharedPreferences("Credentials", Context.MODE_WORLD_READABLE);
        String name = sharedPref.getString("name",""); ;
        welcome = (TextView) findViewById (R.id.txtWelcome);
        welcome.setText ("Bienvenido "+name);
        backProcedure = (Button) findViewById(R.id.btnnew);
        backMenu = (Button) findViewById(R.id.btnGoBack);
        code = (TextView) findViewById(R.id.txtShowCode);
        Intent intent = getIntent();

        if (intent.getStringExtra("code").equals("NA")){
            message = (TextView) findViewById(R.id.textView19);
            message.setText("El trámite fue registrado éxitosamente localmente. En el próximo ingresó de sesión se sincronizará");
        }
        else{
            code.setText(intent.getStringExtra("code"));
        }



        backProcedure.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                Intent newScreen = new Intent(getApplicationContext(),enterProcedure.class);
                startActivity(newScreen);

            }
        });
        backMenu.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                Intent newScreen = new Intent(getApplicationContext(),Menu.class);
                startActivity(newScreen);
            }
        });
    }

    @Override
    public void onBackPressed() {

    }



}
