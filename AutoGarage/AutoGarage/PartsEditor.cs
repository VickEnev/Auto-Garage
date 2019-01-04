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
using AutoGarage.DataModel.SparePartsDataModels;

namespace AutoGarage
{
    public partial class PartsEditor : Form
    {
        private MiscController MiscController { get; set; }
        private SparePartsDataModel Model { get; set; }

        public PartsEditor()
        {
            InitializeComponent();
        }

        public PartsEditor(MiscController miscController)
        {
            InitializeComponent();
            this.MiscController = miscController;
        }

        public PartsEditor(MiscController miscController, SparePartsDataModel model)
        {
            InitializeComponent();
            this.MiscController = miscController;
            this.Model = model;
        }

        private void LoadModel()
        {
            tb_Name.Text = Model.Name;
            tb_Price.Text = Model.Price.ToString();
        }

        private void btn_OK_Click(object sender, EventArgs e)
        {
            if (decimal.TryParse(tb_Price.Text, out decimal price) && price > 0)
            {
                if (Model == null)
                    Model = new SparePartsDataModel();

                Model.Name = tb_Name.Text;
                Model.Price = price;
                Model.IsDeleted = false;
                MiscController.AddOrUpdateParts(Model);
            }
            else
            {
                MessageBox.Show("Invalid Price", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btn_CANCEL_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
