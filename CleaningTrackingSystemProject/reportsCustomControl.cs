using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.Entity;
using System.Diagnostics;

namespace CleaningTrackingSystemProject
{
    public partial class reportsCustomControl : UserControl
    {
        cleaningDBEntities _context = new cleaningDBEntities();
        BindingSource source = new BindingSource();
        //public basketDetail SelectedBasketDetails;
        public List<ClientBasketDetail> SelectedBasketDetails = new List<ClientBasketDetail>();
        //public ClientBasketDetail SelectedBasketDetails;
        public reportsCustomControl()
        {
            InitializeComponent();
        }

        private void reportsCustomControl_Load(object sender, EventArgs e)
        {
            //base.OnLoad(e);
            if (!DesignMode)
            {
                LoadData();
                //_context = new cleaningDBEntities();
                //_context.clients.Load();
                //this.ReportsGrid.DataSource = _context.clients.Local.ToBindingList();
            }
        }

        private void LoadData()
        {
            //SampleDBEntities db = new SampleDBEntities();
            //db.Products.Load();
            //this.productBindingSource.DataSource = db.Products.Local.ToBindingList();
            var clientsDS = from c in _context.clients
                            join b in _context.baskets on c.ID equals b.clientID
                            select new
                            {
                                Id = c.ID,
                                Name = c.name,
                                Telephone = c.telephone,
                                Address = c.address,
                                BasketDate = b.basketDateTime,
                                BasketID = b.basketID
                            };
            //context.clients.Load();
            this.ReportsGrid.DataSource = clientsDS.ToList();

            
            //source.DataSource = clientsDS.ToList();
            //this.ReportsGrid.DataSource = source;

            // dataGridView1.Columns[0].HeaderCell.Value = "Created";

            this.ReportsGrid.Columns[0].HeaderCell.Value = "Müşteri Kimliği";
            this.ReportsGrid.Columns[1].HeaderCell.Value = "Müşteri Adı";
            this.ReportsGrid.Columns[2].HeaderCell.Value = "Telefon numarası";
            this.ReportsGrid.Columns[3].HeaderCell.Value = "Adres";
            this.ReportsGrid.Columns[4].HeaderCell.Value = "Sepet tarih ve saat";
            this.ReportsGrid.Columns[5].HeaderCell.Value = "Sepet numarası";

            //ReportsGrid
            //context.Dispose();
        }
        public void RefreshAll()
        {
            //var clientsDS = from c in _context.clients
            //                join b in _context.baskets on c.ID equals b.clientID
            //                select new
            //                {
            //                    Id = c.ID,
            //                    Name = c.name,
            //                    Telephone = c.telephone,
            //                    Address = c.address,
            //                    BasketDate = b.basketDateTime,
            //                    BasketID = b.basketID
            //                };

            //_context.Entry(clientsDS).Reload();
            _context.Dispose();
            var context = new cleaningDBEntities();
            var clientsDS = from c in context.clients
                            join b in context.baskets on c.ID equals b.clientID
                            select new
                            {
                                Id = c.ID,
                                Name = c.name,
                                Telephone = c.telephone,
                                Address = c.address,
                                BasketDate = b.basketDateTime,
                                BasketID = b.basketID
                            };
            this.ReportsGrid.DataSource = clientsDS.ToList();
            //context.clients.Load();
            

        }

        // On click on Row
        private void ReportsGrid_SelectionChanged(object sender, EventArgs e)
        {


            //foreach (DataGridView row in ReportsGrid.SelectedRows)
            //{
            //    string value1 = row.SelectedCells[0].Value.ToString();
            //    string value2 = row.SelectedCells[1].Value.ToString();
            //    MessageBox.Show(value1 + value2);
            //}
        }

        // On Double click row
        private void ReportsGrid_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = ReportsGrid.Rows[e.RowIndex];

                int id = Int32.Parse(row.Cells["Id"].Value.ToString());
                string name = row.Cells["name"].Value.ToString();
                string telephone = row.Cells["Telephone"].Value.ToString();
                string address = row.Cells["Address"].Value.ToString();

                int BasketID = Int32.Parse(row.Cells["BasketID"].Value.ToString());
                using (var context = new cleaningDBEntities())
                {
                    //var BasketDetailsDS = context.baskets.Select(b => b.basketID == BasketID).ToList();
                    var BasketDetailsDS = Enumerable.ToList((from bd in context.basketDetails
                                                             where (bd.basketID == 17)
                                                             select new
                                                             {
                                                                 basketPID = bd.basketDetailsID,
                                                                 basketPName = bd.basketProductName,
                                                                 basketPPrice = bd.basketProductPrice,
                                                                 basketID = bd.basketID,
                                                                 basketPStatus = bd.basketProdcutStatus,
                                                             }));

                    foreach (var item in BasketDetailsDS)
                    {
                        //SelectedBasketDetails.Add(new ClientBasketDetail {
                        //    basketDetailsId = item.basketPID,
                        //    basketProductName = item.basketPName,
                        //    basketProductPrice = item.basketPPrice.ToString(),
                        //    basketProductStatus = item.basketPStatus,
                        //});
                        SelectedBasketDetails.Add( new ClientBasketDetail {

                            basketDetailsId = item.basketPID,
                            basketProductName = item.basketPName,
                            basketProductPrice = item.basketPPrice.ToString(),
                            basketProductStatus = item.basketPStatus

                        } );
                    }

                    //SelectedBasketDetails.Add(BasketDetailsDS.);
                    //ClientBasketDetail cBasketDetails = new ClientBasketDetail();
                    //SelectedBasketDetails.basketID = 1;
                    //SelectedBasketDetails.basketProductName = "Test";
                    //SelectedBasketDetails.basketProductPrice  = 15;
                    //SelectedBasketDetails.basketID = 17;
                    //SelectedBasketDetails.basketProductStatus = "Waiting";

                }


                ClientDetails SelectedClient = new ClientDetails(id, name, telephone, address);
                List<ClientBasketDetail> SelectedClientBasket = new List<ClientBasketDetail>( SelectedBasketDetails );

                using (frmBasketDetails clintSelectedBasket = new frmBasketDetails(SelectedClient, SelectedClientBasket))
                {
                    DialogResult dr = clintSelectedBasket.ShowDialog();
                    //if (dr == DialogResult.OK)
                    //{
                    //    // Calling function to add Services to Invoice
                    //    // Passing Service as params
                    //    //clintSelectedBasket(SelectedClient);
                    //    //AddServicesToInvoice(addServiceForm.ReturnServiceDetails);

                    //}
                    //else
                    //{
                    //    MessageBox.Show("iptal edildi !");
                    //}
                }


            }

        }
    }


    public class ClientDetails
    {
        public int id { get; set; }
        public string name { get; set; }
        public string telephone { get; set; }
        public string address { get; set; }

        //public List<ClientBasketDetails> ClientBasketDetails { get; set; } //how to do it?
        //public basketDetail clientBasketDetails { get; set; }
        //public ClientDetails(int id, string name, string telephone, string address, basketDetail clientBasket) {
        public ClientDetails(int id, string name, string telephone, string address)
        {
            this.id = id;
            this.name = name;
            this.telephone = telephone;
            this.address = address;
            //this.ClientBasketDetails = clientBasket;
        }

    }
    public class ClientBasketDetail
    {
        
        public int basketDetailsId { get; set; }
        public string basketProductName { get; set; }
        public string basketProductPrice { get; set; }
        public int basketID { get; set; }
        public string basketProductStatus { get; set; }

        //public ClientBasketDetail(int id, string name, string price, string status)
        //{
        //    this.basketDetailsId = id;
        //    this.basketProductName = name;
        //    this.basketProductPrice = price;
        //    this.basketProductStatus = status;
        //}
    }

}
