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
using AutoGarage.DataModel.AutomobileDataModels;
using AutoGarage.ViewModels;
using AutoGarage.DataModel.SaveTokens;

namespace AutoGarage
{
    public partial class AutomobileDataInput : Form
    {
      
        private MiscController miscController { get; set; }
        private AutomobileController automobileController { get; set; }

        public AutomobileDataInput()
        {
            InitializeComponent();
            
        }

        public AutomobileDataInput(MiscController miscController, AutomobileController automobileController)
        {
            InitializeComponent();
            this.miscController = miscController;
            this.automobileController = automobileController;
        }



        private void btn_Add_Click(object sender, EventArgs e)
        {
            var token = new AutomobileSaveToken()
            {
                DRN = txt_DRN.Text,
                EngineID = ((EngineViewModel)cmb_Engine.SelectedItem).Id,
                Year = int.Parse(txt_Year.Text),
                ChassiNumber = txt_Chassi.Text,
                ColorId = ((ColorViewModel)cmb_Color.SelectedItem).Id,
                OwnerName = txt_Owner.Text,
                OwnerTelephoneNumber = txt_Telephone.Text,
                Description = rtxt_Description.Text
            };


            automobileController.SaveAutomobile(token);

            this.Close();
        }

        private void btn_Clear_Click(object sender, EventArgs e)
        {
            foreach(var c in this.Controls)
            {
                var type = c.GetType();
                if (type.Name == "TextBox")
                    ((TextBox)c).Clear();
                else if (type.Name == "RichTextBox")
                    ((RichTextBox)c).Clear();
                else if (type.Name == "ComboBox")
                    ((ComboBox)c).SelectedIndex = -1;
            }
        }

        private void AutomobileDataInput_Load(object sender, EventArgs e)
        {
            LoadDataIntoComboBoxes();
        }

        private void LoadDataIntoComboBoxes()
        {
            cmb_Brand.Items.AddRange(miscController.GetAllBrands().ToArray());
            cmb_Color.Items.AddRange(miscController.GetAllColors().ToArray());     
        }

        private void LoadEngines(string modelName)
        {
            cmb_Engine.Items.Clear();
            var engines = miscController.GetAllEnginesByModel(modelName);
            if (engines != null)
            {
                cmb_Engine.Items.AddRange(engines.ToArray());
            }
            cmb_Engine.Items.Add("Add New Engine");
        }

        private void ComboBoxItemSelected(object sender, EventArgs args)
        {
            if (((ComboBox)sender).Name == "cmb_Engine")
            {
                try
                {
                    if ((string)(((ComboBox)sender).SelectedItem) == "Add New Engine")
                    {
                        var EngineDialog = new EngineDialog(((CarModelViewModel)cmb_Model.SelectedItem).Name, 
                            cmb_Brand.SelectedItem.ToString(),
                            miscController);

                        if (EngineDialog.ShowDialog() == DialogResult.OK)
                        {
                            var result = EngineDialog.EngineModel;
                            miscController.WriteEngineDataModelToDatabase(result);
                            LoadEngines(cmb_Model.SelectedItem.ToString());
                        }
                    }
                }
                catch (InvalidCastException)
                {

                }
               
            }
        }

        private void cmb_Brand_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(cmb_Brand.SelectedIndex != -1)
            {
                cmb_Model.Items.Clear();
                cmb_Model.Enabled = true;
                var models = miscController.GetAllModels(cmb_Brand.SelectedItem.ToString());
                cmb_Model.Items.AddRange(models.ToArray());               
            }
        }

        private void cmb_Model_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(cmb_Model.SelectedIndex != -1 )
            {
                cmb_Engine.Items.Clear();
                LoadEngines(cmb_Model.SelectedItem.ToString());
                cmb_Engine.Enabled = true;
            }
        }
    }



}
