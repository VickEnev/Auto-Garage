using AutoGarage.Controller;
using AutoGarage.DataModel.SparePartsDataModels;
using System;
using System.Windows.Forms;

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
            LoadModel();
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
