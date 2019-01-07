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
    public partial class SellingFrm : MetroForm
    {




        public SellingFrm()
        {
            InitializeComponent();
        }

        private void SellingFrm_Load(object sender, EventArgs e)
        {
            FillCatogories();
        }

        private void FillCatogories()
        {
            using (cleaningDBEntities cntx = new cleaningDBEntities())
            {
                //List<category> categories = cntx.categories.ToList();

                var categories = cntx.categories;

                foreach (var item in categories)
                {
                    //category x = new categoriesX() { catID = item.catID, catName = item.catName, services = item.services };
                    //cmbCatogories.Items.Add(x);
                }
            }
        }


        private void cmbCatogories_SelectedIndexChanged(object sender, EventArgs e)
        {
            listView1.Items.Clear();

            categoriesX selectedCat = (categoriesX)cmbCatogories.SelectedItem;
            //var services = selectedCat.services.ToList();
            //FillLiServices(services);
        }
        
        private void FillLiServices(List<service> mySelectedSvcs)
        {

            listView1.BeginUpdate();

            foreach (var item in mySelectedSvcs)
            {
                ListViewItem li = listView1.Items.Add(item.serviceName);

                decimal cprice  = item.price ?? 0;
                string formated = cprice.ToString("###,##0.00") + " TL";

                string priceStr = ((decimal) item.price).ToString("###,##0.00");
                li.SubItems.Add(formated);
                li.Tag = item;
              
            }

            listView1.EndUpdate();
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count == 0) return;

            service selectedSvc = (service) listView1.SelectedItems[0].Tag;

            frmAddService frm = new frmAddService(selectedSvc);

            DialogResult dr = frm.ShowDialog();
            if(dr == DialogResult.OK)
            {
                ListViewItem dc = new ListViewItem(frm.product.productName);
                dc.SubItems.Add(frm.product.productPrince.ToString());
                listViewRightSide.Items.Add(dc);
            }
            else
            {
                MessageBox.Show("iptal edildi !");
            }
                
        }

        private void listView2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }


    class categoriesX : category
    {
        public override string ToString()
        {
            return base.catName.ToString();
        }
    }
}
