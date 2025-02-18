
namespace rover
{
    partial class Pattern_Brush
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Pattern_Brush));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.r_box = new System.Windows.Forms.TextBox();
            this.g_box = new System.Windows.Forms.TextBox();
            this.b_box = new System.Windows.Forms.TextBox();
            this.bytes_box = new System.Windows.Forms.TextBox();
            this.x_box = new System.Windows.Forms.TextBox();
            this.y_box = new System.Windows.Forms.TextBox();
            this.w_box = new System.Windows.Forms.TextBox();
            this.h_box = new System.Windows.Forms.TextBox();
            this.btn_use = new System.Windows.Forms.Button();
            this.btn_clear = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(80, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Color from RGB";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 45);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(33, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Bytes";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 83);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(54, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Position X";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 117);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(54, 13);
            this.label4.TabIndex = 3;
            this.label4.Text = "Position Y";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 152);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(35, 13);
            this.label5.TabIndex = 4;
            this.label5.Text = "Width";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(12, 187);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(38, 13);
            this.label6.TabIndex = 5;
            this.label6.Text = "Height";
            // 
            // r_box
            // 
            this.r_box.Location = new System.Drawing.Point(127, 6);
            this.r_box.MaxLength = 3;
            this.r_box.Name = "r_box";
            this.r_box.Size = new System.Drawing.Size(24, 20);
            this.r_box.TabIndex = 6;
            this.r_box.Text = "0";
            this.r_box.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.r_box.TextChanged += new System.EventHandler(this.r_box_TextChanged);
            // 
            // g_box
            // 
            this.g_box.Location = new System.Drawing.Point(157, 6);
            this.g_box.MaxLength = 3;
            this.g_box.Name = "g_box";
            this.g_box.Size = new System.Drawing.Size(24, 20);
            this.g_box.TabIndex = 7;
            this.g_box.Text = "0";
            this.g_box.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.g_box.TextChanged += new System.EventHandler(this.g_box_TextChanged);
            // 
            // b_box
            // 
            this.b_box.Location = new System.Drawing.Point(187, 6);
            this.b_box.MaxLength = 3;
            this.b_box.Name = "b_box";
            this.b_box.Size = new System.Drawing.Size(24, 20);
            this.b_box.TabIndex = 8;
            this.b_box.Text = "0";
            this.b_box.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.b_box.TextChanged += new System.EventHandler(this.b_box_TextChanged);
            // 
            // bytes_box
            // 
            this.bytes_box.Location = new System.Drawing.Point(127, 38);
            this.bytes_box.Name = "bytes_box";
            this.bytes_box.Size = new System.Drawing.Size(211, 20);
            this.bytes_box.TabIndex = 9;
            this.bytes_box.Text = "0x0, 0x0, 0x3c, 0x24, 0x24, 0x3c, 0x0, 0x0";
            this.bytes_box.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.bytes_box.TextChanged += new System.EventHandler(this.bytes_box_TextChanged);
            // 
            // x_box
            // 
            this.x_box.Location = new System.Drawing.Point(127, 76);
            this.x_box.MaxLength = 5;
            this.x_box.Name = "x_box";
            this.x_box.Size = new System.Drawing.Size(50, 20);
            this.x_box.TabIndex = 10;
            this.x_box.Text = "0";
            this.x_box.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.x_box.TextChanged += new System.EventHandler(this.x_box_TextChanged);
            // 
            // y_box
            // 
            this.y_box.Location = new System.Drawing.Point(127, 110);
            this.y_box.MaxLength = 5;
            this.y_box.Name = "y_box";
            this.y_box.Size = new System.Drawing.Size(50, 20);
            this.y_box.TabIndex = 11;
            this.y_box.Text = "0";
            this.y_box.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.y_box.TextChanged += new System.EventHandler(this.y_box_TextChanged);
            // 
            // w_box
            // 
            this.w_box.Location = new System.Drawing.Point(127, 145);
            this.w_box.MaxLength = 5;
            this.w_box.Name = "w_box";
            this.w_box.Size = new System.Drawing.Size(50, 20);
            this.w_box.TabIndex = 12;
            this.w_box.Text = "0";
            this.w_box.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.w_box.TextChanged += new System.EventHandler(this.w_box_TextChanged);
            // 
            // h_box
            // 
            this.h_box.Location = new System.Drawing.Point(127, 180);
            this.h_box.MaxLength = 5;
            this.h_box.Name = "h_box";
            this.h_box.Size = new System.Drawing.Size(50, 20);
            this.h_box.TabIndex = 13;
            this.h_box.Text = "0";
            this.h_box.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.h_box.TextChanged += new System.EventHandler(this.h_box_TextChanged);
            // 
            // btn_use
            // 
            this.btn_use.Location = new System.Drawing.Point(12, 228);
            this.btn_use.Name = "btn_use";
            this.btn_use.Size = new System.Drawing.Size(153, 23);
            this.btn_use.TabIndex = 14;
            this.btn_use.Text = "Use";
            this.btn_use.UseVisualStyleBackColor = true;
            this.btn_use.Click += new System.EventHandler(this.btn_use_Click);
            // 
            // btn_clear
            // 
            this.btn_clear.Location = new System.Drawing.Point(171, 228);
            this.btn_clear.Name = "btn_clear";
            this.btn_clear.Size = new System.Drawing.Size(163, 23);
            this.btn_clear.TabIndex = 15;
            this.btn_clear.Text = "Clear";
            this.btn_clear.UseVisualStyleBackColor = true;
            this.btn_clear.Click += new System.EventHandler(this.btn_clear_Click);
            // 
            // Pattern_Brush
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(346, 262);
            this.Controls.Add(this.btn_clear);
            this.Controls.Add(this.btn_use);
            this.Controls.Add(this.h_box);
            this.Controls.Add(this.w_box);
            this.Controls.Add(this.y_box);
            this.Controls.Add(this.x_box);
            this.Controls.Add(this.bytes_box);
            this.Controls.Add(this.b_box);
            this.Controls.Add(this.g_box);
            this.Controls.Add(this.r_box);
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
            this.Name = "Pattern_Brush";
            this.ShowInTaskbar = false;
            this.Text = "Pattern Brush";
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
        private System.Windows.Forms.TextBox r_box;
        private System.Windows.Forms.TextBox g_box;
        private System.Windows.Forms.TextBox b_box;
        private System.Windows.Forms.TextBox bytes_box;
        private System.Windows.Forms.TextBox x_box;
        private System.Windows.Forms.TextBox y_box;
        private System.Windows.Forms.TextBox w_box;
        private System.Windows.Forms.TextBox h_box;
        private System.Windows.Forms.Button btn_use;
        private System.Windows.Forms.Button btn_clear;
    }
}