using LunchTime.Server.Model;
using Microsoft.AspNet.SignalR.Client;
using System;
using System.Linq;
using System.Net.Http;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;



namespace LunchTime.Client
{
    /// <summary>
    /// The Main-Form, used to visualize all Data.
    /// </summary>
    public partial class MainForm : Form
    {
        //Constants

        const string ServerURI = "http://localhost:8080";



        //Members

        private String UserName { get; set; }
        
        private IHubProxy HubProxy { get; set; }
        
        private HubConnection Connection { get; set; }

        private Guid userID;

        private Locations locations;

        private Votes votes;



        #region Publics

        /// <summary>
        /// Initializes the Form.
        /// </summary>
        public MainForm()
        {
            InitializeComponent();

            userID = Guid.NewGuid();
        }

        #endregion



        #region Privates (UI)

        /// <summary>
        /// Loads the Form - called after the Constructor has been called.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MainForm_Load(object sender, EventArgs e)
        {
            setUIElementLockedStatus(false);
            RichTextBox_ChatMessages.AppendText("Connecting to server at " + ServerURI + Environment.NewLine);

            ConnectAsync();
        }



        private void Button_VoteForSelectedLocation_Click(object sender, EventArgs e)
        {
            HubProxy.Invoke("Vote", locations.locations.First(x => x.name.Equals(ComboBox_Locations.SelectedItem.ToString())), new User() { guid = userID, username = TextBox_Username.Text });
        }



        private void Button_SendChatMessage_Click(object sender, EventArgs e)
        {
            if (!TextBox_ChatMessage.Text.Equals("") && !TextBox_Username.Text.Equals(""))
            {
                HubProxy.Invoke("Send", TextBox_ChatMessage.Text, new User() { guid = userID, username = TextBox_Username.Text });
            }

            TextBox_ChatMessage.Text = "";
        }



        private void Button_SendChatMessage_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                Button_SendChatMessage.PerformClick();

                // these last two lines will stop the beep sound
                e.SuppressKeyPress = true;
                e.Handled = true;
            }
        }

        #endregion



        #region Privates

        /// <summary>
        /// Creates and connects the hub connection and hub proxy. This method
        /// is called asynchronously from SignInButton_Click.
        /// </summary>
        private async void ConnectAsync()
        {
            Connection = new HubConnection(ServerURI);
            Connection.Closed += Connection_Closed;
            HubProxy = Connection.CreateHubProxy("MyHub");

            HubProxy.On<LunchTime.Server.Model.Message>("addMessage", (message) =>
                                            this.Invoke((Action)(() =>
                                                            ReceivedNewChatMessage(message.Username, message.MessageText, message.CreatedTimeStamp)
                                                        ))
                                       );

            HubProxy.On<Locations>("getAllLocations", (locations) =>
                                            this.Invoke((Action)(() =>
                                                            ReceivedAllLocations(locations)
                                                        ))
                                       );

            HubProxy.On<Votes>("getAllVotes", (votes) =>
                                            this.Invoke((Action)(() =>
                                                            ReceivedAllVotes(votes)
                                                        ))
                                       );

            HubProxy.On<Votes>("vote", (votes) =>
                                            this.Invoke((Action)(() =>
                                                            ReceivedAllVotes(votes)
                                                        ))
                                       );

            try
            {
                await Connection.Start();
                await HubProxy.Invoke("GetAllLocations");
                await HubProxy.Invoke("GetAllVotes");
                await HubProxy.Invoke("RegisterUser", new User() { guid = userID, username = "" });
            }
            catch (HttpRequestException)
            {
                RichTextBox_ChatMessages.AppendText("Unable to connect to server: Start server before connecting clients." + Environment.NewLine);
                //No connection: Don't enable Send button or show chat UI
                return;
            }

            //Activate UI
            RichTextBox_ChatMessages.AppendText("Connected to server!" + Environment.NewLine);
            setUIElementLockedStatus(true);
        }



        private void setUIElementLockedStatus(bool flag)
        {
            Button_SendChatMessage.Enabled = flag;
            Button_VoteForSelectedLocation.Enabled = flag;
            ComboBox_Locations.Enabled = flag;
        }



        private void Connection_Closed()
        {
            this.Invoke((Action)(() => RichTextBox_ChatMessages.AppendText("You have been disconnected." + Environment.NewLine)));
        }



        private void ReceivedAllLocations(Locations locations)
        {
            this.locations = locations;

            ComboBox_Locations.Items.Clear();
            ComboBox_Locations.Items.AddRange(locations.locations.Select(x => x.name).ToArray());
            ComboBox_Locations.SelectedIndex = 0;
        }



        private void ReceivedAllVotes(Votes votes)
        {
            this.votes = votes;

            string[] locationNames = locations.locations.Select(x => x.name).ToArray();
            int[] voteCounts = new int[locationNames.Length];

            for (int i = 0; i < locationNames.Length; i++)
            {
                voteCounts[i] = votes.votes.Count(x => x.location.name.Equals(locationNames[i]));
            }

            Chart_LocationVotes.Titles.Clear();
            Chart_LocationVotes.Series.Clear();
            Chart_LocationVotes.Titles.Add("Locations");
            Chart_LocationVotes.ChartAreas[0].AxisY.Maximum = Math.Max(5, voteCounts.Max());
            Chart_LocationVotes.ChartAreas[0].AxisY.Minimum = 0;

            for (int i = 0; i < locationNames.Length; i++)
            {
                Series series = Chart_LocationVotes.Series.Add(locationNames[i]);

                series.Points.Add(voteCounts[i]);
            }

            Chart_LocationVotes.Update();
        }



        private void ReceivedNewChatMessage(string userName, string message, DateTime timeStamp)
        {
            RichTextBox_ChatMessages.AppendText(userName + " (" + timeStamp.ToString("hh:mm:ss") + "): " + message + Environment.NewLine);
        }

        #endregion

    }
}
