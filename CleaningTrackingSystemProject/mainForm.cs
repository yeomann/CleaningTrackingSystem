using MetroFramework;
using MetroFramework.Forms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CleaningTrackingSystemProject
{

    public partial class mainForm : Form
    {
        public mainForm()
        {
            InitializeComponent();
        }

        private void mainForm_Load(object sender, EventArgs e)
        {

            HomebodyPanel.BringToFront();
            ReportsBodyPanel.SendToBack();

            //Fetch Akinsoft and Fill localDB
            FetchAkinSoftnFillDB();

            // Passing Name, ID, telephone, Address to send UI as Event
            // event delagation
            //this.HomeClientPanel.MyEvent += MainWindow_myevent;
            //this.HomeClientPanel.ButtonClicked += MainWindow_myevent;
            //this.HomeClientPanel.Control1ButtonClicked += new EventHandler<meventArgs>(userControl1_Control1ButtonClicked);
            //this.HomeClientPanel.clicked .ClickPointData += new this.HomeClientPanel.OnClickPointDataEvent(form_subscribe_event);
            this.HomeClientPanel.Control1ButtonClicked += HomeClientPanel_Control1ButtonClicked;
            this.HomeBasketPanel.NewInvoiceClicked += HomeBasketPanel_NewInvoiceClicked;
        }

        // Event to Rest client details in First UI, calling it from second UI
        private void HomeBasketPanel_NewInvoiceClicked(object sender, EventArgs e)
        {
            // Reset Client fields
            // Restart Client Combox Source
            // Make UI changes
            // Make Menu Button enabled again
            // Reset Services List from basket UI => doing that on call on need here
            // Reset Btn save and Btn Cancel from basket UI => doing that on call on need here
            // Restart Reports DataSource

            // fuction to rest all client fields
            this.HomeClientPanel.InitNewInvoice();
            // Restart Client Combox Source
            this.HomeClientPanel.ReLoadClientsSource();
            // making UI changes
            HomebodyPanel.BringToFront();
            ReportsBodyPanel.SendToBack();
            // Making Menu buttons enabled 
            btnReports.Enabled = true;
            btnSearch.Enabled = true;
            // Restart Reports DataSource
            this.HomeReportsPanel.RefreshAll();
        }

        // Event to send selected client details to second UI
        private void HomeClientPanel_Control1ButtonClicked(object sender, meventArgs e)
        {
            //MessageBox.Show("Hi => " + e.textname);
            this.HomeBasketPanel.UpdateClientName(e.ClientID, e.Clientname, e.Telephone, e.Address);
            // Disbale the Menu buttons
            btnReports.Enabled = false;
            btnSearch.Enabled = false;

        }

        //private void form_subscribe_event(object sender, PointF[] data)
        //{
        //    uc2.SomePublicMethod(data);
        //}


        void userControl1_Control1ButtonClicked()
        {
            //Do Something to control 2
            //this.HomeBasketPanel.MyPoints.Add("1"); //Whatever
        }
        void MainWindow_myevent(object sender, EventArgs e)
        {
            //this.HomeBasketPanel.UpdateClientName(sender.ToString());

            //this.HomeBasketPanel.UpdateClientName = e.Text;
            //this.HomeBasketPanel.FillClientDetails = this.HomeClientPanel.getClientName;
        }

        // Fetch Akinsoft Group and services
        // Fill localDB tables 1- products 2- Services
        private void FetchAkinSoftnFillDB()
        {
            
            SqlConnectionStringBuilder sqlConnectionString = new SqlConnectionStringBuilder()
            {
                DataSource = @"DESKTOP-0LJV0Q0\DANISH",
                InitialCatalog = "WOLVOX8_DRYCLEANING_2018_WOLVOX",
                UserID = "sa",
                Password = "12345"
            };
            //SqlConnection conn = new SqlConnection(sqlConnectionString.ConnectionString);

            using (SqlConnection connection = new SqlConnection(sqlConnectionString.ConnectionString))
            {
                // GRUP and HIZMET are the tables from AkinSoft
                string QueryGroup = "SELECT [GRUP_ADI] FROM GRUP";
                string QueryServices = "SELECT [ADI],[GRUBU],[KPB_FIYATI] FROM HIZMET";

                var cmd = new SqlCommand(QueryGroup, connection);
                cmd.CommandType = CommandType.Text;

                var cmdService = new SqlCommand(QueryServices, connection);
                cmdService.CommandType = CommandType.Text;

                // list for categories
                List<String> allCategories = new List<String>();
                // list for 2 column services
                //List<string>[] allServices = new List<String>[];
                //allServices[0] = new List<string>();
                //allServices[1] = new List<string>();
                List<ServiceType> allService = new List<ServiceType>();

                // Convert All Group name to their Crossponding ID's
                List<CateogryLocalDB> prepareService = new List<CateogryLocalDB>();


                connection.Open();
                if (connection.State == ConnectionState.Open)
                {
                    MetroMessageBox.Show(this, " Akin soft connected. Fetching Data", "Connection Success", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    //Delete Group
                    //Delete Services
                    // in localDB they are called Categories and Services
                    using (var context = new cleaningDBEntities())
                    {
                        //https://stackoverflow.com/questions/253849/cannot-truncate-table-because-it-is-being-referenced-by-a-foreign-key-constraint
                        // The DELETE statement conflicted with the REFERENCE constraint "FK_services_categories". 
                        // The conflict occurred in database "cleaningDB", table "dbo.services", column 'catID'.
                        // thats why delete Services first and then Categories
                        context.Database.ExecuteSqlCommand("TRUNCATE TABLE services");
                        context.Database.ExecuteSqlCommand("DELETE FROM categories DBCC CHECKIDENT('categories', RESEED, 0)");


                        // Query [WOLVOX8_DRYCLEANING_2018_WOLVOX].[dbo].[GRUP] 
                        using (SqlDataReader objReader = cmd.ExecuteReader())
                        {
                            if (objReader.HasRows)
                            {
                                while (objReader.Read())
                                {
                                    //I would also check for DB.Null here before reading the value.
                                    //string item = objReader.GetString(objReader.GetOrdinal("Column1"));
                                    string category = objReader.GetString(objReader.GetOrdinal("GRUP_ADI"));
                                    allCategories.Add(category);

                                }
                            }
                        }
                        // Query [WOLVOX8_DRYCLEANING_2018_WOLVOX].[dbo].[HIZMET] 
                        using (SqlDataReader objReader = cmdService.ExecuteReader())
                        {
                            if (objReader.HasRows)
                            {
                                while (objReader.Read())
                                {
                                    //I would also check for DB.Null here before reading the value.
                                    //string item = objReader.GetString(objReader.GetOrdinal("Column1"));
                                    string serviceName = objReader.GetString(objReader.GetOrdinal("ADI"));
                                    string serviceGroup = objReader.GetString(objReader.GetOrdinal("GRUBU"));
                                    double servicePrice = objReader.GetDouble(objReader.GetOrdinal("KPB_FIYATI"));
                                    allService.Add(new ServiceType { ServiceName = serviceName, GroupName = serviceGroup, ServicePrice = servicePrice });
                                }
                            }
                        }


                        // First Fill Group (Categories)
                        // Save localDB
                        for (int i = 0; i < allCategories.Count; i++)
                        {
                            string catname = allCategories[i];
                            //var category = new category
                            //{
                            //    catName = allCategories[i]
                            //};
                            category newCat = new category();
                            newCat.catName = allCategories[i];
                            //var category = context.Set<categories>();

                            context.categories.Add(new category() { catName = catname });
                        }
                        context.SaveChanges();

                        // Convert All Group name to their Crossponding ID's
                        var QueryCategoies = context.categories;
                        foreach (var item in QueryCategoies)
                        {
                            prepareService.Add(new CateogryLocalDB() { CateogryName = item.catName, CategoryID = item.catID });
                        }
                        // close context
                        context.Dispose();

                    }
                    connection.Close();

                    // Preparing Categories ID for services
                    foreach (var cat in prepareService)
                    {
                        var cateogry = cat.CateogryName;
                        //MessageBox.Show(cat.CateogryName);
                        foreach (var service in allService)
                        {
                            if (service.GroupName == cateogry)
                            {
                                service.GroupName = cat.CategoryID.ToString();
                            }
                        }
                    }
                    // Saving services in localDB
                    using (var context = new cleaningDBEntities())
                    {
                        foreach (var item in allService)
                        {
                            context.services.Add(new service() { serviceName = item.ServiceName, catID = Int32.Parse(item.GroupName), price = (decimal)item.ServicePrice });
                            //Debug.WriteLine("Name: {0}, Cat: {1}", item.serviceName, item.groupName);
                        }
                        context.SaveChanges();
                        context.Dispose();
                    }

                }
                else
                {
                    DialogResult dr = MetroMessageBox.Show(this, " AkinSoft veritabanı çalışmıyor. Belki Akinsoft açık değil.", "veritabanı hatası", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    if (dr == DialogResult.OK)
                    {
                        System.Windows.Forms.Application.Exit();
                    }
                }
            }
        }

        // delete all data in DB from given table
        private void Trunicate(string table)
        {
            using (var db = new cleaningDBEntities())
            {
                db.Database.ExecuteSqlCommandAsync("TRUNCATE TABLE " + table);
            }
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


        private void pictureBox2_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.Application.Exit();
        }

        private void btnReports_Click(object sender, EventArgs e)
        {
            //change height and top of activeRibbon
            //this.Height = activeRibbon.Height;
            //this.Top = activeRibbon.Top;
            activeRibbon.Height = btnReports.Height;
            activeRibbon.Top = btnReports.Top;

            //this.SendToBack(); // Home UI first Controler
            //BasketCusomControl.SendToBackHelper(); // Home UI Second Controler
            //ReportsCustomControl.BringToFront();

            // Changing Body panel
            HomebodyPanel.SendToBack();
            ReportsBodyPanel.BringToFront();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            //change height and top of activeRibbon
            //this.Height = activeRibbon.Height;
            //this.Top = activeRibbon.Top;
            activeRibbon.Height = btnSearch.Height;
            activeRibbon.Top = btnSearch.Top;

        }

        private void btnHome_Click(object sender, EventArgs e)
        {
            activeRibbon.Height = btnHome.Height;
            activeRibbon.Top = btnHome.Top;

            //HomeClientPanel.BringToFront();
            HomebodyPanel.BringToFront();
            ReportsBodyPanel.SendToBack();

        }

        private void homeCustomControl2_Load(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
    public class ServiceType
    {
        public string GroupName { get; set; }

        public string ServiceName { get; set; }
        public double ServicePrice { get; set; }
    }

    public class CateogryLocalDB
    {
        public int CategoryID { get; set; }

        public string CateogryName { get; set; }
    }
}
