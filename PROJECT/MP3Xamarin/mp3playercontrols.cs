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

namespace Mp3layerFinal
{
    [Activity(Label = "mp3playercontrols")]
    public class mp3playercontrols : Activity
    {
        MediaPlayer mp;
        Button startbr, stopbr, startrc, stoprc, next, previous, ffw, rrw, play_stop;
        int position { get; set; }
        Android.Net.Uri uri;
        int length { get; set; }
        ArrayList songs;
        SendBroadcast send;
        recieveBroadcast recieve;
        Getip gip;
       string iprecieved { get; set; }
        int portNum { get; set; }
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.Mp3PlayerControls);
            // Create your application here
            startbr = FindViewById<Button>(Resource.Id.startbr);
            stopbr = FindViewById<Button>(Resource.Id.stopbr);
            startrc = FindViewById<Button>(Resource.Id.startrc);
            stoprc = FindViewById<Button>(Resource.Id.stoprc);
            ffw = FindViewById<Button>(Resource.Id.ffw);
            rrw = FindViewById<Button>(Resource.Id.rrw);
            next = FindViewById<Button>(Resource.Id.next);
            previous = FindViewById<Button>(Resource.Id.previous);
            play_stop = FindViewById<Button>(Resource.Id.play_stop);
            portNum = 16388;
            recieve = new recieveBroadcast();

            ffw.Click += Ffw_Click;
            rrw.Click += Rrw_Click;
            next.Click += Next_Click;
            previous.Click += Previous_Click;
            play_stop.Click += Play_stop_Click;
            startbr.Click += Startbr_Click;
            stopbr.Click += Stopbr_Click;
            startrc.Click += Startrc_Click;
            stoprc.Click += Stoprc_Click;

         //   Intent inten;
          //  ArrayList songs = Intent.g

        }

        private void Stoprc_Click(object sender, EventArgs e)
        {
            recieve.Stoprecieving();
            throw new NotImplementedException();
        }

        private void Startrc_Click(object sender, EventArgs e)
        {
            recieve.StartRecieving(portNum);
            throw new NotImplementedException();
        }

        private void Stopbr_Click(object sender, EventArgs e)
        {
            send = new SendBroadcast();
            send.stopBroadcat();           
            throw new NotImplementedException();
        }

        private void Startbr_Click(object sender, EventArgs e)
        {
            send = new SendBroadcast();
            gip = new Getip();
            iprecieved = gip.getip();
            send.startBroascast(ApplicationContext,iprecieved,portNum);
            throw new NotImplementedException();
        }

        private void Play_stop_Click(object sender, EventArgs e)
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
                throw new NotImplementedException();
        }

        private void Previous_Click(object sender, EventArgs e)
        {
            mp.Stop();
            mp.Release();
            position = (position - 1 < 0) ? songs.Size() - 1 : position - 1;
            uri = Android.Net.Uri.Parse(songs.Get(position).ToString());
            mp = MediaPlayer.Create(ApplicationContext, uri);
            mp.Start();
            throw new NotImplementedException();
        }

        private void Next_Click(object sender, EventArgs e)
        {
            mp.Stop();
            mp.Release();
            position = (position + 1) % songs.Size();
            uri = Android.Net.Uri.Parse(songs.Get(position).ToString());
            mp = MediaPlayer.Create(ApplicationContext, uri);
            mp.Start();
            throw new NotImplementedException();
        }

        private void Rrw_Click(object sender, EventArgs e)
        {
            mp.SeekTo(mp.CurrentPosition - 5000);
            throw new NotImplementedException();
        }

        private void Ffw_Click(object sender, EventArgs e)
        {
            mp.SeekTo(mp.CurrentPosition + 5000);
            throw new NotImplementedException();
        }
    }
}