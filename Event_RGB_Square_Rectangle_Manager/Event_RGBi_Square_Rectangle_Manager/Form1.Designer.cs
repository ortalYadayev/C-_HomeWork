namespace Event_RGBi_Square_Rectangle_Manager
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
            this.radioButtonBlue = new System.Windows.Forms.RadioButton();
            this.radioButtonGreen = new System.Windows.Forms.RadioButton();
            this.radioButtonRed = new System.Windows.Forms.RadioButton();
            this.Min_Max_label = new System.Windows.Forms.Label();
            this.Rectangle_Square_label = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // radioButtonBlue
            // 
            this.radioButtonBlue.AutoSize = true;
            this.radioButtonBlue.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.radioButtonBlue.Location = new System.Drawing.Point(601, 2);
            this.radioButtonBlue.Margin = new System.Windows.Forms.Padding(2);
            this.radioButtonBlue.Name = "radioButtonBlue";
            this.radioButtonBlue.Size = new System.Drawing.Size(59, 24);
            this.radioButtonBlue.TabIndex = 11;
            this.radioButtonBlue.Text = "Blue";
            this.radioButtonBlue.UseVisualStyleBackColor = true;
            // 
            // radioButtonGreen
            // 
            this.radioButtonGreen.AutoSize = true;
            this.radioButtonGreen.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.radioButtonGreen.Location = new System.Drawing.Point(514, 2);
            this.radioButtonGreen.Margin = new System.Windows.Forms.Padding(2);
            this.radioButtonGreen.Name = "radioButtonGreen";
            this.radioButtonGreen.Size = new System.Drawing.Size(72, 24);
            this.radioButtonGreen.TabIndex = 10;
            this.radioButtonGreen.Text = "Green";
            this.radioButtonGreen.UseVisualStyleBackColor = true;
            // 
            // radioButtonRed
            // 
            this.radioButtonRed.AutoSize = true;
            this.radioButtonRed.Checked = true;
            this.radioButtonRed.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.radioButtonRed.Location = new System.Drawing.Point(436, 2);
            this.radioButtonRed.Margin = new System.Windows.Forms.Padding(2);
            this.radioButtonRed.Name = "radioButtonRed";
            this.radioButtonRed.Size = new System.Drawing.Size(57, 24);
            this.radioButtonRed.TabIndex = 9;
            this.radioButtonRed.TabStop = true;
            this.radioButtonRed.Text = "Red";
            this.radioButtonRed.UseVisualStyleBackColor = true;
            // 
            // Min_Max_label
            // 
            this.Min_Max_label.Font = new System.Drawing.Font("Arial", 14F);
            this.Min_Max_label.Location = new System.Drawing.Point(11, 2);
            this.Min_Max_label.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.Min_Max_label.Name = "Min_Max_label";
            this.Min_Max_label.Size = new System.Drawing.Size(52, 24);
            this.Min_Max_label.TabIndex = 12;
            // 
            // Rectangle_Square_label
            // 
            this.Rectangle_Square_label.Font = new System.Drawing.Font("Arial", 14F);
            this.Rectangle_Square_label.Location = new System.Drawing.Point(78, 2);
            this.Rectangle_Square_label.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.Rectangle_Square_label.Name = "Rectangle_Square_label";
            this.Rectangle_Square_label.Size = new System.Drawing.Size(157, 24);
            this.Rectangle_Square_label.TabIndex = 13;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Aqua;
            this.ClientSize = new System.Drawing.Size(1204, 197);
            this.Controls.Add(this.Rectangle_Square_label);
            this.Controls.Add(this.Min_Max_label);
            this.Controls.Add(this.radioButtonBlue);
            this.Controls.Add(this.radioButtonGreen);
            this.Controls.Add(this.radioButtonRed);
            this.Name = "Form1";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.RadioButton radioButtonBlue;
        public System.Windows.Forms.RadioButton radioButtonGreen;
        public System.Windows.Forms.RadioButton radioButtonRed;
        public System.Windows.Forms.Label Min_Max_label;
        public System.Windows.Forms.Label Rectangle_Square_label;
    }
}

