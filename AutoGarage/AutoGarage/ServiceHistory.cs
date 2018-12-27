using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AutoGarage.Controller;

namespace AutoGarage
{
    public partial class ServiceHistory : Form
    {
        private AutomobileController AutomobileController { get; set; }
        private MiscController MiscController { get; set; }
        private int AutomobileId { get; set; }

        public ServiceHistory()
        {
            InitializeComponent();
        }

        public ServiceHistory(int Id, AutomobileController automobileController, MiscController miscController)
        {
            InitializeComponent();
            this.AutomobileController = automobileController;
            this.MiscController = miscController;
            AutomobileId = Id;
        }

        private void ServiceHistory_Load(object sender, EventArgs e)
        {
          
        }
    }
}
