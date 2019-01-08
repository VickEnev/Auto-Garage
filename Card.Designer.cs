namespace AutoGarage
{
    partial class Card
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.lbl_PPrice = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.tb_Client = new System.Windows.Forms.TextBox();
            this.tb_Employee = new System.Windows.Forms.TextBox();
            this.tb_labour = new System.Windows.Forms.TextBox();
            this.lb_Parts = new System.Windows.Forms.ListBox();
            this.b_ADD = new System.Windows.Forms.Button();
            this.b_Remove = new System.Windows.Forms.Button();
            this.b_OK = new System.Windows.Forms.Button();
            this.b_CANCEL = new System.Windows.Forms.Button();
            this.dtp_arrival = new System.Windows.Forms.DateTimePicker();
            this.dtp_departure = new System.Windows.Forms.DateTimePicker();
            this.rtb_Description = new System.Windows.Forms.RichTextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(28, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(64, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Client Name";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(28, 56);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(73, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Date of arrival";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(28, 84);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(90, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Date of departure";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(28, 114);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(84, 13);
            this.label4.TabIndex = 3;
            this.label4.Text = "Employee Name";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(28, 147);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(58, 13);
            this.label5.TabIndex = 4;
            this.label5.Text = "Parts Price";
            // 
            // lbl_PPrice
            // 
            this.lbl_PPrice.AutoSize = true;
            this.lbl_PPrice.Location = new System.Drawing.Point(121, 147);
            this.lbl_PPrice.Name = "lbl_PPrice";
            this.lbl_PPrice.Size = new System.Drawing.Size(46, 13);
            this.lbl_PPrice.TabIndex = 5;
            this.lbl_PPrice.Text = "$000.00";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(28, 187);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(67, 13);
            this.label7.TabIndex = 6;
            this.label7.Text = "Labour Price";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(501, 23);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(31, 13);
            this.label8.TabIndex = 7;
            this.label8.Text = "Parts";
            // 
            // tb_Client
            // 
            this.tb_Client.BackColor = System.Drawing.Color.White;
            this.tb_Client.Location = new System.Drawing.Point(124, 20);
            this.tb_Client.Name = "tb_Client";
            this.tb_Client.ReadOnly = true;
            this.tb_Client.Size = new System.Drawing.Size(100, 20);
            this.tb_Client.TabIndex = 8;
            // 
            // tb_Employee
            // 
            this.tb_Employee.Location = new System.Drawing.Point(124, 111);
            this.tb_Employee.Name = "tb_Employee";
            this.tb_Employee.Size = new System.Drawing.Size(100, 20);
            this.tb_Employee.TabIndex = 11;
            // 
            // tb_labour
            // 
            this.tb_labour.Location = new System.Drawing.Point(124, 180);
            this.tb_labour.Name = "tb_labour";
            this.tb_labour.Size = new System.Drawing.Size(100, 20);
            this.tb_labour.TabIndex = 12;
            this.tb_labour.Leave += new System.EventHandler(this.tb_labour_Leave);
            // 
            // lb_Parts
            // 
            this.lb_Parts.FormattingEnabled = true;
            this.lb_Parts.Location = new System.Drawing.Point(407, 47);
            this.lb_Parts.Name = "lb_Parts";
            this.lb_Parts.Size = new System.Drawing.Size(199, 199);
            this.lb_Parts.TabIndex = 13;
            // 
            // b_ADD
            // 
            this.b_ADD.Location = new System.Drawing.Point(407, 277);
            this.b_ADD.Name = "b_ADD";
            this.b_ADD.Size = new System.Drawing.Size(65, 23);
            this.b_ADD.TabIndex = 14;
            this.b_ADD.Text = "Add";
            this.b_ADD.UseVisualStyleBackColor = true;
            this.b_ADD.Click += new System.EventHandler(this.b_ADD_Click);
            // 
            // b_Remove
            // 
            this.b_Remove.Location = new System.Drawing.Point(542, 277);
            this.b_Remove.Name = "b_Remove";
            this.b_Remove.Size = new System.Drawing.Size(64, 23);
            this.b_Remove.TabIndex = 15;
            this.b_Remove.Text = "Remove";
            this.b_Remove.UseVisualStyleBackColor = true;
            this.b_Remove.Click += new System.EventHandler(this.b_Remove_Click);
            // 
            // b_OK
            // 
            this.b_OK.Location = new System.Drawing.Point(31, 348);
            this.b_OK.Name = "b_OK";
            this.b_OK.Size = new System.Drawing.Size(75, 23);
            this.b_OK.TabIndex = 16;
            this.b_OK.Text = "Update";
            this.b_OK.UseVisualStyleBackColor = true;
            this.b_OK.Click += new System.EventHandler(this.b_OK_Click);
            // 
            // b_CANCEL
            // 
            this.b_CANCEL.Location = new System.Drawing.Point(124, 348);
            this.b_CANCEL.Name = "b_CANCEL";
            this.b_CANCEL.Size = new System.Drawing.Size(75, 23);
            this.b_CANCEL.TabIndex = 17;
            this.b_CANCEL.Text = "Cancel";
            this.b_CANCEL.UseVisualStyleBackColor = true;
            this.b_CANCEL.Click += new System.EventHandler(this.b_CANCEL_Click);
            // 
            // dtp_arrival
            // 
            this.dtp_arrival.Location = new System.Drawing.Point(124, 50);
            this.dtp_arrival.Name = "dtp_arrival";
            this.dtp_arrival.Size = new System.Drawing.Size(200, 20);
            this.dtp_arrival.TabIndex = 18;
            // 
            // dtp_departure
            // 
            this.dtp_departure.Location = new System.Drawing.Point(124, 78);
            this.dtp_departure.Name = "dtp_departure";
            this.dtp_departure.Size = new System.Drawing.Size(200, 20);
            this.dtp_departure.TabIndex = 19;
            // 
            // rtb_Description
            // 
            this.rtb_Description.Location = new System.Drawing.Point(124, 223);
            this.rtb_Description.Name = "rtb_Description";
            this.rtb_Description.Size = new System.Drawing.Size(200, 96);
            this.rtb_Description.TabIndex = 20;
            this.rtb_Description.Text = "";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(28, 226);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(69, 26);
            this.label6.TabIndex = 21;
            this.label6.Text = "Description\r\nof work done";
            // 
            // Card
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(646, 394);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.rtb_Description);
            this.Controls.Add(this.dtp_departure);
            this.Controls.Add(this.dtp_arrival);
            this.Controls.Add(this.b_CANCEL);
            this.Controls.Add(this.b_OK);
            this.Controls.Add(this.b_Remove);
            this.Controls.Add(this.b_ADD);
            this.Controls.Add(this.lb_Parts);
            this.Controls.Add(this.tb_labour);
            this.Controls.Add(this.tb_Employee);
            this.Controls.Add(this.tb_Client);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.lbl_PPrice);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Card";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Card";
            this.Load += new System.EventHandler(this.Card_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label lbl_PPrice;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox tb_Client;
        private System.Windows.Forms.TextBox tb_Employee;
        private System.Windows.Forms.TextBox tb_labour;
        private System.Windows.Forms.ListBox lb_Parts;
        private System.Windows.Forms.Button b_ADD;
        private System.Windows.Forms.Button b_Remove;
        private System.Windows.Forms.Button b_OK;
        private System.Windows.Forms.Button b_CANCEL;
        private System.Windows.Forms.DateTimePicker dtp_arrival;
        private System.Windows.Forms.DateTimePicker dtp_departure;
        private System.Windows.Forms.RichTextBox rtb_Description;
        private System.Windows.Forms.Label label6;
    }
}