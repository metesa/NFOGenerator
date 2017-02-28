using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

using NFOGenerator.Model.General;
using NFOGenerator.Model.NFO.Line;

namespace NFOGenerator.Model.NFO
{
    class NFOTemplate
    {
        string firstLine = "\r\n" +
            "             ░ ░░░░    ░░░░░      ░░░░                ░░░      ░░░░    ░░░\r\n" +
            "  ░░░░░░░▒▒▒▒█▓████▒  ▒▒████░   ░▒▓██▒░             ░▒██▒░    ░███▒░░░▒██▒░\r\n" +
            "  ▒▒▓███████████▒▒▒░ ▒███▒██▓░  ░▒▓███▒    ░░░▒▒░░░░▒███▒░    ▒███▒░ ░▒███▓░\r\n" +
            "  ░▒▒▒▓██▒▒▒▒▒░░░   ░████░▒██░    ░▓██▒  ░▒▒██████▒░░████░    ░▒███▒  ░▒██▓░\r\n" +
            "     ░░▒█▒░░        ▒███▓░ ▓█▒░    ░██░  ▒████▒▒▒▒▒░ ▒███░░░░░▒▓▓███░  ░▒█▒\r\n" +
            "       ░█▒░        ░▓██▓░  ░██░    ░██▒  ▓███▒░ ░    ░▓██▓█████████▓░   ▒██░\r\n" +
            "        █░░        ░▓██▓▒▒░░▒█▓░   ▒███░ ▒███░        ░██▒▒░░░░ ░▓█▒   ░███▒\r\n" +
            "        ▓░░       ░▒███▓▒░  ░▒█▓░ ░▓███▒░░▒██▒░        ░▒░       ▒█▒   ▒███▓░░\r\n" +
            "        ▒░         ░▒▒▒▒░    ░▒█▓░ ░████░ ░▒▒███▓▓▒▒░░  ░▒        ░▓░  ░▒███▒░\r\n" +
            "        ░          ░░░░      ░▒▒░ ░▒▒░░    ░░░▒▒░░░░░             ░░   ░▒▒░░\r\n\r\n\r\n" +
            "                                                 ░░░░░░\r\n" +
            "                                               ▒▓████▓░\r\n" +
            "                                               ▓██████▒                ░░░░\r\n" +
            "                                               ▒██████░         ░░▒▒▒▒▓█▒▒█▓▒░\r\n" +
            "   Knowing others is intelligence.             ▒█████▓░▒▒▒▒▒▒▒▓█████▓▒░░  ▒▒▓░\r\n" +
            "                                              ░▒██████████████▒▒▒░░░       ░░\r\n" +
            "    Knowing yourself is true wisdom.        ░▒████████████▒░░░\r\n" +
            "                                            ▒███████████▓░       ░░\r\n" +
            "     Mastering others is strength.          ▒███████████░       ░██░\r\n" +
            "                                           ░███████████▓░░░░░░░░░██▒\r\n" +
            "      Mastering yourself is true power.   ░▓██████████████████████▓░\r\n" +
            "                                       ░▒▒███████████▒░▒▒▒▒▒▒░░░░░\r\n" +
            "                       --Lao Tzu     ░▒█████████████▒░░░░░\r\n" +
            "                                   ░░██████████████████████▓▒▒░░\r\n" +
            "                                ░▒▒█████████████████████████████▒░\r\n" +
            "                            ░░▒▒████████████████████████████████▒\r\n" +
            "                      ░░░░▒▓█████████████▓▒▒▒░░░░▒▒▒▒▒▒▒███████▓░\r\n" +
            "                  ░▒▒▓███████████████▓▒░░              ▒███████░\r\n" +
            "              ░▒▒▓████████████████▒▒░                 ░███████▒\r\n" +
            "          ░▒▒▓████████████████▒▒░░                   ░████████░\r\n" +
            "       ░▒▒██████████████▓▒▒░░░                      ░████████▒\r\n" +
            "      ░▓███░▒███████▒▒░░                           ░▓██████▒▒░\r\n" +
            "      ▒███▒  ░░░░░░                                 ░░░▒▒▒▓█▓▒\r\n" +
            "       ░░░░\r\n\r\n\r\n" +
            "╔═════════════════════════════════════════════════════════════════════════════╗\r\n" +
            "║█████╗ █████╗██╗   █████╗ █████╗ ██████╗██████╗   ██╗███╗  ██╗██████╗ █████╗ ║\r\n" +
            "║██╔═██╗██╔══╝██║   ██╔══╝██╔══██╗██╔═══╝██╔═══╝   ██║████╗ ██║██╔═══╝██╔══██╗║\r\n" +
            "║█████╔╝████╗ ██║   ████╗ ███████║██████╗████╗     ██║██╔██╗██║████╗  ██║  ██║║\r\n" +
            "║██╔═██╗██╔═╝ ██║   ██╔═╝ ██╔══██║╚═══██║██╔═╝     ██║██║╚████║██╔═╝  ██║  ██║║\r\n" +
            "║██║ ██║█████╗█████╗█████╗██║  ██║██████║██████╗   ██║██║ ╚███║██║    ╚█████╔╝║\r\n" +
            "║╚═╝ ╚═╝╚════╝╚════╝╚════╝╚═╝  ╚═╝╚═════╝╚═════╝   ╚═╝╚═╝  ╚══╝╚═╝     ╚════╝ ║\r\n" +
            "║                                                                             ║\r\n";
        string lineTitle = "";
        string lineEmpty = "║                                                                             ║\r\n";
        NFOInfo nfoInfo;
        NFOStyle nfoStyle;
        string lastLine = "║                                                                             ║\r\n" +
            "╚══════════════════════════════════════════════════════════════════════Rev.01═╝\r\n\r\n\r\n" +
            "                                   ░░         Greetings to all P2P and scene\r\n" +
            "                               ░▒▒▓▓▓▒▓▒▒░    groups/individuals who provided\r\n" +
            "                               ░▒████████▒    us with great sources!\r\n" +
            "     ░░░░                       ▒████████▒\r\n" +
            "    ░▓██▒                      ░▓███████▓░    Thanks to all TAiCHi members for\r\n" +
            "    ░███▒░                    ░▒▒███████░     your time and effort!\r\n" +
            "     ▓███░                      ░███████░\r\n" +
            "     ▒███▒░                     ░░▒█████▒░░░░░░░                ░░░░░░\r\n" +
            "     ░▒▓██▓▒░░               ░░░░▒▓█████████▓▓▓▓▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▓▓▓███▒░\r\n" +
            "      ░▒█████▓▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▓▓████████████████████████████████████████▓▒\r\n" +
            "      ░█████████████████████████████████████████████████████████▓▒▒▒░▒██▒\r\n" +
            "      ░░▒▒▓███████████████████████████████████████████████▓▒▒▒░░░░   ░▓░░\r\n" +
            "         ░░░░░▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▓██████████████████▒▒▒▒▒▒░░░░░░░        ░░\r\n" +
            "                            ░░█████████████████▒\r\n" +
            "                              ▒████████████████▒\r\n" +
            "                              ▒████████████████▓░\r\n" +
            "                              ░█████████████████░\r\n" +
            "                               ▒████████████████▒░\r\n" +
            "                              ░▓█████████████████▒░\r\n" +
            "                             ░▒███████████████████▒░\r\n" +
            "                           ░▒▒█████████████████████▒░\r\n" +
            "                         ░░▒████████████████████████▒░\r\n" +
            "                        ░▒▓██████████▓▒▒▒▒▓██████████▒\r\n" +
            "                      ░▒▓██████████▓▒░    ░▒██████████░\r\n" +
            "                    ░▒▓███████████▒░       ░▒█████████▓░\r\n" +
            "                  ░░▒███████████▓▒░          ▒█████████▒░\r\n" +
            "                  ░███████████▓▒░             ▒█████████▒\r\n" +
            "                  ▒████████▒▒░░                ▒█████████▒\r\n" +
            "                 ░████████░░                    ▒█████████▒░\r\n" +
            "                 ░███████▒                       ░▓████████▒░\r\n" +
            "                 ▒██████▓░                        ░▒████████▒░\r\n" +
            "                ░███████░                          ░▒▓███████▒░\r\n" +
            "                ░██████▓░                            ░▒███████▒░\r\n" +
            "                ▒██████▒                               ░▓██████▒░\r\n" +
            "                ▒██████░                                ░▒██████▒░\r\n" +
            "             ░░░▒██████░                                 ░▒▓█████▒░\r\n" +
            "          ░░▒▒█████████░                                   ░██████▓▒░\r\n" +
            "          ░▒▒▒▒▒▒▒░░░░░░                                   ░▒▒▒█████▓▒░\r\n" +
            "                                                             ░▒▓▓▓▒▒▒\r\n" +
            "                                                                 ░░\r\n";
        private ImmutableLine line1;

        public NFOTemplate(NFOInfo nfoInfo, NFOStyle nfoStyle)
        {
            this.nfoInfo = nfoInfo;
            this.nfoStyle = nfoStyle;
            
        }

        private string GenerateNfoText()
        {
            string fullText = firstLine;
            
            Dictionary<string, Alignment> nfoMutContent = nfoInfo.MapMutableValue();
            foreach (KeyValuePair<string, Alignment> dataPair in nfoMutContent)
            {
                fullText += new MutableLine(dataPair, nfoStyle).ToString();
            }

            fullText += lineEmpty;
            
            Dictionary<string, string> nfoDictContent = nfoInfo.MapDictionaryValue();
            foreach (KeyValuePair<string, string> dataPair in nfoDictContent)
            {
                fullText += new DictionaryLine(dataPair, nfoStyle).ToString();
            }

            fullText += lastLine;
            return fullText;
        }

        public void WriteToFile(string file)
        {
            string fullText = GenerateNfoText();
            using (StreamWriter sw = new StreamWriter(file))
            {
                sw.WriteLine(fullText);
                sw.Flush();
                sw.Close();
            }
        }

        public void TestWriteToFile()
        {
            using (StreamWriter sw = new StreamWriter(@"C:\TEST.txt"))
            {
                sw.WriteLine(firstLine);
                sw.Flush();
                sw.WriteLine(lastLine);
                sw.Flush();
                sw.Close();
            }
        }
    }
}
