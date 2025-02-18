
namespace rover
{
    partial class Custom_Melting
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Custom_Melting));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.speed_bar = new System.Windows.Forms.TrackBar();
            this.dur_bar = new System.Windows.Forms.TrackBar();
            this.size_bar = new System.Windows.Forms.TrackBar();
            this.length_bar = new System.Windows.Forms.TrackBar();
            this.r_vertical = new System.Windows.Forms.RadioButton();
            this.r_horizontal = new System.Windows.Forms.RadioButton();
            this.r_mix = new System.Windows.Forms.RadioButton();
            this.btn_use = new System.Windows.Forms.Button();
            this.btn_clear = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.speed_bar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dur_bar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.size_bar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.length_bar)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(162, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Set your own melting effect";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 31);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(38, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Speed";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 98);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(47, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Duration";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(136, 146);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(0, 13);
            this.label4.TabIndex = 3;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 162);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(27, 13);
            this.label5.TabIndex = 4;
            this.label5.Text = "Size";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(12, 226);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(40, 13);
            this.label6.TabIndex = 5;
            this.label6.Text = "Length";
            // 
            // speed_bar
            // 
            this.speed_bar.LargeChange = 2;
            this.speed_bar.Location = new System.Drawing.Point(15, 47);
            this.speed_bar.Maximum = 50;
            this.speed_bar.Minimum = 1;
            this.speed_bar.Name = "speed_bar";
            this.speed_bar.Size = new System.Drawing.Size(303, 45);
            this.speed_bar.TabIndex = 6;
            this.speed_bar.Value = 1;
            this.speed_bar.Scroll += new System.EventHandler(this.speed_bar_Scroll);
            // 
            // dur_bar
            // 
            this.dur_bar.LargeChange = 2;
            this.dur_bar.Location = new System.Drawing.Point(11, 114);
            this.dur_bar.Minimum = 1;
            this.dur_bar.Name = "dur_bar";
            this.dur_bar.Size = new System.Drawing.Size(303, 45);
            this.dur_bar.TabIndex = 7;
            this.dur_bar.Value = 1;
            this.dur_bar.Scroll += new System.EventHandler(this.dur_bar_Scroll);
            // 
            // size_bar
            // 
            this.size_bar.LargeChange = 2;
            this.size_bar.Location = new System.Drawing.Point(11, 178);
            this.size_bar.Maximum = 30;
            this.size_bar.Minimum = 1;
            this.size_bar.Name = "size_bar";
            this.size_bar.Size = new System.Drawing.Size(303, 45);
            this.size_bar.TabIndex = 8;
            this.size_bar.Value = 1;
            this.size_bar.Scroll += new System.EventHandler(this.size_bar_Scroll);
            // 
            // length_bar
            // 
            this.length_bar.LargeChange = 2;
            this.length_bar.Location = new System.Drawing.Point(11, 242);
            this.length_bar.Maximum = 100;
            this.length_bar.Minimum = 1;
            this.length_bar.Name = "length_bar";
            this.length_bar.Size = new System.Drawing.Size(303, 45);
            this.length_bar.TabIndex = 9;
            this.length_bar.Value = 1;
            this.length_bar.Scroll += new System.EventHandler(this.length_bar_Scroll);
            // 
            // r_vertical
            // 
            this.r_vertical.AutoSize = true;
            this.r_vertical.Location = new System.Drawing.Point(15, 279);
            this.r_vertical.Name = "r_vertical";
            this.r_vertical.Size = new System.Drawing.Size(60, 17);
            this.r_vertical.TabIndex = 10;
            this.r_vertical.Text = "Vertical";
            this.r_vertical.UseVisualStyleBackColor = true;
            this.r_vertical.CheckedChanged += new System.EventHandler(this.r_vertical_CheckedChanged);
            // 
            // r_horizontal
            // 
            this.r_horizontal.AutoSize = true;
            this.r_horizontal.Location = new System.Drawing.Point(161, 279);
            this.r_horizontal.Name = "r_horizontal";
            this.r_horizontal.Size = new System.Drawing.Size(72, 17);
            this.r_horizontal.TabIndex = 11;
            this.r_horizontal.Text = "Horizontal";
            this.r_horizontal.UseVisualStyleBackColor = true;
            this.r_horizontal.CheckedChanged += new System.EventHandler(this.r_horizontal_CheckedChanged);
            // 
            // r_mix
            // 
            this.r_mix.AutoSize = true;
            this.r_mix.Location = new System.Drawing.Point(15, 302);
            this.r_mix.Name = "r_mix";
            this.r_mix.Size = new System.Drawing.Size(41, 17);
            this.r_mix.TabIndex = 12;
            this.r_mix.Text = "Mix";
            this.r_mix.UseVisualStyleBackColor = true;
            this.r_mix.CheckedChanged += new System.EventHandler(this.r_mix_CheckedChanged);
            // 
            // btn_use
            // 
            this.btn_use.Location = new System.Drawing.Point(11, 333);
            this.btn_use.Name = "btn_use";
            this.btn_use.Size = new System.Drawing.Size(135, 23);
            this.btn_use.TabIndex = 13;
            this.btn_use.Text = "Use";
            this.btn_use.UseVisualStyleBackColor = true;
            this.btn_use.Click += new System.EventHandler(this.btn_use_Click);
            // 
            // btn_clear
            // 
            this.btn_clear.Location = new System.Drawing.Point(161, 333);
            this.btn_clear.Name = "btn_clear";
            this.btn_clear.Size = new System.Drawing.Size(153, 23);
            this.btn_clear.TabIndex = 14;
            this.btn_clear.Text = "Clear";
            this.btn_clear.UseVisualStyleBackColor = true;
            this.btn_clear.Click += new System.EventHandler(this.btn_clear_Click);
            // 
            // Custom_Melting
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(322, 362);
            this.Controls.Add(this.btn_clear);
            this.Controls.Add(this.btn_use);
            this.Controls.Add(this.r_mix);
            this.Controls.Add(this.r_horizontal);
            this.Controls.Add(this.r_vertical);
            this.Controls.Add(this.length_bar);
            this.Controls.Add(this.size_bar);
            this.Controls.Add(this.dur_bar);
            this.Controls.Add(this.speed_bar);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Custom_Melting";
            this.ShowInTaskbar = false;
            this.Text = "Custom Melting";
            ((System.ComponentModel.ISupportInitialize)(this.speed_bar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dur_bar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.size_bar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.length_bar)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TrackBar speed_bar;
        private System.Windows.Forms.TrackBar dur_bar;
        private System.Windows.Forms.TrackBar size_bar;
        private System.Windows.Forms.TrackBar length_bar;
        private System.Windows.Forms.RadioButton r_vertical;
        private System.Windows.Forms.RadioButton r_horizontal;
        private System.Windows.Forms.RadioButton r_mix;
        private System.Windows.Forms.Button btn_use;
        private System.Windows.Forms.Button btn_clear;
    }
}