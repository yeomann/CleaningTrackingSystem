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
    public partial class frmAddService : MetroForm
    {

        private readonly service myService;
        public Product product { get; set; }

        public frmAddService(service service)
        {
            this.myService = service;
            InitializeComponent();
        }

        private void frmAddService_Load(object sender, EventArgs e)
        {
            lblPrice.Text = myService.price.ToString();
            lblProductName.Text = myService.serviceName;
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            int val = (int)numericUpDown1.Value;
            decimal price = val * (decimal)myService.price;
            lblPrice.Text = price.ToString("###,##0.00");
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            int val = (int)numericUpDown1.Value;

            Product mypr = new Product()
            {
                clientID = 0,
                productName = myService.serviceName,
                productPrince = val * (decimal)myService.price
            };

            product = mypr;


            this.DialogResult = DialogResult.OK;
            this.Close();

        }


        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}
