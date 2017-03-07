using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using NFOGenerator.Forms;

namespace NFOGenerator.Main.IMDb
{
    public partial class SearchResults : Form
    {
        public string selectedTitle;
        public string selectedYear;
        public string selectedLink;

        public SearchResults(string title, string year, string link)
        {
            InitializeComponent();
            this.selectedTitle = title;
            this.selectedYear = year;
            this.selectedLink = link;
        }

        public void LogSelectedMovie(string title, string year, string link)
        {
            this.selectedTitle = title;
            this.selectedYear = year;
            this.selectedLink = link;
        }
    }
}
