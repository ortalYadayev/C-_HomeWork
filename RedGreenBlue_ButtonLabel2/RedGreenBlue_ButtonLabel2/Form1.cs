using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.Threading;

namespace RedGreenBlue_ButtonLabel2
{
    public delegate void myAddDelegate(UserControl1 UC, int index, Control C, int width);
    public delegate void myRemoveDelegate(UserControl1 UC, int index);
    public partial class Form1 : Form
    {
        private UserControl1[] arrUC_From = new UserControl1[2], arrUC_To = new UserControl1[3], arrUC_Transport = new UserControl1[3];
        private Color[] arrColors = { Color.Red, Color.Green, Color.Blue };
        private int width_FromTo = 1000, maxCounter_FromTo = 80, width_Transport = 150, maxCounter_Transport = 8;

        private int[] arrFlag_ButtonLabel = { 0, 0, 0 };

        private int[] arrIndex_Transport = { 0, 0, 0 }; //max 8
        private int[] arrSize_Transport = { 2, 2, 2 };  // max 150 : controls + space between them

        private int[] arrCounter_To = { 0, 0, 0 };
        private int[] arrSize_To = { 2, 2, 2 }; // it bagins with 2 spaces

        private Thread[] arr_toTransport = new Thread[3], arr_fromTransport = new Thread[3];
        private AutoResetEvent[] arrAutoResetEvent_1 = new AutoResetEvent[3], arrAutoResetEvent_2 = new AutoResetEvent[3];

        public Form1()
        {
            InitializeComponent();

            this.Width = 1025;
            arrUC_From[0] = new UserControl1(width_FromTo, maxCounter_FromTo, "Full", "Button");
            arrUC_From[1] = new UserControl1(width_FromTo, maxCounter_FromTo, "Full", "Label");
            for (int i = 0; i < 2; i++)
            {
                arrUC_From[i].Location = new Point(2, 40 + 57 * i);
                this.Controls.Add(arrUC_From[i]);
            }
            
            for (int i = 0; i < 3; i++)
            {
                arrUC_Transport[i] = new UserControl1(width_Transport, maxCounter_Transport, "Empty", "");
                arrUC_Transport[i].Location = new Point(2 + (width_Transport + 8) * i, 161);
                this.Controls.Add(arrUC_Transport[i]);

                arrUC_To[i] = new UserControl1(width_FromTo, maxCounter_FromTo, "Empty", "");
                arrUC_To[i].Location = new Point(2, 220 + 57 * i);
                this.Controls.Add(arrUC_To[i]);

                arrAutoResetEvent_1[i] = new AutoResetEvent(false);
                arrAutoResetEvent_2[i] = new AutoResetEvent(false);
            }
        }
        private void startToolStripMenuItem_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < 3; i++)
            {
                arr_toTransport[i] = new Thread(toTransport_Function);
                arr_fromTransport[i] = new Thread(fromTransport_Function);

                arr_toTransport[i].Start(i);
                arr_fromTransport[i].Start(i);
            }
        }
        void toTransport_Function(object o)
        {
            int indexColor = (int)o;

            for (int j = 0; j < 2; j++)
            {
                for (int i = 0; i < maxCounter_FromTo; i++)
                {
                    Control temp = arrUC_From[j].arrControls[i];

                    if (temp != null && temp.BackColor == arrColors[indexColor])
                    {
                        if (arrSize_Transport[indexColor] + temp.Width > width_Transport)
                        {
                            arrAutoResetEvent_1[indexColor].Set();
                            arrAutoResetEvent_2[indexColor].WaitOne();
                        }

                        this.Invoke(new myAddDelegate(add), arrUC_Transport[indexColor], arrIndex_Transport[indexColor], temp, arrSize_Transport[indexColor]);
                        this.Invoke(new myRemoveDelegate(remove), arrUC_From[j], i);

                        arrIndex_Transport[indexColor]++;
                        arrSize_Transport[indexColor] += temp.Width + 2;
                        Thread.Sleep(200);

                        if (arrIndex_Transport[indexColor] == maxCounter_Transport)
                        {
                            arrAutoResetEvent_1[indexColor].Set();
                            arrAutoResetEvent_2[indexColor].WaitOne();
                        }
                    }
                }

                arrFlag_ButtonLabel[indexColor]++;
                if (arrFlag_ButtonLabel[indexColor] == 2)
                    break;
            }
            arrAutoResetEvent_1[indexColor].Set();
        }
        void fromTransport_Function(object o)
        {
            int indexColor = (int)o;

            while (true)
            {
                arrAutoResetEvent_1[indexColor].WaitOne();

                for (int i = 0; i < arrIndex_Transport[indexColor]; i++)
                {
                    Control temp = arrUC_Transport[indexColor].arrControls[i];

                    this.Invoke(new myAddDelegate(add), arrUC_To[indexColor], arrCounter_To[indexColor], temp, arrSize_To[indexColor]);
                    this.Invoke(new myRemoveDelegate(remove), arrUC_Transport[indexColor], i);

                    arrCounter_To[indexColor]++;
                    arrSize_To[indexColor] += temp.Width + 2;
                    Thread.Sleep(200);
                }

                if (arrFlag_ButtonLabel[indexColor] != 2)
                {
                    arrIndex_Transport[indexColor] = 0;
                    arrSize_Transport[indexColor] = 0;
                    arrAutoResetEvent_2[indexColor].Set();
                }
                else
                    break;
            }
        }

        private void add(UserControl1 UC, int index, Control C, int width_of_control)
        {
            UC.arrControls[index] = C;
            UC.Controls.Add(C);
            UC.arrControls[index].Location = new Point(width_of_control, 3);
        }

        private void remove(UserControl1 UC, int index)
        {
            UC.Controls.Remove(UC.arrControls[index]);
            UC.arrControls[index] = null;
        }
    }
}