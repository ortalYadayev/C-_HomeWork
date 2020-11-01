using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Event_RGBi_Square_Rectangle_Manager
{
    public class myEventArgs : EventArgs
    {
        public UserControl1 EventArgs_UC;
        public string EventArgs_ButtonLabel;
        public string EventArgs_MinMax;
        public string EventArgs_RectangleSquare;
        public string EventArgs_RGB;
    }
}
