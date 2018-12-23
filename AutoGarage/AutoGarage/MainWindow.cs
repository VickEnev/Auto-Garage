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
    public partial class MainWindow : Form
    {
        private Data.Dependancies Dependancies; 

        public MainWindow()
        {
            InitializeComponent();
            Dependancies = new Data.Dependancies();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            slbl_DBStatus.Text = "Database Connection: Connecting...";
            Task t = new Task(() => LoadData());
            t.Start();
        }

        private void LoadData()
        {
           
            var db = new Data.DatabaseController();
            var ex = new Exception();
            if(!db.CreateIfNotExists(out ex))
            {
                this.Invoke(new Action(() => 
                {
                    MessageBox.Show(ex.ToString(), "Creating Error",MessageBoxButtons.OK,MessageBoxIcon.Error);
                    slbl_DBStatus.Text = "Database Connection: Not Connected!";
                }));
            }
            else
            {
                
                LoadAutomobiles();
                this.Invoke(new Action(() =>
                {
                    slbl_DBStatus.Text = "Database Connection: Connected!";
                    EnableMenuStrip();
                }));
            }
           
        } 


        private void LoadAutomobiles()
        {
            var items = Dependancies.AutomobileController.getCarViewModel();
            foreach(var s in items)
            {              
                this.Invoke(new Action(() =>
                {
                    lb_DataBox.Items.Add($"Reg.#: {s.DRN} / Vehicle Model: {s.ModelName}");

                }));
                    
            }
        }

        private void EnableMenuStrip()
        {
            foreach(var c in menuStrip1.Items)
            {
                ((ToolStripMenuItem)c).Enabled = true;
            }
        }


        private void addToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AutomobileDataInput automobileDataInput = new AutomobileDataInput(Dependancies.MiscController,
                Dependancies.AutomobileController);
            automobileDataInput.ShowDialog();
        }

       

        private void loadBrandModelsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var dbInfoLoader = new Data.DatabaseInfoLoader(Application.StartupPath, Dependancies.MiscController);
            dbInfoLoader.LoadBrandsAndModels();
        }

        private void loadColorsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var dbInfoLoader = new Data.DatabaseInfoLoader(Application.StartupPath, Dependancies.MiscController);
            dbInfoLoader.LoadColorsFromFile();
        }
    }
}
