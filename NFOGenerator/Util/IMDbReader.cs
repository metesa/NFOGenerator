using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;

namespace NFOGenerator.Util
{
    class IMDbReader
    {
        public string title { get; set; }
        public WebRequest omdbRequest = new WebRequest();

    }
}
