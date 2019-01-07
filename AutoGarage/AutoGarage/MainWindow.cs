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
using AutoGarage.ViewModels;

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
            refreshToolStripMenuItem_Click(sender, e);
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
                    lb_DataBox.Items.Add(s);
                }));
                    
            }
        }

        private void EnableMenuStrip()
        {
            foreach(var c in menuStrip1.Items)
            {
                var strip = ((ToolStripMenuItem)c);
                if(!strip.Name.Contains("noname"))
                strip.Enabled = true;
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
            MessageBox.Show("Brand & Models Loaded!","Done",MessageBoxButtons.OK,MessageBoxIcon.Information);
        }

        private void loadColorsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var dbInfoLoader = new Data.DatabaseInfoLoader(Application.StartupPath, Dependancies.MiscController);
            dbInfoLoader.LoadColorsFromFile();
            MessageBox.Show("Colors Loaded!", "Done", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var selected = ((CarViewModel)lb_DataBox.SelectedItem).ID;
            var model = Dependancies.AutomobileController.LoadAutomobile(selected);

            AutomobileDataInput automobileDataInput = new AutomobileDataInput(Dependancies.MiscController,
             Dependancies.AutomobileController, model);
            automobileDataInput.ShowDialog();
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                var selected = ((CarViewModel)lb_DataBox.SelectedItem).ID;
                Dependancies.AutomobileController.DeleteAutomobile(selected);
            }
            catch (Exception ex) { }
         
        }

        private void refreshToolStripMenuItem_Click(object sender, EventArgs e)
        {
            lb_DataBox.Items.Clear();
            Task t = new Task(() => LoadData());
            t.Start();
        }

        private void lb_DataBox_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            try
            {
                var selected = ((CarViewModel)lb_DataBox.SelectedItem).ID;
                ServiceHistory serviceHistory = new ServiceHistory(selected, Dependancies.AutomobileController, Dependancies.MiscController);
                serviceHistory.ShowDialog();
            }
            catch (Exception ex) { }
        }

        private void allPartsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var dialog = new PartsDialog(Dependancies.MiscController,false);
            dialog.ShowDialog();
        }
    }
}
