
namespace rover
{
    partial class TTS_settings
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TTS_settings));
            this.label1 = new System.Windows.Forms.Label();
            this.track_vol = new System.Windows.Forms.TrackBar();
            this.label2 = new System.Windows.Forms.Label();
            this.track_rate = new System.Windows.Forms.TrackBar();
            ((System.ComponentModel.ISupportInitialize)(this.track_vol)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.track_rate)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(42, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Volume";
            // 
            // track_vol
            // 
            this.track_vol.LargeChange = 2;
            this.track_vol.Location = new System.Drawing.Point(9, 25);
            this.track_vol.Maximum = 100;
            this.track_vol.Name = "track_vol";
            this.track_vol.Size = new System.Drawing.Size(377, 45);
            this.track_vol.TabIndex = 1;
            this.track_vol.Value = 50;
            this.track_vol.Scroll += new System.EventHandler(this.track_vol_Scroll);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 60);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(30, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Rate";
            // 
            // track_rate
            // 
            this.track_rate.Location = new System.Drawing.Point(9, 76);
            this.track_rate.Minimum = -10;
            this.track_rate.Name = "track_rate";
            this.track_rate.Size = new System.Drawing.Size(377, 45);
            this.track_rate.TabIndex = 3;
            this.track_rate.Scroll += new System.EventHandler(this.track_rate_Scroll);
            // 
            // TTS_settings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(398, 120);
            this.Controls.Add(this.track_rate);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.track_vol);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "TTS_settings";
            this.ShowInTaskbar = false;
            this.Text = "Text to Speech(TTS) Settings";
            ((System.ComponentModel.ISupportInitialize)(this.track_vol)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.track_rate)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        public System.Windows.Forms.TrackBar track_vol;
        public System.Windows.Forms.TrackBar track_rate;
    }
}