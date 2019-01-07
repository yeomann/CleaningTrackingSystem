namespace CleaningTrackingSystemProject
{
    partial class mainForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(mainForm));
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnSearch = new System.Windows.Forms.Button();
            this.activeRibbon = new System.Windows.Forms.Panel();
            this.btnReports = new System.Windows.Forms.Button();
            this.btnHome = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.headerPanel = new System.Windows.Forms.Panel();
            this.HomebodyPanel = new System.Windows.Forms.Panel();
            this.HomeClientPanel = new CleaningTrackingSystemProject.homeCustomControl();
            this.HomeBasketPanel = new CleaningTrackingSystemProject.BasketCusomControl();
            this.ReportsBodyPanel = new System.Windows.Forms.Panel();
            this.HomeReportsPanel = new CleaningTrackingSystemProject.reportsCustomControl();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.headerPanel.SuspendLayout();
            this.HomebodyPanel.SuspendLayout();
            this.ReportsBodyPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.HotTrack;
            this.panel1.Controls.Add(this.btnSearch);
            this.panel1.Controls.Add(this.activeRibbon);
            this.panel1.Controls.Add(this.btnReports);
            this.panel1.Controls.Add(this.btnHome);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(250, 1188);
            this.panel1.TabIndex = 0;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // btnSearch
            // 
            this.btnSearch.FlatAppearance.BorderSize = 0;
            this.btnSearch.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSearch.Font = new System.Drawing.Font("Franklin Gothic Book", 12F);
            this.btnSearch.ForeColor = System.Drawing.Color.White;
            this.btnSearch.Image = ((System.Drawing.Image)(resources.GetObject("btnSearch.Image")));
            this.btnSearch.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSearch.Location = new System.Drawing.Point(12, 642);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(238, 89);
            this.btnSearch.TabIndex = 3;
            this.btnSearch.Text = "Search";
            this.btnSearch.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnSearch.UseVisualStyleBackColor = false;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // activeRibbon
            // 
            this.activeRibbon.BackColor = System.Drawing.SystemColors.Control;
            this.activeRibbon.Location = new System.Drawing.Point(0, 317);
            this.activeRibbon.Name = "activeRibbon";
            this.activeRibbon.Size = new System.Drawing.Size(12, 89);
            this.activeRibbon.TabIndex = 2;
            // 
            // btnReports
            // 
            this.btnReports.FlatAppearance.BorderSize = 0;
            this.btnReports.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnReports.Font = new System.Drawing.Font("Franklin Gothic Book", 12F);
            this.btnReports.ForeColor = System.Drawing.Color.White;
            this.btnReports.Image = ((System.Drawing.Image)(resources.GetObject("btnReports.Image")));
            this.btnReports.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnReports.Location = new System.Drawing.Point(12, 484);
            this.btnReports.Name = "btnReports";
            this.btnReports.Size = new System.Drawing.Size(238, 89);
            this.btnReports.TabIndex = 2;
            this.btnReports.Text = "Reports";
            this.btnReports.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnReports.UseVisualStyleBackColor = false;
            this.btnReports.Click += new System.EventHandler(this.btnReports_Click);
            // 
            // btnHome
            // 
            this.btnHome.FlatAppearance.BorderSize = 0;
            this.btnHome.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnHome.Font = new System.Drawing.Font("Franklin Gothic Book", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnHome.ForeColor = System.Drawing.Color.White;
            this.btnHome.Image = ((System.Drawing.Image)(resources.GetObject("btnHome.Image")));
            this.btnHome.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnHome.Location = new System.Drawing.Point(12, 317);
            this.btnHome.Name = "btnHome";
            this.btnHome.Size = new System.Drawing.Size(238, 89);
            this.btnHome.TabIndex = 2;
            this.btnHome.Text = "Home";
            this.btnHome.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnHome.UseVisualStyleBackColor = false;
            this.btnHome.Click += new System.EventHandler(this.btnHome_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(22, 126);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(207, 32);
            this.label1.TabIndex = 1;
            this.label1.Text = "Dry Cleaning App";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(56, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(96, 96);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Dock = System.Windows.Forms.DockStyle.Right;
            this.pictureBox2.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox2.Image")));
            this.pictureBox2.Location = new System.Drawing.Point(1473, 0);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(30, 42);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox2.TabIndex = 1;
            this.pictureBox2.TabStop = false;
            this.pictureBox2.Click += new System.EventHandler(this.pictureBox2_Click);
            // 
            // headerPanel
            // 
            this.headerPanel.Controls.Add(this.pictureBox2);
            this.headerPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.headerPanel.Location = new System.Drawing.Point(250, 0);
            this.headerPanel.Name = "headerPanel";
            this.headerPanel.Size = new System.Drawing.Size(1503, 42);
            this.headerPanel.TabIndex = 2;
            // 
            // HomebodyPanel
            // 
            this.HomebodyPanel.Controls.Add(this.ReportsBodyPanel);
            this.HomebodyPanel.Controls.Add(this.HomeClientPanel);
            this.HomebodyPanel.Controls.Add(this.HomeBasketPanel);
            this.HomebodyPanel.Cursor = System.Windows.Forms.Cursors.Default;
            this.HomebodyPanel.Location = new System.Drawing.Point(271, 46);
            this.HomebodyPanel.Name = "HomebodyPanel";
            this.HomebodyPanel.Size = new System.Drawing.Size(1452, 1130);
            this.HomebodyPanel.TabIndex = 3;
            // 
            // HomeClientPanel
            // 
            this.HomeClientPanel.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.HomeClientPanel.ExistsClienID = 0;
            this.HomeClientPanel.IsClientExists = false;
            this.HomeClientPanel.Location = new System.Drawing.Point(0, 4);
            this.HomeClientPanel.Name = "HomeClientPanel";
            this.HomeClientPanel.Size = new System.Drawing.Size(1452, 1036);
            this.HomeClientPanel.TabIndex = 0;
            this.HomeClientPanel.Load += new System.EventHandler(this.homeCustomControl2_Load);
            // 
            // HomeBasketPanel
            // 
            this.HomeBasketPanel.Location = new System.Drawing.Point(0, 5);
            this.HomeBasketPanel.Name = "HomeBasketPanel";
            this.HomeBasketPanel.NewbasketID = 0;
            this.HomeBasketPanel.Size = new System.Drawing.Size(1452, 1035);
            this.HomeBasketPanel.TabIndex = 1;
            // 
            // ReportsBodyPanel
            // 
            this.ReportsBodyPanel.Controls.Add(this.HomeReportsPanel);
            this.ReportsBodyPanel.Location = new System.Drawing.Point(0, 3);
            this.ReportsBodyPanel.Name = "ReportsBodyPanel";
            this.ReportsBodyPanel.Size = new System.Drawing.Size(1452, 1108);
            this.ReportsBodyPanel.TabIndex = 2;
            // 
            // HomeReportsPanel
            // 
            this.HomeReportsPanel.Location = new System.Drawing.Point(9, -4);
            this.HomeReportsPanel.Name = "HomeReportsPanel";
            this.HomeReportsPanel.Size = new System.Drawing.Size(1440, 1084);
            this.HomeReportsPanel.TabIndex = 0;
            // 
            // mainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1753, 1188);
            this.Controls.Add(this.HomebodyPanel);
            this.Controls.Add(this.headerPanel);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.Name = "mainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "mainForm";
            this.Load += new System.EventHandler(this.mainForm_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.headerPanel.ResumeLayout(false);
            this.headerPanel.PerformLayout();
            this.HomebodyPanel.ResumeLayout(false);
            this.ReportsBodyPanel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Panel activeRibbon;
        private System.Windows.Forms.Button btnHome;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.Button btnReports;
        private System.Windows.Forms.Panel headerPanel;
        private System.Windows.Forms.Panel HomebodyPanel;
        private homeCustomControl HomeClientPanel;
        private BasketCusomControl HomeBasketPanel;
        private System.Windows.Forms.Panel ReportsBodyPanel;
        private reportsCustomControl HomeReportsPanel;
    }
}