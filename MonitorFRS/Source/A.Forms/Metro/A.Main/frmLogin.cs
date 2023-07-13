using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MonitorFRS.Source.C.Units;
using System.Security.Cryptography;
using System.Data.SqlClient;

namespace MonitorFRS.Source.A.Forms.Metro.A.Main
{
    public partial class frmLogin : MetroFramework.Forms.MetroForm
    {
        //private frmMain frmMain_FRSMonitor;
        private UnitCommon uCommon;
        private SHA256Managed sha256Managed;
        private AppDatabase.accountMaster_actMaster_DataSet accountMaster_actMaster_Set;
        public string userId = "";
        public string loginId = "";
        public string appId = "FRS";
        public string accountNo = "";

        public frmLogin()
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

        public void SuccessLogin()
        {
            userId = txtID.Text;
            loginId = txtID.Text;
            appId = "FRS";

            frmLogin_LoginInfo.sloginId = loginId;
            //frmLogin_LoginInfo.sAccountNo = MainFrmLogin.accountNo;
            frmLogin_LoginInfo.sUserId = userId;
            frmLogin_LoginInfo.sAppId = appId;
            //frmLogin_LoginInfo.sEmpNo = MainFrmLogin.empno;

            //menuRoleSet();

            //// 직원별 권한
            uCommon.staffRoleSet(userId);            

            //직원 부서 연결 (site, repository, workspace)
            //setDept();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            frmLogin_LoginInfo.bChkLogin = false;
            
            // 해쉬 - 단반향
            byte[] encryptBytes = sha256Managed.ComputeHash(Encoding.UTF8.GetBytes(txtPW.Text));
            
            // Convert To base64
            String encryptString = Convert.ToBase64String(encryptBytes);

            if (string.IsNullOrEmpty(txtID.Text) == true || string.IsNullOrEmpty(txtPW.Text) == true)
            {
                MessageBox.Show("ID 또는 Password를 입력해주세요.");
            }
            else
            {
                //if (uCommon.Call_Login_Chk(txtID.Text, txtPW.Text).Equals("Success"))
                if (uCommon.Call_Login_Chk(txtID.Text, encryptString).Equals("Success"))
                {
                    SuccessLogin();
                    this.Close();

                    // 정상 로그인 확인
                    frmLogin_LoginInfo.bChkLogin = true;
                }
            }
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
                            SqlTransaction trans = AppRes.DB.BeginTrans();

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

                            accountMaster_actMaster_Set.Insert(trans);

                            AppRes.DB.CommitTrans();

                            MessageBox.Show("계정등록에 성공하였습니다. 로그인 해주세요.");

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
                    AppRes.DB.RollbackTrans();
                    MessageBox.Show("계정등록 실패!" + Environment.NewLine + f.Source + Environment.NewLine + f.Message);
                }
            }
        }

        private void txtID_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.btnLogin_Click(sender, e);
            }
        }

        private void txtPW_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.btnLogin_Click(sender, e);
            }
        }

        private void frmLogin_Load(object sender, EventArgs e)
        {
            this.Activate();
        }
    }    
}