using SuperSimpleTcp;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TCPChatClient
{
    public partial class Client : Form
    {
        public Client()
        {
            InitializeComponent();
        }
        private SimpleTcpClient client;
        private void Client_Load(object sender, EventArgs e)
        {

        }
        private void btnConnect_Click(object sender, EventArgs e)
        {
            IPAddress[] host = Dns.GetHostAddresses(txt_IP.Text);
            client = new SimpleTcpClient(host[0], int.Parse(txtPort.Text));
            client.Connect();
            client.Events.DataReceived += Events_DataReceived;
        }
        public void ShowMess(string mess)
        {
            txtResult.Text += "\r\n" + mess;
        }
        private void Events_DataReceived(object sender, DataReceivedEventArgs e)
        {
            string mess = Encoding.UTF8.GetString(e.Data.Array);
            ShowMess(mess);
        }

        private void btnDisConnect_Click(object sender, EventArgs e)
        {

        }

        private void btnSend_Click(object sender, EventArgs e)
        {
            client.SendAsync(txtMess.Text);
        }
    }
}
