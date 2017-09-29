using System;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;



namespace LunchTime.Client
{
    /// <summary>
    /// The Main-Form, used to visualize all Data.
    /// </summary>
    public partial class MainForm : Form
    {
        /// <summary>
        /// Initializes the Form.
        /// </summary>
        public MainForm()
        {
            InitializeComponent();
        }



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

            

            for(int i = 0; i < locations.Length; i++)
            {
                Series series = Chart_LocationVotes.Series.Add(locations[i]);

                series.Points.Add(votes[i]);
            }
        }
    }
}
