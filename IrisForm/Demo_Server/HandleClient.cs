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
        TcpClient clientSocket;
        string clientNumber;
        byte[] buffer;

        public HandleClient(TcpClient inClientSocket, string clineNo)
        {
            clientSocket = inClientSocket;
            clientNumber = clineNo;
            Thread clientThread = new Thread(Handle);
            clientThread.Start();
        }

        private void Handle()
        {
            buffer = new byte[65536];
            NetworkStream networkStream = clientSocket.GetStream();

            while ((true))
            {
                try
                {
                    List<byte> imageInBytes = new List<byte>();
                    //int received = 0;
                    networkStream = clientSocket.GetStream();
                    int receivedLength = 0;
                    

                    if (networkStream.CanRead)
                    {
                        do
                        {
                            receivedLength += networkStream.Read(buffer, 0, clientSocket.ReceiveBufferSize);
                            imageInBytes.AddRange(buffer);
                            Log("Readed");
                        } while (networkStream.DataAvailable);

                    }
                    

                    if (receivedLength == 0)
                    {
                        Log("Client #" + clientNumber + ": disconnected!");
                        break;
                    }

                    


                    ImageConverter IC = new ImageConverter();
                    Bitmap image = (Bitmap)IC.ConvertFrom(imageInBytes.ToArray());

                    // Other way to decode image
                    //
                    //MemoryStream ms = new MemoryStream(buffer);
                    //ms.Seek(0, SeekOrigin.Begin);
                    //Bitmap image = new Bitmap(ms);

                    image.Save("image.jpg");

                    Array.Clear(buffer, 0, buffer.Length);

                    //Resize(ref buffer, 1048576);
                    Log("From client #" + clientNumber + ": received image");

                    networkStream.Flush();

                    // TODO send data
                    //serverResponse = "Server to clinet(" + clNo + ") " + rCount;
                    //sendBytes = Encoding.ASCII.GetBytes(serverResponse);
                    //networkStream.Write(sendBytes, 0, sendBytes.Length);
                    //networkStream.Flush();
                    //Console.WriteLine(" >> " + serverResponse);
                    //
                }
                catch (Exception ex)
                {
                    Log(ex.Message);
                }
            }
        }


        private void Log(string info)
        {
            Console.WriteLine("[" + DateTime.Now.ToShortTimeString() + "] " + info);
        }
    }
}
