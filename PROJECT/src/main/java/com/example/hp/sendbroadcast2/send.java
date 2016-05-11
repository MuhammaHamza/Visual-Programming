package com.example.hp.sendbroadcast2;

import java.io.IOException;
import java.net.DatagramPacket;
import java.net.DatagramSocket;
import java.net.Inet4Address;
import java.net.InetAddress;
import java.net.SocketException;
import java.net.UnknownHostException;

import android.app.Activity;
import android.media.AudioFormat;
import android.media.AudioRecord;
import android.media.AudioTrack;
import android.media.MediaRecorder;
import android.net.rtp.AudioGroup;
import android.os.Bundle;
import android.util.Log;
import android.view.View;
import android.view.View.OnClickListener;
import android.widget.Button;
import android.widget.EditText;

public class send extends Activity {
    private Button startButton,stopButton;
    private EditText ip_addr,prt;
    public byte[] buffer;

    public static DatagramSocket socket;
    private int port;

    AudioRecord recorder;
    private int sampleRate = 44100 ;
    private int channelConfig = AudioFormat.CHANNEL_IN_MONO;
    private int audioFormat = AudioFormat.ENCODING_PCM_16BIT;

    int minBufSize = AudioRecord.getMinBufferSize(sampleRate, channelConfig, audioFormat);
    private boolean status = true;

    @Override
    public void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_send);

        startButton = (Button) findViewById (R.id.start_button);
        stopButton = (Button) findViewById (R.id.stop_button);
        ip_addr=(EditText)findViewById(R.id.editText);
        prt=(EditText)findViewById(R.id.editText2);

        startButton.setOnClickListener (startListener);
        stopButton.setOnClickListener (stopListener);


    }

    private final OnClickListener stopListener = new OnClickListener() {

        @Override
        public void onClick(View arg0) {
            status = false;
            recorder.release();
            Log.d("VS","Recorder released");
        }

    };

    private final OnClickListener startListener = new OnClickListener() {

        @Override
        public void onClick(View arg0) {
            status = true;
            startStreaming();
        }

    };

    public void startStreaming() {


        Thread streamThread = new Thread(new Runnable() {

            @Override
            public void run() {
                try {
                    String ip=ip_addr.getText().toString();
                    String prt1=prt.getText().toString();
                    port=Integer.parseInt(prt1);
                    recorder = new AudioRecord(MediaRecorder.AudioSource.MIC,sampleRate,channelConfig,audioFormat,minBufSize*10);
                    Log.d("VS", "Recorder initialized");
                    DatagramSocket socket = new DatagramSocket();
                    Log.d("VS", "Socket Created");
                    byte[] buffer = new byte[minBufSize];
                    Log.d("VS","Buffer created of size " + minBufSize);
                    DatagramPacket packet;
                   final InetAddress destination = InetAddress.getByName(ip);
                    Log.d("VS", "Address retrieved");

                    recorder.startRecording();
                    while(status == true) {
                        socket.setBroadcast(true);
                        //reading data from MIC into buffer
                        minBufSize = recorder.read(buffer, 0, buffer.length);
                        packet = new DatagramPacket (buffer,buffer.length,destination,port);
                        socket.send(packet);
                        System.out.println("MinBufferSize: " +minBufSize);
                    }
                }
                catch (SocketException e) {
                    e.printStackTrace();
                }
                catch(UnknownHostException e)
                {
                    Log.e("VS", "UnknownHostException");
                }
                catch (IOException e)
                {
                    e.printStackTrace();
                    Log.e("VS", "IOException");
                }
            }

        });
        streamThread.start();
    }
}