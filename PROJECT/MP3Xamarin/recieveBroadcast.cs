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
using Java.IO;
using Java.Net;
using Android.Media;
using Android.Util;

namespace Mp3layerFinal
{
    class recieveBroadcast
    {

        public static DatagramSocket socket { get; set; }
        AudioFormat audioFormt;
        private AudioTrack speaker;        
        int[] sampleRates { get; set; }
        Android.Media.Encoding[] encodings ;
        ChannelIn[] channelConfigs;
        private Boolean status = true;
        ChannelConfiguration chanel = ChannelConfiguration.Mono;


         public recieveBroadcast()
        {
            sampleRates = new int[] { 44100, 22050, 11025, 8000 };
            channelConfigs = new ChannelIn[] { ChannelIn.Mono, ChannelIn.Stereo };
            encodings = new Android.Media.Encoding[] { Android.Media.Encoding.Pcm8bit, Android.Media.Encoding.Pcm16bit };
        }
        public void StartRecieving(int PortNum)
        {
           
            socket = new DatagramSocket(PortNum);
            Byte[] buffer = new Byte[256];


            foreach (int sampleRate in sampleRates)
            {
                foreach (Android.Media.Encoding encoding in encodings)
                {
                    foreach (ChannelIn channelConfig in channelConfigs)
                    {
                        int bufferSize = AudioRecord.GetMinBufferSize(sampleRate, channelConfig, encoding);
                        speaker = new AudioTrack(Stream.Music, sampleRate, chanel, encoding, bufferSize,AudioTrackMode.Stream);
                        speaker.Play();
                        while (status == true)
                            try
                            {
                                DatagramPacket packet = new DatagramPacket(buffer, buffer.Length);
                                socket.Receive(packet);
                                buffer = packet.GetData();
                                speaker.Write(buffer, 0, bufferSize);
                            }
                            catch (IOException ie)
                            {
                                ie.PrintStackTrace();
                               Log.Debug(""+ ie.Source,"");
                            }


                    }
                }
            }

        }


        public void Stoprecieving()
        {
            status = false;
            speaker.Release();
        }
    }
}