using System;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace SnarlNetworkProtocol
{
    class SNP
    {

        string hostName = null;
        int hostPort = 0;

        public void SnarlNetwork(string hostName, int hostPort)
        {

        }

        public SNP(string hostname, int hostport)
        {
            this.hostName = hostname;
            this.hostPort = hostport;
        }

        private static void SnarlNetwork(string hostName, int hostPort, string request)
        {
            int response = 0;
            IPAddress host = IPAddress.Parse(hostName);
            IPEndPoint hostep = new IPEndPoint(host, hostPort);
            Socket sock = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            try
            {
                sock.Connect(hostep);
                response = sock.Send(Encoding.UTF8.GetBytes(request));
                response = sock.Send(Encoding.UTF8.GetBytes("\r\n"));
                sock.Close();
            }
            catch (SocketException e)
            {
                Console.WriteLine("An error occurred when attempting to access the socket");
                Console.WriteLine(e.ToString());
                if (sock.Connected)
                    sock.Close();
            }

        }


        public bool register(string appName)
        {
            string request = "type=SNP#?version=1.0#?action=register#?app=" + appName;

            SNP.SnarlNetwork(hostName, hostPort, request);
            return true;
        }


        public bool unregister(string appName)
        {
            string request = "type=SNP#?version=1.0#?action=unregister#?app=" + appName;

            SNP.SnarlNetwork(hostName, hostPort, request);
            return true;
        }


        public bool addClass(string appName, string className, string classTitle)
        {
            string request  = "type=SNP#?version=1.0#?action=add_class#?app=" + appName + "#?class=" + className + "#?title=" + classTitle;

            SNP.SnarlNetwork(hostName, hostPort, request);
            return true;
        }


        public bool notify(string appName, string className, string title, string text, string timeout, string icon)
        {
            string request = "type=SNP#?version=1.0#?action=notification#?app=" + appName + "#?class=" + className + "#?title=" + title + "#?text=" + text + "#?timeout=" + timeout + "#?icon=" + icon;

            SNP.SnarlNetwork(hostName, hostPort, request);
            return true;
        }

    }
}
