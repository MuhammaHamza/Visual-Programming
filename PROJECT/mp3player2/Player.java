package com.example.hp.mp3player2;

import android.content.Context;
import android.content.Intent;
import android.media.MediaPlayer;
import android.net.DhcpInfo;
import android.net.Uri;
import android.net.wifi.WifiManager;
import android.support.v7.app.AppCompatActivity;
import android.os.Bundle;
import android.util.Log;
import android.view.View;
import android.widget.ArrayAdapter;
import android.widget.Button;
import android.widget.TextView;
import android.widget.Toast;

import java.io.File;
import java.io.FilenameFilter;
import java.util.ArrayList;

public class Player extends AppCompatActivity {
    MediaPlayer mp;
    ArrayList<File> mysongs;
    int position;
    Uri uri;
    int length;
    TextView local,BroadcastIp;
    Button bu_stop,btn_ffd,btn_rrd,btn_nxt,btn_rev,btnStr_Brd,btnStp_Brd,pod,back;
    SendBroadcast send;
    DhcpInfo d;
    WifiManager wifi;
    String cip = null;
    String bip=null;
    String[] bip1=null;



    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_player);
        btn_ffd = (Button) findViewById(R.id.ffd);
        btn_rrd = (Button) findViewById(R.id.rrd);
        btn_nxt = (Button) findViewById(R.id.nxt_song);
        btn_rev = (Button) findViewById(R.id.pre_song);
        btnStr_Brd = (Button) findViewById(R.id.StartBrd);
        btnStp_Brd = (Button) findViewById(R.id.StopBrd);
        pod = (Button) findViewById(R.id.pod);
        local = (TextView) findViewById(R.id.localip);
        BroadcastIp = (TextView) findViewById(R.id.BroadcastIp);
        back = (Button) findViewById(R.id.back);

        send = new SendBroadcast();
        try {
            Intent i = getIntent();
            final Bundle b = i.getExtras();
            final ArrayList<File> mySongs = (ArrayList) b.getParcelableArrayList("song");
            position = b.getInt("pos", 0);
            // mp.stop();
            //mp.release();
            final Uri[] uri = {Uri.parse(mySongs.get(position).toString())};
            mp = MediaPlayer.create(getApplicationContext(), uri[0]);

            mp.start();
            bu_stop = (Button) findViewById(R.id.stop);
            bu_stop.setOnClickListener(new View.OnClickListener() {
                @Override
                public void onClick(View v) {
                    if (mp.isPlaying()) {
                        bu_stop.setText("play");
                        mp.pause();
                        length = mp.getCurrentPosition();
                    } else if (!mp.isPlaying()) {
                        bu_stop.setText("stop");
                        mp.start();
                        mp.seekTo(length);
                    }
                }
            });
            btn_ffd.setOnClickListener(new View.OnClickListener() {
                @Override
                public void onClick(View v) {
                    mp.seekTo(mp.getCurrentPosition() + 5000);

                }
            });
            btn_rrd.setOnClickListener(new View.OnClickListener() {
                @Override
                public void onClick(View v) {
                    mp.seekTo(mp.getCurrentPosition() - 5000);
                }
            });

            btn_nxt.setOnClickListener(new View.OnClickListener() {
                @Override
                public void onClick(View v) {
                    mp.stop();
                    mp.release();
                    position = (position + 1) % mySongs.size();
                    uri[0] = Uri.parse(mySongs.get(position).toString());
                    mp = MediaPlayer.create(getApplicationContext(), uri[0]);
                    mp.start();

                }
            });
            btn_rev.setOnClickListener(new View.OnClickListener() {
                @Override
                public void onClick(View v) {
                    mp.stop();
                    mp.release();
                    position = (position - 1 < 0) ? mySongs.size() - 1 : position - 1;
                    uri[0] = Uri.parse(mySongs.get(position).toString());
                    mp = MediaPlayer.create(getApplicationContext(), uri[0]);
                    mp.start();

                }
            });
            btnStr_Brd.setOnClickListener(new View.OnClickListener() {
                @Override
                public void onClick(View v) {
                    StratBroadcast();
                }
            });
            btnStp_Brd.setOnClickListener(new View.OnClickListener() {
                @Override
                public void onClick(View v) {
                    StopBroadcast();
                }
            });
            Back();



        } catch (Exception ee)
        {
            ee.printStackTrace();
            Toast.makeText(getApplicationContext(),""+ee.getMessage(),Toast.LENGTH_SHORT).show();
        }
    }


    public void StratBroadcast()
    {
        btnStr_Brd.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                try {

                    String port = Integer.toString(50005);
                    wifi = (WifiManager) getSystemService(Context.WIFI_SERVICE);
                    d = wifi.getDhcpInfo();
                    int ip = d.ipAddress;
                    cip = Toip(ip);
                    bip1 = cip.split("\\.");
                    bip = bip1[0] + "." + bip1[1] + "." + bip1[2] + "." + Integer.toString(255);
                    local.setText(cip);
                    BroadcastIp.setText(bip);
                    send.StartBroadcast(bip, port);
                    Toast.makeText(getApplicationContext(), "Sending to :" + bip + " ", Toast.LENGTH_SHORT).show();
                    pod.setVisibility(View.VISIBLE);
                    btnStr_Brd.setEnabled(false);
                    btnStp_Brd.setEnabled(true);
                }
                catch(Exception esb)
                {
                    esb.printStackTrace();
                    Toast.makeText(getApplicationContext(),""+esb.getMessage(),Toast.LENGTH_SHORT).show();
                }



            }
        });
    }
    public String Toip(int ip)
    {
        return (ip&0xFF)+"."+
                ((ip>>8)&0xFF)+"."+
                ((ip>>16)&0xFF)+"."+
                ((ip>>24)&0xFF);
    }
    public void StopBroadcast()
    {
        btnStp_Brd.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                try {
                    send.StopBroadcast();
                    pod.setVisibility(View.GONE);
                    btnStp_Brd.setEnabled(false);
                    btnStr_Brd.setEnabled(true);
                } catch (Exception est)
                {
                    est.printStackTrace();
                    Toast.makeText(getApplicationContext(),""+est.getMessage(),Toast.LENGTH_SHORT).show();
                }

            }
        });

    }
    public void Back()
    {
        back.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                try {
                    mp.stop();
                    mp.release();
                    Intent inten = new Intent(getApplicationContext(), MainActivity.class);
                    startActivity(inten);
                }catch (Exception eb)
                {
                    eb.printStackTrace();
                    Toast.makeText(getApplicationContext(),""+eb.getMessage(),Toast.LENGTH_SHORT).show();
                }
            }
        });
    }


    @Override
    public void onRestart() {
        super.onRestart();
        Intent restart = new Intent(Player.this, Player.class);
        startActivity(restart);
        Log.d("Appliacction  :","Restarted");
        finish();
    }
}
