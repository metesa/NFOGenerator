using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace NFOGenerator
{
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
        }

        private void btnGeneralGenerate_Click(object sender, EventArgs e)
        {
            
            // enable process button after generating release name
            this.btnProcess.Enabled = true;
        }
    }
}
