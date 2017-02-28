using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace NFOGenerator.Forms
{
    public partial class frmAboutUs : Form
    {
        public frmAboutUs()
        {
            InitializeComponent();
        }

        private void llbOfficalSite_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start("https://github.com/metesa/NFOGenerator");
        }

        private void btnHandTea_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.MessageBox.Show("不要茶，要PY");
            this.Close();
        }

        private void btnNotHandTea_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.MessageBox.Show("哼！");
            this.Close();
        }
    }
}
