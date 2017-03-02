using System;
using System.Collections.Generic;
using System.Text;
using NFOGenerator.Tools.Zones;

namespace NFOGenerator.Tools.Zones
{
    class ZonesCommand
    {
        public int ranges { get; set; }
        public ZonesRange[] zonesRanges;

        public ZonesCommand(int ranges)
        {
            this.zonesRanges = new ZonesRange[ranges];
        }

        public string GetZonesCommand()
        {
            string command = "";

            for (int i = 0; i < this.ranges; i++)
            {
                command = command + this.zonesRanges[i].GetRangeCommand() + @"/";
            }

            return command;
        }
    }
}
