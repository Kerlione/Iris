using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Demo_Server
{
    class HandleClient
    {
        private const int BufferSize = 1024;
        private byte[] buffer;
        private Socket client;
        private List<byte> listOfBytes;

        private int packetCounter;


        public HandleClient(Socket clientSocket)
        {
            client = clientSocket;
            
            Server.Log("Client connected!");
            buffer = new byte[BufferSize];
            listOfBytes = new List<byte>();

            packetCounter = 0;

            client.BeginReceive(buffer, 0, BufferSize, SocketFlags.None, new AsyncCallback(AsyncReceiveCallback), null);
        }

        private void AsyncReceiveCallback(IAsyncResult ar)
        {
            try
            {
                int bytes = client.EndReceive(ar);

                if (bytes == 0)
                {
                    Server.Log("Client disconnected!");
                    client.Close();
                    return;
                }

                if (packetCounter == 0)
                {
                    packetCounter = BitConverter.ToInt16(buffer, 0);
                    Server.Log("Will receive " + packetCounter + " packets!");
                } else
                {
                    listOfBytes.AddRange(buffer);
                    Array.Clear(buffer, 0, BufferSize);

                    packetCounter--;
                    
                    Server.Log("Data received! (" + packetCounter + ")");

                    if (packetCounter == 0)
                    {
                        ImageConverter IC = new ImageConverter();
                        Bitmap image = (Bitmap)IC.ConvertFrom(listOfBytes.ToArray());
                        
                        image.Save("image.jpg");
                        listOfBytes.Clear();

                        Server.Log("Image created!");
                    }
                }

                

                client.BeginReceive(buffer, 0, BufferSize, SocketFlags.None, new AsyncCallback(AsyncReceiveCallback), null);
            }
            catch (Exception ex)
            {
                Server.Log(ex.Message);
            }
        }
        




    }
}
