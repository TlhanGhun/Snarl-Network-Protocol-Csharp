using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace FileSystemSnarl.SnarlNetwork
{
    class SnarlNetwork
    {
        int response = 0;


        public SnarlNetwork(string hostName, int hostPort)
        {

        }

        public bool register(string hostName, int hostPort, string appName)
        {
            IPAddress host = IPAddress.Parse(hostName);
            IPEndPoint hostep = new IPEndPoint(host, hostPort);
            Socket sock = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            try
            {
                sock.Connect(hostep);
                response = sock.Send(Encoding.ASCII.GetBytes("type=SNP#?version=1.0#?action=register#?app=" + appName));
                response = sock.Send(Encoding.ASCII.GetBytes("\r\n"));
                sock.Close();
            }
            catch (SocketException e)
            {
                Console.WriteLine("Problem connecting to host");
                Console.WriteLine(e.ToString());
                sock.Close();
            }
            return true;
        }

        public bool unregister(string hostName, int hostPort,string appName)
        {
            IPAddress host = IPAddress.Parse(hostName);
            IPEndPoint hostep = new IPEndPoint(host, hostPort);
            Socket sock = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            try
            {
                sock.Connect(hostep);
                response = sock.Send(Encoding.ASCII.GetBytes("type=SNP#?version=1.0#?action=unregister#?app=" + appName));
                response = sock.Send(Encoding.ASCII.GetBytes("\r\n"));
                sock.Close();
            }
            catch (SocketException e)
            {
                Console.WriteLine("Problem connecting to host");
                Console.WriteLine(e.ToString());
                if (sock.Connected)
                {
                    sock.Close();
                }
            }
            return true;
        }

        public bool addClass(string hostName, int hostPort, string appName, string className, string classTitle)
        {
            IPAddress host = IPAddress.Parse(hostName);
            IPEndPoint hostep = new IPEndPoint(host, hostPort);
            Socket sock = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            try
            {
                sock.Connect(hostep);
            }
            catch (SocketException e)
            {
                Console.WriteLine("Problem connecting to host");
                Console.WriteLine(e.ToString());
                if (sock.Connected)
                {
                    sock.Close();
                }
            }
            try {
                response = sock.Send(Encoding.ASCII.GetBytes("type=SNP#?version=1.0#?action=add_class#?app=" + appName + "#?class=" + className + "#?title=" + classTitle));
                response = sock.Send(Encoding.ASCII.GetBytes("\r\n"));
            }
            catch (SocketException e)
            {
                Console.WriteLine(e.ToString());
            }
            sock.Close();
            return true;
        }

        public bool notify(string hostName, int hostPort, string appName, string className, string title, string text, string timeout)
        {
            IPAddress host = IPAddress.Parse(hostName);
            IPEndPoint hostep = new IPEndPoint(host, hostPort);
            Socket sock = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            try
            {
                sock.Connect(hostep);
                response = sock.Send(Encoding.ASCII.GetBytes("type=SNP#?version=1.0#?action=notification#?app=" + appName + "#?class=" + className + "#?title=" + title + "#?text=" + text + "#?timeout=" + timeout));
                response = sock.Send(Encoding.ASCII.GetBytes("\r\n"));
                sock.Close();
            }
            catch (SocketException e)
            {
                Console.WriteLine("Problem connecting to host");
                Console.WriteLine(e.ToString());
                if (sock.Connected)
                {
                    sock.Close();
                }
            }
            return true;
        }

    }
}
