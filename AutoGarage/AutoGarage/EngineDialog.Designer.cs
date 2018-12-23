namespace AutoGarage
{
    partial class EngineDialog
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.tb_engVolume = new System.Windows.Forms.TextBox();
            this.tb_engCode = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btn_Add = new System.Windows.Forms.Button();
            this.btn_Cancel = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.lbl_CarModel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // tb_engVolume
            // 
            this.tb_engVolume.Location = new System.Drawing.Point(48, 39);
            this.tb_engVolume.Name = "tb_engVolume";
            this.tb_engVolume.Size = new System.Drawing.Size(151, 20);
            this.tb_engVolume.TabIndex = 1;
            // 
            // tb_engCode
            // 
            this.tb_engCode.Location = new System.Drawing.Point(48, 89);
            this.tb_engCode.Name = "tb_engCode";
            this.tb_engCode.Size = new System.Drawing.Size(151, 20);
            this.tb_engCode.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(45, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(78, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Engine Volume";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(45, 73);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(68, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Engine Code";
            // 
            // btn_Add
            // 
            this.btn_Add.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btn_Add.Location = new System.Drawing.Point(106, 186);
            this.btn_Add.Name = "btn_Add";
            this.btn_Add.Size = new System.Drawing.Size(75, 23);
            this.btn_Add.TabIndex = 6;
            this.btn_Add.Text = "Add";
            this.btn_Add.UseVisualStyleBackColor = true;
            this.btn_Add.Click += new System.EventHandler(this.btn_Add_Click);
            // 
            // btn_Cancel
            // 
            this.btn_Cancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btn_Cancel.Location = new System.Drawing.Point(187, 186);
            this.btn_Cancel.Name = "btn_Cancel";
            this.btn_Cancel.Size = new System.Drawing.Size(75, 23);
            this.btn_Cancel.TabIndex = 7;
            this.btn_Cancel.Text = "Cancel";
            this.btn_Cancel.UseVisualStyleBackColor = true;
            this.btn_Cancel.Click += new System.EventHandler(this.btn_Cancel_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(45, 120);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(55, 13);
            this.label3.TabIndex = 9;
            this.label3.Text = "Car Model";
            // 
            // lbl_CarModel
            // 
            this.lbl_CarModel.AutoSize = true;
            this.lbl_CarModel.Location = new System.Drawing.Point(45, 145);
            this.lbl_CarModel.Name = "lbl_CarModel";
            this.lbl_CarModel.Size = new System.Drawing.Size(113, 13);
            this.lbl_CarModel.TabIndex = 10;
            this.lbl_CarModel.Text = "Car Model placeholder";
            // 
            // EngineDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(274, 218);
            this.Controls.Add(this.lbl_CarModel);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btn_Cancel);
            this.Controls.Add(this.btn_Add);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tb_engCode);
            this.Controls.Add(this.tb_engVolume);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "EngineDialog";
            this.Text = "Engine Dialog";
            this.Load += new System.EventHandler(this.EngineDialog_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox tb_engVolume;
        private System.Windows.Forms.TextBox tb_engCode;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btn_Add;
        private System.Windows.Forms.Button btn_Cancel;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lbl_CarModel;
    }
}