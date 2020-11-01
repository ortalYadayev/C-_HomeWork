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
    public partial class Manager : Form
    {
        private Form1 myForm_1 = null, myForm_2 = null;
        private Random myRand = new Random();

        private int counterEvents = 0;
        private UserControl1 button_UC = null, label_UC = null;
        private string button_MinMax = "", label_MinMax = "";
        private string button_RectangleSquare = "", label_RectangleSquare = "";
        private string button_RGB = "", label_RGB = "";
        private Control button_MinMax_RectangleSquare_control = null, label_MinMax_RectangleSquare_control = null;

        private List<Control> buttonList = new List<Control>(), labelList = new List<Control>();

        public Manager()
        {
            InitializeComponent();

            string ButtonLabel1 = "Button", ButtonLabel2 = "Label";
            if (myRand.Next(2) == 0)
            {
                ButtonLabel1 = "Label"; ButtonLabel2 = "Button";
            }

            string MinMax1 = "Min", MinMax2 = "Max";
            if (myRand.Next(2) == 0)
            {
                MinMax1 = "Max"; MinMax2 = "Min";
            }

            string RectangleSquare1 = "Rectangle", RectangleSquare2 = "Square";
            if (myRand.Next(2) == 0)
            {
                RectangleSquare1 = "Square"; RectangleSquare2 = "Rectangle";
            }

            myForm_1 = new Form1(ButtonLabel1, MinMax1, RectangleSquare1);
            myForm_1.event_From_Form += new MyEventHadler(Manager_event_FromForm);
            myForm_1.Show();
            myForm_2 = new Form1(ButtonLabel2, MinMax2, RectangleSquare2);
            myForm_2.event_From_Form += new MyEventHadler(Manager_event_FromForm);
            myForm_2.Show();

            this.FormBorderStyle = FormBorderStyle.None;
            this.TransparencyKey = SystemColors.Control;
            this.ShowInTaskbar = false;
        }

        private void Manager_event_FromForm(object sender, myEventArgs e)
        {
            if (e.EventArgs_ButtonLabel == "Button")
            {
                button_UC = e.EventArgs_UC;
                button_MinMax = e.EventArgs_MinMax;
                button_RectangleSquare = e.EventArgs_RectangleSquare;
                button_RGB = e.EventArgs_RGB;
                button_MinMax_RectangleSquare_control = ((Form1)sender).ButtonLabel_MinMax_RectangleSquare_control;
            }
            else
            {
                label_UC = e.EventArgs_UC;
                label_MinMax = e.EventArgs_MinMax;
                label_RectangleSquare = e.EventArgs_RectangleSquare;
                label_RGB = e.EventArgs_RGB;
                label_MinMax_RectangleSquare_control = ((Form1)sender).ButtonLabel_MinMax_RectangleSquare_control;
            }

            counterEvents++;
            if (counterEvents == 2)
                Action();
        }
        void Action()
        {
            if (button_UC == null)
            {
                MessageBox.Show("There is a problem with button");
                return;       
            }
            if (label_UC == null)
            {
                MessageBox.Show("There is a problem with label");
                return;
            }
              
            for (int i = 0; i < button_UC.arrControls.Length; i++)
            {
                if (button_UC.arrControls[i].GetType().Name == "Button")
                    buttonList.Add(button_UC.arrControls[i]);
                else
                    labelList.Add(button_UC.arrControls[i]);
            }

            for (int i = 0; i < label_UC.arrControls.Length; i++)
            {
                if (label_UC.arrControls[i].GetType().Name == "Button")
                    buttonList.Add(label_UC.arrControls[i]);
                else
                    labelList.Add(label_UC.arrControls[i]);
            }

            buttonList = filter_RGB_RectangleSquare(buttonList, button_RGB, button_RectangleSquare);
            labelList = filter_RGB_RectangleSquare(labelList, label_RGB, label_RectangleSquare);

            buttonList.Sort((x, y) => x.Width * x.Height - y.Width * y.Height);
            labelList.Sort((x, y) => x.Width * x.Height - y.Width * y.Height);

            button_MinMax_RectangleSquare_control.Text = (buttonList.Count).ToString();
            button_MinMax_RectangleSquare_control.Font = new Font("Microsoft Sans Serif", 15, FontStyle.Regular);
            label_MinMax_RectangleSquare_control.Text = (labelList.Count).ToString();
            label_MinMax_RectangleSquare_control.Font = new Font("Microsoft Sans Serif", 15, FontStyle.Regular);

            if (button_MinMax == "Min")
            {
                Arrange(button_UC, buttonList[0]);
                Arrange(label_UC, labelList[labelList.Count - 1]);
            }
            else
            {
                Arrange(button_UC, buttonList[buttonList.Count - 1]);
                Arrange(label_UC, labelList[0]);
            }
        } 
           List<Control> filter_RGB_RectangleSquare(List<Control> tempList, string strRGB, string strRectangleSquare)
        {
            List<Control> returnList = new List<Control>();
            for (int i = 0; i < tempList.Count; i++)
            {
                Control tempControl = tempList[i];
                if (tempControl.BackColor.Name == strRGB
                    &&
                    (tempControl.Width == tempControl.Height && strRectangleSquare == "Square"
                    ||
                    tempControl.Width != tempControl.Height && strRectangleSquare == "Rectangle"))
                {
                    tempControl.Text = "x";
                    tempControl.Font = new Font("Microsoft Sans Serif", 14, FontStyle.Regular);
                    returnList.Add(tempList[i]);
                }
            }
            return returnList;
        }

        void Arrange(UserControl1 UC, Control tempList)
        {
            UC.Controls.Clear();
            Control tempControl = tempList;
            tempControl.Location = new Point(2, 2);
            UC.Controls.Add(tempControl);
        }
    }
}