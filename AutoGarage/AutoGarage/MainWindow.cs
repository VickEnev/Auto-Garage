using AutoGarage.ViewModels;
using System;
using System.Threading.Tasks;
using System.Windows.Forms;

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

        /// <summary>
        /// Асинхронно зарежда базата данни.
        /// </summary>
        private void LoadData()
        {
            var db = new Data.DatabaseController();
            var ex = new Exception();
            if (!db.CreateIfNotExists(out ex))
            {
                this.Invoke(new Action(() =>
                {
                    MessageBox.Show(ex.ToString(), "Creating Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
            DisplayResults(items.ToArray());
        }

        private void EnableMenuStrip()
        {
            foreach (var c in menuStrip1.Items)
            {
                try
                {
                    var strip = ((ToolStripMenuItem)c);
                    if (!strip.Name.Contains("noname"))
                        strip.Enabled = true;
                }
                catch (InvalidCastException)
                {
                    var strip = ((ToolStripComboBox)c);
                    if (!strip.Name.Contains("noname"))
                        strip.Enabled = true;
                }


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
            MessageBox.Show("Brand & Models Loaded!", "Done", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
            var model = Dependancies.AutomobileController.GetAutomobileDataModel(selected);

            AutomobileDataInput automobileDataInput = new AutomobileDataInput(Dependancies.MiscController,
             Dependancies.AutomobileController, model);
            automobileDataInput.ShowDialog();
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                var r = MessageBox.Show("Are you sure you want to delete this entry?", "Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (r == DialogResult.Yes)
                {
                    var selected = ((CarViewModel)lb_DataBox.SelectedItem).ID;
                    Dependancies.AutomobileController.DeleteAutomobile(selected);
                }
            }
            catch { }

        }

        private void refreshToolStripMenuItem_Click(object sender, EventArgs e)
        {          
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
            catch{ }
        }

        private void allPartsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var dialog = new PartsDialog(Dependancies.MiscController, false);
            dialog.ShowDialog();
        }

       
        private void toolStripFilterBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (toolStripFilterBox.SelectedIndex)
            {

                case 0:
                    {
                        dtp_Filter.Visible = false;
                        LoadAutomobiles();
                    }
                    break;
                case 1:
                case 2:
                    dtp_Filter.Visible = true;
                    break;
                case 3:
                    {
                        dtp_Filter.Visible = false;
                        Task w = new Task(() => GetAllAutosWithUnfinishedRepairs());
                        w.Start();
                    }
                    break;
            }
        }

        private void dtp_Filter_ValueChanged(object sender, EventArgs e)
        {
            switch (toolStripFilterBox.SelectedIndex)
            {
                case 1:
                    {
                        Task w = new Task(() => GetAllAutosAfterDate());
                        w.Start();
                    }
                    break;
                case 2:
                    {
                        Task w = new Task(() => GetAllAutosBeforeDate());
                        w.Start();
                    }
                    break;
            }

        }

        private void GetAllAutosAfterDate()
        {
            var results = Dependancies.AutomobileController.GetAutomobilesAfterDate(dtp_Filter.Value);
            DisplayResults(results);
        }

        private void GetAllAutosBeforeDate()
        {     
            var results = Dependancies.AutomobileController.GetAutomobilesBeforeDate(dtp_Filter.Value);
            DisplayResults(results);
        }

        private void GetAllAutosWithUnfinishedRepairs()
        {
            var results = Dependancies.AutomobileController.GetAllAutomobilesWithUnfinishedRepairs();
            DisplayResults(results);
        }

        private void DisplayResults(CarViewModel[] models)
        {
            this.Invoke(new Action(() =>
            {
                lb_DataBox.Items.Clear();
            }));

            foreach (var s in models)
            {
                this.Invoke(new Action(() =>
                {
                    lb_DataBox.Items.Add(s);
                }));

            }
        }


    }
}
