using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MonitorFRS.Source.C.Units;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid;
using System.IO;
using System.Data;
using System.Diagnostics;
using System.Drawing.Imaging;

namespace MonitorFRS.Source.C.Units
{
    #region class
    class UnitCommon
    {
        // 생성자
        public UnitCommon()
        {
        }

        public string userId = "";
        public string loginId = "";
        public string appId = "FRS";
        public string accountNo = "";
        private OleDbConnection Conn;
        public string connect_string =
                          "Provider=SQLOLEDB.1; User ID=dev01; pwd=dev010207; data source=KRSEC001; Persist Security Info=True; initial catalog=accountMaster";

        public enum COLUMNS { HZ, G }
        List<FRS_Data> FRS_List = new List<FRS_Data>();

        public string Call_Login_Chk(string sID, string sPW)
        {
            return login_chk(sID, sPW);
        }

        public class FRS_Data
        {
            public string HZ { get; set; }
            public string G { get; set; }
        }

        public void Initialize_LoginInfo() 
        {
            frmLogin_FRS_Info.iIDX = 0;

            frmLogin_LoginInfo.sAccountNo = string.Empty;
            frmLogin_LoginInfo.sAppId = string.Empty;
            frmLogin_LoginInfo.sEmpNo = string.Empty;

            frmLogin_LoginInfo.sGroupName = string.Empty;
            frmLogin_LoginInfo.sloginId = string.Empty;
            frmLogin_LoginInfo.sUserId = string.Empty;
            frmLogin_LoginInfo.sUserName = string.Empty;
            frmLogin_LoginInfo.bChkLogin = false;
        }

        private string login_chk(string sID = "", string sPW = "")
        {
            string sSuccess = "";
            accountNo = "";
            userId = "";
            loginId = "";
            appId = "FRS";

            Conn = new OleDbConnection(connect_string);

            string query = " select a.accountNo, a.logInId, a.userId, a.appId, b.empID, b.firstName" +
                         "     from [accountMaster].dbo.[accountMaster] a with(nolock) inner join userMaster b on a.userID = b.userID " +
                         "    where a.logInId = '" + sID + "' " +
                         "      and a.passWord = '" + sPW + "' " +
                         "      and a.appID = '" + appId + "' " +
                         "      and a.requestStatusCode ='approved'" +
                         "      and a.disuse <> 1 ";

            OleDbCommand cmd = new OleDbCommand(query, Conn);

            Conn.Open();

            using (OleDbDataReader reader = cmd.ExecuteReader())
            {
                if (reader.HasRows == true)
                {
                    while (reader.Read())
                    {
                        //panel1.Visible = false;

                        accountNo = reader.GetValue(0).ToString();
                        loginId = reader.GetValue(1).ToString();
                        userId = reader.GetValue(2).ToString();
                        frmLogin_LoginInfo.sUserName = reader.GetValue(5).ToString();
                        appId = "FRS";
                        //empno = reader.GetValue(4).ToString();

                        //staff_id = reader.GetValue(0).ToString();
                        //Team_id = reader.GetValue(2).ToString();
                        //SubTeam_id = reader.GetValue(3).ToString();
                        //approver_id = reader.GetValue(1).ToString();
                        //stusername.Text = staff_id;
                        MessageBox.Show(userId + " 님이 로그인 했습니다.");

                        //menuStrip1.Visible = true;
                        //panel1.Visible = false;

                        break;

                        //menuRoleSet();
                    }
                    sSuccess = "Success";
                }
                else
                {
                    MessageBox.Show("아이디/패스워드를 확인해주세요.");
                    sSuccess = "Fail";
                }
            }
            Conn.Close();
            return sSuccess;

            //if (loginId != "")
            //{
            //    query = " select userid " +
            //    "     from Staff " +
            //    "    where approver like '%" + staff_id + "%' ";

            //    cmd = new OleDbCommand(query, Conn);

            //    Conn.Open();

            //    using (OleDbDataReader reader = cmd.ExecuteReader())
            //    {
            //        if (reader.HasRows == true)
            //        {
            //            while (reader.Read())
            //            {
            //                //주의 - 로그인한 사용자(staff_id)가 승인할 승인요청자(apppover_id)의 아이디 = approver_id 의 개념을 바꿈
            //                approver_id = approver_id + "," + reader.GetValue(0).ToString();

            //            }
            //        }
            //    }
            //    Conn.Close();
            //}
        }

        public void staffRoleSet(string sID = "")
        {
            Conn = new OleDbConnection(connect_string);
            loginId = sID;

            string query = " SELECT * " +
                           " FROM [accountMaster].dbo.[groupMaster] AS A " +
                           " INNER JOIN [accountMaster].dbo.groupMemberMaster AS b " +
                           " ON a.groupNo = b.groupNo " +
                           " INNER JOIN [accountMaster].dbo.accountMaster AS c " +
                           " ON b.accountNo = c.accountNo " +
                           " WHERE c.appID = '" + appId + "' AND c.loginID = '" + loginId + "'";

            OleDbCommand cmd = new OleDbCommand(query, Conn);

            Conn.Open();

            using (OleDbDataReader reader = cmd.ExecuteReader())
            {
                if (reader.HasRows == true)
                {
                    int i = 0;
                    while (reader.Read())
                    {
                        i = i + 1;
                        if (reader.GetName(i).Equals("groupName"))
                        {
                            frmLogin_LoginInfo.sGroupName = reader.GetValue(i).ToString();
                        }
                    }
                    i = 0;
                }
            }
            Conn.Close();

            if (frmLogin_LoginInfo.sGroupName == null)
            {
                frmLogin_LoginInfo.sGroupName = "KR_Dongtan_FRS_User";
            }
        }

        public void Save_Another_File(Image FrsSavedPicture)
        {
            string sFilePath = string.Empty;
            SaveFileDialog dialog = new SaveFileDialog();

            dialog.InitialDirectory = @"C:\";
            dialog.Filter = "png files (*.png)|*.png|jpg files (*.jpg)|*.jpg|All files (*.*)|*.*";
            dialog.FilterIndex = 1;
            dialog.RestoreDirectory = true;

            if (dialog.ShowDialog() == DialogResult.OK)
            {
                // 지정한 파일이름으로 작업
                sFilePath = dialog.FileName;
                FrsSavedPicture.Save(@sFilePath, ImageFormat.Jpeg);
            }
        }

        public void Save_Image(PictureEdit picEdit)
        {
            string image_file = string.Empty;            

            OpenFileDialog dialog = new OpenFileDialog();
            dialog.InitialDirectory = @"C:\";
            dialog.Filter = "png files (*.png)|*.png|jpg files (*.jpg)|*.jpg|All files (*.*)|*.*";
            dialog.FilterIndex = 1;
            dialog.RestoreDirectory = true;

            if (dialog.ShowDialog() == DialogResult.OK)
            {
                image_file = dialog.FileName;
                picEdit.Image = Bitmap.FromFile(image_file);
            }
            //else if(dialog.ShowDialog() == DialogResult.Cancel)
            //{
            //    return;
            //}            
        }

        public void Export_Csv(DevExpress.XtraGrid.GridControl gridControl_Grid)
        {
            string sPath = string.Empty;

            SaveFileDialog csv_fileName = new SaveFileDialog();
            csv_fileName.InitialDirectory = @"C:\";
            csv_fileName.Filter = "csv files (*.csv)|*.csv|All files (*.*)|*.*";
            csv_fileName.FilterIndex = 1;
            csv_fileName.RestoreDirectory = true;

            if (csv_fileName.ShowDialog() == DialogResult.OK)
            {
                sPath = csv_fileName.FileName;
                gridControl_Grid.ExportToCsv(sPath);
            }
        }

        public void ExportCSV_MAX(DataTable dt) 
        {
            //파일 저장 위치 선택.
            SaveFileDialog saveDlg = new SaveFileDialog();
            saveDlg.InitialDirectory = @"C:\";
            //saveDlg.InitialDirectory = System.Environment.CurrentDirectory;
            saveDlg.Filter = "csv (*.csv)|*.csv|txt (*txt)|*.txt|All files (*.*)|*.*";
            if (saveDlg.ShowDialog() == DialogResult.Cancel)
            {
                return;
            }

            //파일 저장을 위해 스트림 생성.
            FileStream fs = new FileStream(saveDlg.FileName, FileMode.Create, FileAccess.Write);
            StreamWriter sw = new StreamWriter(fs, Encoding.UTF8);

            //컬럼 이름들을 ","로 나누고 저장.
            string line = string.Join(",", dt.Columns.Cast<object>());
            sw.WriteLine(line);

            //row들을 ","로 나누고 저장.
            foreach (DataRow item in dt.Rows)
            {
                line = string.Join(",", item.ItemArray.Cast<object>());
                sw.WriteLine(line);
            }

            sw.Close();
            fs.Close();
        }

        public void GetCSVData(string csv = "")
        {
            FRS_List.Clear();

            using (var sr = new System.IO.StreamReader(csv, Encoding.Default, true))
            {
                while (!sr.EndOfStream)
                {
                    string array = sr.ReadLine();
                    string[] values = array.Split(',');

                    //컬럼명은 건너뛰기
                    if (array.Contains("HZ"))
                        continue;

                    FRS_Data frs = new FRS_Data();
                    FRS_List.Add(SetData(frs, values));
                }
            }
        }

        public FRS_Data SetData(FRS_Data frs, string[] values)
        {
            // 소수점 둘째자리 반올림 
            frs.HZ = Math.Round(Convert.ToDouble(values[(int)COLUMNS.HZ].ToString()), 1).ToString();
            frs.G = values[(int)COLUMNS.G].ToString();

            return frs;
        }

        /// <summary>
        /// DataTable 생성
        /// </summary>
        /// <returns></returns>
        public DataTable GetDataTable()
        {
            DataTable dt = new DataTable();

            //컬럼 추가
            CreateColumn(dt);

            //Row 추가
            CreateRow(dt);

            return dt;
        }

        /// <summary>
        /// 컬럼 생성
        /// </summary>
        /// <param name="dt"></param>
        private void CreateColumn(DataTable dt)
        {
            dt.Columns.Add("HZ");
            dt.Columns.Add("G");
        }

        /// <summary>
        /// Row데이터 넣기
        /// </summary>
        /// <param name="dt"></param>
        private void CreateRow(DataTable dt)
        {
            for (int idx = 0; idx < FRS_List.Count; idx++)
            {
                dt.Rows.Add(new string[] { FRS_List[idx].HZ,
                                           FRS_List[idx].G });
            }
        }

        public void DataSouceGridView(DevExpress.XtraGrid.GridControl gridControl_View)
        {
            // 값들이 입력된 테이블을 DataGridView에 입력합니다.
            gridControl_View.DataSource = GetDataTable();
        }

        public void Import_Csv_Grid(DevExpress.XtraGrid.GridControl gridControl_View) 
        {
            //List<string> csvList = null;
            string csv_file = string.Empty;

            //FolderBrowserDialog fbd = new FolderBrowserDialog();
            OpenFileDialog csv_fileName = new OpenFileDialog();
            csv_fileName.InitialDirectory = @"C:\";
            csv_fileName.Filter = "csv files (*.csv)|*.csv|All files (*.*)|*.*";
            csv_fileName.FilterIndex = 1;
            csv_fileName.RestoreDirectory = true;

            if (csv_fileName.ShowDialog() == DialogResult.OK)
            {
                //string[] fileName = fbd.FileName; //폴더 읽기

                //csvList = csv_file.Where(x => x.IndexOf(".csv", StringComparison.OrdinalIgnoreCase) >= 0)
                //               .Select(x => x).ToList();

                csv_file = csv_fileName.FileName;

                try
                {
                    GetCSVData(csv_file); //CSV 파일 내용 읽어오기
                    DataSouceGridView(gridControl_View); //DataGridView 에 CSV 내용 바인딩
                }
                catch (Exception e)
                {
                    MessageBox.Show(e.Source + Environment.NewLine + e.Message);
                }
            }
        }

        public DataTable ReturnDT()
        {
            DataTable dt = new DataTable();
            dt = GetDataTable();
            //frmLogin_FRS_Info.dtTest = dt;

            return dt;
        }
    }
}   
#endregion