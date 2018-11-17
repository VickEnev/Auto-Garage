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
    public partial class Form1 : Form
    {
        AutomobileController AController; 

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            AController = new AutomobileController();
            LoadAutomobiles();
        }

        private void LoadAutomobiles()
        {
            var items = AController.getCarViewModel();
            foreach(var s in items)
            {
                listBox.Items.Add($"{s.DRN} / {s.ModelName}");
            }
        }


        private void addToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            var drn = listBox.SelectedItem
                //  .SelectedValue
                  ?.ToString()
                  .Split('/')[0];

            var ServiceForm = new ServiceHistory(drn);
              
            ServiceForm.ShowDialog();
        }

        
    }
}
