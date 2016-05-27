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
            wifi = (WifiManager)GetSystemService(Context.WifiService);

            // Create your application here
            getlocalip();
            broadcastip();
        }
        public string getlocalip()
        {
            dhcp = wifi.DhcpInfo;
            ip = IntToIp(dhcp.IpAddress);
            return ip;  
        }

        public string broadcastip()
        {
            dhcp = wifi.DhcpInfo;
            ip = IntToIp(dhcp.IpAddress);
            bcast = ip.Split('.');
            broadcast = broadcast[0] + "." + broadcast[1] + "." + broadcast[2] + "." + Convert.ToString(255);
            return broadcast;
        }

        public string IntToIp(int ip)
        {
            return
                (ip & 0xFF) + "." +
                ((ip >> 8) & 0xFF) + "." +
                ((ip >> 16) & 0xFF) + "." +
                ((ip >> 24) & 0xFF);


        }

    }
}