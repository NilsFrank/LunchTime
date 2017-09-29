using LunchTime.Server.Model;
using Microsoft.AspNet.SignalR.Client;
using System;
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

        private Location[] locations;

        private Vote[] votes;



        #region Publics

        /// <summary>
        /// Initializes the Form.
        /// </summary>
        public MainForm()
        {
            InitializeComponent();
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
            string[] locations = { "Burger", "Asia", "Tacco Tacco", "Dosenchili", "Burger1", "Asia1", "Tacco Tacco1", "Dosenchili1", "Burger2", "Asia2", "Tacco Tacco2", "Dosenchili2" };
            int[] votes = { 1, 0, 4, 2, 1, 0, 4, 2, 1, 0, 4, 2 };

            Chart_LocationVotes.Titles.Clear();
            Chart_LocationVotes.Series.Clear();
            Chart_LocationVotes.Titles.Add("Locations");



            for (int i = 0; i < locations.Length; i++)
            {
                Series series = Chart_LocationVotes.Series.Add(locations[i]);

                series.Points.Add(votes[i]);
            }



            ConnectAsync();



            
        }



        private void Button_VoteForSelectedLocation_Click(object sender, EventArgs e)
        {
            HubProxy.Invoke("Vote", locations[0], "MeMyselfAndI");
        }



        private void Button_SendChatMessage_Click(object sender, EventArgs e)
        {
            HubProxy.Invoke("GetAllLocations");
            HubProxy.Invoke("GetAllVotes");
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
            //Handle incoming event from server: use Invoke to write to console from SignalR's thread
            HubProxy.On<string, string>("AddMessage", (name,
                                                       message) =>
                                            this.Invoke((Action)(() =>
                                                            RichTextBox_ChatMessages.AppendText(String.Format("{0}: {1}" + Environment.NewLine, name, message))
                                                        ))
                                       );

            HubProxy.On<Location[]>("ReceivedAllLocations", (locations) =>
                                            this.Invoke((Action)(() =>
                                                            ReceivedAllLocations(locations)
                                                        ))
                                       );

            HubProxy.On<Vote[]>("ReceivedAllVotes", (votes) =>
                                            this.Invoke((Action)(() =>
                                                            ReceivedAllVotes(votes)
                                                        ))
                                       );

            try
            {
                await Connection.Start();
            }
            catch (HttpRequestException)
            {
                RichTextBox_ChatMessages.AppendText("Unable to connect to server: Start server before connecting clients.");
                //No connection: Don't enable Send button or show chat UI
                return;
            }

            //Activate UI
            RichTextBox_ChatMessages.AppendText("Connected to server at " + ServerURI + Environment.NewLine);
        }



        private void Connection_Closed()
        {
            this.Invoke((Action)(() => RichTextBox_ChatMessages.AppendText("You have been disconnected.")));
        }



        private void ReceivedAllLocations(Location[] locations)
        {
            this.locations = locations;
        }



        private void ReceivedAllVotes(Vote[] votes)
        {
            this.votes = votes;
        }

        #endregion

        

        
    }
}
