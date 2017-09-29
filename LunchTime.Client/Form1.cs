using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.AspNet.SignalR.Client;
using Microsoft.AspNet.SignalR.Client.Hubs;

namespace LunchTime.Client
{
    public partial class Form1 : Form
    {
        private String UserName { get; set; }
        private IHubProxy HubProxy { get; set; }
        const string ServerURI = "http://localhost:8080";
        private HubConnection Connection { get; set; }


        public Form1()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Creates and connects the hub connection and hub proxy. This method
        /// is called asynchronously from SignInButton_Click.
        /// </summary>
        private async void ConnectAsync()
        {
            Connection = new HubConnection(ServerURI);
            Connection.Closed += Connection_Closed;
            HubProxy = Connection.CreateHubProxy("MyHub");
            //Handle incoming event from server: use Invoke to write to console from SignalR's thread
            HubProxy.On<string, string>("AddMessage", (name,
                                                       message) =>
                                            this.Invoke((Action) (() =>
                                                            richTextBox1.AppendText(String.Format("{0}: {1}" + Environment.NewLine, name, message))
                                                        ))
                                       );
            try
            {
                await Connection.Start();
            }
            catch (HttpRequestException)
            {
                richTextBox1.AppendText("Unable to connect to server: Start server before connecting clients.");
                //No connection: Don't enable Send button or show chat UI
                return;
            }

            //Activate UI
            richTextBox1.AppendText("Connected to server at " + ServerURI + Environment.NewLine);
        }

        private void Connection_Closed()
        {
            //Deactivate chat UI; show login UI. 
            this.Invoke((Action) (() => richTextBox1.AppendText("You have been disconnected.")));
        }


        private void Form1_Load(object sender,
                                EventArgs e)
        {
        }

        private void button2_Click(object sender,
                                   EventArgs e)
        {
            HubProxy.Invoke("Send", UserName, textBox2.Text);
            textBox2.Text = String.Empty;
        }

        private void WinFormsClient_FormClosing(object sender,
                                                FormClosingEventArgs e)
        {
            if (Connection != null)
            {
                Connection.Stop();
                Connection.Dispose();
            }
        }

        private void button3_Click(object sender,
                                   EventArgs e)
        {
            UserName = "Ich";
            //Connect to server (use async method to avoid blocking UI thread)
            if (!String.IsNullOrEmpty(UserName))
            {
                ConnectAsync();
            }
        }
    }
}