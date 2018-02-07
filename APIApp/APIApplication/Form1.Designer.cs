namespace APIApplication
{
    partial class Form1
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
            this.Departure = new System.Windows.Forms.Label();
            this.label_TrainMsg = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.Stationbox = new System.Windows.Forms.ComboBox();
            this.ListboxName = new System.Windows.Forms.ListBox();
            this.Saved = new System.Windows.Forms.Label();
            this.SavedDeparture = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // Departure
            // 
            this.Departure.AutoSize = true;
            this.Departure.BackColor = System.Drawing.Color.Transparent;
            this.Departure.Font = new System.Drawing.Font("Old English Text MT", 48F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Departure.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.Departure.Location = new System.Drawing.Point(86, 9);
            this.Departure.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.Departure.MinimumSize = new System.Drawing.Size(450, 54);
            this.Departure.Name = "Departure";
            this.Departure.Size = new System.Drawing.Size(486, 114);
            this.Departure.TabIndex = 9;
            this.Departure.Text = "Departures";
            // 
            // label_TrainMsg
            // 
            this.label_TrainMsg.AutoSize = true;
            this.label_TrainMsg.BackColor = System.Drawing.Color.Transparent;
            this.label_TrainMsg.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_TrainMsg.Location = new System.Drawing.Point(64, 501);
            this.label_TrainMsg.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label_TrainMsg.MaximumSize = new System.Drawing.Size(525, 231);
            this.label_TrainMsg.Name = "label_TrainMsg";
            this.label_TrainMsg.Size = new System.Drawing.Size(0, 29);
            this.label_TrainMsg.TabIndex = 11;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Lucida Calligraphy", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.label1.Location = new System.Drawing.Point(20, 160);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(121, 31);
            this.label1.TabIndex = 1;
            this.label1.Text = "Station:";
            // 
            // Stationbox
            // 
            this.Stationbox.BackColor = System.Drawing.Color.Thistle;
            this.Stationbox.FormattingEnabled = true;
            this.Stationbox.Location = new System.Drawing.Point(26, 195);
            this.Stationbox.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Stationbox.Name = "Stationbox";
            this.Stationbox.Size = new System.Drawing.Size(282, 28);
            this.Stationbox.TabIndex = 5;
            this.Stationbox.SelectedIndexChanged += new System.EventHandler(this.Stationbox_SelectedIndexChanged);
            this.Stationbox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Stationbox_KeyDown);
            // 
            // ListboxName
            // 
            this.ListboxName.BackColor = System.Drawing.Color.Thistle;
            this.ListboxName.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ListboxName.FormattingEnabled = true;
            this.ListboxName.ItemHeight = 25;
            this.ListboxName.Location = new System.Drawing.Point(26, 298);
            this.ListboxName.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.ListboxName.Name = "ListboxName";
            this.ListboxName.Size = new System.Drawing.Size(601, 179);
            this.ListboxName.TabIndex = 4;
            this.ListboxName.SelectedIndexChanged += new System.EventHandler(this.ListboxName_SelectedIndexChanged);
            // 
            // Saved
            // 
            this.Saved.AutoSize = true;
            this.Saved.BackColor = System.Drawing.Color.Transparent;
            this.Saved.Font = new System.Drawing.Font("Lucida Calligraphy", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Saved.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.Saved.Location = new System.Drawing.Point(339, 160);
            this.Saved.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.Saved.Name = "Saved";
            this.Saved.Size = new System.Drawing.Size(103, 31);
            this.Saved.TabIndex = 8;
            this.Saved.Text = "Saved:";
            // 
            // SavedDeparture
            // 
            this.SavedDeparture.BackColor = System.Drawing.Color.Thistle;
            this.SavedDeparture.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SavedDeparture.FormattingEnabled = true;
            this.SavedDeparture.ItemHeight = 25;
            this.SavedDeparture.Location = new System.Drawing.Point(345, 195);
            this.SavedDeparture.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.SavedDeparture.Name = "SavedDeparture";
            this.SavedDeparture.Size = new System.Drawing.Size(282, 79);
            this.SavedDeparture.TabIndex = 7;
            this.SavedDeparture.SelectedIndexChanged += new System.EventHandler(this.SavedDeparture_SelectedIndexChanged);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Navy;
            this.BackgroundImage = global::APIApplication.Properties.Resources.Background;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(650, 619);
            this.Controls.Add(this.ListboxName);
            this.Controls.Add(this.label_TrainMsg);
            this.Controls.Add(this.Departure);
            this.Controls.Add(this.Saved);
            this.Controls.Add(this.SavedDeparture);
            this.Controls.Add(this.Stationbox);
            this.Controls.Add(this.label1);
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label Departure;
        private System.Windows.Forms.Label label_TrainMsg;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox Stationbox;
        private System.Windows.Forms.ListBox ListboxName;
        private System.Windows.Forms.Label Saved;
        private System.Windows.Forms.ListBox SavedDeparture;
    }
}

