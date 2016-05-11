using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Net.Sockets;
using System.Net;

namespace ConsoleApplication2
{
    class Program
    {
        public static void Main(string[] args)
        {
            try
            {
                UdpClient ud;
                Socket s = new Socket(AddressFamily.InterNetwork, SocketType.Dgram,
               ProtocolType.Udp);

                IPAddress broadcast = IPAddress.Parse("192.168.0.255");
                byte[] sendbuf = Encoding.ASCII.GetBytes("foo  barrr hello ");
                IPEndPoint ep = new IPEndPoint(broadcast, 11000);
                // s.SendTo(sendbuf, ep);

                string _FileName = "G:\\SONGS\\jc.mp3";
                byte[] p;
                p = File.ReadAllBytes(_FileName);
                byte[] Stm = StereoToMono(p);
                for (int i = 0; i < Stm.Length; i++)
                {
                    // Console.Out.WriteLine(Stm[i]);
                    s.SendTo(Stm, ep);

                }

                Console.WriteLine("Message sent to the broadcast address");
                Console.ReadKey();
                
            }catch(SocketException ee)
            {
                Console.WriteLine(ee.Message+"\n"+ee.StackTrace+"\n"+ee.Source);
            }
            finally
            {
                Console.ReadKey();
            }
        }
        public static byte[] StereoToMono(byte[] input)
        {
            byte[] output = new byte[input.Length / 2];
            int outputIndex = 0;
            try
            {
                for (int n = 0; n < input.Length; n += 4)
                {
                    // copy in the first 16 bit sample
                    output[outputIndex++] = input[n];
                    output[outputIndex++] = input[n + 1];

                }
            }
            catch (Exception e)
            { return output; }
            return output;
        }


        private byte[] MonoToStereo(byte[] input)
        {
            byte[] output = new byte[input.Length * 2];
            int outputIndex = 0;
            try
            {
                for (int n = 0; n < input.Length; n += 2)
                {
                    // copy in the first 16 bit sample
                    output[outputIndex++] = input[n];
                    output[outputIndex++] = input[n + 1];
                    // now copy it in again
                    output[outputIndex++] = input[n];
                    output[outputIndex++] = input[n + 1];
                }
            }
            catch (Exception e)
            { return output; }
            return output;
        }


    }
}
