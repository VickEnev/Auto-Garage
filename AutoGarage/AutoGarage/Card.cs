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

        }

        // remove parts
        private void b_Remove_Click(object sender, EventArgs e)
        {

        }

        //update button
        private void b_OK_Click(object sender, EventArgs e)
        {

        }

        private void b_CANCEL_Click(object sender, EventArgs e)
        {

        }
    }
}
