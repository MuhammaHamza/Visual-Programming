using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Java.Net;
using Android.Media;

namespace Mp3layerFinal
{
    class SendBroadcast
    {
        public byte[] buffer { get; set; }
        public static DatagramSocket socket;
        private int port { get; set; }
        AudioRecord recorder; 
        private int sampleRate = 44100;
        ChannelIn chanel = ChannelIn.Mono;
        Android.Media.Encoding encode = Android.Media.Encoding.Pcm16bit;
        int buffersize { get; set; }
        private Boolean status = true;
        public void startBroascast(Context context, String Ip, int port)
        {
            try
            {
                buffersize = AudioRecord.GetMinBufferSize(sampleRate, chanel, encode);
                recorder = new AudioRecord(AudioSource.Mic, sampleRate, chanel, encode, buffersize * 10);
                DatagramSocket socket = new DatagramSocket();
                buffer = new byte[buffersize];
                DatagramPacket packet;
                InetAddress destination = InetAddress.GetByName(Ip);
                recorder.StartRecording();
                while (status == true)
                {
                    socket.Broadcast = true;
                    //reading data from MIC into buffer
                    buffersize = recorder.Read(buffer, 0, buffer.Length);
                    packet = new DatagramPacket(buffer, buffersize, destination, port);
                    socket.Send(packet);


                }
            }
            catch (Exception ee)
            {
                Toast.MakeText(context, ee.Source + "\n" + ee.StackTrace, ToastLength.Short).Show();
            }
        }



        public void stopBroadcat()
        {
             
            status = false;
            recorder.Release();    
        
    }
    }
}