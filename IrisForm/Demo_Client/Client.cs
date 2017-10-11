using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Demo_Client
{
    public partial class Client : Form
    {
        OpenFileDialog openFileDialog = new OpenFileDialog();
        Bitmap Image;
        TcpClient clientSocket = new TcpClient();

        public Client()
        {
            InitializeComponent();
        }

        private void Client_Load(object sender, EventArgs e)
        {
            // TODO
            // Connect camera and start it

            clientSocket.Connect("127.0.0.1", 2017);
            LblStatus.Text = "Status: Connected to the server";

        }

        protected override void OnClosed(EventArgs e)
        {
            base.OnClosed(e);

            if (clientSocket != null && clientSocket.Connected)
            {
                clientSocket.Client.Disconnect(false);
                clientSocket.Close();
            }
        }

        private void btnOpenFile_Click(object sender, EventArgs e)
        {
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                LblFile.Text = openFileDialog.SafeFileName;
                Image = new Bitmap(openFileDialog.FileName);
                imgBox.Image = Image;
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            // TODO
            // Turn on camera again

        }

        private void btnScan_Click(object sender, EventArgs e)
        {
            ImageConverter converter = new ImageConverter();
            byte[] buffer = (byte[])converter.ConvertTo(Image, typeof(byte[]));

            NetworkStream serverStream = clientSocket.GetStream();
            
            serverStream.Write(buffer, 0, buffer.Length);
            serverStream.Flush();


            // TODO get data
            //byte[] inStream = new byte[10025];
            //serverStream.Read(inStream, 0, (int)clientSocket.ReceiveBufferSize);
            //string returndata = System.Text.Encoding.ASCII.GetString(inStream);
            //msg("Data from Server : " + returndata);
        }
    }
}
