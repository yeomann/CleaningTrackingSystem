using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MetroFramework;
using System.Data.SqlClient;

namespace CleaningTrackingSystemProject
{
    public partial class homeCustomControl : UserControl
    {
        public bool IsClientExists { get; set; }
        public int ExistsClienID { get; set; }
        //public event EventHandler MyEvent;
        //public event EventHandler<MyEventArgs> ButtonClicked;

        //public delegate void OnClickPointDataEvent(object sender, PointF[] data);
        public event EventHandler<meventArgs> Control1ButtonClicked;


        public homeCustomControl()
        {
            InitializeComponent();
        }

        private void homeCustomControl_Load(object sender, EventArgs e)
        {
            if (!DesignMode)
                FillClientBox();
        }

        // Fetch all Clients from LocalDb
        private void FillClientBox()
        {

            using (var context = new cleaningDBEntities())
            {
                var query = context.clients;
                foreach (var item in query)
                {
                    cmbClients.Items.Add(item.name);
                }
            }
        }
        public void ReLoadClientsSource()
        {
            FillClientBox();
        }
        // Let telephone accept only Numbers and 1 plus sign
        private void txtbTelephone_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar)
                && !char.IsDigit(e.KeyChar)
                && e.KeyChar != '+')
            {
                e.Handled = true;
            }

            // only allow one decimal point
            if (e.KeyChar == '+'
                && (sender as TextBox).Text.IndexOf('+') > -1)
            {
                e.Handled = true;
            }
        }

        // Fetch all detials if Exsiting User from LocalDb depending upon provided "selectedName"
        private void FillAutofilds(string selectedName)
        {
            using (var context = new cleaningDBEntities())
            {
                var query = from clientName in context.clients
                            where clientName.name.Equals(selectedName)
                            select clientName;

                // if query has any results then fill up phone and address
                if (query.Any())
                {
                    IsClientExists = true;
                    
                    var data = query.ToList();

                    foreach (var item in data)
                    {
                        ExistsClienID = item.ID; // Asign the ID of found user
                        txtbTelephone.Text = item.telephone.ToString();
                        txtbAddress.Text = item.address.ToString();
                    }

                }
                else
                {
                    IsClientExists = false;
                    //int? ExistsClienID = null;
                }
            }
        }

        private void ClearAutofilds()
        {
            txtbTelephone.Text = "";
            txtbAddress.Text = "";
            IsClientExists = false;
        }

        private void DisableAllFields()
        {
            cmbClients.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbClients.Enabled = false;
            txtbTelephone.ReadOnly = true;
            txtbAddress.ReadOnly = true;
        }

        private void EnableAllFields()
        {
            cmbClients.Text = null;
            cmbClients.DropDownStyle = ComboBoxStyle.DropDown;
            cmbClients.Enabled = true;

            txtbTelephone.Text = "";
            txtbTelephone.ReadOnly = false;
            txtbAddress.Text = "";
            txtbAddress.ReadOnly = false;
        }
        public void InitNewInvoice()
        {
            EnableAllFields();
        }

        private void cmbClients_SelectedIndexChanged(object sender, EventArgs e)
        {
            //string selected = (cmbClients.SelectedItem as ComboBox).Text.ToString();
            string selectedName = cmbClients.Text.ToString();
            FillAutofilds(selectedName);
            DisableAllFields();
            GotoStartBtn();

        }

        private void cmbClients_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Back)
            {
                int countName = cmbClients.Text.Count();
                if (countName == 2)
                {
                    ClearAutofilds();
                }
            }
        }

        // if selected from dropdown of combox the auto fill data will come so shit the user to select on Go button
        private void cmbClients_DropDownClosed(object sender, EventArgs e)
        {
            GotoStartBtn();
            //btnStart.Focus();
            //this.BeginInvoke(new Action(() => { cmbClients.Select(0, 0); }));
        }

        private void GotoStartBtn()
        {
            BtnStart.Focus();
        }

        private void BtnClear_Click(object sender, EventArgs e)
        {
            EnableAllFields();
        }

        private void GetClientDetials()
        {
            XClient client = new XClient();
            //object clientObj = new object();
            //clientObj.name = cmbClients.Text.ToString();

        }

        private void BtnStart_Click(object sender, EventArgs e)
        {
            if (IsClientExists)
            {
                string clientName = cmbClients.Text.ToString();
                // Exsiting client
                DialogResult dr = MetroMessageBox.Show(this, clientName + " geri dönmeye hoşgeldiniz.", "Müşteri Bulundu", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                if (dr == DialogResult.OK)
                {
                    //SellingFrm sellingForm = new SellingFrm();
                    //this.Hide();
                    //sellingForm.ShowDialog();
                    //this.Close();
                    GotoBasketForm();

                    //var hand = ButtonClicked;
                    //if (hand != null) ButtonClicked(this, new MyEventArgs(this.cmbClients.Text.ToString()));
                    // Calling EVENT to get Client all details
                    SendClientDetailsTOBasketUI(this.cmbClients.Text.ToString());
                }
                //MessageBox.Show(clientName + " geri dönmeye hoşgeldiniz");
                //MessageBox.Show(IsClientExists.ToString());
            }
            else
            {
                // First Validate for emptiness
                if ((cmbClients.Text == string.Empty))
                {
                    MessageBox.Show("Lütfen isim giriniz!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                else if (txtbTelephone.Text == string.Empty)
                {
                    MessageBox.Show("Telefon gerekli!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                //MessageBox.Show(cmbClients.Text.ToString());
                
                // create new Client in DB
                using (var context = new cleaningDBEntities())
                {
                    ////var queryTable = context.clients;
                    //XClient newClient = new XClient();
                    //newClient.name = cmbClients.Text.ToString();
                    //newClient.telephone = txtbTelephone.Text.ToString();
                    //newClient.address = txtbAddress.Text.ToString();

                    //context.clients.Add(newClient);
                    //context.SaveChanges();

                    var client = new client()
                    {
                        name = cmbClients.Text.ToString(),
                        telephone = txtbTelephone.Text.ToString(),
                        address = txtbAddress.Text.ToString()
                    };

                    context.clients.Add(client);
                    context.SaveChanges();

                    // Get the newly create user ID
                    // additionally passing name bcz it's not showing on second UI but save on DB
                    ExistsClienID = client.ID;
                    

                    DialogResult dr = MetroMessageBox.Show(this, "Yeni müşteri oluşturuldu", "Yeni Müşteri", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    DisableAllFields(); // after creating disabling the fields

                    // Save new client to Akinsoft
                    SqlConnectionStringBuilder sqlConnectionString = new SqlConnectionStringBuilder()
                    {
                        DataSource = @"DESKTOP-0LJV0Q0\DANISH",
                        InitialCatalog = "WOLVOX8_DRYCLEANING_2018_WOLVOX",
                        UserID = "sa",
                        Password = "12345"
                    };

                    using (SqlConnection connection = new SqlConnection(sqlConnectionString.ConnectionString))
                    {
                        // GRUP and HIZMET are the tables from AkinSoft
                        string QueryGroup = "SELECT [GRUP_ADI] FROM GRUP";

                        var cmd = new SqlCommand(QueryGroup, connection);
                        cmd.CommandType = CommandType.Text;

                        connection.Open();
                        if (connection.State == ConnectionState.Open) { }
                    }


                    // Upon click Ok go to basket
                    if (dr == DialogResult.OK)
                    {
                        //SellingFrm sellingForm = new SellingFrm();
                        //this.Hide();
                        //sellingForm.ShowDialog();
                        //this.Close();
                        GotoBasketForm();
                        // Invoke event to send Client all details to second UI
                        SendClientDetailsTOBasketUI(client.name.ToString());
                    }
                }
            }
        }

        public void getClientName()
        {
            //get { this.cmbClients.Text.ToString() }
        }

        //https://stackoverflow.com/questions/2082615/pass-method-as-parameter-using-c-sharp
        private void GotoBasketForm()
        {
            //SellingFrm sellingForm = new SellingFrm();
            //this.Hide();
            //sellingForm.ShowDialog();
            //this.Close();

            // send Client Panel to back and make visible false
            this.SendToBack();

            //this.Controls.Find("ReportsCustomControl", true).SendThisToBack();
            //this.Visible = false;

            //if (MyEvent != null)
            //{
            //    MyEvent(null, null);
            //}

            // bring OR make Basket visible
            //basketCusomControl basketPanel = new basketCusomControl();
            //basketPanel.BringToFront();
            //basketPanel.Visible = true;
        }

        private void SendClientDetailsTOBasketUI( string name)
        {

            int id = this.ExistsClienID;
            //string name = this.cmbClients.Text.ToString();
            string phone = this.txtbTelephone.Text.ToString();
            string address = this.txtbAddress.Text.ToString();

            //MessageBox.Show(id +" -> "+ name);

            var handler = Control1ButtonClicked;
            if (handler != null)
            {
                handler(this, new meventArgs(id, name, phone, address));
                //handler(this, new meventArgs(this.ExistsClienID, this.cmbClients.Text.ToString(), this.txtbTelephone.Text.ToString(), this.txtbAddress.Text.ToString()));
                //handler(this, new meventArgs( this.ExistsClienID, daClientName, this.txtbTelephone.Text.ToString(), this.txtbAddress.Text.ToString()));
            }
        }
    }


    public class meventArgs:  EventArgs
    {
        public int ClientID { get; set; }
        public string Clientname { get; set; }
        public string Telephone { get; set; }
        public string Address { get; set; }
        public meventArgs(int id, string name, string telephone, string address)
        {
            this.ClientID = id;
            this.Clientname = name;
            this.Telephone = telephone;
            this.Address = address;
        }
    }
    //public class MyEventArgs : EventArgs
    //{
    //    public string Text { get; private set; }
    //    public MyEventArgs(string Text)
    //    {
    //        this.Text = Text;
    //    }
    //}




    public class XClient
    {
        public string name { get; set; }
        public string telephone { get; set; }
        public string address { get; set; }
    }

}
