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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea3 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend3 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series3 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.RichTextBox_ChatMessages = new System.Windows.Forms.RichTextBox();
            this.TextBox_ChatMessage = new System.Windows.Forms.TextBox();
            this.Button_SendChatMessage = new System.Windows.Forms.Button();
            this.ComboBox_Locations = new System.Windows.Forms.ComboBox();
            this.Button_VoteForSelectedLocation = new System.Windows.Forms.Button();
            this.Chart_LocationVotes = new System.Windows.Forms.DataVisualization.Charting.Chart();
            ((System.ComponentModel.ISupportInitialize)(this.Chart_LocationVotes)).BeginInit();
            this.SuspendLayout();
            // 
            // RichTextBox_ChatMessages
            // 
            this.RichTextBox_ChatMessages.Location = new System.Drawing.Point(12, 443);
            this.RichTextBox_ChatMessages.Name = "RichTextBox_ChatMessages";
            this.RichTextBox_ChatMessages.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.Vertical;
            this.RichTextBox_ChatMessages.Size = new System.Drawing.Size(868, 188);
            this.RichTextBox_ChatMessages.TabIndex = 0;
            this.RichTextBox_ChatMessages.Text = "";
            // 
            // TextBox_ChatMessage
            // 
            this.TextBox_ChatMessage.Location = new System.Drawing.Point(12, 637);
            this.TextBox_ChatMessage.Name = "TextBox_ChatMessage";
            this.TextBox_ChatMessage.Size = new System.Drawing.Size(787, 20);
            this.TextBox_ChatMessage.TabIndex = 1;
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
            // 
            // ComboBox_Locations
            // 
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
            chartArea3.Name = "ChartArea1";
            this.Chart_LocationVotes.ChartAreas.Add(chartArea3);
            legend3.Name = "Legend1";
            this.Chart_LocationVotes.Legends.Add(legend3);
            this.Chart_LocationVotes.Location = new System.Drawing.Point(12, 12);
            this.Chart_LocationVotes.Name = "Chart_LocationVotes";
            series3.ChartArea = "ChartArea1";
            series3.Legend = "Legend1";
            series3.Name = "Series1";
            this.Chart_LocationVotes.Series.Add(series3);
            this.Chart_LocationVotes.Size = new System.Drawing.Size(662, 425);
            this.Chart_LocationVotes.TabIndex = 5;
            this.Chart_LocationVotes.Text = "chart1";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(892, 669);
            this.Controls.Add(this.Chart_LocationVotes);
            this.Controls.Add(this.Button_VoteForSelectedLocation);
            this.Controls.Add(this.ComboBox_Locations);
            this.Controls.Add(this.Button_SendChatMessage);
            this.Controls.Add(this.TextBox_ChatMessage);
            this.Controls.Add(this.RichTextBox_ChatMessages);
            this.Name = "MainForm";
            this.Text = "MainForm";
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
    }
}