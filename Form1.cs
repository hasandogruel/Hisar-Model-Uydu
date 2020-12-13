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

namespace hisar_alıcı
{
    public partial class Form1 : Form
    {
        static Socket dinleyiciSoket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
        const int PORT = 52000;
        TcpListener dinle = new TcpListener(IPAddress.Any, PORT);

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
           


        }

        private void button1_Click(object sender, EventArgs e)
        {

            dinle.Start();
            label1.Text = "Bağlantı Bekleniyor";
            dinleyiciSoket = dinle.AcceptSocket();
            label1.Text = "Bağlantı Kurulu";

            while (true)
            {
                try
                {
                    byte[] gelenData = new byte[256];
                    dinleyiciSoket.Receive(gelenData);
                    string mesaj = (Encoding.UTF8.GetString(gelenData)).Split('\0')[0];
                    label1.Text = mesaj;

                }

                catch (Exception ex)
                {

                }

            }
        }
    }
}
