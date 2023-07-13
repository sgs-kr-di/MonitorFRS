using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MonitorFRS.Source.A.Forms.Fluent.B.Dialog;
using MonitorFRS.Source.C.Units;
using Ulee.Utils;
using System.Data.SqlClient;

namespace MonitorFRS.Source.B.Controls.A.Edit
{
    public partial class ucFrsMain : DevExpress.XtraEditors.XtraUserControl
    {
        private frmFRSInquire frmFRSInquire_Main;
        private frmFRSDetail frmFRSDetail_Main;
        private AppDatabase.frmFrsMain_P1_DataSet frmFrsMain_P1_Set;
        private AppDatabase.frmFRSInquire_P1_IMAGE_DataSet frmFRSInquire_P1_IMAGE_Set;
        private AppDatabase.frmFRSInquire_FRS_P1_DATA_DataSet frmFRSInquire_FRS_P1_DATA_Set;
        private AppDatabase.frmFRSInquire_FRS_P1_REVIEW_DataSet frmFRSInquire_P1_REVIEW_Set;

        string sSelectRowCell_Status = string.Empty;
        string sSelectRowCell_Register = string.Empty;

        public ucFrsMain()
        {
            InitializeComponent();
            Initialize();
        }

        private void Initialize()
        {
            frmFRSInquire_Main = new frmFRSInquire();
            frmFRSDetail_Main = new frmFRSDetail();
            frmFrsMain_P1_Set = new AppDatabase.frmFrsMain_P1_DataSet(AppRes.DB.Connect, null, null);
            frmFRSInquire_P1_IMAGE_Set = new AppDatabase.frmFRSInquire_P1_IMAGE_DataSet(AppRes.DB.Connect, null, null);
            frmFRSInquire_FRS_P1_DATA_Set = new AppDatabase.frmFRSInquire_FRS_P1_DATA_DataSet(AppRes.DB.Connect, null, null);
            frmFRSInquire_P1_REVIEW_Set = new AppDatabase.frmFRSInquire_FRS_P1_REVIEW_DataSet(AppRes.DB.Connect, null, null);
        }

        private void tileBar_SelectedItemChanged(object sender, TileItemEventArgs e)
        {
            //navigationFrame.SelectedPageIndex = tileBarGroupTablesLeft.Items.IndexOf(e.Item);
        }

        private void BarItemFRSInsert_ItemClick(object sender, TileItemEventArgs e)
        {
            frmFRSInquire_Main.ShowDialog();
        }

        private void BarItemFRSDetail_ItemClick(object sender, TileItemEventArgs e)
        {
            // frmMain에 기본값 0을 설정
            if (frmLogin_FRS_Info.iIDX == 0)
            {
                MessageBox.Show("데이터를 선택해주세요.");
            }
            else 
            {
                frmFRSDetail_Main.ShowDialog();
            }
            frmLogin_FRS_Info.iIDX = 0;
        }

        private void BarItemFRSSearch_ItemClick(object sender, TileItemEventArgs e)
        {
            // FRS 조회
            try
            {
                frmFrsMain_P1_Set.sBUILDING = txtBUILDING.Text;                
                frmFrsMain_P1_Set.sFROM = FrsFromDateEdit.Value.ToString(AppRes.csDateFormat);
                frmFrsMain_P1_Set.sTO = FrsToDateEdit.Value.ToString(AppRes.csDateFormat);
                frmFrsMain_P1_Set.sREGISTRANT = txtREGISTRANT.Text;
                frmFrsMain_P1_Set.sHEIGHT = txtHEIGHT.Text;
                frmFrsMain_P1_Set.sPOWERPLANT = txtPOWERPLANT.Text;
                frmFrsMain_P1_Set.sSTATUS = cbmSTATUS.Text;
                frmFrsMain_P1_Set.Select();

                if (frmFrsMain_P1_Set.Empty == false)
                {
                    //AppHelper.RefreshGridData(FRS_Data_InquireGridView);
                    AppHelper.SetGridDataSource(FRS_Data_InquireGrid, frmFrsMain_P1_Set);
                }
                else
                {

                }
            }
            catch (Exception f)
            {
                MessageBox.Show("조회 실패!" + Environment.NewLine + f.Source + Environment.NewLine + f.Message);
            }
        }

        private void FRS_Data_InquireGridView_RowCellClick(object sender, DevExpress.XtraGrid.Views.Grid.RowCellClickEventArgs e)
        {
            if (e.RowHandle < 0) return;
            frmLogin_FRS_Info.iIDX = Convert.ToInt32(FRS_Data_InquireGridView.GetFocusedDataRow()["IDX"].ToString());
            sSelectRowCell_Status = FRS_Data_InquireGridView.GetFocusedDataRow()["STATUS"].ToString();
            sSelectRowCell_Register = FRS_Data_InquireGridView.GetFocusedDataRow()["ID"].ToString();

            if (sSelectRowCell_Status.Equals("리뷰 2차완료"))
            {
                BarItemFRSReview.Enabled = false;
            }
            else
            {
                BarItemFRSReview.Enabled = true;
            }

            if (!sSelectRowCell_Status.Equals("리뷰전") || !sSelectRowCell_Register.Equals(frmLogin_LoginInfo.sloginId))
            {
                BarItemFRSCancelInsert.Enabled = false;
            }
            else
            {
                BarItemFRSCancelInsert.Enabled = true;
            }
        }

        private void BarItemFRSReview_ItemClick(object sender, TileItemEventArgs e)
        {   
            if (MessageBox.Show("선택하신 정보를 리뷰 하시겠습니까?", "리뷰하기", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                // 리뷰하기 - 로그인 유저와 등록한 유저가 동일하지 않은 것
                if (sSelectRowCell_Register.Equals(frmLogin_LoginInfo.sloginId))
                {
                    MessageBox.Show("자신이 등록한 자료는 리뷰할 수 없습니다.");
                    return;
                }

                // frmMain에 기본값 0을 설정
                if (frmLogin_FRS_Info.iIDX == 0)
                {
                    MessageBox.Show("데이터를 선택해주세요.");
                }
                else
                {
                    try
                    {
                        frmFRSInquire_P1_REVIEW_Set.iIDX = frmLogin_FRS_Info.iIDX;
                        frmFRSInquire_P1_REVIEW_Set.Select();
                        frmFRSInquire_P1_REVIEW_Set.Fetch();

                        if (frmFRSInquire_P1_REVIEW_Set.Empty == false)
                        {
                            if (frmFRSInquire_P1_REVIEW_Set.sSTATUS.Equals("리뷰전"))
                            {
                                SqlTransaction trans = AppRes.DB.BeginTrans();

                                frmFRSInquire_P1_REVIEW_Set.sSTATUS = "리뷰 1차완료" + " (" + frmLogin_LoginInfo.sUserName + ")";                                
                                frmFRSInquire_P1_REVIEW_Set.sREVIEW1_ID = frmLogin_LoginInfo.sUserId;
                                frmFRSInquire_P1_REVIEW_Set.sModifiedDate = DateTime.Now;
                                frmFRSInquire_P1_REVIEW_Set.Update(trans);

                                AppRes.DB.CommitTrans();
                                MessageBox.Show("리뷰 완료!");
                            }
                            else if (frmFRSInquire_P1_REVIEW_Set.sSTATUS.Contains("리뷰 1차완료"))
                            {
                                SqlTransaction trans = AppRes.DB.BeginTrans();

                                frmFRSInquire_P1_REVIEW_Set.sSTATUS = "리뷰 2차완료" + " (" + frmLogin_FRS_Info.sSTATUS.Substring(9,3) + ", " + frmLogin_LoginInfo.sUserName + ")";
                                frmFRSInquire_P1_REVIEW_Set.sREVIEW2_ID = frmLogin_LoginInfo.sUserId;
                                frmFRSInquire_P1_REVIEW_Set.sModifiedDate = DateTime.Now;
                                frmFRSInquire_P1_REVIEW_Set.Update(trans);

                                AppRes.DB.CommitTrans();
                                MessageBox.Show("리뷰 완료!");
                            }
                            else if (frmFRSInquire_P1_REVIEW_Set.sSTATUS.Equals("리뷰 2차완료"))
                            {
                                MessageBox.Show("리뷰 완료!");
                            }
                            else
                            {

                            }
                            BarItemFRSSearch.PerformItemClick();
                        }
                    }
                    catch (Exception f)
                    {
                        AppRes.DB.RollbackTrans();
                        MessageBox.Show("리뷰 실패!" + Environment.NewLine + f.Source + Environment.NewLine + f.Message);
                    }
                }
            }
            else
            {

            }
            frmLogin_FRS_Info.iIDX = 0;
        }

        private void BarItemFRSCancelInsert_ItemClick(object sender, TileItemEventArgs e)
        {
            if (MessageBox.Show("선택하신 정보를 등록 취소 하시겠습니까?", "등록취소", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                // frmMain에 기본값 0을 설정
                if (frmLogin_FRS_Info.iIDX == 0)
                {
                    MessageBox.Show("데이터를 선택해주세요.");
                }
                else
                {
                    // 등록취소 - 로그인 유저와 등록한 유저가 동일하고 상태가 리뷰전인 것
                    if (sSelectRowCell_Status.Equals("리뷰전") && sSelectRowCell_Register.Equals(frmLogin_LoginInfo.sloginId))
                    {
                        try
                        {
                            SqlTransaction trans = AppRes.DB.BeginTrans();

                            frmFRSInquire_FRS_P1_DATA_Set.iFRS_P1_IDX = frmLogin_FRS_Info.iIDX;
                            frmFRSInquire_FRS_P1_DATA_Set.Delete(trans);
                            frmFRSInquire_P1_IMAGE_Set.iP1_IDX = frmLogin_FRS_Info.iIDX;
                            frmFRSInquire_P1_IMAGE_Set.Delete(trans);
                            frmFrsMain_P1_Set.iIDX = frmLogin_FRS_Info.iIDX;
                            frmFrsMain_P1_Set.Delete(trans);

                            AppRes.DB.CommitTrans();
                            BarItemFRSSearch.PerformItemClick();
                        }
                        catch (Exception f)
                        {
                            AppRes.DB.RollbackTrans();
                            MessageBox.Show("등록취소 실패!" + Environment.NewLine + f.Source + Environment.NewLine + f.Message);
                        }
                    }
                }
            }
            frmLogin_FRS_Info.iIDX = 0;
        }

        private void BarItemFRSDelete_ItemClick(object sender, TileItemEventArgs e)
        {
            if (MessageBox.Show("선택하신 정보를 삭제 하시겠습니까?", "삭제", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                // frmMain에 기본값 0을 설정
                if (frmLogin_FRS_Info.iIDX == 0)
                {
                    MessageBox.Show("데이터를 선택해주세요.");
                }
                else
                {
                    // 삭제 - 로그인 유저가 Admin이고 상태가 리뷰전인 것
                    if (sSelectRowCell_Status.Equals("리뷰전"))
                    {
                        SqlTransaction trans = AppRes.DB.BeginTrans();

                        frmFRSInquire_FRS_P1_DATA_Set.iFRS_P1_IDX = frmLogin_FRS_Info.iIDX;
                        frmFRSInquire_FRS_P1_DATA_Set.Delete(trans);
                        frmFRSInquire_P1_IMAGE_Set.iP1_IDX = frmLogin_FRS_Info.iIDX;
                        frmFRSInquire_P1_IMAGE_Set.Delete(trans);
                        frmFrsMain_P1_Set.iIDX = frmLogin_FRS_Info.iIDX;
                        frmFrsMain_P1_Set.Delete(trans);

                        AppRes.DB.CommitTrans();
                        BarItemFRSSearch.PerformItemClick();
                    }
                }
            }            
            frmLogin_FRS_Info.iIDX = 0;
        }

        private void ucFrsMain_Load(object sender, EventArgs e)
        {
            if (frmLogin_LoginInfo.sGroupName.ToUpper().Contains("ADM"))
            {
                BarItemFRSDelete.Visible = true;
            }
            else
            {
                BarItemFRSDelete.Visible = false;
            }
        }

        private void FRS_P1_IDX_RadioGroup_Click(object sender, EventArgs e)
        {            
            frmLogin_FRS_Info.iIDX = Convert.ToInt32(FRS_Data_InquireGridView.GetFocusedDataRow()["IDX"].ToString());
            sSelectRowCell_Status = FRS_Data_InquireGridView.GetFocusedDataRow()["STATUS"].ToString();
            sSelectRowCell_Register = FRS_Data_InquireGridView.GetFocusedDataRow()["ID"].ToString();            

            if (sSelectRowCell_Status.Contains("리뷰 2차완료"))
            {
                BarItemFRSReview.Enabled = false;
            }
            else
            {
                BarItemFRSReview.Enabled = true;
            }

            if (!sSelectRowCell_Status.Equals("리뷰전"))
            {
                BarItemFRSCancelInsert.Enabled = false;
            }
            //else if (sSelectRowCell_Status.Contains("리뷰 1차완료"))
            //{
            //    BarItemFRSCancelInsert.Enabled = false;
            //}
            else if (!sSelectRowCell_Register.Contains(frmLogin_LoginInfo.sloginId))
            {
                BarItemFRSCancelInsert.Enabled = false;
            }
            else
            {
                BarItemFRSCancelInsert.Enabled = true;
            }

            if (sSelectRowCell_Status.Contains("리뷰 1차완료"))
            {
                frmLogin_FRS_Info.sSTATUS = FRS_Data_InquireGridView.GetFocusedDataRow()["STATUS"].ToString();
            }
        }
    }
}