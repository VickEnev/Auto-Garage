namespace AutoGarage
{
    partial class Parts
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
            this.lb_AllParts = new System.Windows.Forms.ListBox();
            this.lb_UsedParts = new System.Windows.Forms.ListBox();
            this.b_ADD = new System.Windows.Forms.Button();
            this.b_Remove = new System.Windows.Forms.Button();
            this.b_OK = new System.Windows.Forms.Button();
            this.b_Cancel = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lb_AllParts
            // 
            this.lb_AllParts.FormattingEnabled = true;
            this.lb_AllParts.Location = new System.Drawing.Point(12, 40);
            this.lb_AllParts.Name = "lb_AllParts";
            this.lb_AllParts.Size = new System.Drawing.Size(199, 264);
            this.lb_AllParts.TabIndex = 0;
            // 
            // lb_UsedParts
            // 
            this.lb_UsedParts.FormattingEnabled = true;
            this.lb_UsedParts.Location = new System.Drawing.Point(349, 40);
            this.lb_UsedParts.Name = "lb_UsedParts";
            this.lb_UsedParts.Size = new System.Drawing.Size(204, 264);
            this.lb_UsedParts.TabIndex = 1;
            // 
            // b_ADD
            // 
            this.b_ADD.Location = new System.Drawing.Point(236, 96);
            this.b_ADD.Name = "b_ADD";
            this.b_ADD.Size = new System.Drawing.Size(75, 23);
            this.b_ADD.TabIndex = 2;
            this.b_ADD.Text = "ADD";
            this.b_ADD.UseVisualStyleBackColor = true;
            // 
            // b_Remove
            // 
            this.b_Remove.Location = new System.Drawing.Point(236, 166);
            this.b_Remove.Name = "b_Remove";
            this.b_Remove.Size = new System.Drawing.Size(75, 23);
            this.b_Remove.TabIndex = 3;
            this.b_Remove.Text = "REMOVE";
            this.b_Remove.UseVisualStyleBackColor = true;
            // 
            // b_OK
            // 
            this.b_OK.Location = new System.Drawing.Point(196, 376);
            this.b_OK.Name = "b_OK";
            this.b_OK.Size = new System.Drawing.Size(75, 23);
            this.b_OK.TabIndex = 4;
            this.b_OK.Text = "OK";
            this.b_OK.UseVisualStyleBackColor = true;
            // 
            // b_Cancel
            // 
            this.b_Cancel.Location = new System.Drawing.Point(302, 376);
            this.b_Cancel.Name = "b_Cancel";
            this.b_Cancel.Size = new System.Drawing.Size(75, 23);
            this.b_Cancel.TabIndex = 5;
            this.b_Cancel.Text = "CANCEL";
            this.b_Cancel.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(86, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(45, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "All Parts";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(346, 13);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(59, 13);
            this.label2.TabIndex = 7;
            this.label2.Text = "Used Parts";
            // 
            // Parts
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(583, 430);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.b_Cancel);
            this.Controls.Add(this.b_OK);
            this.Controls.Add(this.b_Remove);
            this.Controls.Add(this.b_ADD);
            this.Controls.Add(this.lb_UsedParts);
            this.Controls.Add(this.lb_AllParts);
            this.Name = "Parts";
            this.Text = "Parts";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox lb_AllParts;
        private System.Windows.Forms.ListBox lb_UsedParts;
        private System.Windows.Forms.Button b_ADD;
        private System.Windows.Forms.Button b_Remove;
        private System.Windows.Forms.Button b_OK;
        private System.Windows.Forms.Button b_Cancel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
    }
}