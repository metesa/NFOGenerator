using System;
using System.Collections.Generic;
using System.Text;

namespace NFOGenerator.Model.NFO.Line
{
    public class ImmutableLine : Line
    {
        public ImmutableLine(string line)
        {
            base.line = line;
        }
    }
}
