using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoilDetect
{
    public class SJRControlCData : EventArgs
    {
        public float Time { get; set; }
        public float LoopNum { get; set; }
        public float CarOrNot { get; set; }
        public float TroubleState { get; set; }
        public double Speed { get; set; }
    }
}
