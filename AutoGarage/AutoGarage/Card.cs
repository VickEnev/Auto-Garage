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
using AutoGarage.DataModel.MaintenanceCardDataModel;
using AutoGarage.DataModel.SparePartsDataModels;
using AutoGarage.ViewModels;

namespace AutoGarage
{
    public partial class Card : Form
    {

        private AutomobileController AutomobileController { get; set; }
        private MiscController MiscController { get; set; }
        private MaintenanceCardDataModel CardModel { get; set; }


        public Card()
        {
            InitializeComponent();
        }

        public Card(AutomobileController automobileController, MiscController miscController,
            MaintenanceCardDataModel card)
        {
            InitializeComponent();
            this.AutomobileController = automobileController;
            this.MiscController = miscController;
            this.CardModel = card;
        }

        private void Card_Load(object sender, EventArgs e)
        {
            AssignValues();
        }

        private void AssignValues()
        {
            dtp_arrival.Value = CardModel.DateOfArrival;
            Task t = new Task(() =>
            {
                var name = AutomobileController.GetOwnerNameByMaintenanceCardId(CardModel.Id);
                this.Invoke(new Action(() => { tb_Client.Text = name; }));
            });
            t.Start();
        }

        //add parts
        private void b_ADD_Click(object sender, EventArgs e)
        {
            var partsDialog = new PartsDialog(MiscController, true);
            if (partsDialog.ShowDialog() == DialogResult.OK)
            {
                if (lb_Parts.Items.Count > 0)
                    lb_Parts.Items.Clear();

                lb_Parts.Items.AddRange(partsDialog
                   .SelectedParts
                   .ConvertAll(new Converter<PartsViewModel, SparePartsDataModel>(ConvertViewModel))
                   .ToArray());

                if (decimal.TryParse(tb_labour.Text, out decimal labour))
                    CardModel.TotalPrice = SumPartsPrice() + labour;

                lbl_PPrice.Text = CardModel.TotalPrice.ToString();
            }
        }

        // remove parts
        private void b_Remove_Click(object sender, EventArgs e)
        {

        }

        //update button
        private void b_OK_Click(object sender, EventArgs e)
        {
            UpdateMaintenanceCard();
        }

        private void b_CANCEL_Click(object sender, EventArgs e)
        {

        }

        private void tb_labour_TextChanged(object sender, EventArgs e)
        {

        }

        private void UpdateMaintenanceCard()
        {
            var employeeName = tb_Employee.Text;
            double.TryParse(tb_labour.Text, out double labourPrice);
            var departureTime = dtp_departure.Value;
            var arrivalTime = dtp_arrival.Value;
            var description = rtb_Description.Text;

        }


        private bool ValidateInput()
        {
            if (dtp_departure.Value > dtp_arrival.Value)
            {
                double labourPrice = 0;
                if (double.TryParse(tb_labour.Text, out labourPrice))
                {
                    if (labourPrice > 0)
                    {
                        if (rtb_Description.Text != "")
                        {
                            if (tb_Employee.Text != "")
                            {
                                if (lb_Parts.Items.Count > 0)
                                {
                                    return true;
                                }
                            }
                        }
                    }
                }
            }
            return false;
        }

        private SparePartsDataModel ConvertViewModel(PartsViewModel p)
        {
            return new SparePartsDataModel() { Id = p.Id, Name = p.Name, Price = p.Price, IsDeleted = true };
        }

        private decimal SumPartsPrice()
        {
            return
                   Math.Round(lb_Parts.Items.Cast<SparePartsDataModel>().Select(p => p.Price).Sum(), 2);
        }
    }


}
