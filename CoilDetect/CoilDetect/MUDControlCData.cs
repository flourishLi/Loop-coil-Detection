using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoilDetect
{
    public class MUDControlCData:EventArgs
    {
        public float A { get; set; }
        public float B { get; set; }
        public float C { get; set; }
        public float D { get; set; }
        public double Time { get; set; }
        public double Speed { get; set; }
        public float OneZero { get; set; }
        public bool State { get; set; }
    }
}
