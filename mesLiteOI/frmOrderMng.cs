using System;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace mesLiteOI
{
    public partial class frmOrderMng : MetroFramework.Forms.MetroForm
    {
        #region Valirable
        private static readonly HttpClient client = new HttpClient();
        #endregion

        #region Load
        public frmOrderMng()
        {
            InitializeComponent();
        }

        private void frmOrderMng_Load(object sender, EventArgs e)
        {
            //dtOrder.Format = DateTimePickerFormat.Short;

            grdMain.DataSource = workOrderInfos;
        }

        #endregion

        #region Varliable
        List<WorkOrderInfo> workOrderInfos = new List<WorkOrderInfo>
        {
            new WorkOrderInfo {FACTORY_CODE = "hycu", ORDER_NO = "20241101-0001", LINE_CODE = "TIP", MAT_CODE = "생성", PRIORITY = 1
                , CREATE_USER_ID= "sjchoi", CREATE_TIME = "2024-11-01", UPDATE_USER_ID= "sjchoi", UPDATE_TIME = "2024-11-01"},
            new WorkOrderInfo {FACTORY_CODE = "hycu", ORDER_NO = "20241101-0002", LINE_CODE = "Cartridge", MAT_CODE = "대기", PRIORITY = 1
                , CREATE_USER_ID= "sjchoi", CREATE_TIME = "2024-11-01", UPDATE_USER_ID= "sjchoi", UPDATE_TIME = "2024-11-01"},
            new WorkOrderInfo {FACTORY_CODE = "hycu", ORDER_NO = "20241101-0002", LINE_CODE = "BODY", MAT_CODE = "종료", PRIORITY = 1
                , CREATE_USER_ID= "sjchoi", CREATE_TIME = "2024-11-01", UPDATE_USER_ID= "sjchoi", UPDATE_TIME = "2024-11-01"},

        };
        #endregion

        #region Event
        #endregion

        #region Func
        #endregion

        #region Model
        public class WorkOrderInfo
        {
            public string FACTORY_CODE { get; set; }
            public string ORDER_NO { get; set; }
            public string LINE_CODE { get; set; }
            public string MAT_CODE { get; set; }
            public int PRIORITY { get; set; }
            public string CREATE_USER_ID { get; set; }
            public string CREATE_TIME { get; set; }
            public string UPDATE_USER_ID { get; set; }
            public string UPDATE_TIME { get; set; }

            #endregion
        }

        private async void metroButton1_Click(object sender, EventArgs e)
        {
            string url = "http://localhost:8080/api/orders"; // 호출할 API URL

            try
            {
                HttpResponseMessage response = await client.GetAsync(url);
                response.EnsureSuccessStatusCode(); // 응답이 성공적인지 확인

                string responseBody = await response.Content.ReadAsStringAsync();
                List<WorkOrderInfo> data = JsonSerializer.Deserialize<List<WorkOrderInfo>>(responseBody);
                grdMain.DataSource = data;
                //MessageBox.Show(responseBody); // 응답 본문을 메시지 박스로 표시
            }
            catch (HttpRequestException ex)
            {
                MessageBox.Show("Request error: " + ex.Message);
            }
        }

        private void metroButton4_Click(object sender, EventArgs e)
        {
            grdMain.DataSource = null;
        }
    }
}
