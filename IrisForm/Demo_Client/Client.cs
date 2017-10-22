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
using System.IO;
using AForge;
using AForge.Video.DirectShow;
using AForge.Video;
using System.Drawing.Imaging;

namespace Demo_Client
{
    public partial class Client : Form
    {
        OpenFileDialog openFileDialog = new OpenFileDialog();
        Bitmap Image;
        TcpClient clientSocket = new TcpClient();

        private FilterInfoCollection Devices;
        private VideoCaptureDevice VideoFromCamera;

        public Client()
        {
            InitializeComponent();
        }

        private void Client_Load(object sender, EventArgs e)
        {
            // TODO
            // Connect camera and start it

            clientSocket.Connect("127.0.0.1", 4242);
            LblStatus.Text = "Status: Connected to the server";

            Devices = new FilterInfoCollection(FilterCategory.VideoInputDevice);

            foreach (FilterInfo Device in Devices) {
                cmbBoxAvailableDevices.Items.Add(Device.Name);
            }
            cmbBoxAvailableDevices.SelectedIndex = 0;
            VideoFromCamera = new VideoCaptureDevice();
        }

        protected override void OnClosed(EventArgs e)
        {
            base.OnClosed(e);

            if (clientSocket != null && clientSocket.Connected)
            {
                clientSocket.Client.Disconnect(false);
                clientSocket.Close();
            }
            if (VideoFromCamera.IsRunning == true) VideoFromCamera.Stop();
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
            NetworkStream serverStream = clientSocket.GetStream();

            ImageConverter converter = new ImageConverter();
            byte[] buffer = (byte[])converter.ConvertTo(Image, typeof(byte[]));

            byte[] buffLength = BitConverter.GetBytes(buffer.Length/1024+1);

            serverStream.Write(buffLength, 0, buffLength.Length);
            serverStream.Flush();

            

            
            serverStream.Write(buffer, 0, buffer.Length);
            serverStream.Flush();


            // TODO get data
            //byte[] inStream = new byte[10025];
            //serverStream.Read(inStream, 0, (int)clientSocket.ReceiveBufferSize);
            //string returndata = System.Text.Encoding.ASCII.GetString(inStream);
            //msg("Data from Server : " + returndata);
        }

        private void btnUseTheCamera_Click(object sender, EventArgs e) {
            if (VideoFromCamera.IsRunning == true) VideoFromCamera.Stop();
            VideoFromCamera = new VideoCaptureDevice(Devices[cmbBoxAvailableDevices.SelectedIndex].MonikerString);
            VideoFromCamera.NewFrame += new NewFrameEventHandler(VideoFromCamera_NewFrame);

            VideoFromCamera.Start();
        }

        private void VideoFromCamera_NewFrame(object sender, NewFrameEventArgs eventArgs) {
            //Bitmap video = (Bitmap)eventArgs.Frame.Clone();
            if(imgBox.Image != null) imgBox.Image.Dispose();
            imgBox.Image = (Bitmap)eventArgs.Frame.Clone();
        }

        private void btnCapture_Click(object sender, EventArgs e) {
            if(imgBox.Image!=null)
                Image = (Bitmap)imgBox.Image;
        }
    }
}
