using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AutoGarage
{
    public partial class ServiceHistory : Form
    {
        public string DRN { get; set; }

        public ServiceHistory()
        {
            InitializeComponent();
        }

        public ServiceHistory(string DRN)
        {
            InitializeComponent();
            this.DRN = DRN;
        }

        private void ServiceHistory_Load(object sender, EventArgs e)
        {
            System.Diagnostics.Debug.WriteLine(DRN);
        }
    }
}
