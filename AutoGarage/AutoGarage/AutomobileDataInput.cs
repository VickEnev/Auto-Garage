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
    /// <summary>
    /// Adds or Updates an Automobile
    /// </summary>
    public partial class AutomobileDataInput : Form
    {

        private MiscController miscController { get; set; }
        private AutomobileController automobileController { get; set; }
        private AutomobileDataModel Model { get; set; }

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

        /// <summary>
        /// Update Constructor. Call if you want to load an automobile for updates. 
        /// </summary>
        /// <param name="miscController">Controller for small operations - side table controller</param>
        /// <param name="automobileController">Controller for the automobile table.</param>
        /// <param name="Model">The AutomobileDataModel you are going to update.</param>
        public AutomobileDataInput(MiscController miscController, AutomobileController automobileController, AutomobileDataModel Model)
        {
            InitializeComponent();
            this.miscController = miscController;
            this.automobileController = automobileController;
            this.Model = Model;
        }

        /// <summary>
        /// Loads Information from the Data Model to the form fields. Only usable when there is a model.
        /// </summary>
        private void UpdateFormFields()
        {
            if (Model != null)
            {

                txt_DRN.Text = Model.DRN;
                cmb_Brand.Text = Model.Engine.CarModel.CarBrand.Name;
                LoadModels(Model.Engine.CarModel.CarBrand.Name);
                cmb_Model.Text = Model.Engine.CarModel.Name;
                LoadEngines(Model.Engine.CarModel.Name);
                txt_Year.Text = Model.Year.ToString();
                cmb_Engine.Text = (new EngineViewModel()
                { Volume = Model.Engine.Volume, EngineNumber = Model.Engine.EngineNumber, Id = Model.Engine.Id }).ToString();
                txt_Chassi.Text = Model.ChassiNumber;
                cmb_Color.SelectedIndex = Model.ColorId - 1;
                txt_Owner.Text = Model.Owner.Name;
                txt_Telephone.Text = Model.Owner.TelephoneNumber;
                rtxt_Description.Text = Model.Description;

                btn_Add.Text = "Update";
                btn_Clear.Visible = false;
            }
        }


        private void btn_Add_Click(object sender, EventArgs e)
        {
            if (Validation())
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

                if (Model == null)
                    automobileController.SaveAutomobile(token);
                else
                    automobileController.UpdateAutomobile(token, Model);



                this.Close();
            }
        }

        private void btn_Clear_Click(object sender, EventArgs e)
        {
            foreach (var c in this.Controls)
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
            UpdateFormFields();
        }

        private void LoadEngines(string modelName)
        {
            cmb_Engine.Items.Clear();
            cmb_Engine.Enabled = true;
            var engines = miscController.GetAllEnginesByModel(modelName);
            if (engines != null)
            {
                cmb_Engine.Items.AddRange(engines.ToArray());
            }
            cmb_Engine.Items.Add("Add New Engine");
        }

        private void LoadModels(string brandName)
        {
            cmb_Model.Items.Clear();
            cmb_Model.Enabled = true;
            var models = miscController.GetAllModels(brandName);
            cmb_Model.Items.AddRange(models.ToArray());
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
                catch (InvalidCastException) { }
            }
        }

        private void cmb_Brand_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmb_Brand.SelectedIndex != -1)
            {
                LoadModels(cmb_Brand.SelectedItem.ToString());
            }
        }

        private void cmb_Model_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmb_Model.SelectedIndex != -1)
            {
                LoadEngines(cmb_Model.SelectedItem.ToString());
            }
        }

        private bool Validation()
        {
            if (txt_Telephone.Text.Length < 10)
            {
                MessageBox.Show("Invalid telephone number!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (txt_Year.Text.Length < 4)
            {
                MessageBox.Show("Invalid year!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (txt_Owner.Text.Length < 2)
            {
                MessageBox.Show("Enter a valid owner name!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (cmb_Brand.SelectedIndex == -1)
            {
                MessageBox.Show("Select a brand!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (cmb_Color.SelectedIndex == -1)
            {
                MessageBox.Show("Select a color!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (cmb_Model.SelectedIndex == -1)
            {
                MessageBox.Show("Select a model!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (cmb_Engine.SelectedIndex == -1)
            {
                MessageBox.Show("Select an engine!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (txt_Chassi.Text.Length < 1)
            {
                MessageBox.Show("Enter a valid chassi number!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if(rtxt_Description.Text.Length < 1)
            {
                MessageBox.Show("Enter a valid descripion!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            return true;

        }

    }



}
