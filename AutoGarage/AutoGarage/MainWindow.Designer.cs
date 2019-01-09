namespace AutoGarage
{
    partial class MainWindow
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
            this.lb_DataBox = new System.Windows.Forms.ListBox();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.refreshToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.noname = new System.Windows.Forms.ToolStripMenuItem();
            this.addToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.noname1 = new System.Windows.Forms.ToolStripMenuItem();
            this.allPartsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.noname2 = new System.Windows.Forms.ToolStripMenuItem();
            this.optionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.loadBrandModelsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.loadColorsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.slbl_DBStatus = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripFilterBox = new System.Windows.Forms.ToolStripComboBox();
            this.noname3 = new System.Windows.Forms.ToolStripMenuItem();
            this.dtp_Filter = new System.Windows.Forms.DateTimePicker();
            this.menuStrip1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lb_DataBox
            // 
            this.lb_DataBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lb_DataBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lb_DataBox.FormattingEnabled = true;
            this.lb_DataBox.ItemHeight = 20;
            this.lb_DataBox.Location = new System.Drawing.Point(0, 27);
            this.lb_DataBox.Name = "lb_DataBox";
            this.lb_DataBox.Size = new System.Drawing.Size(865, 484);
            this.lb_DataBox.TabIndex = 0;
            this.lb_DataBox.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.lb_DataBox_MouseDoubleClick);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.refreshToolStripMenuItem,
            this.noname,
            this.addToolStripMenuItem,
            this.editToolStripMenuItem,
            this.deleteToolStripMenuItem,
            this.noname1,
            this.allPartsToolStripMenuItem,
            this.noname2,
            this.optionsToolStripMenuItem,
            this.noname3,
            this.toolStripFilterBox});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(865, 27);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // refreshToolStripMenuItem
            // 
            this.refreshToolStripMenuItem.Name = "refreshToolStripMenuItem";
            this.refreshToolStripMenuItem.Size = new System.Drawing.Size(58, 23);
            this.refreshToolStripMenuItem.Text = "Refresh";
            this.refreshToolStripMenuItem.Click += new System.EventHandler(this.refreshToolStripMenuItem_Click);
            // 
            // noname
            // 
            this.noname.Enabled = false;
            this.noname.Name = "noname";
            this.noname.Size = new System.Drawing.Size(28, 23);
            this.noname.Text = " | ";
            // 
            // addToolStripMenuItem
            // 
            this.addToolStripMenuItem.Enabled = false;
            this.addToolStripMenuItem.Name = "addToolStripMenuItem";
            this.addToolStripMenuItem.Size = new System.Drawing.Size(44, 23);
            this.addToolStripMenuItem.Text = "Add ";
            this.addToolStripMenuItem.Click += new System.EventHandler(this.addToolStripMenuItem_Click);
            // 
            // editToolStripMenuItem
            // 
            this.editToolStripMenuItem.Enabled = false;
            this.editToolStripMenuItem.Name = "editToolStripMenuItem";
            this.editToolStripMenuItem.Size = new System.Drawing.Size(39, 23);
            this.editToolStripMenuItem.Text = "Edit";
            this.editToolStripMenuItem.Click += new System.EventHandler(this.editToolStripMenuItem_Click);
            // 
            // deleteToolStripMenuItem
            // 
            this.deleteToolStripMenuItem.Enabled = false;
            this.deleteToolStripMenuItem.Name = "deleteToolStripMenuItem";
            this.deleteToolStripMenuItem.Size = new System.Drawing.Size(52, 23);
            this.deleteToolStripMenuItem.Text = "Delete";
            this.deleteToolStripMenuItem.Click += new System.EventHandler(this.deleteToolStripMenuItem_Click);
            // 
            // noname1
            // 
            this.noname1.Enabled = false;
            this.noname1.Name = "noname1";
            this.noname1.Size = new System.Drawing.Size(22, 23);
            this.noname1.Text = "|";
            // 
            // allPartsToolStripMenuItem
            // 
            this.allPartsToolStripMenuItem.Enabled = false;
            this.allPartsToolStripMenuItem.Name = "allPartsToolStripMenuItem";
            this.allPartsToolStripMenuItem.Size = new System.Drawing.Size(62, 23);
            this.allPartsToolStripMenuItem.Text = "All Parts";
            this.allPartsToolStripMenuItem.Click += new System.EventHandler(this.allPartsToolStripMenuItem_Click);
            // 
            // noname2
            // 
            this.noname2.Enabled = false;
            this.noname2.Name = "noname2";
            this.noname2.Size = new System.Drawing.Size(22, 23);
            this.noname2.Text = "|";
            // 
            // optionsToolStripMenuItem
            // 
            this.optionsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.loadBrandModelsToolStripMenuItem,
            this.loadColorsToolStripMenuItem});
            this.optionsToolStripMenuItem.Enabled = false;
            this.optionsToolStripMenuItem.Name = "optionsToolStripMenuItem";
            this.optionsToolStripMenuItem.Size = new System.Drawing.Size(61, 23);
            this.optionsToolStripMenuItem.Text = "Settings";
            // 
            // loadBrandModelsToolStripMenuItem
            // 
            this.loadBrandModelsToolStripMenuItem.Name = "loadBrandModelsToolStripMenuItem";
            this.loadBrandModelsToolStripMenuItem.Size = new System.Drawing.Size(199, 22);
            this.loadBrandModelsToolStripMenuItem.Text = "Load Brand and Models";
            this.loadBrandModelsToolStripMenuItem.Click += new System.EventHandler(this.loadBrandModelsToolStripMenuItem_Click);
            // 
            // loadColorsToolStripMenuItem
            // 
            this.loadColorsToolStripMenuItem.Name = "loadColorsToolStripMenuItem";
            this.loadColorsToolStripMenuItem.Size = new System.Drawing.Size(199, 22);
            this.loadColorsToolStripMenuItem.Text = "Load Colors";
            this.loadColorsToolStripMenuItem.Click += new System.EventHandler(this.loadColorsToolStripMenuItem_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.slbl_DBStatus});
            this.statusStrip1.Location = new System.Drawing.Point(0, 489);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(865, 22);
            this.statusStrip1.TabIndex = 2;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // slbl_DBStatus
            // 
            this.slbl_DBStatus.Name = "slbl_DBStatus";
            this.slbl_DBStatus.Size = new System.Drawing.Size(0, 17);
            // 
            // toolStripFilterBox
            // 
            this.toolStripFilterBox.Enabled = false;
            this.toolStripFilterBox.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.toolStripFilterBox.Items.AddRange(new object[] {
            "No Filter",
            "After date",
            "Before date",
            "Unfinished repairs"});
            this.toolStripFilterBox.Name = "toolStripFilterBox";
            this.toolStripFilterBox.Size = new System.Drawing.Size(121, 23);
            this.toolStripFilterBox.Text = "Filter";
            this.toolStripFilterBox.SelectedIndexChanged += new System.EventHandler(this.toolStripFilterBox_SelectedIndexChanged);
            // 
            // noname3
            // 
            this.noname3.Enabled = false;
            this.noname3.Name = "noname3";
            this.noname3.Size = new System.Drawing.Size(22, 23);
            this.noname3.Text = "|";
            // 
            // dtp_Filter
            // 
            this.dtp_Filter.Location = new System.Drawing.Point(551, 3);
            this.dtp_Filter.Name = "dtp_Filter";
            this.dtp_Filter.Size = new System.Drawing.Size(200, 20);
            this.dtp_Filter.TabIndex = 3;
            this.dtp_Filter.Visible = false;
            this.dtp_Filter.ValueChanged += new System.EventHandler(this.dtp_Filter_ValueChanged);
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(865, 511);
            this.Controls.Add(this.dtp_Filter);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.lb_DataBox);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "MainWindow";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Garage Pal";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox lb_DataBox;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem addToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem editToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem deleteToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem optionsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem loadBrandModelsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem loadColorsToolStripMenuItem;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel slbl_DBStatus;
        private System.Windows.Forms.ToolStripMenuItem refreshToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem noname;
        private System.Windows.Forms.ToolStripMenuItem noname1;
        private System.Windows.Forms.ToolStripMenuItem allPartsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem noname2;
        private System.Windows.Forms.ToolStripMenuItem noname3;
        private System.Windows.Forms.ToolStripComboBox toolStripFilterBox;
        private System.Windows.Forms.DateTimePicker dtp_Filter;
    }
}

