using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;


namespace Demo_Server
{
    class Server
    {
        public static Socket server;
        private static Socket client;

        public static void Start()
        {
            try
            {
                if (server != null && server.Connected)
                    server.Disconnect(false);

                server = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                EndPoint endPoint = new IPEndPoint(IPAddress.Any, 4242);

                server.Bind(endPoint);
                server.Listen(100);

                Log("Server started!");

                while (true)
                {
                    client = server.Accept();
                    new HandleClient(client);
                }

            }
            catch (Exception ex)
            {
                Log(ex.Message);
            }
        }
        


        public static void Log(string info)
        {
            Console.WriteLine("[" + DateTime.Now.ToLongTimeString() + "] " + info);
        }
    }
}
