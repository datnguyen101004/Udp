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

namespace UdpServer
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try 
            {
                DateTime date = DateTime.Now.AddSeconds(30);
                int port = int.Parse(textBox1.Text);
                UdpClient client = new UdpClient(port);
                IPEndPoint iPEndPoint = new IPEndPoint(IPAddress.Any, 0);
                while (date > DateTime.Now)
                {
                    Byte[] content = client.Receive(ref iPEndPoint);
                    String message = Encoding.UTF8.GetString(content);
                    textBox2.AppendText(message);
                }
                client.Close();
            }
            catch (Exception ex)
            {
                // Handle exception appropriately
                MessageBox.Show(ex.Message);
            }
        }
    }
}
