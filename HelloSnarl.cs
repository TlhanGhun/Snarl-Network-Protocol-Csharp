/*This is a basic example on how to use Snarl C# API to send notification to Snarl.
  Tested on versions<2.5 and R3.0 beta.*/

using SnarlNetworkProtocol;
using System;

class HelloSnarl
{
    public static void Main(String[] args)
    {
        string hostname = "127.0.0.1";
        int hostport = 9887;
        string appName = "HelloSnarlApp";
        string icon = "http://a0.twimg.com/profile_images/1100695109/snarl_logo_2008a_normal.png";
        string title = "Notification from";
        string message = "HelloSnarl";
        string timeout = "5";

        SNP snarl_object = new SNP(hostname, hostport);

        if (snarl_object.isSnarlRunning())
        {
            Console.WriteLine("Yes snarl is running");

            snarl_object.register(appName);
            snarl_object.notify(appName, null, title, message, timeout, icon);

            /*According to Snarl Developer Guide "When your application exits, it should unregister with Snarl."
              If you want you can remove snarl_object.unregister because when you
              quit snarl it will automatically unregister your application.*/

            snarl_object.unregister(appName);
        }
        else
            Console.WriteLine("Snarl not running");



    }

}

