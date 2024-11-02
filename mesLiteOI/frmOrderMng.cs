namespace mesLiteOI
{
    public partial class frmOrderMng : MetroFramework.Forms.MetroForm
    {
        #region Load
        public frmOrderMng()
        {
            InitializeComponent();
        }

        private void frmOrderMng_Load(object sender, EventArgs e)
        {
            //dtOrder.Format = DateTimePickerFormat.Short;

            grdMain.DataSource = order;
        }

        #endregion

        #region Varliable
        List<Order> order = new List<Order>
        {
            new Order {ID = 1, orderNo = "20241101-0001", matCOde = "TIP", orderStatue = "생성", type = "정규생산", orderDate = "2024-11-01", description = "BODY"},
            new Order {ID = 2, orderNo = "20241101-0002", matCOde = "Cartridge", orderStatue = "대기", type = "정규생산", orderDate = "2024-11-01", description = "TIP"},
            new Order {ID = 2, orderNo = "20241101-0002", matCOde = "BODY", orderStatue = "종료", type = "정규생산", orderDate = "2024-11-02", description = "Cartridge"},

        };
        #endregion

        #region Event
        #endregion

        #region Func
        #endregion

        #region Model
        public class Order
        {
            public int ID { get; set; }
            public string orderNo { get; set; }
            public string matCOde { get; set; }
            public string orderStatue {  get; set; }
            public string type { get; set; }
            public string orderDate { get; set; }
            public string description { get; set; }

            #endregion
        }

        

    }
}
