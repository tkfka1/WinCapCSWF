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
    public partial class Form3 : Form
    {
        TcpListener listener;
        TcpClient client;
        NetworkStream networkStream;
        MemoryStream memoryStream;
        Bitmap bitmap;
        IPHostEntry iPHostEntry;

        string serverIP;
        int serverPort;
        byte[] data = new byte[1048576]; //1mb
        byte[] dataSizeFormClient;
        int receivedDataSize;
        int expectedDataSize;


        public Form3()
        {
            InitializeComponent();

            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;

            serverPort = 7000;
            // 호스트 이름으로 검색되는 첫 번째 IP4 주소 확인
            string hostName = Dns.GetHostName();
            iPHostEntry = Dns.GetHostEntry(hostName);
            foreach (IPAddress address in iPHostEntry.AddressList)
            {
                if (address.AddressFamily == AddressFamily.InterNetwork)
                {
                    serverIP = address.ToString();
                    break;
                }
            }
            listBox1.Items.Add("Server IP: " + serverIP);

            listener = new TcpListener(IPAddress.Any, serverPort);
            //listener = new TcpListener(IPAddress.Parse("127.0.0.1"), serverPort);

        }

        private void Form3_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void ServerStartBTN_Click(object sender, EventArgs e)
        {
            listener.Start();
            client = listener.AcceptTcpClient();
            listBox1.Items.Add("Client IP: " + client.Client.RemoteEndPoint.ToString().Split(':')[0]);

            networkStream = client.GetStream();

            receivedDataSize = 0;
            dataSizeFormClient = new byte[sizeof(int)];

            if (networkStream.CanRead)
            {
                //클라로부터 받을 데이터 사이즈 확인
                networkStream.Read(dataSizeFormClient, 0, dataSizeFormClient.Length);
                expectedDataSize = BitConverter.ToInt32(dataSizeFormClient, 0);
                listBox1.Items.Add("Expected data size: "+ (expectedDataSize / 1024).ToString()+ "KB");

                //데이터 송신
                do
                {
                    receivedDataSize += networkStream.Read(data, receivedDataSize, data.Length - receivedDataSize);
                    // reads adta from the networkstream and stores it to a byte array

                } while (networkStream.DataAvailable);
                //while (expectedDataSize > receivedDataSize);

            }

            listBox1.Items.Add("Data received: " + (receivedDataSize / 1024).ToString() + "KB");
            memoryStream = new MemoryStream(data, 0, receivedDataSize);
            bitmap = new Bitmap(memoryStream);
            pictureBox1.Image = bitmap;

            listener.Stop();
            client.Close();
            networkStream.Close();
            memoryStream.Close();


        }
    }
}
