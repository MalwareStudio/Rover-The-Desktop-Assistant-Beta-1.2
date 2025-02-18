
namespace rover
{
    partial class Custom_Filter
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Custom_Filter));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.r_box = new System.Windows.Forms.TextBox();
            this.g_box = new System.Windows.Forms.TextBox();
            this.b_box = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(177, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Set your own color using RGB";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 33);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(15, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "R";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(13, 85);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(14, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "B";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 59);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(15, 13);
            this.label4.TabIndex = 3;
            this.label4.Text = "G";
            // 
            // r_box
            // 
            this.r_box.Location = new System.Drawing.Point(33, 30);
            this.r_box.MaxLength = 3;
            this.r_box.Name = "r_box";
            this.r_box.Size = new System.Drawing.Size(52, 20);
            this.r_box.TabIndex = 4;
            this.r_box.Text = "0";
            this.r_box.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.r_box.TextChanged += new System.EventHandler(this.r_box_TextChanged);
            // 
            // g_box
            // 
            this.g_box.Location = new System.Drawing.Point(33, 56);
            this.g_box.MaxLength = 3;
            this.g_box.Name = "g_box";
            this.g_box.Size = new System.Drawing.Size(52, 20);
            this.g_box.TabIndex = 5;
            this.g_box.Text = "0";
            this.g_box.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.g_box.TextChanged += new System.EventHandler(this.g_box_TextChanged);
            // 
            // b_box
            // 
            this.b_box.Location = new System.Drawing.Point(33, 82);
            this.b_box.MaxLength = 3;
            this.b_box.Name = "b_box";
            this.b_box.Size = new System.Drawing.Size(52, 20);
            this.b_box.TabIndex = 6;
            this.b_box.Text = "0";
            this.b_box.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.b_box.TextChanged += new System.EventHandler(this.b_box_TextChanged);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(114, 30);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 7;
            this.button1.Text = "Use";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(114, 76);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 8;
            this.button2.Text = "Clear";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // Custom_Filter
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(208, 111);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.b_box);
            this.Controls.Add(this.g_box);
            this.Controls.Add(this.r_box);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Custom_Filter";
            this.ShowInTaskbar = false;
            this.Text = "Custom Filter";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox r_box;
        private System.Windows.Forms.TextBox g_box;
        private System.Windows.Forms.TextBox b_box;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        public System.Windows.Forms.Label label1;
    }
}