using MetroFramework.Forms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CleaningTrackingSystemProject
{
    public partial class Form1 : MetroForm
    {

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
        }

        //  making the shit window to move(dragable) with mouse
        protected override void WndProc(ref Message m)
        {
            base.WndProc(ref m);
            if (m.Msg == WM_NCHITTEST)
                m.Result = (IntPtr)(HT_CAPTION);
        }

        private const int WM_NCHITTEST = 0x84;
        private const int HT_CLIENT = 0x1;
        private const int HT_CAPTION = 0x2;

        private void Form1_Load(object sender, EventArgs e)
        {

            //int w = Screen.PrimaryScreen.Bounds.Width;
            //int h = Screen.PrimaryScreen.Bounds.Height;
            //this.Location = new Point(0, 0);
            //this.Size = new Size(w, h);

            using (cleaningDBEntities cntx = new cleaningDBEntities())
            {
                var clients = cntx.clients;
                foreach (var client in clients)
                {
                    ListViewItem li = new ListViewItem(client.ID.ToString());
                    li.SubItems.Add(client.name);
                    li.Tag = client;
                    listView1.Items.Add(li);
                }
               
            }






                // create main categories depending upon akin soft 
                // for now lets assume stuff :)
                int howmanyCats = 4;

            for (int i = 0; i < howmanyCats; i++)
            {
                Label newCat = CreateCategoriesLabel(i);
                flowLayoutPanelCategories.Controls.Add(newCat);
                // Hover
                newCat.MouseEnter += new System.EventHandler(this.MouseEnterCategoriesLabel);
                newCat.MouseLeave += new System.EventHandler(this.MouseLeaveCategoriesLabel);

                // Click handling
                //newCat.MouseClick += new EventHandler(MouseClickCategoriesLabel);
                newCat.Click += new EventHandler(MouseClickCategoriesLabel);
            }
        }


        Label CreateCategoriesLabel(int i)
        {
            // Create an instance of a Label.
            Label l = new Label();

            // Set the text of the control and specify a mnemonic character.
            l.Text = "Label:" + i.ToString();
            l.Name = "Label:" + i.ToString();

            //Background and forground color
            l.ForeColor = ColorTranslator.FromHtml("#888888"); // text color
            l.BackColor = SystemColors.Control; // btn background
            l.Width = 170;
            l.Height = 80;

            l.Font = new Font("Serif", 12, FontStyle.Bold);

            //text align
            l.TextAlign = ContentAlignment.MiddleCenter;
            //margin
            l.Margin = new Padding(5);
            
            return l;
        }

        // Hover fucntion
        public void MouseEnterCategoriesLabel(object sender, EventArgs e)
        {
            Label currentLabel = (Label)sender;
            currentLabel.BackColor = Color.Black;
            currentLabel.ForeColor = Color.White;

            //MessageBox.Show(currentLabel.Text);
            //l.ForeColor = SystemColors.ButtonHighlight;
            //MessageBox.Show(sender.ToString());
        }
        // Hover fucntion
        public void MouseLeaveCategoriesLabel(object sender, EventArgs e)
        {
            Label currentLabel = (Label)sender;
            currentLabel.BackColor = SystemColors.Control;
            currentLabel.ForeColor = ColorTranslator.FromHtml("#888888");
        }
        // Click fucntion
        public void MouseClickCategoriesLabel(object sender, EventArgs e)
        {
            Label currentLabel = (Label)sender;
            MessageBox.Show(currentLabel.Text);
        }


        private void acceptOrderTab_Click(object sender, EventArgs e)
        {

        }

        private void metroButton2_Click(object sender, EventArgs e)
        {

        }

        private void metroPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void metroLabel1_Click(object sender, EventArgs e)
        {

        }

        private void metroLabel1_Click_1(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void metroTextBox1_Click(object sender, EventArgs e)
        {

        }
        //Allow only numbers in phone field
        private void textBoxTelephone_KeyPress(object sender, KeyPressEventArgs e)
        {
            //if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            //{
            //    e.Handled = true;
            //}
            if (!char.IsControl(e.KeyChar)
                && !char.IsDigit(e.KeyChar)
                && e.KeyChar != '+')
            {
                e.Handled = true;
            }

            // only allow one decimal point
            if (e.KeyChar == '+'
                && (sender as TextBox).Text.IndexOf('.') > -1)
            {
                e.Handled = true;
            }

        }

        private void flowLayoutPanelSubCategories_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void textBoxTelephone_TextChanged(object sender, EventArgs e)
        {

        }

        private void flowLayoutPanelCategories_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
