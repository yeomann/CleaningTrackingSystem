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
    public partial class addServiceToInvoice : MetroForm
    {
        public service myservice;
        // Converting default Constructor to accept service
        public AddToBasketServices ReturnServiceDetails { get; set; }
        public addServiceToInvoice(service aService)
        {
            this.myservice = aService;
            InitializeComponent();
        }

        private void addServiceToInvoice_Load(object sender, EventArgs e)
        {
            fillFields();
        }

        private void fillFields()
        {
            this.lblServiceName.Text = myservice.serviceName;
            this.lblServicePrice.Text = myservice.price.ToString();
        }

        private void numericUpDownPrice_ValueChanged(object sender, EventArgs e)
        {
            int serviceQuantity = (int)numericUpDownPrice.Value;
            decimal NewPrice = serviceQuantity * (decimal)myservice.price;
            this.lblServicePrice.Text = NewPrice.ToString("###,##0.00");
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void buttonOk_Click(object sender, EventArgs e)
        {
            int serviceQuantity = (int)numericUpDownPrice.Value;
            decimal NewPrice = serviceQuantity * (decimal)myservice.price;


            //basket slectedServiceDetails = new basket()
            //{
            //    productName = this.lblServiceName.Text,
            //    productPrince = (decimal)NewPrice,
            //};

            AddToBasketServices slectedServiceDetails = new AddToBasketServices();
            slectedServiceDetails.ServiceName = this.lblServiceName.Text;
            slectedServiceDetails.ServicePrice = (decimal)NewPrice;

            ReturnServiceDetails = slectedServiceDetails;

            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }

    public class AddToBasketServices
    {
        public string ServiceName { get; set; }
        public decimal ServicePrice { get; set; }
    }
}
