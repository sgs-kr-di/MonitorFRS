using DevExpress.XtraBars;
using DevExpress.XtraEditors;
using MonitorFRS.Source.C.Units;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MonitorFRS.Source.A.Forms.Fluent.B.Dialog
{
    public partial class frmFRSDetail : XtraForm
    {
        private UnitCommon uCommon;
        private AppDatabase.frmFRSInquire_P1_DataSet frmFRSInquire_P1_Set;
        private AppDatabase.frmFRSInquire_P1_IMAGE_DataSet frmFRSInquire_P1_IMAGE_Set;
        private AppDatabase.frmFRSInquire_FRS_P1_DATA_DataSet frmFRSInquire_FRS_P1_DATA_Set;
        private DataTable FRS_Data_DT;

        public frmFRSDetail()
        {
            InitializeComponent();
            Initialize();
        }

        private void Initialize()
        {
            uCommon = new UnitCommon();
            frmFRSInquire_P1_Set = new AppDatabase.frmFRSInquire_P1_DataSet(AppRes.DB.Connect, null, null);
            frmFRSInquire_P1_IMAGE_Set = new AppDatabase.frmFRSInquire_P1_IMAGE_DataSet(AppRes.DB.Connect, null, null);
            frmFRSInquire_FRS_P1_DATA_Set = new AppDatabase.frmFRSInquire_FRS_P1_DATA_DataSet(AppRes.DB.Connect, null, null);
            FRS_Data_DT = new DataTable();
            FRS_Data_DT.Columns.Add("HZ");
            FRS_Data_DT.Columns.Add("G");
        }

        void windowsUIButtonPanel_ButtonClick(object sender, DevExpress.XtraBars.Docking2010.ButtonEventArgs e)
        {
            if (e.Button.Properties.Caption == "그림 다운로드")
            {
                uCommon.Save_Another_File(FRS_Data_pic.Image);
            }
            else if (e.Button.Properties.Caption == "데이터 다운로드")
            {
                uCommon.Export_Csv(FRS_Data_DetailGrid);
            }
            else if (e.Button.Properties.Caption == "참고 다운로드")
            {
                MessageBox.Show("준비중입니다.");
            }
            else if (e.Button.Properties.Caption == "나가기")
            {
                this.Close();
            }
            else 
            {

            }
        }

        private void frmFRSDetail_Load(object sender, EventArgs e)
        {
            // FRS P1 불러오기
            frmFRSInquire_P1_Set.iIDX = frmLogin_FRS_Info.iIDX;
            frmFRSInquire_P1_Set.Select();
            frmFRSInquire_P1_Set.Fetch();

            if (frmFRSInquire_P1_Set.Empty == false)
            {
                txtREGISTRANT.Text = frmFRSInquire_P1_Set.sREGISTRANT;
                txtPOWERPLANT.Text = frmFRSInquire_P1_Set.sPOWERPLANT;
                txtBUILDING.Text = frmFRSInquire_P1_Set.sBUILDING;
                txtHEIGHT.Text = frmFRSInquire_P1_Set.sHEIGHT;
                dateEditREGISTRATIONDATE.Text = frmFRSInquire_P1_Set.sREGISTRATIONDATE.ToString();
                txtWAY.Text = frmFRSInquire_P1_Set.sWAY;
                txtDAMPING.Text = frmFRSInquire_P1_Set.sDAMPING;
            }            

            // FRS P1 IMAGE 불러오기
            frmFRSInquire_P1_IMAGE_Set.iP1_IDX = frmLogin_FRS_Info.iIDX;
            frmFRSInquire_P1_IMAGE_Set.Select();
            frmFRSInquire_P1_IMAGE_Set.Fetch();

            if (frmFRSInquire_P1_IMAGE_Set.Empty == false)
            {
                FRS_Data_pic.Image = frmFRSInquire_P1_IMAGE_Set.bPicture;
            }

            // FRS P1 DATA 불러오기
            frmFRSInquire_FRS_P1_DATA_Set.iFRS_P1_IDX = frmLogin_FRS_Info.iIDX;
            frmFRSInquire_FRS_P1_DATA_Set.Select();
            FRS_Data_DT.Clear();

            for (int i = 0; i < frmFRSInquire_FRS_P1_DATA_Set.RowCount; i++)
            {
                frmFRSInquire_FRS_P1_DATA_Set.Fetch(i);
                FRS_Data_DT.Rows.Add(frmFRSInquire_FRS_P1_DATA_Set.sHZ, frmFRSInquire_FRS_P1_DATA_Set.sG);
            }

            if (frmFRSInquire_FRS_P1_DATA_Set.Empty == false)
            {
                FRS_Data_DetailGrid.DataSource = FRS_Data_DT;                
            }
        }

        /*
public BindingList<Customer> GetDataSource()
{
   BindingList<Customer> result = new BindingList<Customer>();
   result.Add(new Customer()
   {
       ID = 1,
       Name = "ACME",
       Address = "2525 E El Segundo Blvd",
       City = "El Segundo",
       State = "CA",
       ZipCode = "90245",
       Phone = "(310) 536-0611"
   });
   result.Add(new Customer()
   {
       ID = 2,
       Name = "Electronics Depot",
       Address = "2455 Paces Ferry Road NW",
       City = "Atlanta",
       State = "GA",
       ZipCode = "30339",
       Phone = "(800) 595-3232"
   });
   return result;
}
public class Customer
{
   [Key, Display(AutoGenerateField = false)]
   public int ID { get; set; }
   [Required]
   public string Name { get; set; }
   public string Address { get; set; }
   public string City { get; set; }
   public string State { get; set; }
   [Display(Name = "Zip Code")]
   public string ZipCode { get; set; }
   public string Phone { get; set; }
}
*/
    }

}
