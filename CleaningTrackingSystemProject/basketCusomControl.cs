using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Collections.ObjectModel;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Collections;
using static System.Windows.Forms.ListViewItem;
using MetroFramework;

namespace CleaningTrackingSystemProject
{
    public partial class BasketCusomControl : UserControl
    {
        public event EventHandler NewInvoiceClicked;
        public int currentGapinPrint;
        //public ObservableCollection<PointF[]> MyPoints { get; set; }
        public int NewbasketID { get; set; }
        public BasketCusomControl()
        {
            InitializeComponent();
        }

        private void basketCusomControl_Load(object sender, EventArgs e)
        {
            if (!DesignMode)
            {

                DisableAllFields();
                GetAkinsoftCategoriesinLocalDB();
            }
        }

        private void GetAkinsoftCategoriesinLocalDB()
        {
            using (var context = new cleaningDBEntities())
            {
                var getCategories = context.categories;
                foreach (var cat in getCategories)
                {
                    Button catBtn = CreateButton(cat.catName);
                    catBtn.Tag = new CatBtnTag { CatBtnID = cat.catID };
                    FlowlayoutCategoryPanel.Controls.Add(catBtn);
                    catBtn.Click += CatBtn_Click;
                }

            }
        }

        private void CatBtn_Click(object sender, EventArgs e)
        {
            Button currentBtn = (Button)sender;
            var currentCatID = int.Parse(currentBtn.Tag.ToString());

            //MessageBox.Show(currentCatID);
            using (var context = new cleaningDBEntities())
            {
                var getServicesDataSet = context.services
                                  .Where(x => x.catID == currentCatID).ToList();
                //.Select(x => new MyServiceDataset{ ServiceID = x.serviceID, ServerName = x.serviceName, Price = x.price  }).ToList();
                //FillListServices(getServicesDataSet);
                // Clear and ask for new one
                FillListServices(getServicesDataSet);


            }
            //throw new NotImplementedException();
        }
        // Helper function
        // using to for showing services on click of selected category
        private void FillListServices(List<service> getServicesDataSet)
        {
            ListViewServices.Items.Clear();
            ListViewServices.BeginUpdate();
            foreach (var item in getServicesDataSet)
            {
                ListViewItem li = new ListViewItem();


                li.Text = item.serviceName; // First column

                decimal cprice = item.price ?? 0;
                string formatedPrice = cprice.ToString("###,##0.00") + " TL";
                li.SubItems.Add(formatedPrice); // Second Column
                li.Tag = item; // Give tag saving all info of indivusal services on each
                ListViewServices.Items.Add(li);
                //ListViewServices.Controls.Add(item.ServerName.ToString());
            }
            ListViewServices.EndUpdate();
            ListViewServices.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);
            ListViewServices.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);

        }

        //private void FillListServices(IQueryable<service> getServicesDataSet)
        //{
        //    ListViewServices.BeginUpdate();
        //    foreach (var item in getServicesDataSet)
        //    {
        //        ListView li = new ListView();
        //        li.Items.Add( item.serviceName );
        //        //ListViewServices.Controls.Add(item.ServerName.ToString());
        //    }
        //    ListViewServices.EndUpdate();
        //    //throw new NotImplementedException();
        //}

        //private void FillListServices(List<MyServiceDataset> myservices)
        //{
        //    ListViewServices.BeginUpdate();

        //    foreach (var item in myservices)
        //    {
        //        ListView li = new ListView();
        //        li.Items.Add(item.ServerName);
        //        //ListViewServices.Controls.Add(item.ServerName.ToString());
        //    }

        //    ListViewServices.EndUpdate();
        //}

        // Helper function to creat buttons
        // using for creating Categories
        Button CreateButton(string txt)
        {
            Button btn = new Button();
            btn.Size = new Size(110, 50);
            btn.Font = new Font("Candara", 12, FontStyle.Bold);
            btn.Text = txt;

            //Background and forground color
            btn.ForeColor = ColorTranslator.FromHtml("#888888"); // text color
            btn.BackColor = SystemColors.Control; // btn background

            btn.TextAlign = ContentAlignment.MiddleCenter;
            btn.Margin = new Padding(5);

            return btn;

        }

        private void DisableAllFields()
        {
            this.txtbSelectedName.ReadOnly = true;
            this.txtbSelectedTelephone.ReadOnly = true;
            this.txtbSelectedAddress.ReadOnly = true;
        }

        // Get Client details using EVENT
        public void UpdateClientName(int id, string name, string tel, string address)
        {
            //set { this.txtbSelectedName.Text = value; }
            //set { this.txtbSelectedName.Text = value; }
            this.lblClientNumber.Text = id.ToString(); // iD to string
            this.txtbSelectedName.Text = name;
            this.txtbSelectedTelephone.Text = tel;
            this.txtbSelectedAddress.Text = address;
        }

        // Upon selected index of the service, Process to add on Invoice Form
        private void ListViewServices_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ListViewServices.SelectedItems.Count == 0) return;

            service selectedService = (service)ListViewServices.SelectedItems[0].Tag;

            // Design Flaw: A form that's displayed with ShowDialog() isn't disposed
            // Therefore using using(){} i.e blocks
            using (addServiceToInvoice addServiceForm = new addServiceToInvoice(selectedService))
            {
                DialogResult dr = addServiceForm.ShowDialog();
                if (dr == DialogResult.OK)
                {
                    // Calling function to add Services to Invoice
                    // Passing Service as params
                    AddServicesToInvoice(addServiceForm.ReturnServiceDetails);

                }
                else
                {
                    MessageBox.Show("iptal edildi !");
                }
            }
        }

        private void AddServicesToInvoice(AddToBasketServices returnServiceDetails)
        {
            listViewInvoiceServices.BeginUpdate();

            ListViewItem li = new ListViewItem();
            li.Text = returnServiceDetails.ServiceName; // first item, service name
            li.SubItems.Add(returnServiceDetails.ServicePrice.ToString()); // second item, service name
            listViewInvoiceServices.Items.Add(li); // add Items to List view

            listViewInvoiceServices.EndUpdate();
            // Auto resize columns
            ListViewServices.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);
            ListViewServices.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);

            // Update Total Price Label
            decimal TotalPrice = 0;
            foreach (ListViewItem itemRow in this.listViewInvoiceServices.Items)
            {
                decimal ServicePriceInInovice = decimal.Parse(itemRow.SubItems[1].Text);
                TotalPrice += ServicePriceInInovice;
            }

            this.lblTotalPrice.Text = TotalPrice.ToString();
        }

        // Fill Client Invoice with Selected Services
        //private void AddServicesToInvoice(Product returnServiceDetails)
        //{
        //    listViewInvoiceServices.BeginUpdate();
        //    ListViewItem li = new ListViewItem();
        //    li.Text = returnServiceDetails.productName;
        //    li.SubItems.Add(returnServiceDetails.productPrince.ToString());
        //    listViewInvoiceServices.Items.Add(li); // add Items to List view
        //    listViewInvoiceServices.EndUpdate();
        //    // Auto resize columns
        //    ListViewServices.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);
        //    ListViewServices.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
        //}

        private IEnumerable<ListViewSubItem> GetItemsFromListViewControl()
        {
            foreach (ListViewItem itemRow in this.listViewInvoiceServices.Items)
            {
                for (int i = 0; i < itemRow.SubItems.Count; i++)
                {
                    //Debug.WriteLine(itemRow.SubItems[i]);
                    yield return itemRow.SubItems[i];
                }
            }
        }


        // Saving all Invoice to DB
        private void btnSave_Click(object sender, EventArgs e)
        {


            GetnSaveInvoiceDetails();
            //foreach (ListViewItem itemRow in this.listViewInvoiceServices.Items)
            //{                
            //    //for (int i = 0; i < itemRow.SubItems.Count; i++)
            //    //{
            //    //    //Debug.WriteLine(itemRow.SubItems[i]);
            //    //    yield return itemRow.SubItems[i];
            //    //}
            //}


            //int i = 0;
            //foreach (ListViewItem.ListViewSubItem subItem in GetItemsFromListViewControl())
            //{
            //    if (i % 2 == 0)
            //    {
            //        Debug.WriteLine("=====================");
            //    }
            //    Debug.WriteLine(subItem.ToString());
            //    i++;
            //}



            //ArrayList arrList = new ArrayList();
            //var ServicesinInvoices = this.ListViewServices.Items.Cast<ListViewItem>();
            //string [] ServiceList = this.ListViewServices.Items.Select
            //ListView.ListViewItemCollection( ListViewServices );
            //ListView.ListViewItemCollection ServiceCollection = this.ListViewServices.Items;

            //ArrayList lviItemsArrayList = new ArrayList(ListViewServices.Items.ToList());

            //foreach (ListViewItem itemRow in listViewInvoiceServices.Items)
            //{
            //    for (int i = 0; i < itemRow.SubItems.Count; i++)
            //    {
            //        Debug.WriteLine(itemRow.SubItems[i]);
            //    }
            //}


            //MessageBox.Show("Items Count? " + a);

            //for (int i = 0; i < ServicesinInvoices.Count; i++)
            //{
            //    Debug.WriteLine("Items => " + this.ListViewServices.Items[i].Text);
            //}

            //var myList = new List<string>();
            //foreach (var item in ServicesinInvoices)
            //{
            //    Debug.WriteLine("Items => " + item.Text);
            //}
        }

        private void GetnSaveInvoiceDetails()
        {
            int id = Int32.Parse(this.lblClientNumber.Text);
            string name = this.txtbSelectedName.Text; // name
            string telephone = this.txtbSelectedTelephone.Text; // telephone
            string address = this.txtbSelectedAddress.Text; // address


            // First save Client Basket i.e each user will have its own basket id
            // Return new Basket ID
            using (var context = new cleaningDBEntities())
            {
                var basket = new basket()
                {
                    clientID = Int32.Parse(this.lblClientNumber.Text),
                };

                context.baskets.Add(basket);
                context.SaveChanges();
                NewbasketID = basket.basketID;
            }

            // Add Basket Details to particular Basket(basketID)
            using (var context = new cleaningDBEntities())
            {
                // Get all Services in Invoice
                // While getting save them on DB 
                foreach (ListViewItem itemRow in this.listViewInvoiceServices.Items)
                {
                    string ServiceNameInInovice = itemRow.SubItems[0].Text;
                    decimal ServicePriceInInovice = decimal.Parse(itemRow.SubItems[1].Text);

                    var basketDetails = new basketDetail()
                    {
                        basketID = NewbasketID,
                        basketProductName = ServiceNameInInovice,
                        basketProductPrice = ServicePriceInInovice,
                    };
                    context.basketDetails.Add(basketDetails);
                }
                // Save Context afer preparing Entitties
                context.SaveChanges();
            }

            // After saving showing Dialog and ask for Print or Go back to First UI with rest
            // nah just disbale the button and remove cancel button
            this.btnSave.Enabled = false;
            this.btnSave.BackColor = SystemColors.WindowFrame;
            MetroMessageBox.Show(this, "Yeni Fatura kaydedildi", "Fatura", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            // remove cancel button
            this.btnCancel.Text = "Tekrar Başla?";
            this.btnCancel.BackColor = SystemColors.MenuHighlight;
            this.btnCancel.Image = null;
            //this.btnCancel.TextAlign = 
            this.btnCancel.Click += BtnCancel_WithNewInovice_Click;
            //if (dr == DialogResult.OK) {}
            // Test Debug
            //Debug.WriteLine(id);
        }

        // get image from resources
        public static Bitmap GetImageByName(string imageName)
        {
            System.Reflection.Assembly asm = System.Reflection.Assembly.GetExecutingAssembly();
            string resourceName = asm.GetName().Name + ".Properties.Resources";
            var rm = new System.Resources.ResourceManager(resourceName, asm);
            return (Bitmap)rm.GetObject(imageName);

        }

        private void BtnCancel_WithNewInovice_Click(object sender, EventArgs e)
        {
            // Clear all Fields of baskets detials
            goBack();
            // Clear new Invoice Button to cancel button details
            this.btnCancel.Text = "İptal et";
            this.btnCancel.BackColor = Color.Firebrick;
            this.btnCancel.Image = GetImageByName("icons8_Cancel_Subscription_32px");
            // Make Save button enabled
            this.btnSave.Enabled = true;
            this.btnSave.BackColor = Color.Chartreuse;
            // Make service listview empty as well.
            this.ListViewServices.Items.Clear();
            // Invoke event
            // will calling function from 1st ui to clearn Client Fields
            // also Bring UI first up and make second UI down, see mainform for that.
            NewInvoiceClicked?.Invoke(this, EventArgs.Empty);
            //newInvoiceEvent();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            // Rest Basket List
            // throw this view one back
            // make visible false
            goBack();

            //NewInvoiceClicked?.Invoke(this, new meventArgs());

        }

        private void goBack()
        {
            this.listViewInvoiceServices.Items.Clear();
            SendToBackHelper();
        }

        public void SendToBackHelper()
        {
            this.SendToBack();
        }
        // Create Print Preview
        private void BtnPrintPreview_Click(object sender, EventArgs e)
        {
            InvoicePrintPreviewDialog.Document = InvoicePrintDocument;
            InvoicePrintPreviewDialog.Size = new System.Drawing.Size(1000, 1000);
            InvoicePrintPreviewDialog.StartPosition = FormStartPosition.CenterScreen;
            InvoicePrintPreviewDialog.ShowDialog();
        }
        // Send Print command to Invoice Document
        private void BtnPrint_Click_1(object sender, EventArgs e)
        {
            //InvoicePrintDocument is document for invoice see in Designer
            InvoicePrintDocument.Print();
        }

        // Creating Print Data and Design
        private void InvoicePrintDocument_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            string Dashlines = "------------------------------------------------------------------------------------------------------------";
            PrintLineHeading(e, "Müşteri detayları", 100, 100);

            PrintLineNormal(e, "Fatura Numarası: " + this.lblClientNumber.Text.ToString(), 100, 180);
            PrintLineNormal(e, "Tarih: " + DateTime.Now, 100, 200);
            PrintLineNormal(e, "Müşteri Ad: " + this.txtbSelectedName.Text.ToString(), 100, 220);
            PrintLineNormal(e, "telefon: " + this.txtbSelectedTelephone.Text.ToString(), 100, 240);
            PrintLineNormal(e, "Adres: " + this.txtbSelectedAddress.Text.ToString(), 100, 260);

            PrintLineNormal(e, Dashlines, 100, 340);
            PrintLineNormal(e, "Hizmet Adı" + this.txtbSelectedAddress.Text.ToString(), 100, 360);
            PrintLineNormal(e, "Fiyat" + this.txtbSelectedAddress.Text.ToString(), 550, 360);
            PrintLineNormal(e, "Miktar" + this.txtbSelectedAddress.Text.ToString(), 675, 360);
            PrintLineNormal(e, Dashlines, 100, 380);

            // Get all Services inside the Invoice
            //ref int gap = ref "400";
            currentGapinPrint = 420;

            foreach (ListViewItem itemRow in this.listViewInvoiceServices.Items)
            {
                string ServiceNameInInovice = itemRow.SubItems[0].Text;
                decimal ServicePriceInInovice = decimal.Parse(itemRow.SubItems[1].Text);

                PrintLineNormal(e, ServiceNameInInovice, 100, currentGapinPrint);
                PrintLineNormal(e, ServicePriceInInovice.ToString(), 550, currentGapinPrint);
                PrintLineNormal(e, "0", 675, currentGapinPrint);

                currentGapinPrint = currentGapinPrint + 20;
                //ref gap;
            }

            PrintLineNormal(e, Dashlines, 100, currentGapinPrint + 20);
            PrintLineNormal(e, "Ziyaret için teşekkür ederim!" + this.txtbSelectedAddress.Text.ToString(), 100, currentGapinPrint + 40);

        }

        private void PrintLineNormal(System.Drawing.Printing.PrintPageEventArgs e, string myargs, int x, int y)
        {
            e.Graphics.DrawString(myargs, new Font("Arial", 12, FontStyle.Regular), Brushes.Black, new Point(x, y));
        }
        private void PrintLineHeading(System.Drawing.Printing.PrintPageEventArgs e, string myargs, int x, int y)
        {
            e.Graphics.DrawString(myargs, new Font("Arial", 18, FontStyle.Regular), Brushes.Black, new Point(x, y));
        }
    }


    internal class CatBtnTag
    {
        public int CatBtnID { get; set; }
        public int ReturnCatId()
        {
            return this.CatBtnID;
        }

        public override string ToString()
        {
            return this.CatBtnID.ToString();
        }
    }

    public class MyServiceDataset
    {
        public string ServerName { get; set; }
        public int ServiceID { get; set; }
        public float Price { get; set; }
    }
}
