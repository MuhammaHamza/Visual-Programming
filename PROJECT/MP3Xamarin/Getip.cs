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
using Android.Net.Wifi;
using Android.Net;
namespace Mp3layerFinal
{
    [Activity(Label = "Getip")]
    public class Getip : Activity
    {

        WifiManager wifi;
        DhcpInfo dhcp;
        string ip,broadcast;
        string[] bcast;
        protected override void OnCreate(Bundle savedInstanceState) 
        {
            base.OnCreate(savedInstanceState);

            // Create your application here
        }
        public string getip()
        {
            wifi = (WifiManager)GetSystemService(Context.WifiService);
            dhcp = wifi.DhcpInfo;
            ip = Convert.ToString(dhcp.IpAddress);
            bcast = ip.Split('.');
            broadcast = broadcast[0] + "." + broadcast[1] + "." + broadcast[2] + "." + Convert.ToString(255);
            return broadcast;  
        }

    }
}