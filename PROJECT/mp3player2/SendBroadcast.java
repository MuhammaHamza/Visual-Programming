package com.example.hp.mp3player2;

import android.media.AudioFormat;
import android.media.AudioRecord;
import android.media.MediaRecorder;
import android.util.Log;
import android.widget.Toast;

import java.io.IOException;
import java.net.DatagramPacket;
import java.net.DatagramSocket;
import java.net.InetAddress;
import java.net.SocketException;
import java.net.UnknownHostException;

/**
 * Created by hp on 5/16/2016.
 */
public class SendBroadcast {

    public byte[] buffer;
    public static DatagramSocket socket;
    private int port;
    AudioRecord recorder;
    private int sampleRate = 16000 ;
    private int channelConfig = AudioFormat.CHANNEL_IN_MONO;
    private int audioFormat = AudioFormat.ENCODING_PCM_16BIT;
    int minBufSize = AudioRecord.getMinBufferSize(sampleRate, channelConfig, audioFormat);
    private boolean status = true;

    public void startStreaming(final String ip, final String prt1) {


        Thread streamThread = new Thread(new Runnable() {

            @Override
            public void run() {
                try {
                    //String ip=ip_addr.getText().toString();
                    //String prt1=prt.getText().toString();
                    port=Integer.parseInt(prt1);
                    recorder = new AudioRecord(MediaRecorder.AudioSource.MIC,sampleRate,channelConfig,audioFormat,minBufSize*10);
                    DatagramSocket socket = new DatagramSocket();
                    buffer = new byte[minBufSize];
                    DatagramPacket packet;
                    final InetAddress destination = InetAddress.getByName(ip);
                    recorder.startRecording();
                    while(status == true) {
                        socket.setBroadcast(true);
                        //reading data from MIC into buffer
                        minBufSize = recorder.read(buffer, 0, buffer.length);
                        packet = new DatagramPacket (buffer,minBufSize,destination,port);
                        socket.send(packet);
                        System.out.println("MinBufferSize: " +minBufSize);
                    }
                }
                catch (SocketException e) {
                    e.printStackTrace();
                }
                catch(UnknownHostException e)
                {
                    e.printStackTrace();
                    Log.e("VS", "UnknownHostException");
                }
                catch (IOException e)
                {
                    e.printStackTrace();
                    Log.e("VS", "IOException");
                }
                catch (Exception  ee)
                {
                    ee.printStackTrace();
                    Log.e("Error","Restart");
                }
            }

        });
        streamThread.start();
    }
    public void StopBroadcast()
    {
        status = false;
        recorder.release();
        Log.d("VS", "Recorder released");
    }

    public void StartBroadcast(String Ip,String prt)
    {
        status = true;
        startStreaming(Ip,prt);
    }
}
