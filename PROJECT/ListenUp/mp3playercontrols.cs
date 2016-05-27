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
using Android.Media;
using Java.Util;
using Android.Net.Wifi;
using Android.Net;
using Java.Net;

namespace Mp3layerFinal
{
    [Activity(Label = "mp3playercontrols")]
    public class mp3playercontrols : Activity
    {
        MediaPlayer mp;
        Button startbr, stopbr, next, previous, ffw, rrw, play_stop,back;
        int position { get; set; }
        Android.Net.Uri uri;
        int length { get; set; }
        string local { get; set; }
        string broadcast { get; set; }
        ArrayList songs;
        SendBroadcast send;
        TextView localip,broadcastip;      
        Getip gip;
       string iprecieved { get; set; }
        int portNum { get; set; }


        WifiManager wifii;
        DhcpInfo d;
        string[] bcast;


        string ip;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            try {
                base.OnCreate(savedInstanceState);
                SetContentView(Resource.Layout.Mp3PlayerControls);
                // Create your application here
                startbr = FindViewById<Button>(Resource.Id.startbr);
                stopbr = FindViewById<Button>(Resource.Id.stopbr);
                ffw = FindViewById<Button>(Resource.Id.ffw);
                rrw = FindViewById<Button>(Resource.Id.rrw);
                next = FindViewById<Button>(Resource.Id.next);
                previous = FindViewById<Button>(Resource.Id.previous);
                play_stop = FindViewById<Button>(Resource.Id.play_stop);
                localip = FindViewById<TextView>(Resource.Id.localIp);
                broadcastip = FindViewById<TextView>(Resource.Id.broadcastIp);
                back = FindViewById<Button>(Resource.Id.back);
                portNum = 50005;

                wifii = (WifiManager)GetSystemService(Context.WifiService);
                d = wifii.DhcpInfo;
                ip = Convert.ToString(IntToIp(d.IpAddress));


                bcast = ip.Split('.');
                broadcast = bcast[0] + "." + bcast[1] + "." + bcast[2] + "." + Convert.ToString(255);



                ffw.Click += Ffw_Click;
                rrw.Click += Rrw_Click;
                next.Click += Next_Click;
                previous.Click += Previous_Click;
                play_stop.Click += Play_stop_Click;
                startbr.Click += Startbr_Click;
                stopbr.Click += Stopbr_Click;
                back.Click += Back_Click;


                // Assign to TextViev (localip)
                localip.Text = ip.ToString();                               // get Broadcast ip from Getip Class
                broadcastip.Text = broadcast.ToString();                       // ASSign To TextView Broadcast ip 

                //   Intent inten;
                //  ArrayList songs = Intent.g

            }
            catch (Exception e)
            { Toast.MakeText(this, e.StackTrace,ToastLength.Short).Show(); }
            }

        private void Back_Click(object sender, EventArgs e)
        {
            try {
                var backIntent = new Intent(this, typeof(MainActivity));
                StartActivity(backIntent);
            }
            catch (Exception e1)
            { Toast.MakeText(this, e1.StackTrace, ToastLength.Short).Show(); }

        }

        private void Stopbr_Click(object sender, EventArgs e)
        {
            try {
                send = new SendBroadcast();
                send.stopBroadcat();
                stopbr.Enabled = false;
                startbr.Enabled = true;
            }
            catch (Exception e2)
            { Toast.MakeText(this, e2.StackTrace, ToastLength.Short).Show(); }
        }                  // Stop Brodcast Button delegate

        private void Startbr_Click(object sender, EventArgs e)
        {
            try {
                send = new SendBroadcast();

                send.startBroascast(ApplicationContext, broadcast, portNum);
                startbr.Enabled = false;
                stopbr.Enabled = true;
            }
            catch (Exception e3)
            { Toast.MakeText(this, e3.StackTrace, ToastLength.Short).Show(); }
        }                  // start Broadcast  Button Delegate

        private void Play_stop_Click(object sender, EventArgs e)
        {
            try
            {
                if (mp.IsPlaying)
                {
                    play_stop.Text = "Play";
                    mp.Pause();
                    length = mp.CurrentPosition;
                }
                else if (!mp.IsPlaying)
                {
                    play_stop.Text = "Stop";
                    mp.Start();
                    mp.SeekTo(length);
                }
            }
            catch (Exception e4)
            { Toast.MakeText(this, e4.StackTrace, ToastLength.Short).Show(); }

        }               //  PLAY /STOP Button Delegate

        private void Previous_Click(object sender, EventArgs e)
        {
            try {
                mp.Stop();
                mp.Release();
                position = (position - 1 < 0) ? songs.Size() - 1 : position - 1;
                uri = Android.Net.Uri.Parse(songs.Get(position).ToString());
                mp = MediaPlayer.Create(ApplicationContext, uri);
                mp.Start();
            }
            catch (Exception e5)
            { Toast.MakeText(this, e5.StackTrace, ToastLength.Short).Show(); }
        }                 //Previous Button delegate

        private void Next_Click(object sender, EventArgs e)
        {
            try {
                mp.Stop();
                mp.Release();
                position = (position + 1) % songs.Size();
                uri = Android.Net.Uri.Parse(songs.Get(position).ToString());
                mp = MediaPlayer.Create(ApplicationContext, uri);
                mp.Start();
            }
            catch (Exception e6)
            { Toast.MakeText(this, e6.StackTrace, ToastLength.Short).Show(); }
        }                    //Next Button delegate

        private void Rrw_Click(object sender, EventArgs e)
        {
            try {
                mp.SeekTo(mp.CurrentPosition - 5000);
            }
            catch (Exception e7)
            { Toast.MakeText(this, e7.StackTrace, ToastLength.Short).Show(); }
        }                        //Rewind Button delegate

        public string IntToIp(int ip)
        {
            return
                (ip & 0xFF) + "." +
                ((ip >> 8) & 0xFF) + "." +
                ((ip >> 16) & 0xFF) + "." +
                ((ip >> 24) & 0xFF);


        }
        private void Ffw_Click(object sender, EventArgs e)
        {
            try {
                mp.SeekTo(mp.CurrentPosition + 5000);
            }
            catch (Exception e8)
            { Toast.MakeText(this, e8.StackTrace, ToastLength.Short).Show(); }

        }                       //FastForward Button delegate
    }
}