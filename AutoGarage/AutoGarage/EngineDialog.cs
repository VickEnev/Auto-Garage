using AutoGarage.Controller;
using AutoGarage.DataModel.AutomobileDataModels;
using System;
using System.Windows.Forms;

namespace AutoGarage
{


    public partial class EngineDialog : Form
    {
        public EngineDataModel EngineModel { get; set; }
        private string CarModelName { get; set; }
        private string BrandName { get; set; }
        private MiscController miscController { get; set; }


        public EngineDialog()
        {
            InitializeComponent();
        }

        public EngineDialog(string CarModel, string BrandName, MiscController miscController)
        {
            InitializeComponent();
            this.CarModelName = CarModel;
            this.BrandName = BrandName;
            this.miscController = miscController;
        }

        private void EngineDialog_Load(object sender, EventArgs e)
        {
            lbl_CarModel.Text = CarModelName;
        }

        private void btn_Add_Click(object sender, EventArgs e)
        {
            if (tb_engCode.Text != "" && tb_engVolume.Text != "" && int.TryParse(tb_horsePower.Text, out int hp))
            {
                var carModel = miscController.GetModelByName(CarModelName, BrandName);
                EngineModel = new EngineDataModel()
                {
                    EngineNumber = tb_engCode.Text,
                    Volume = tb_engVolume.Text,
                    CarModel = carModel,
                    CarModelId = carModel.Id,
                    Horsepower = hp
                };
            }
            else
            {
                MessageBox.Show("Please Enter Valid Values", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                DialogResult = DialogResult.None;
            }
        }

        private void btn_Cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }


    }
}
