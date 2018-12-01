namespace AutoGarage
{
    partial class ServiceHistory
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
            this.lb_MH = new System.Windows.Forms.ListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.lbl_RegN = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lbl_Brand = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.lbl_Model = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.lbl_HP = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.lbl_Volume = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lb_MH
            // 
            this.lb_MH.FormattingEnabled = true;
            this.lb_MH.Location = new System.Drawing.Point(79, 257);
            this.lb_MH.Name = "lb_MH";
            this.lb_MH.Size = new System.Drawing.Size(549, 199);
            this.lb_MH.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(44, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(44, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Reg. N.";
            // 
            // lbl_RegN
            // 
            this.lbl_RegN.AutoSize = true;
            this.lbl_RegN.Location = new System.Drawing.Point(44, 66);
            this.lbl_RegN.Name = "lbl_RegN";
            this.lbl_RegN.Size = new System.Drawing.Size(35, 13);
            this.lbl_RegN.TabIndex = 2;
            this.lbl_RegN.Text = "label2";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(139, 26);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(35, 13);
            this.label3.TabIndex = 3;
            this.label3.Text = "Brand";
            // 
            // lbl_Brand
            // 
            this.lbl_Brand.AutoSize = true;
            this.lbl_Brand.Location = new System.Drawing.Point(139, 66);
            this.lbl_Brand.Name = "lbl_Brand";
            this.lbl_Brand.Size = new System.Drawing.Size(35, 13);
            this.lbl_Brand.TabIndex = 4;
            this.lbl_Brand.Text = "label4";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(232, 26);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(36, 13);
            this.label5.TabIndex = 5;
            this.label5.Text = "Model";
            // 
            // lbl_Model
            // 
            this.lbl_Model.AutoSize = true;
            this.lbl_Model.Location = new System.Drawing.Point(232, 66);
            this.lbl_Model.Name = "lbl_Model";
            this.lbl_Model.Size = new System.Drawing.Size(35, 13);
            this.lbl_Model.TabIndex = 6;
            this.lbl_Model.Text = "label6";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(327, 26);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(22, 13);
            this.label7.TabIndex = 7;
            this.label7.Text = "HP";
            // 
            // lbl_HP
            // 
            this.lbl_HP.AutoSize = true;
            this.lbl_HP.Location = new System.Drawing.Point(327, 66);
            this.lbl_HP.Name = "lbl_HP";
            this.lbl_HP.Size = new System.Drawing.Size(35, 13);
            this.lbl_HP.TabIndex = 8;
            this.lbl_HP.Text = "label8";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(416, 26);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(42, 13);
            this.label9.TabIndex = 9;
            this.label9.Text = "Volume";
            // 
            // lbl_Volume
            // 
            this.lbl_Volume.AutoSize = true;
            this.lbl_Volume.Location = new System.Drawing.Point(416, 66);
            this.lbl_Volume.Name = "lbl_Volume";
            this.lbl_Volume.Size = new System.Drawing.Size(41, 13);
            this.lbl_Volume.TabIndex = 10;
            this.lbl_Volume.Text = "label10";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(76, 212);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(104, 13);
            this.label11.TabIndex = 11;
            this.label11.Text = "Maintenance History";
            // 
            // ServiceHistory
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(717, 492);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.lbl_Volume);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.lbl_HP);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.lbl_Model);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.lbl_Brand);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.lbl_RegN);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lb_MH);
            this.Name = "ServiceHistory";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "ServiceHistory";
            this.Load += new System.EventHandler(this.ServiceHistory_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox lb_MH;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lbl_RegN;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lbl_Brand;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label lbl_Model;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label lbl_HP;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label lbl_Volume;
        private System.Windows.Forms.Label label11;
    }
}