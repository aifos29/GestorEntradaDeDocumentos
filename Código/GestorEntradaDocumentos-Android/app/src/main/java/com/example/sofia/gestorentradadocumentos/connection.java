package com.example.sofia.gestorentradadocumentos;

import android.os.AsyncTask;
import android.util.Log;
import android.widget.ArrayAdapter;

import java.io.IOException;
import java.net.InetSocketAddress;
import java.net.Socket;

public class connection extends  AsyncTask<String,Integer,Boolean>  {

    @Override
    protected Boolean doInBackground(String... params) {
            try (Socket socket = new Socket()) {
                socket.connect(new InetSocketAddress ("192.168.43.18",80), 2000);
                return true;
            } catch (IOException e) {
                // Either we have a timeout or unreachable host or failed DNS lookup
                System.out.println(e);
                return false;


            }
    }

    protected void onPostExecute(Boolean result) {
        if (result)
        {
           Log.d("Connection","FINE");

        }
        else
        {
            Log.d("ShowError","Error");
        }
    }
}

