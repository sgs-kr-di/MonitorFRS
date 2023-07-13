using DevExpress.XtraBars;
using DevExpress.XtraEditors;
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
using MonitorFRS.Source.C.Units;
using System.Data.SqlClient;

namespace MonitorFRS.Source.A.Forms.Fluent.B.Dialog
{
    public partial class frmFRSInquire : XtraForm
    {
        private UnitCommon uCommon;
        private DataTable dt_FRS_Data;
        private AppDatabase.frmFRSInquire_P1_DataSet frmFRSInquire_P1_Set;
        private AppDatabase.frmFRSInquire_P1_IMAGE_DataSet frmFRSInquire_P1_IMAGE_Set;
        private AppDatabase.frmFRSInquire_FRS_P1_DATA_DataSet frmFRSInquire_FRS_P1_DATA_Set;
        private AppDatabase.frmFRSInquire_FRS_P1_REVIEW_DataSet frmFRSInquire_P1_REVIEW_Set;

        public frmFRSInquire()
        {
            InitializeComponent();
            Initialize();
        }

        private void Initialize()
        {
            Initialize_Data();
            uCommon = new UnitCommon();
            frmFRSInquire_P1_Set = new AppDatabase.frmFRSInquire_P1_DataSet(AppRes.DB.Connect, null, null);
            frmFRSInquire_P1_IMAGE_Set = new AppDatabase.frmFRSInquire_P1_IMAGE_DataSet(AppRes.DB.Connect, null, null);
            frmFRSInquire_FRS_P1_DATA_Set = new AppDatabase.frmFRSInquire_FRS_P1_DATA_DataSet(AppRes.DB.Connect, null, null);
            frmFRSInquire_P1_REVIEW_Set = new AppDatabase.frmFRSInquire_FRS_P1_REVIEW_DataSet(AppRes.DB.Connect, null, null);
        }

        public void windowsUIButtonPanel_ButtonClick(object sender, DevExpress.XtraBars.Docking2010.ButtonEventArgs e)
        {
            //if (e.Button.Properties.Caption == "Print") FRS_Data_Grid.ShowRibbonPrintPreview();
            if (e.Button.Properties.Caption == "그림 첨부")
            {
                uCommon.Save_Image(FRS_Data_picEdit);
            }
            else if (e.Button.Properties.Caption == "데이터 첨부")
            {
                uCommon.Import_Csv_Grid(FRS_Data_InquireGrid);
                dt_FRS_Data = uCommon.ReturnDT();
            }
            else if (e.Button.Properties.Caption == "참고첨부")
            {
                MessageBox.Show("준비중입니다.");
            }
            else if (e.Button.Properties.Caption == "등록")
            {
                if (string.IsNullOrEmpty(txtBuilding.Text))
                {
                    MessageBox.Show("건물 값을 입력해주세요.");
                }
                else if (string.IsNullOrEmpty(txtWay.Text))
                {
                    MessageBox.Show("방향 값을 입력해주세요.");
                }
                else if (string.IsNullOrEmpty(txtPowerPlant.Text))
                {
                    MessageBox.Show("발전소 값을 입력해주세요.");
                }
                else if (string.IsNullOrEmpty(txtHeight.Text))
                {
                    MessageBox.Show("높이 값을 입력해주세요.");
                }
                else if (string.IsNullOrEmpty(txtDamping.Text))
                {
                    MessageBox.Show("댐핑 값을 입력해주세요.");
                }
                else if (FRS_Data_picEdit.Image == null)
                {
                    MessageBox.Show("그림 첨부를 해주세요.");
                }
                else if (FRS_Data_InquireGrid.DataSource == null)
                {
                    MessageBox.Show("데이터 첨부를 해주세요.");
                }
                else
                {
                    SqlTransaction trans = AppRes.DB.BeginTrans();

                    try
                    {
                        // P1값 입력
                        frmFRSInquire_P1_Set.sREGISTRANT = txtRegistrant.Text;
                        frmFRSInquire_P1_Set.sREGISTRATIONDATE = DateTime.Now;
                        frmFRSInquire_P1_Set.sBUILDING = txtBuilding.Text;
                        frmFRSInquire_P1_Set.sWAY = txtWay.Text;
                        frmFRSInquire_P1_Set.sPOWERPLANT = txtPowerPlant.Text;
                        frmFRSInquire_P1_Set.sHEIGHT = txtHeight.Text;
                        frmFRSInquire_P1_Set.sDAMPING = txtDamping.Text;
                        frmFRSInquire_P1_Set.sID = frmLogin_LoginInfo.sUserId;
                        frmFRSInquire_P1_Set.sLASTM_ID = frmLogin_LoginInfo.sUserId;
                        frmFRSInquire_P1_Set.sLASTM_NAME = frmLogin_LoginInfo.sUserName;
                        frmFRSInquire_P1_Set.sLASTM_DATE = DateTime.Now;
                        frmFRSInquire_P1_Set.Insert(trans);

                        // P1 Image값 입력
                        frmFRSInquire_P1_IMAGE_Set.iP1_IDX = frmFRSInquire_P1_Set.iIDX;
                        frmFRSInquire_P1_IMAGE_Set.bPicture = (Bitmap)FRS_Data_picEdit.Image;
                        frmFRSInquire_P1_IMAGE_Set.Insert(trans);

                        // P1 Status값 입력
                        frmFRSInquire_P1_REVIEW_Set.iIDX = frmFRSInquire_P1_Set.iIDX;
                        frmFRSInquire_P1_REVIEW_Set.sSTATUS = "리뷰전";
                        frmFRSInquire_P1_REVIEW_Set.sModifiedDate = DateTime.Now; ;
                        frmFRSInquire_P1_REVIEW_Set.Insert(trans);

                        // P1 Data값 입력
                        foreach (DataRow row_FRS in dt_FRS_Data.Rows)
                        {
                            frmFRSInquire_FRS_P1_DATA_Set.iFRS_P1_IDX = frmFRSInquire_P1_Set.iIDX;
                            frmFRSInquire_FRS_P1_DATA_Set.sHZ = row_FRS["HZ"].ToString();
                            frmFRSInquire_FRS_P1_DATA_Set.sG = row_FRS["G"].ToString();
                            frmFRSInquire_FRS_P1_DATA_Set.Insert(trans);
                        }

                        AppRes.DB.CommitTrans();
                        MessageBox.Show("입력 완료!");

                        Initialize_Data();
                    }
                    catch (Exception f)
                    {
                        AppRes.DB.RollbackTrans();
                        MessageBox.Show("입력 실패!" + Environment.NewLine + f.Source + Environment.NewLine + f.Message);
                    }
                }
            }
            else if (e.Button.Properties.Caption == "취소")
            {
                //Initialize_Data();
                this.Close();
            }
            else
            {
                MessageBox.Show("정상적인 접근이 아닙니다.");
            }
        }

        private void frmFRSInquire_Load(object sender, EventArgs e)
        {
            Initialize_Data();
            if (!string.IsNullOrEmpty(frmLogin_LoginInfo.sUserId) || !string.IsNullOrWhiteSpace(frmLogin_LoginInfo.sUserId)) 
            {
                txtRegistrant.Text = frmLogin_LoginInfo.sUserName;
            }
        }

        private void Initialize_Data() 
        {
            txtBuilding.Text = "";
            txtWay.Text = "";
            txtPowerPlant.Text = "";
            txtHeight.Text = "";
            txtDamping.Text = "";
            FRS_Data_picEdit.Image = null;
            FRS_Data_InquireGrid.DataSource = null;
            FRS_Data_picEdit.Refresh();
            FRS_Data_InquireGrid.RefreshDataSource();
            FRS_Data_InquireGrid.Refresh();
            dt_FRS_Data = new DataTable();
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
