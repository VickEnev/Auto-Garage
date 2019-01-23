using AutoGarage.Controller;
using AutoGarage.DataModel.MaintenanceCardDataModel;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AutoGarage
{
    public partial class ServiceHistory : Form
    {
        private AutomobileController AutomobileController { get; set; }
        private MiscController MiscController { get; set; }
        private int AutomobileId { get; set; }
        private IList<MaintenanceCardDataModel> Cards { get; set; }

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
            LoadServiceHistory();
            PopulateMaintenanceCardListBox();
        }

        private void LoadServiceHistory()
        {
            var viewModel = AutomobileController.GetServiceHistoryViewModel(AutomobileId);
            lbl_RegN.Text = viewModel.DRN;
            lbl_horsePower.Text = viewModel.HP.ToString();
            lbl_Brand.Text = viewModel.Brand.Name;
            lbl_Model.Text = viewModel.Model.Name;
            lbl_Volume.Text = viewModel.Volume;
        }

        private void PopulateMaintenanceCardListBox()
        {
            Task worker = new Task(() =>
            {
                Cards = AutomobileController
                    .GetMaintenanceCardDataModelsByChassisCode(
                    AutomobileController.GetAutomobileDataModel(AutomobileId).ChassiNumber);

                foreach (var c in Cards)
                {
                    DisplayCard(c);
                }

            });

            worker.Start();

        }

        private void DisplayCard(MaintenanceCardDataModel card)
        {
            var f = (card.Finished) ? "Finished" : "Not Finished";
            string d = $"Date of arrival: {card.DateOfArrival.ToShortDateString()} - Maintenance Status: {f}";
            this.Invoke(new Action(() => lb_MH.Items.Add(d)));
        }

        private void lb_MH_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            var card = new Card(AutomobileController, MiscController, Cards[lb_MH.SelectedIndex]);
            card.ShowDialog();
        }

        private void btn_add_Click(object sender, EventArgs e)
        {
            AutomobileController.AddMaintenanceCard(this.AutomobileId);
        }

        private void btn_refresh_Click(object sender, EventArgs e)
        {
            lb_MH.Items.Clear();
            PopulateMaintenanceCardListBox();
        }

        private void btn_delete_Click(object sender, EventArgs e)
        {
            var r = MessageBox.Show("Are you sure you want to delete this card?", "Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (r == DialogResult.Yes)
                AutomobileController.DeleteMaintenanceCard(AutomobileId, Cards[lb_MH.SelectedIndex].Id);
        }
    }
}
