using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace NFOGenerator.Main.IMDb
{
    public partial class IMDbResult : UserControl
    {
        private SearchResults sr;
        
        public IMDbResult(SearchResults sr)
        {
            InitializeComponent();
            this.sr = sr;
        }

        /// <summary>
        /// Add movie info to search result control.
        /// </summary>
        /// <param name="paraPoster">Link to poster.</param>
        /// <param name="paraTitle">Movie title.</param>
        /// <param name="paraYear">Release year.</param>
        /// <param name="paraID">IMDb ID.</param>
        public void DisplayMovie(string paraPoster, string paraTitle, string paraYear, string paraID)
        {
            this.picIMDbPoster.ImageLocation = paraPoster;
            this.txtIMDbTitle.Text = paraTitle;
            this.txtIMDbYear.Text = paraYear;
            if (paraID != "")
            {
                this.lnkIMDbLink.Text = "http://www.imdb.com/title/" + paraID + "/";
            }
            else
            {
                this.lnkIMDbLink.Text = "";
            }
        }

        private void lnkIMDbLink_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start(this.lnkIMDbLink.Text);
        }

        private void btnIMDbSelect_Click(object sender, EventArgs e)
        {
            this.sr.LogSelectedMovie(this.txtIMDbTitle.Text, this.txtIMDbYear.Text, this.lnkIMDbLink.Text);
            this.sr.Close();
        }
    }

    public class IMDbResultSelectedEventArgs : EventArgs
    {
        public string title;
        public string year;
        public string link;

        public IMDbResultSelectedEventArgs()
        {
            this.title = "";
            this.year = "";
            this.link = "";
        }

        public IMDbResultSelectedEventArgs(string title, string year, string link)
        {
            this.title = title;
            this.year = year;
            this.link = link;
        }
    }
}
