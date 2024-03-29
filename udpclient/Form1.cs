﻿using System;
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

namespace udp
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                int port;
                IPAddress ipAddress;
                IPEndPoint ipEndPoint;
                UdpClient udpClient = new UdpClient();
                if (IPAddress.TryParse(textBox1.Text, out ipAddress) && int.TryParse(textBox2.Text, out port))
                {
                    ipAddress = IPAddress.Parse(textBox1.Text);
                    port = int.Parse(textBox2.Text);
                    ipEndPoint = new IPEndPoint(ipAddress, port);
                    Byte[] message = Encoding.UTF8.GetBytes(textBox3.Text);
                    udpClient.Send(message, message.Length, ipEndPoint);
                    textBox3.Text = "";
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
