using System;
using System.Collections.Generic;
using System.Text;

namespace NFOGenerator.Tools.Zones
{
    class ZonesRange
    {
        public string rangeStart { get; set; }
        public string rangeEnd { get; set; }
        public ZoneMode rangeMode;
        public double rangePara { get; set; }

        public ZonesRange(string start, string end, ZoneMode mode, double para)
        {
            this.rangeStart = start;
            this.rangeEnd = end;
            this.rangeMode = mode;
            this.rangePara = para;
        }

        public string GetRangeCommand()
        {
            string command = this.rangeStart + "," + this.rangeEnd + "," + this.rangeMode.ToString() + 
                "=" + this.rangePara.ToString();
            return command;
        }
    }

    public enum ZoneMode
    {
        crf = 0,
        b = 1
    }
}
