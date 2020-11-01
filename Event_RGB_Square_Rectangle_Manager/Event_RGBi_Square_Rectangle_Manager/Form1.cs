using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Event_RGBi_Square_Rectangle_Manager
{
    public partial class Form1 : Form
    {
        public UserControl1[] arrUC = new UserControl1[2];
        public Control ButtonLabel_MinMax_RectangleSquare_control = null;

        public event MyEventHadler event_From_Form;
        public Form1(string ButtonLabel, string MinMax, string RectangleSquare)
        {
            InitializeComponent();

            for (int i = 0; i < 2; i++)
            {
                arrUC[i] = new UserControl1();
                arrUC[i].Location = new Point(100, 27 + 85 * i);
                arrUC[i].event_FromUC += new MyEventHadler(Form_event_FromUC);
                this.Controls.Add(arrUC[i]);
            }
            this.Text = ButtonLabel;
            Min_Max_label.Text = MinMax;
            Rectangle_Square_label.Text = RectangleSquare;

            if (ButtonLabel == "Button")
                ButtonLabel_MinMax_RectangleSquare_control = new Button();
            else
                ButtonLabel_MinMax_RectangleSquare_control = new Label();
            ButtonLabel_MinMax_RectangleSquare_control.Size = new Size(40, 40);
            ButtonLabel_MinMax_RectangleSquare_control.BackColor = Color.White;
            ButtonLabel_MinMax_RectangleSquare_control.Location = new Point(2, 60);
            this.Controls.Add(ButtonLabel_MinMax_RectangleSquare_control);
        }
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }
        private void Form_event_FromUC(object sender, myEventArgs e)
        {
            e.EventArgs_ButtonLabel = this.Text;
            e.EventArgs_MinMax = Min_Max_label.Text;
            e.EventArgs_RectangleSquare = Rectangle_Square_label.Text;

            if (radioButtonRed.Checked)
                e.EventArgs_RGB = "Red";
            if (radioButtonGreen.Checked)
                e.EventArgs_RGB = "Green";
            if (radioButtonBlue.Checked)
                e.EventArgs_RGB = "Blue";

            if (event_From_Form != null)
                event_From_Form(this, e);
        }
    }
}