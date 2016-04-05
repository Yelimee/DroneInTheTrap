package com.example.totoroto.capstone_proto;

import android.app.AlertDialog;
import android.content.DialogInterface;
import android.content.Intent;
import android.os.Bundle;
import android.os.Handler;
import android.support.v7.app.AppCompatActivity;
import android.view.View;
import android.widget.Button;


public class FirstActivity extends AppCompatActivity {
    Handler handler = new Handler();
    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_first);

        Button startBtn = (Button)findViewById(R.id.start);
        Button infoBtn = (Button)findViewById(R.id.info);
        Button exitBtn = (Button)findViewById(R.id.exit);

        startBtn.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                //스테이지 액티비티로 이동
                handler.postDelayed(new Runnable() {
                    @Override
                    public void run() {
                        Intent intent = new Intent(getApplicationContext(), StageActivity.class);
                        startActivity(intent);
                       // finish();
                    }
                }, 100);
            }
        });
        infoBtn.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                //설명 액티비티로 이동
                handler.postDelayed(new Runnable() {
                    @Override
                    public void run() {
                        Intent intent = new Intent(getApplicationContext(), InfoActivity.class);
                        startActivity(intent);
                       // finish();
                    }
                }, 100);
            }
        });

        exitBtn.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                AlertDialog.Builder alertDialogBuilder = new AlertDialog.Builder(FirstActivity.this);

                // 제목셋팅
                alertDialogBuilder.setTitle("프로그램 종료");

                // AlertDialog 셋팅
                alertDialogBuilder
                        .setMessage("프로그램을 종료할 것입니까?")
                        .setCancelable(false)
                        .setPositiveButton("종료",
                                new DialogInterface.OnClickListener() {
                                    public void onClick(
                                            DialogInterface dialog, int id) {
                                        // 프로그램을 종료한다
                                        FirstActivity.this.finish();
                                    }
                                })
                        .setNegativeButton("취소",
                                new DialogInterface.OnClickListener() {
                                    public void onClick(
                                            DialogInterface dialog, int id) {
                                        // 다이얼로그를 취소한다
                                        dialog.cancel();
                                    }
                                });
                // 다이얼로그 생성
                AlertDialog alertDialog = alertDialogBuilder.create();

                alertDialog.show();
            }
        });
    }
}
