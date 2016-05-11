package com.example.hp.rtpreciever;

import android.media.MediaPlayer;
import android.net.DhcpInfo;
import android.net.wifi.WifiManager;
import android.net.wifi.p2p.WifiP2pManager;
import android.support.v7.app.AppCompatActivity;


import android.content.Context;
import android.media.AudioManager;
import android.net.rtp.AudioCodec;
import android.net.rtp.AudioGroup;
import android.net.rtp.AudioStream;
import android.net.rtp.RtpStream;
import android.os.Bundle;
import android.os.StrictMode;
import android.util.Log;
import android.widget.EditText;
import android.widget.TextView;

import java.io.IOException;
import java.net.InetAddress;
import java.net.NetworkInterface;
import java.net.SocketException;
import java.net.UnknownHostException;
import java.util.Enumeration;

public class MainActivity extends AppCompatActivity implements Runnable{
public TextView txt1,txt2;
    DhcpInfo d;
    WifiManager wifi;
   public String Broadcast,cip;
    public MediaPlayer mp;
    private boolean realized = false;
    private boolean configured = false;
    private String ipAddress;
    public EditText ed1,ed2;

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_main);
        StrictMode.ThreadPolicy policy = new StrictMode.ThreadPolicy.Builder().permitAll().build();
        StrictMode.setThreadPolicy(policy);
        txt1=(TextView)findViewById(R.id.textView2);

        ed1=(EditText)findViewById(R.id.ipaddr);
        ed1.setText("192.168.43.104");

        wifi=(WifiManager)getSystemService(Context.WIFI_SERVICE);
        d=wifi.getDhcpInfo();
        int ip=d.ipAddress;
        cip=Toip(ip);
        txt1.setText(cip);
        /*mp=MediaPlayer.create(this,R.raw.wwb);
        mp.setLooping(true);
        mp.setVolume(10000f,10000f);
        mp.start();*/
        // String[] splitip=cip.split("\\.");
       // InetAddress Remote= null;
        //new Thread(() -> execute("192.168.0.3")).start();
        Runnable r2=new Runnable() {
            @Override
            public void run() {
                String ipadd=ed1.getText().toString();

                execute(cip,ipadd,22222);
            }
        };
        Thread th2=new Thread(r2);
        th2.start();

       /* Runnable r1=new Runnable() {
            @Override
            public void run() {
                execute(cip,"192.168.0.5",6000);
            }
        };
        Thread t1=new Thread(r1);
        t1.start();*/

        }



       // execute("192.168.0.2");

       /*
            count++;
            for(int i=0;i<=255;i++)
        {
            Broadcast=splitip[0]+"."+splitip[1]+"."+splitip[2]+"."+i;
            if(count==7)
                return;
            try {
                InetAddress Remote=InetAddress.getByName(Broadcast);
                if(Remote.isReachable(5000))
                {
                    Log.d("Reachable " ,Broadcast);

                }
            } catch (UnknownHostException e) {
                e.printStackTrace();
            } catch (IOException e) {
                e.printStackTrace();
            }
        }*/


    public String Toip(int ip)
    {
     return (ip&0xFF)+"."+
             ((ip>>8)&0xFF)+"."+
             ((ip>>16)&0xFF)+"."+
             ((ip>>24)&0xFF);
    }
    public void execute(String cip,String stat,int port)
    {
        try {
            AudioManager audio =  (AudioManager) getSystemService(Context.AUDIO_SERVICE);
            audio.setMode(AudioManager.MODE_IN_COMMUNICATION);
            audio.setSpeakerphoneOn(true);
            AudioGroup audioGroup = new AudioGroup();
            audioGroup.setMode(AudioGroup.MODE_ECHO_SUPPRESSION);
            InetAddress local=InetAddress.getByName(cip);
            AudioStream audioStream = new AudioStream(local);
            audioStream.setCodec(AudioCodec.PCMU);
            audioStream.setMode(RtpStream.MODE_NORMAL);
            InetAddress remote=InetAddress.getByName(stat);
            audioStream.associate(remote,port);
            audioStream.join(audioGroup);



        } catch (Exception e) {
            Log.e("----------------------", e.toString());
            e.printStackTrace();
        }
    }

    @Override
    public void run() {

    }
}
