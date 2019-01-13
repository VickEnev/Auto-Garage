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
            lbl_cardNumber.Text = CardModel.Id.ToString();
            dtp_arrival.Value = CardModel.DateOfArrival;
            dtp_departure.Value = CardModel.DateOfDeparture;
            if (CardModel.Description != null)
                rtb_Description.Text = CardModel.Description;
            if (CardModel.EmployeeName != null)
                tb_Employee.Text = CardModel.EmployeeName;
            lbl_PPrice.Text = CardModel.TotalPrice.ToString();
            if (CardModel.Parts.Count > 0)
                lb_Parts.Items.AddRange(Array.ConvertAll(CardModel.Parts.ToArray(),
                    ConvertDataModel_To_ViewModel));
            cb_Finished.Checked = CardModel.Finished;

            tb_labour.Text = $"{ CardModel.TotalPrice - CardModel.Parts.Sum(p => p.Price)}";

            Task t = new Task(() =>
            {
                var name = AutomobileController.GetOwnerName(CardModel.AutomobileId);
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
                if (partsDialog.SelectedParts != null)
                    lb_Parts.Items.AddRange(partsDialog
                       .SelectedParts
                       .ToArray());

                decimal.TryParse(tb_labour.Text, out decimal labour);
                CardModel.TotalPrice = SumPartsPrice() + labour;

                lbl_PPrice.Text = CardModel.TotalPrice.ToString("C");
            }
        }

        // remove parts
        private void b_Remove_Click(object sender, EventArgs e)
        {
            if (lb_Parts.SelectedIndex > -1)
            {
                var part = ConvertViewModel_To_DataModel((PartsViewModel)lb_Parts.SelectedItem);
                MiscController.UnlinkPartsAndMaintenanceCards(part.Id, CardModel.Id);
                lb_Parts.Items.RemoveAt(lb_Parts.SelectedIndex);
            }

        }

        //update button
        private void b_OK_Click(object sender, EventArgs e)
        {
            UpdateMaintenanceCard();
        }

        private void b_CANCEL_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        private void UpdateMaintenanceCard()
        {
            if (ValidateInput())
            {
                var employeeName = tb_Employee.Text;
                double.TryParse(tb_labour.Text, out double labourPrice);
                var departureTime = dtp_departure.Value;
                var arrivalTime = dtp_arrival.Value;
                var description = rtb_Description.Text;
                var parts = Array.ConvertAll(
                    lb_Parts.Items.Cast<PartsViewModel>().ToArray(),
                    ConvertViewModel_To_DataModel);


                CardModel.DateOfDeparture = departureTime;
                CardModel.EmployeeName = employeeName;
                CardModel.Description = description;
                CardModel.DateOfDeparture = departureTime;

                if (CardModel.DateOfArrival.Date != arrivalTime.Date)
                CardModel.DateOfArrival = arrivalTime;

                foreach (var p in parts)
                {
                    MiscController.LinkPartsToMaintenanceCards(p.Id, this.CardModel.Id);
                }

                CardModel.Finished = cb_Finished.Checked;

                AutomobileController.SaveMaintenanceCard(CardModel);
                this.Close();
            }
            else
            {
                MessageBox.Show("Invalid Input!", "Error", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
            }
        }


        private bool ValidateInput()
        {
            if (dtp_departure.Value.Date >= dtp_arrival.Value.Date)
            {
                if (double.TryParse(tb_labour.Text, out double labourPrice))
                {
                    if (rtb_Description.Text != "")
                    {
                        if (tb_Employee.Text != "")
                        {
                            return true;
                        }
                    }
                }
            }
            return false;
        }

        private SparePartsDataModel ConvertViewModel_To_DataModel(PartsViewModel p)
        {
            return new SparePartsDataModel() { Id = p.Id, Name = p.Name, Price = p.Price };
        }

        private PartsViewModel ConvertDataModel_To_ViewModel(SparePartsDataModel p)
        {
            return new PartsViewModel() { Id = p.Id, Name = p.Name, Price = p.Price };
        }

        private decimal SumPartsPrice()
        {
            if (lb_Parts.Items.Count > 0)
                return
                       Math.Round(lb_Parts.Items.Cast<PartsViewModel>().Select(p => p.Price).Sum(), 2);
            return 0.00M;
        }

        private void tb_labour_Leave(object sender, EventArgs e)
        {
            if (decimal.TryParse(tb_labour.Text, out decimal labour))
                CardModel.TotalPrice = SumPartsPrice() + labour;

            lbl_PPrice.Text = CardModel.TotalPrice.ToString("C");
        }
    }


}
