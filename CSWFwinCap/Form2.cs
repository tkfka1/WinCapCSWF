using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.Net;
using System.Net.Sockets;
using System.IO;

namespace CSWFwinCap
{
    public partial class Form2 : Form
    {
        TcpClient client;
        NetworkStream networkStream;
        MemoryStream memoryStream;
        Bitmap screen;

        string serverIP;
        int serverPort;
        byte[] data;
        byte[] dataSizeForServer;

        public Form2()
        {
            InitializeComponent();

            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            textBox1.Text = "192.168.0.100";
        }

        private void Form2_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void ClientStartBTN_Click(object sender, EventArgs e)
        {
            memoryStream = new MemoryStream();
            screen = GetScreen();
            pictureBox1.Image = screen;
            screen.Save(memoryStream, System.Drawing.Imaging.ImageFormat.Png);
            data = memoryStream.ToArray();

            serverIP = textBox1.Text;
            serverPort = 7000;
            client = new TcpClient(serverIP, serverPort);
            listBox1.Items.Add("Connected to: " + client.Client.RemoteEndPoint.ToString().Split(':')[0]);

            networkStream = client.GetStream();

            if (networkStream.CanWrite)
            {
                // 보낼 데이터 사이즈를 서버에 미리 공유
                dataSizeForServer = BitConverter.GetBytes(data.Length);
                networkStream.Write(dataSizeForServer, 0, dataSizeForServer.Length);

                // 데이터 전송
                networkStream.Write(data, 0, data.Length);
                listBox1.Items.Add("Data sent: " + (data.Length / 1024).ToString() + "KB");
            }

            client.Close();
            networkStream.Close();
            memoryStream.Close();
        }
        private Bitmap GetScreen()
        {
            Bitmap bitmap = new Bitmap(Screen.PrimaryScreen.Bounds.Width, Screen.PrimaryScreen.Bounds.Height);
            Graphics g = Graphics.FromImage(bitmap);
            g.CopyFromScreen(0, 0, 0, 0, bitmap.Size);
            g.Dispose();

            return bitmap;
        }
    }
}
