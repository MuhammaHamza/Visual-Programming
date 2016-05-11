package com.example.hp.sendbroadcast;

import android.media.AudioFormat;
import android.media.AudioRecord;
import android.media.MediaRecorder;
import android.os.Build;
import android.os.StrictMode;
import android.support.v7.app.AppCompatActivity;
import android.os.Bundle;
import android.util.Log;
import android.view.View;
import android.widget.Button;
import android.widget.EditText;

import java.io.ByteArrayOutputStream;
import java.io.FileInputStream;
import java.io.IOException;
import java.io.InputStream;
import java.net.DatagramPacket;
import java.net.DatagramSocket;
import java.net.InetAddress;
import java.net.Socket;
import java.net.SocketException;
import java.net.UnknownHostException;

public class Broadcast extends AppCompatActivity {
    public EditText ipAd,prt;
    public Button bu_Start,bu_Stop;
    public byte[] buffer;
    public static DatagramSocket socket;
    public int port;
    AudioRecord record;
    int sampleRate=11025;
    int channelConfig= AudioFormat.CHANNEL_IN_MONO;
    int audioformat=AudioFormat.ENCODING_PCM_16BIT;
    public  boolean state;


    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_broadcast);
        try {
           // byteconversion(R.raw.s1);
            sendMusic(R.raw.s1);
        } catch (IOException e) {
            e.printStackTrace();
        }
        if(Build.VERSION.SDK_INT >9)
        {
            StrictMode.ThreadPolicy Policy=new StrictMode.ThreadPolicy.Builder().permitAll().build();
            StrictMode.setThreadPolicy(Policy);
        }
        ipAd=(EditText)findViewById(R.id.editText);
        prt=(EditText)findViewById(R.id.editText2);
        bu_Start=(Button)findViewById(R.id.button);
        bu_Stop=(Button)findViewById(R.id.button2);
        bu_Start.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                state=true;
                startBroadcast();
                Log.d("Recorder :","Started");
            }
        });
        bu_Stop.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                record.release();
                Log.d("Recorder :", "Stoped");
            }
        });
    }
    public void startBroadcast()
    {
        Thread streamThread=new Thread(new Runnable() {
        @Override
        public void run() {
            try{
                int bufsize=AudioRecord.getMinBufferSize(sampleRate,channelConfig,audioformat);
                DatagramSocket sok1=new DatagramSocket();
                Log.d("Socket :","Created"); //Check Wether Socket is created or Not
                byte[] buff1=new byte[512];
                Log.d("Bufer :","Created");        //Check Bufer full or not
                DatagramPacket pack1;
                InetAddress dest1=InetAddress.getByName(ipAd.getText().toString());
                if(bufsize!=AudioRecord.ERROR_BAD_VALUE)
                {
                    record=new AudioRecord(MediaRecorder.AudioSource.DEFAULT,sampleRate,channelConfig,audioformat,bufsize);
                    Log.d("Recorder :","Created");      //Mic Start ya nae
                }
                if(record.getState()==AudioRecord.STATE_INITIALIZED)
                    record.startRecording();
                while (state==true)
                {
                    bufsize=record.read(buff1,0,buff1.length);
                    //Log.d("");
                    port=Integer.parseInt(prt.getText().toString());
                    pack1=new DatagramPacket(buff1,buff1.length,dest1,port);
                    sok1.send(pack1);
                }

            } catch (SocketException e) {
                e.printStackTrace();
            } catch (UnknownHostException e) {
                e.printStackTrace();
            } catch (IOException e) {
                e.printStackTrace();
            }
        }
    });
        streamThread.start();
    }
    public byte[] byteconversion(int resid) throws IOException {

        InputStream f1=(getResources().openRawResource(resid));
        ByteArrayOutputStream bos = new ByteArrayOutputStream();
        byte[] b = new byte[1024];

        for (int readNum; (readNum = f1.read(b)) != -1;) {
            bos.write(b, 0, readNum);
        }

        byte[] bytes = bos.toByteArray();

        Log.d("File :", "Converted");
        return bytes;

    }

    public void sendMusic(final int Resid) throws IOException {
        Thread musicThread=new Thread(new Runnable() {
            @Override
            public void run() {
                DatagramPacket pack2;
                // InetAddress dest1=InetAddress.getByName(ipAd.getText().toString());
                //String getip=ipAd.getText().toString();
                String getip="192.168.1.0";
                String[] Sip=getip.split("\\.");
                String Broadcastip=null;
                InetAddress dest1 = null;
                byte[] EncodedMusic;
                try {
                EncodedMusic = byteconversion(Resid);
                Log.d(EncodedMusic.toString(),"Data");
                DatagramSocket sock2 = null;
                for (int i=0;i<=2;i++ )
                {
                    Broadcastip=Sip[0]+"."+Sip[1]+"."+Sip[2]+"."+i;

                        sock2 = new DatagramSocket();
                        dest1 = InetAddress.getByName(Broadcastip);
                      //  port=Integer.parseInt(prt.getText().toString());
                        port = 8080;
                        pack2 = new DatagramPacket(EncodedMusic, EncodedMusic.length, dest1, port+(2*i));
                        Log.d("Static Music :", "Sent"+i+"");
                        sock2.send(pack2);
                        Log.d("Packet :","Sent"+i+"");
                    }
                }
                catch (UnknownHostException e) {
                    e.printStackTrace();
                } catch (SocketException e) {
                    e.printStackTrace();
                } catch (IOException e) {
                    e.printStackTrace();
                }
            }
        });
      musicThread.start();
    }



}
