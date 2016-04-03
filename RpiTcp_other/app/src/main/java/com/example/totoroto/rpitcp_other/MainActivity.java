package com.example.totoroto.rpitcp_other;

import android.app.Activity;
import android.os.Bundle;
import android.os.Handler;
import android.os.Message;
import android.util.Log;
import android.view.View;
import android.widget.Button;
import android.widget.EditText;
import android.widget.TextView;

import java.io.BufferedReader;
import java.io.IOException;
import java.io.InputStreamReader;
import java.io.PrintWriter;
import java.net.Socket;

/*
* THREAD는 메인 스레드에서 변경하면 안돼!
*  방법 1) Handler를 이용
*       2) AsyncTask 이용
* 2)번이 좋은것 같다!
* 내일은 이거 구현해야징
* */

public class MainActivity extends Activity {
    private Socket socket;
    BufferedReader socket_in;
    PrintWriter socket_out;
    EditText input;
    Button button;
    TextView output;
    String data;


    @Override
    public void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);

        setContentView(R.layout.activity_main);

        input = (EditText) findViewById(R.id.input); //내가 보내는 값
        button = (Button) findViewById(R.id.button);
        output = (TextView) findViewById(R.id.output); //받는 값

        button.setOnClickListener(new View.OnClickListener() {

            public void onClick(View v) {
                String data = input.getText().toString();
                Log.w("NETWORK", " " + data); //보내는 값 로그 찍어줌

                if(data != null) {
                    socket_out.println(data);
                }
            }

        });


        Thread worker = new Thread() {

            public void run() {

                try {
                    socket = new Socket("192.168.43.196", 9294);
                    socket_out = new PrintWriter(socket.getOutputStream(), true);
                    socket_in = new BufferedReader(new InputStreamReader(socket.getInputStream()));

                } catch (IOException e) {
					e.printStackTrace();
                }

                try {

                    while (true) {
                        data = socket_in.readLine(); //서버에서 메시지 받는다

                        output.post(new Runnable() {

                            public void run() {
                                output.setText(data);
                                handler.sendEmptyMessage(0);
                            }
                        });
                    }

                } catch (Exception e) {
                }
            }
        };
        worker.start();

    }




    @Override
    protected void onStop() {
        super.onStop();
        try {
            socket.close();
        } catch (IOException e) {
            e.printStackTrace();
        }
    }

    Handler handler = new Handler(){
        @Override
       public void handleMessage(Message msg){
            if(msg.what == 0) {
                    output.setText("서버에서 받은 msg" + data);
                }

            }
    };

}