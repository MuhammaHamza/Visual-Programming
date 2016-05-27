using System;
using Android.App;
using Android.Widget;
using Android.OS;
using Java.IO;
using Java.Util;
using Android.Content;

namespace Mp3layerFinal
{
    [Activity(Label = "Mp3layerFinal", MainLauncher = true, Icon = "@drawable/icon")]
    public class MainActivity : Activity
    {
        ListView lv;
        String[] items;
        int count = 1;
        ArrayList songs;

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);
            lv = FindViewById<ListView>(Resource.Id.listView1);
            songs = findsongs(Android.OS.Environment.ExternalStorageDirectory);
            items = new String[songs.Size()];
            for (int i = 0; i < songs.Size(); i++)
            {
                toast(songs.Get(i).ToString());
                items[i] = songs.Get(i).ToString().Replace(".mp3", "").Replace(".wav", "");
            }
            ArrayAdapter<string> adp = new ArrayAdapter<string>(this, Resource.Layout.layout, Resource.Id.textView1, items);
            lv.Adapter=adp;
            lv.ItemClick += Lv_ItemClick;

        }

        private void Lv_ItemClick(object sender, AdapterView.ItemClickEventArgs e)
        {
            var intent = new Intent(this,typeof(mp3playercontrols));
            intent.PutExtra("pos", e.Position);
            intent.PutExtra("song", songs);
            StartActivity(intent );
            
        }

        public ArrayList findsongs(File root)
        {
            ArrayList al = new ArrayList();
            File[] files = root.ListFiles();
            foreach (File singlefile in files)
            {
                if (singlefile.IsDirectory && !singlefile.IsHidden)
                {
                    al.Add(findsongs(singlefile));
                }
                else
                {
                    if (singlefile.Name.EndsWith(".mp3"))
                        al.Add(singlefile);
                }
            }
            return al;
        }


        public void toast(String text)
        {
            Toast.MakeText(this, text, ToastLength.Short);
        }
    }
}


     