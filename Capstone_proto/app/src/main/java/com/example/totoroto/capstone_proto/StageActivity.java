package com.example.totoroto.capstone_proto;

import android.content.Intent;
import android.os.Bundle;
import android.os.Handler;
import android.support.v7.app.AppCompatActivity;
import android.view.View;
import android.widget.Button;

import com.example.totoroto.capstone_proto.main.MainActivity;


public class StageActivity extends AppCompatActivity {
    Button btn_stage0;
    Button btn_stage1;
    Button btn_stage2;
    Button btn_stage3;
    Button btn_stage4;

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        Handler handler = new Handler();
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_stage);

        init();

        btn_stage0.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                Intent intent = new Intent(getApplicationContext(), MainActivity.class);
                startActivity(intent);
              //  finish();
            }
        });
    }

    private void init() {
        btn_stage0 = (Button)findViewById(R.id.btn_stage0);
        btn_stage1 = (Button)findViewById(R.id.btn_stage1);
        btn_stage2 = (Button)findViewById(R.id.btn_stage2);
        btn_stage3 = (Button)findViewById(R.id.btn_stage3);
        btn_stage4 = (Button)findViewById(R.id.btn_stage4);
    }
}
