using DevExpress.XtraEditors;
using MonitorFRS.Source.C.Units;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MonitorFRS.Source.B.Controls.A.Edit
{
    public partial class ucAccountRegistration : DevExpress.XtraEditors.XtraUserControl
    {
        private UnitCommon uCommon;
        private SHA256Managed sha256Managed;
        private AppDatabase.accountMaster_actMaster_DataSet accountMaster_actMaster_Set;
        public string connect_string =
                          "Provider=SQLOLEDB.1; User ID=dev01; pwd=dev010207; data source=KRSEC001; Persist Security Info=True; initial catalog=accountMaster";
        private OleDbConnection Conn;

        public ucAccountRegistration()
        {
            InitializeComponent();
            Initialize();
        }

        private void Initialize()
        {
            uCommon = new UnitCommon();
            sha256Managed = new SHA256Managed();
            accountMaster_actMaster_Set = new AppDatabase.accountMaster_actMaster_DataSet(AppRes.DB.Connect, null, null);
        }        

        private void btnSignUp_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtID.Text) == true || string.IsNullOrEmpty(txtPW.Text) == true)
            {
                MessageBox.Show("ID 또는 Password를 입력해주세요.");
            }
            else
            {
                // 해쉬 - 단반향
                byte[] encryptBytes = sha256Managed.ComputeHash(Encoding.UTF8.GetBytes(txtPW.Text));

                // Convert To base64
                String encryptString = Convert.ToBase64String(encryptBytes);

                try
                {
                    // ID 중복확인
                    accountMaster_actMaster_Set.slogInID = txtID.Text;
                    accountMaster_actMaster_Set.Select_AccountMaster();
                    if (accountMaster_actMaster_Set.Empty == true)
                    {
                        // 회사 계정 유무 확인
                        accountMaster_actMaster_Set.Select_UserMaster();
                        if (accountMaster_actMaster_Set.Empty == false)
                        {
                            //SqlTransaction trans = AppRes.DB.BeginTrans();

                            //accountMaster_actMaster_Set.iAccountNo = 0;
                            accountMaster_actMaster_Set.slogInID = txtID.Text;
                            accountMaster_actMaster_Set.suserID = txtID.Text;
                            accountMaster_actMaster_Set.sappNo = "10";
                            accountMaster_actMaster_Set.sappID = "FRS";
                            accountMaster_actMaster_Set.spassWord = encryptString;
                            accountMaster_actMaster_Set.srequestStatusCode = "approved";
                            accountMaster_actMaster_Set.sregisteredBy = "admin";
                            accountMaster_actMaster_Set.sregisteredDate = DateTime.Now;
                            accountMaster_actMaster_Set.sapprovedBy = "admin";
                            accountMaster_actMaster_Set.sapprovedDate = DateTime.Now;
                            accountMaster_actMaster_Set.smodifiedBy = "";
                            accountMaster_actMaster_Set.sModifiedDate = DateTime.Now;
                            accountMaster_actMaster_Set.sDisuse = "0";
                            accountMaster_actMaster_Set.sDisusedBy = "";
                            accountMaster_actMaster_Set.sDisusedDate = DateTime.Now;

                            //accountMaster_actMaster_Set.Insert(trans);
                            //AppRes.DB.CommitTrans();

                            string query = $" INSERT INTO [accountMaster].dbo.[accountMaster] (logInID, userID,appNo, appID, passWord, requestStatusCode, registeredBy, registeredDate, approvedBy, approvedDate, modifiedBy, ModifiedDate, Disuse, DisusedBy, DisusedDate)" +
                                    $" VALUES " +
                                    $" ('{accountMaster_actMaster_Set.slogInID}', '{accountMaster_actMaster_Set.suserID}', '{accountMaster_actMaster_Set.sappNo}', '{accountMaster_actMaster_Set.sappID}', '{accountMaster_actMaster_Set.spassWord}'," +
                                    $" '{accountMaster_actMaster_Set.srequestStatusCode}', '{accountMaster_actMaster_Set.sregisteredBy}', '{accountMaster_actMaster_Set.sregisteredDate.ToString(AppRes.csDateTimeFormat)}', '{accountMaster_actMaster_Set.sapprovedBy}'," +
                                    $" '{accountMaster_actMaster_Set.sapprovedDate.ToString(AppRes.csDateTimeFormat)}', '{accountMaster_actMaster_Set.smodifiedBy}', " +
                                    $" '{accountMaster_actMaster_Set.sModifiedDate.ToString(AppRes.csDateTimeFormat)}', '{accountMaster_actMaster_Set.sDisuse}', '{accountMaster_actMaster_Set.sDisusedBy}', " +
                                    $" '{accountMaster_actMaster_Set.sDisusedDate.ToString(AppRes.csDateTimeFormat)}'); " +
                                    $" select cast(scope_identity() as bigint); ";

                            Conn = new OleDbConnection(connect_string);
                            OleDbCommand cmd = new OleDbCommand(query, Conn);
                            cmd = new OleDbCommand(query, Conn);
                            Conn.Open();
                            cmd.ExecuteNonQuery();
                            //iAccountNo = (Int64)command.ExecuteScalar();
                            Conn.Close();

                            MessageBox.Show("계정등록에 성공하였습니다.");

                            // 초기화
                            txtID.Text = string.Empty;
                            txtPW.Text = string.Empty;
                        }
                        else
                        {
                            MessageBox.Show("회사 이메일 계정과 동일한 ID로 등록해주세요.");
                        }
                    }
                    else
                    {
                        MessageBox.Show("동일한 계정이 등록되어 있습니다. 확인 부탁드립니다.");
                    }
                }
                catch (Exception f)
                {
                    //AppRes.DB.RollbackTrans();
                    MessageBox.Show("계정등록 실패!" + Environment.NewLine + f.Source + Environment.NewLine + f.Message);
                }
            }
        }

        private void txtID_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.btnSignUp_Click(sender, e);
            }
        }

        private void txtPW_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.btnSignUp_Click(sender, e);
            }
        }
    }
}
