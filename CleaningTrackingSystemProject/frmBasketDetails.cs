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
    public partial class frmBasketDetails : MetroForm
    {
        public ClientDetails getClientBasket;
        public ClientBasketDetail getClientBasketDetails;
        public List<ClientBasketDetail> SelectedBasketDetails = new List<ClientBasketDetail>();

        //private IEnumerable<object> clientBasket;

        //public frmBasketDetails(ClientDetails clientBasket, ClientBasketDetail getClientBasketDetails)
        public frmBasketDetails(ClientDetails clientBasket, List<ClientBasketDetail> getClientBasketDetails)
        {
            this.getClientBasket = clientBasket;
            this.SelectedBasketDetails = getClientBasketDetails;

            InitializeComponent();
        }

        // On Load fill all details from this.getClientBasket
        private void frmBasketDetails_Load(object sender, EventArgs e)
        {
            this.lblClientNumber.Text = this.getClientBasket.id.ToString();
            this.txtbSelectedName.Text = this.getClientBasket.name;
            this.txtbSelectedTelephone.Text = this.getClientBasket.telephone;
            this.txtbSelectedAddress.Text = this.getClientBasket.address;

            // Load services inside invoice
            //clientBasket
            //foreach (var item in getClientBasket.ClientBasketDetails)
            //{

            //}

            foreach (var item in SelectedBasketDetails)
            {
                ListViewItem li = new ListViewItem();
                li.Text = item.basketProductName;
                li.SubItems.Add(item.basketProductPrice);
                li.SubItems.Add("0");
                li.SubItems.Add(item.basketProductStatus);

                listviewServiceInInvoice.Items.Add(li);
                //Debug.WriteLine(" ok? " + i + "=> " + item.basketDetailsId + item.basketProductName + item.basketProductPrice + item.basketProductStatus);
            }

            disableClientFields();
        }

        private void disableClientFields()
        {
            this.txtbSelectedName.Enabled = false;
            this.txtbSelectedTelephone.Enabled = false;
            this.txtbSelectedAddress.Enabled = false;
        }
    }


}
