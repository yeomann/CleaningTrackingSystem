namespace CleaningTrackingSystemProject
{
    partial class Form1
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
            this.metroTabControl1 = new MetroFramework.Controls.MetroTabControl();
            this.acceptOrderTab = new MetroFramework.Controls.MetroTabPage();
            this.flowLayoutPanelSubCategories = new System.Windows.Forms.FlowLayoutPanel();
            this.label2 = new System.Windows.Forms.Label();
            this.flowLayoutPanelCategories = new System.Windows.Forms.FlowLayoutPanel();
            this.customerInfoPanel = new System.Windows.Forms.Panel();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.metroButton1 = new MetroFramework.Controls.MetroButton();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panelProductinfo = new System.Windows.Forms.Panel();
            this.listView1 = new System.Windows.Forms.ListView();
            this.colId = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.metroDateTime1 = new MetroFramework.Controls.MetroDateTime();
            this.addressLabel = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.telephoneLabel = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.textBoxTelephone = new System.Windows.Forms.TextBox();
            this.nameLabel = new System.Windows.Forms.Label();
            this.textBoxName = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.reportingTab = new MetroFramework.Controls.MetroTabPage();
            this.searchnstatusTab = new MetroFramework.Controls.MetroTabPage();
            this.metroTabControl1.SuspendLayout();
            this.acceptOrderTab.SuspendLayout();
            this.customerInfoPanel.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panelProductinfo.SuspendLayout();
            this.SuspendLayout();
            // 
            // metroTabControl1
            // 
            this.metroTabControl1.Appearance = System.Windows.Forms.TabAppearance.FlatButtons;
            this.metroTabControl1.Controls.Add(this.acceptOrderTab);
            this.metroTabControl1.Controls.Add(this.reportingTab);
            this.metroTabControl1.Controls.Add(this.searchnstatusTab);
            this.metroTabControl1.FontSize = MetroFramework.MetroTabControlSize.Tall;
            this.metroTabControl1.Location = new System.Drawing.Point(0, 124);
            this.metroTabControl1.Margin = new System.Windows.Forms.Padding(0, 3, 3, 3);
            this.metroTabControl1.Name = "metroTabControl1";
            this.metroTabControl1.SelectedIndex = 0;
            this.metroTabControl1.Size = new System.Drawing.Size(1921, 1459);
            this.metroTabControl1.TabIndex = 1;
            this.metroTabControl1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.metroTabControl1.UseSelectable = true;
            // 
            // acceptOrderTab
            // 
            this.acceptOrderTab.BackColor = System.Drawing.SystemColors.Control;
            this.acceptOrderTab.Controls.Add(this.flowLayoutPanelSubCategories);
            this.acceptOrderTab.Controls.Add(this.label2);
            this.acceptOrderTab.Controls.Add(this.flowLayoutPanelCategories);
            this.acceptOrderTab.Controls.Add(this.customerInfoPanel);
            this.acceptOrderTab.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.acceptOrderTab.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.acceptOrderTab.HorizontalScrollbarBarColor = true;
            this.acceptOrderTab.HorizontalScrollbarHighlightOnWheel = false;
            this.acceptOrderTab.HorizontalScrollbarSize = 10;
            this.acceptOrderTab.Location = new System.Drawing.Point(4, 47);
            this.acceptOrderTab.Name = "acceptOrderTab";
            this.acceptOrderTab.Size = new System.Drawing.Size(1913, 1408);
            this.acceptOrderTab.TabIndex = 0;
            this.acceptOrderTab.Text = "Accept Order - Operator";
            this.acceptOrderTab.Theme = MetroFramework.MetroThemeStyle.Light;
            this.acceptOrderTab.VerticalScrollbarBarColor = true;
            this.acceptOrderTab.VerticalScrollbarHighlightOnWheel = false;
            this.acceptOrderTab.VerticalScrollbarSize = 0;
            this.acceptOrderTab.Click += new System.EventHandler(this.acceptOrderTab_Click);
            // 
            // flowLayoutPanelSubCategories
            // 
            this.flowLayoutPanelSubCategories.BackColor = System.Drawing.Color.White;
            this.flowLayoutPanelSubCategories.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.flowLayoutPanelSubCategories.Location = new System.Drawing.Point(15, 504);
            this.flowLayoutPanelSubCategories.Name = "flowLayoutPanelSubCategories";
            this.flowLayoutPanelSubCategories.Size = new System.Drawing.Size(978, 652);
            this.flowLayoutPanelSubCategories.TabIndex = 7;
            this.flowLayoutPanelSubCategories.Paint += new System.Windows.Forms.PaintEventHandler(this.flowLayoutPanelSubCategories_Paint);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Palatino Linotype", 19F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label2.Location = new System.Drawing.Point(17, 75);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(309, 51);
            this.label2.TabIndex = 0;
            this.label2.Text = "Main Categories";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // flowLayoutPanelCategories
            // 
            this.flowLayoutPanelCategories.BackColor = System.Drawing.Color.White;
            this.flowLayoutPanelCategories.Location = new System.Drawing.Point(15, 129);
            this.flowLayoutPanelCategories.Name = "flowLayoutPanelCategories";
            this.flowLayoutPanelCategories.Size = new System.Drawing.Size(978, 344);
            this.flowLayoutPanelCategories.TabIndex = 6;
            this.flowLayoutPanelCategories.Paint += new System.Windows.Forms.PaintEventHandler(this.flowLayoutPanelCategories_Paint);
            // 
            // customerInfoPanel
            // 
            this.customerInfoPanel.AutoSize = true;
            this.customerInfoPanel.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.customerInfoPanel.Controls.Add(this.textBox2);
            this.customerInfoPanel.Controls.Add(this.panel2);
            this.customerInfoPanel.Controls.Add(this.panel1);
            this.customerInfoPanel.Controls.Add(this.panelProductinfo);
            this.customerInfoPanel.Controls.Add(this.metroDateTime1);
            this.customerInfoPanel.Controls.Add(this.addressLabel);
            this.customerInfoPanel.Controls.Add(this.label3);
            this.customerInfoPanel.Controls.Add(this.telephoneLabel);
            this.customerInfoPanel.Controls.Add(this.textBox1);
            this.customerInfoPanel.Controls.Add(this.textBoxTelephone);
            this.customerInfoPanel.Controls.Add(this.nameLabel);
            this.customerInfoPanel.Controls.Add(this.textBoxName);
            this.customerInfoPanel.Controls.Add(this.label5);
            this.customerInfoPanel.Controls.Add(this.label6);
            this.customerInfoPanel.Controls.Add(this.label4);
            this.customerInfoPanel.Controls.Add(this.label1);
            this.customerInfoPanel.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.customerInfoPanel.Location = new System.Drawing.Point(999, 0);
            this.customerInfoPanel.Name = "customerInfoPanel";
            this.customerInfoPanel.Size = new System.Drawing.Size(919, 1429);
            this.customerInfoPanel.TabIndex = 5;
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(193, 1135);
            this.textBox2.Multiline = true;
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(373, 50);
            this.textBox2.TabIndex = 7;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.metroButton1);
            this.panel2.Location = new System.Drawing.Point(35, 1213);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(850, 83);
            this.panel2.TabIndex = 6;
            // 
            // metroButton1
            // 
            this.metroButton1.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.metroButton1.FontSize = MetroFramework.MetroButtonSize.Tall;
            this.metroButton1.Location = new System.Drawing.Point(3, 20);
            this.metroButton1.Name = "metroButton1";
            this.metroButton1.Size = new System.Drawing.Size(328, 60);
            this.metroButton1.TabIndex = 0;
            this.metroButton1.Text = "Print and Save Invoice";
            this.metroButton1.UseSelectable = true;
            // 
            // panel1
            // 
            this.panel1.Location = new System.Drawing.Point(683, 513);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(202, 597);
            this.panel1.TabIndex = 5;
            // 
            // panelProductinfo
            // 
            this.panelProductinfo.Controls.Add(this.listView1);
            this.panelProductinfo.Location = new System.Drawing.Point(35, 513);
            this.panelProductinfo.Name = "panelProductinfo";
            this.panelProductinfo.Size = new System.Drawing.Size(612, 597);
            this.panelProductinfo.TabIndex = 4;
            // 
            // listView1
            // 
            this.listView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colId,
            this.colName});
            this.listView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listView1.Location = new System.Drawing.Point(0, 0);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(612, 597);
            this.listView1.TabIndex = 0;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.View = System.Windows.Forms.View.Details;
            this.listView1.SelectedIndexChanged += new System.EventHandler(this.listView1_SelectedIndexChanged);
            // 
            // colId
            // 
            this.colId.Text = "ID";
            this.colId.Width = 171;
            // 
            // colName
            // 
            this.colName.Text = "Name";
            this.colName.Width = 170;
            // 
            // metroDateTime1
            // 
            this.metroDateTime1.CalendarTitleForeColor = System.Drawing.Color.RoyalBlue;
            this.metroDateTime1.CalendarTrailingForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.metroDateTime1.Enabled = false;
            this.metroDateTime1.Location = new System.Drawing.Point(172, 387);
            this.metroDateTime1.MinimumSize = new System.Drawing.Size(0, 29);
            this.metroDateTime1.Name = "metroDateTime1";
            this.metroDateTime1.ShowCheckBox = true;
            this.metroDateTime1.Size = new System.Drawing.Size(597, 35);
            this.metroDateTime1.TabIndex = 3;
            // 
            // addressLabel
            // 
            this.addressLabel.AutoSize = true;
            this.addressLabel.Font = new System.Drawing.Font("Palatino Linotype", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.addressLabel.ForeColor = System.Drawing.SystemColors.Desktop;
            this.addressLabel.Location = new System.Drawing.Point(32, 262);
            this.addressLabel.Name = "addressLabel";
            this.addressLabel.Size = new System.Drawing.Size(111, 32);
            this.addressLabel.TabIndex = 2;
            this.addressLabel.Text = "Address:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Palatino Linotype", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.SystemColors.Desktop;
            this.label3.Location = new System.Drawing.Point(32, 387);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(73, 32);
            this.label3.TabIndex = 2;
            this.label3.Text = "Date:";
            // 
            // telephoneLabel
            // 
            this.telephoneLabel.AutoSize = true;
            this.telephoneLabel.Font = new System.Drawing.Font("Palatino Linotype", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.telephoneLabel.ForeColor = System.Drawing.SystemColors.Desktop;
            this.telephoneLabel.Location = new System.Drawing.Point(32, 189);
            this.telephoneLabel.Name = "telephoneLabel";
            this.telephoneLabel.Size = new System.Drawing.Size(115, 32);
            this.telephoneLabel.TabIndex = 2;
            this.telephoneLabel.Text = "Telefone:";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(172, 261);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(597, 91);
            this.textBox1.TabIndex = 1;
            // 
            // textBoxTelephone
            // 
            this.textBoxTelephone.Location = new System.Drawing.Point(172, 186);
            this.textBoxTelephone.Name = "textBoxTelephone";
            this.textBoxTelephone.Size = new System.Drawing.Size(597, 35);
            this.textBoxTelephone.TabIndex = 1;
            this.textBoxTelephone.TextChanged += new System.EventHandler(this.textBoxTelephone_TextChanged);
            this.textBoxTelephone.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBoxTelephone_KeyPress);
            // 
            // nameLabel
            // 
            this.nameLabel.AutoSize = true;
            this.nameLabel.Font = new System.Drawing.Font("Palatino Linotype", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nameLabel.ForeColor = System.Drawing.SystemColors.Desktop;
            this.nameLabel.Location = new System.Drawing.Point(32, 119);
            this.nameLabel.Name = "nameLabel";
            this.nameLabel.Size = new System.Drawing.Size(86, 32);
            this.nameLabel.TabIndex = 2;
            this.nameLabel.Text = "Name:";
            // 
            // textBoxName
            // 
            this.textBoxName.Location = new System.Drawing.Point(172, 116);
            this.textBoxName.Name = "textBoxName";
            this.textBoxName.Size = new System.Drawing.Size(597, 35);
            this.textBoxName.TabIndex = 1;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Arial Rounded MT Bold", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label5.Location = new System.Drawing.Point(750, 458);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(88, 32);
            this.label5.TabIndex = 0;
            this.label5.Text = "Price";
            this.label5.Click += new System.EventHandler(this.label5_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Arial Rounded MT Bold", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label6.Location = new System.Drawing.Point(32, 1141);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(155, 32);
            this.label6.TabIndex = 0;
            this.label6.Text = "Sub Total:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Arial Rounded MT Bold", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label4.Location = new System.Drawing.Point(32, 458);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(184, 32);
            this.label4.TabIndex = 0;
            this.label4.Text = "Product Info";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Palatino Linotype", 19F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label1.Location = new System.Drawing.Point(273, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(414, 51);
            this.label1.TabIndex = 0;
            this.label1.Text = "Customer Invoice Info";
            // 
            // reportingTab
            // 
            this.reportingTab.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.reportingTab.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.reportingTab.HorizontalScrollbarBarColor = true;
            this.reportingTab.HorizontalScrollbarHighlightOnWheel = false;
            this.reportingTab.HorizontalScrollbarSize = 10;
            this.reportingTab.Location = new System.Drawing.Point(4, 47);
            this.reportingTab.Name = "reportingTab";
            this.reportingTab.Size = new System.Drawing.Size(1913, 1408);
            this.reportingTab.TabIndex = 1;
            this.reportingTab.Text = "Check Reports";
            this.reportingTab.VerticalScrollbarBarColor = true;
            this.reportingTab.VerticalScrollbarHighlightOnWheel = false;
            this.reportingTab.VerticalScrollbarSize = 10;
            // 
            // searchnstatusTab
            // 
            this.searchnstatusTab.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.searchnstatusTab.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.searchnstatusTab.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.searchnstatusTab.HorizontalScrollbarBarColor = true;
            this.searchnstatusTab.HorizontalScrollbarHighlightOnWheel = false;
            this.searchnstatusTab.HorizontalScrollbarSize = 10;
            this.searchnstatusTab.Location = new System.Drawing.Point(4, 47);
            this.searchnstatusTab.Margin = new System.Windows.Forms.Padding(0);
            this.searchnstatusTab.Name = "searchnstatusTab";
            this.searchnstatusTab.Size = new System.Drawing.Size(1913, 1408);
            this.searchnstatusTab.TabIndex = 2;
            this.searchnstatusTab.Text = "Search and Change Status";
            this.searchnstatusTab.VerticalScrollbarBarColor = true;
            this.searchnstatusTab.VerticalScrollbarHighlightOnWheel = false;
            this.searchnstatusTab.VerticalScrollbarSize = 10;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.CancelButton = this.metroButton1;
            this.ClientSize = new System.Drawing.Size(1922, 1586);
            this.Controls.Add(this.metroTabControl1);
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.Padding = new System.Windows.Forms.Padding(0, 60, 0, 0);
            this.Resizable = false;
            this.Text = "Dry Cleaning Ironing and Tailoring Tracking System";
            this.Theme = MetroFramework.MetroThemeStyle.Default;
            this.Load += new System.EventHandler(this.Form1_Load);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseDown);
            this.metroTabControl1.ResumeLayout(false);
            this.acceptOrderTab.ResumeLayout(false);
            this.acceptOrderTab.PerformLayout();
            this.customerInfoPanel.ResumeLayout(false);
            this.customerInfoPanel.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panelProductinfo.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private MetroFramework.Controls.MetroTabControl metroTabControl1;
        private MetroFramework.Controls.MetroTabPage acceptOrderTab;
        private MetroFramework.Controls.MetroTabPage reportingTab;
        private MetroFramework.Controls.MetroTabPage searchnstatusTab;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanelCategories;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanelSubCategories;
        private System.Windows.Forms.Panel customerInfoPanel;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panelProductinfo;
        private MetroFramework.Controls.MetroDateTime metroDateTime1;
        private System.Windows.Forms.Label addressLabel;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label telephoneLabel;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox textBoxTelephone;
        private System.Windows.Forms.Label nameLabel;
        private System.Windows.Forms.TextBox textBoxName;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label6;
        private MetroFramework.Controls.MetroButton metroButton1;
        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.ColumnHeader colId;
        private System.Windows.Forms.ColumnHeader colName;
    }
}

