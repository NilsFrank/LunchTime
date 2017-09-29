namespace LunchTime.Client
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea6 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend6 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series6 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.RichTextBox_ChatMessages = new System.Windows.Forms.RichTextBox();
            this.TextBox_ChatMessage = new System.Windows.Forms.TextBox();
            this.Button_SendChatMessage = new System.Windows.Forms.Button();
            this.ComboBox_Locations = new System.Windows.Forms.ComboBox();
            this.Button_VoteForSelectedLocation = new System.Windows.Forms.Button();
            this.Chart_LocationVotes = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.TextBox_Username = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.Chart_LocationVotes)).BeginInit();
            this.SuspendLayout();
            // 
            // RichTextBox_ChatMessages
            // 
            this.RichTextBox_ChatMessages.Location = new System.Drawing.Point(12, 443);
            this.RichTextBox_ChatMessages.Name = "RichTextBox_ChatMessages";
            this.RichTextBox_ChatMessages.ReadOnly = true;
            this.RichTextBox_ChatMessages.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.Vertical;
            this.RichTextBox_ChatMessages.Size = new System.Drawing.Size(868, 188);
            this.RichTextBox_ChatMessages.TabIndex = 0;
            this.RichTextBox_ChatMessages.Text = "";
            // 
            // TextBox_ChatMessage
            // 
            this.TextBox_ChatMessage.Location = new System.Drawing.Point(12, 637);
            this.TextBox_ChatMessage.Name = "TextBox_ChatMessage";
            this.TextBox_ChatMessage.Size = new System.Drawing.Size(681, 20);
            this.TextBox_ChatMessage.TabIndex = 1;
            this.TextBox_ChatMessage.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Button_SendChatMessage_KeyDown);
            // 
            // Button_SendChatMessage
            // 
            this.Button_SendChatMessage.Location = new System.Drawing.Point(805, 635);
            this.Button_SendChatMessage.Name = "Button_SendChatMessage";
            this.Button_SendChatMessage.Size = new System.Drawing.Size(75, 23);
            this.Button_SendChatMessage.TabIndex = 2;
            this.Button_SendChatMessage.Text = "Send";
            this.Button_SendChatMessage.UseVisualStyleBackColor = true;
            this.Button_SendChatMessage.Click += new System.EventHandler(this.Button_SendChatMessage_Click);
            this.Button_SendChatMessage.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Button_SendChatMessage_KeyDown);
            // 
            // ComboBox_Locations
            // 
            this.ComboBox_Locations.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ComboBox_Locations.FormattingEnabled = true;
            this.ComboBox_Locations.Location = new System.Drawing.Point(680, 12);
            this.ComboBox_Locations.Name = "ComboBox_Locations";
            this.ComboBox_Locations.Size = new System.Drawing.Size(200, 21);
            this.ComboBox_Locations.TabIndex = 3;
            // 
            // Button_VoteForSelectedLocation
            // 
            this.Button_VoteForSelectedLocation.Location = new System.Drawing.Point(805, 39);
            this.Button_VoteForSelectedLocation.Name = "Button_VoteForSelectedLocation";
            this.Button_VoteForSelectedLocation.Size = new System.Drawing.Size(75, 23);
            this.Button_VoteForSelectedLocation.TabIndex = 4;
            this.Button_VoteForSelectedLocation.Text = "Vote";
            this.Button_VoteForSelectedLocation.UseVisualStyleBackColor = true;
            this.Button_VoteForSelectedLocation.Click += new System.EventHandler(this.Button_VoteForSelectedLocation_Click);
            // 
            // Chart_LocationVotes
            // 
            chartArea6.Name = "ChartArea1";
            this.Chart_LocationVotes.ChartAreas.Add(chartArea6);
            legend6.Name = "Legend1";
            this.Chart_LocationVotes.Legends.Add(legend6);
            this.Chart_LocationVotes.Location = new System.Drawing.Point(12, 12);
            this.Chart_LocationVotes.Name = "Chart_LocationVotes";
            series6.ChartArea = "ChartArea1";
            series6.Legend = "Legend1";
            series6.Name = "Series1";
            this.Chart_LocationVotes.Series.Add(series6);
            this.Chart_LocationVotes.Size = new System.Drawing.Size(662, 425);
            this.Chart_LocationVotes.TabIndex = 5;
            this.Chart_LocationVotes.Text = "chart1";
            // 
            // TextBox_Username
            // 
            this.TextBox_Username.Location = new System.Drawing.Point(699, 637);
            this.TextBox_Username.Name = "TextBox_Username";
            this.TextBox_Username.Size = new System.Drawing.Size(100, 20);
            this.TextBox_Username.TabIndex = 6;
            this.TextBox_Username.Text = "Username";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(680, 424);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(87, 13);
            this.label1.TabIndex = 7;
            this.label1.Text = "© P. Dörr, F. Nils";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(892, 669);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.TextBox_Username);
            this.Controls.Add(this.Chart_LocationVotes);
            this.Controls.Add(this.Button_VoteForSelectedLocation);
            this.Controls.Add(this.ComboBox_Locations);
            this.Controls.Add(this.Button_SendChatMessage);
            this.Controls.Add(this.TextBox_ChatMessage);
            this.Controls.Add(this.RichTextBox_ChatMessages);
            this.Name = "MainForm";
            this.Text = "LunchTime ™";
            this.Load += new System.EventHandler(this.MainForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.Chart_LocationVotes)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RichTextBox RichTextBox_ChatMessages;
        private System.Windows.Forms.TextBox TextBox_ChatMessage;
        private System.Windows.Forms.Button Button_SendChatMessage;
        private System.Windows.Forms.ComboBox ComboBox_Locations;
        private System.Windows.Forms.Button Button_VoteForSelectedLocation;
        private System.Windows.Forms.DataVisualization.Charting.Chart Chart_LocationVotes;
        private System.Windows.Forms.TextBox TextBox_Username;
        private System.Windows.Forms.Label label1;
    }
}