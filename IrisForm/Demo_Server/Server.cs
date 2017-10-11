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
        

        public void Start()
        {
            try
            {
                TcpListener serverSocket = new TcpListener(2017);
                TcpClient clientSocket = default(TcpClient);
                int counter = 0;

                serverSocket.Start();
                Log("Server started!");


                while (true)
                {
                    counter ++;
                    clientSocket = serverSocket.AcceptTcpClient();
                    Log("Client #" + counter + ": connected!");

                    HandleClient client = new HandleClient(clientSocket, Convert.ToString(counter));
                }

                clientSocket.Close();
                serverSocket.Stop();
                Log("Exit");
                Console.ReadLine();

            }
            catch (Exception ex)
            {
                Log(ex.Message);
            }
        }



        private void Log(string info)
        {
            Console.WriteLine("[" + DateTime.Now.ToShortTimeString() + "] " + info);
        }
    }
}
