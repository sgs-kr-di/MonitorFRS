using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using Ulee.Database.SqlServer;
using System.Drawing;
using System.IO;

namespace MonitorFRS.Source.C.Units
{
    class UnitAppDatabase
    {
    }

    public class AppDatabase : UlSqlServer
    {
        public SqlConnection Connect { get { return connect; } }

        public AppDatabase(string connectString = null) : base(connectString)
        {
        }

        public new void Open()
        {
            base.Open();
        }

        public new void Close()
        {
            base.Close();
        }

        public class accountMaster_actMaster_DataSet : UlSqlDataSet
        {
            public Int64 iAccountNo { get; set; }
            public string slogInID { get; set; }
            public string suserID { get; set; }
            public string sappNo { get; set; }
            public string sappID { get; set; }
            public string spassWord { get; set; }
            public string srequestStatusCode { get; set; }
            public string sregisteredBy { get; set; }
            public DateTime sregisteredDate { get; set; }
            public string sapprovedBy { get; set; }
            public DateTime sapprovedDate { get; set; }
            public string smodifiedBy { get; set; }
            public DateTime sModifiedDate { get; set; }
            public string sDisuse { get; set; }
            public string sDisusedBy { get; set; }
            public DateTime sDisusedDate { get; set; }

            public accountMaster_actMaster_DataSet(SqlConnection connect, SqlCommand command, SqlDataAdapter adapter)
                : base(connect, command, adapter)
            {
            }

            public void Select_AccountMaster(SqlTransaction trans = null)
            {
                SetTrans(trans);
                command.CommandText =
                    $" SELECT * FROM [KRSEC001_accountMaster_DBLINK].[accountMaster].dbo.[accountMaster] " +
                    $" WHERE logInID = '{slogInID}' AND appid = 'FRS' ";
                dataSet.Clear();
                dataAdapter.Fill(dataSet);
            }

            public void Select_UserMaster(SqlTransaction trans = null)
            {
                SetTrans(trans);
                command.CommandText =
                    $" SELECT * FROM [KRSEC001_accountMaster_DBLINK].[accountMaster].dbo.[userMaster] " +
                    $" WHERE userID = '{slogInID}' ";
                dataSet.Clear();
                dataAdapter.Fill(dataSet);
            }

            public void Insert(SqlTransaction trans = null)
            {


                string sql =
                    //$" INSERT INTO [KRSEC001_accountMaster_DBLINK].[accountMaster].dbo.[accountMaster] VALUES " +
                    //$" ('{slogInID}', '{suserID}', '{sappNo}', '{sappID}', '{spassWord}'," +
                    //$" '{srequestStatusCode}', '{sregisteredBy}', '{sregisteredDate.ToString(AppRes.csDateTimeFormat)}', '{sapprovedBy}'," +
                    //$" '{sapprovedDate.ToString(AppRes.csDateTimeFormat)}', '{smodifiedBy}', " +
                    //$" '{sModifiedDate.ToString(AppRes.csDateTimeFormat)}', '{sDisuse}', '{sDisusedBy}', " +
                    //$" '{sDisusedDate.ToString(AppRes.csDateTimeFormat)}'); " +
                    //$" select cast(scope_identity() as bigint); ";

                    $" INSERT INTO [KRSEC001_accountMaster_DBLINK].[accountMaster].dbo.[accountMaster] (logInID, userID,appNo, appID, passWord, requestStatusCode, registeredBy, registeredDate, approvedBy, approvedDate, modifiedBy, ModifiedDate, Disuse, DisusedBy, DisusedDate)" +
                    $" VALUES " +
                    $" ('{slogInID}', '{suserID}', '{sappNo}', '{sappID}', '{spassWord}'," +
                    $" '{srequestStatusCode}', '{sregisteredBy}', '{sregisteredDate.ToString(AppRes.csDateTimeFormat)}', '{sapprovedBy}'," +
                    $" '{sapprovedDate.ToString(AppRes.csDateTimeFormat)}', '{smodifiedBy}', " +
                    $" '{sModifiedDate.ToString(AppRes.csDateTimeFormat)}', '{sDisuse}', '{sDisusedBy}', " +
                    $" '{sDisusedDate.ToString(AppRes.csDateTimeFormat)}'); " +
                    $" select cast(scope_identity() as bigint); ";

                SetTrans(trans);

                try
                {
                    BeginTrans(trans);
                    command.CommandText = sql;
                    command.ExecuteNonQuery();
                    iAccountNo = (Int64)command.ExecuteScalar();
                    CommitTrans(trans);
                }
                catch (Exception e)
                {
                    RollbackTrans(trans, e);
                }
            }
        }
        public class frmFrsMain_P1_DataSet : UlSqlDataSet
        {
            public Int64 iIDX { get; set; }
            public string sPOWERPLANT { get; set; }
            public string sSTATUS { get; set; }
            public string sBUILDING { get; set; }
            public string sHEIGHT { get; set; }
            public string sWAY { get; set; }
            public string sDAMPING { get; set; }
            public string sID { get; set; }
            public string sREGISTRANT { get; set; }
            public DateTime sREGISTRATIONDATE { get; set; }
            public string sFROM { get; set; }
            public string sTO { get; set; }
            public string sLASTM_ID { get; set; }
            public string sLASTM_NAME { get; set; }
            public DateTime sLASTM_DATE { get; set; }

            public Bitmap bPicture { get; set; }

            public frmFrsMain_P1_DataSet(SqlConnection connect, SqlCommand command, SqlDataAdapter adapter)
                : base(connect, command, adapter)
            {
            }

            public void Select(SqlTransaction trans = null)
            {
                string sql = $" SELECT A.*, B.*, C.* " +
                    $" FROM FRS_P1 A " +
                    $" INNER JOIN [FRS_P1_REVIEW] AS B" +
                    $" ON (A.IDX = B.PK_IDX) " +
                    $" INNER JOIN [FRS_P1_IMAGE] AS C" +
                    $" ON (A.IDX = C.PK_IDX) " +
                    $" WHERE A.IDX > 0";

                if (string.IsNullOrWhiteSpace(sPOWERPLANT) == false)
                {
                    sql += $" and A.POWERPLANT = '{sPOWERPLANT}' ";
                }
                if (string.IsNullOrWhiteSpace(sBUILDING) == false)
                {
                    sql += $" and A.BUILDING = '{sBUILDING}' ";
                }
                if (string.IsNullOrWhiteSpace(sHEIGHT) == false)
                {
                    sql += $" and A.HEIGHT = '{sHEIGHT}' ";
                }
                if (string.IsNullOrWhiteSpace(sWAY) == false)
                {
                    sql += $" and A.WAY = '{sWAY}' ";
                }
                if (string.IsNullOrWhiteSpace(sDAMPING) == false)
                {
                    sql += $" and A.DAMPING = '{sDAMPING}' ";
                }
                if (string.IsNullOrWhiteSpace(sREGISTRANT) == false)
                {
                    sql += $" and A.REGISTRANT = '{sREGISTRANT}' ";
                }
                if (string.IsNullOrWhiteSpace(sSTATUS) == false)
                {
                    sql += $" and B.STATUS like '%{sSTATUS}%' ";
                }
                if (string.IsNullOrWhiteSpace(sFROM) == false)
                {
                    if (sFROM == sTO)
                    {
                        sql += $" and A.REGISTRATIONDATE like '{sFROM}%%' ";
                    }
                    else
                    {
                        sql += $" and (A.REGISTRATIONDATE>='{sFROM} 00:00:00.000' ";
                        sql += $" and A.REGISTRATIONDATE<='{sTO} 23:59:59.999') ";
                    }
                }

                SetTrans(trans);
                command.CommandText = sql;
                dataSet.Clear();
                dataAdapter.Fill(dataSet);
            }

            public void SelectReviewOK(SqlTransaction trans = null)
            {
                string sql = $" SELECT A.*, B.*, C.* " +
                    $" FROM FRS_P1 A " +
                    $" INNER JOIN [FRS_P1_REVIEW] AS B" +
                    $" ON (A.IDX = B.PK_IDX) " +
                    $" INNER JOIN [FRS_P1_IMAGE] AS C" +
                    $" ON (A.IDX = C.PK_IDX) " +
                    $" WHERE A.IDX > 0 AND B.STATUS like '%리뷰 2차완료%'";

                if (string.IsNullOrWhiteSpace(sPOWERPLANT) == false)
                {
                    sql += $" and A.POWERPLANT = '{sPOWERPLANT}' ";
                }
                if (string.IsNullOrWhiteSpace(sBUILDING) == false)
                {
                    sql += $" and A.BUILDING = '{sBUILDING}' ";
                }
                if (string.IsNullOrWhiteSpace(sHEIGHT) == false)
                {
                    sql += $" and A.HEIGHT = '{sHEIGHT}' ";
                }
                if (string.IsNullOrWhiteSpace(sWAY) == false)
                {
                    sql += $" and A.WAY = '{sWAY}' ";
                }
                if (string.IsNullOrWhiteSpace(sDAMPING) == false)
                {
                    sql += $" and A.DAMPING = '{sDAMPING}' ";
                }
                if (string.IsNullOrWhiteSpace(sREGISTRANT) == false)
                {
                    sql += $" and A.REGISTRANT = '{sREGISTRANT}' ";
                }
                if (string.IsNullOrWhiteSpace(sSTATUS) == false)
                {
                    sql += $" and B.STATUS = '{sSTATUS}' ";
                }
                if (string.IsNullOrWhiteSpace(sFROM) == false)
                {
                    if (sFROM == sTO)
                    {
                        sql += $" and A.REGISTRATIONDATE like '{sFROM}%%' ";
                    }
                    else
                    {
                        sql += $" and (A.REGISTRATIONDATE>='{sFROM} 00:00:00.000' ";
                        sql += $" and A.REGISTRATIONDATE<='{sTO} 23:59:59.999') ";
                    }
                }

                SetTrans(trans);
                command.CommandText = sql;
                dataSet.Clear();
                dataAdapter.Fill(dataSet);
            }

            public void Delete(SqlTransaction trans = null)
            {
                string sql =
                    $" DELETE FROM FRS_P1 " +
                    $" WHERE IDX='{iIDX}' ";

                SetTrans(trans);

                try
                {
                    BeginTrans(trans);
                    command.CommandText = sql;
                    command.ExecuteNonQuery();
                    CommitTrans(trans);
                }
                catch (Exception e)
                {
                    RollbackTrans(trans, e);
                }
            }

            public void Fetch(int index = 0, int tableNo = 0)
            {
                if (index < GetRowCount(tableNo))
                {
                    Fetch(dataSet.Tables[tableNo].Rows[index]);
                }
                else
                {
                    iIDX = 0;
                    bPicture = null;
                }
            }

            public void Fetch(DataRow row)
            {
                iIDX = Convert.ToInt32(row["PK_IDX"]);

                if (row["PICTURE"] == DBNull.Value) bPicture = null;
                else
                {
                    byte[] pictureRaw = (byte[])row["PICTURE"];
                    bPicture = (pictureRaw == null) ? null : new Bitmap(new MemoryStream(pictureRaw));
                }
            }
        }

        public class frmFrsImage_Image_DataSet : UlSqlDataSet
        {
            public Int64 iIDX { get; set; }

            public Bitmap bPicture { get; set; }

            public frmFrsImage_Image_DataSet(SqlConnection connect, SqlCommand command, SqlDataAdapter adapter)
                : base(connect, command, adapter)
            {
            }
            
            public void Select(SqlTransaction trans = null)
            {
                string sql = $" SELECT C.* " +
                    $" FROM FRS_P1 A " +
                    $" INNER JOIN [FRS_P1_REVIEW] AS B" +
                    $" ON (A.IDX = B.PK_IDX) " +
                    $" INNER JOIN [FRS_P1_IMAGE] AS C" +
                    $" ON (A.IDX = C.PK_IDX) " +
                    $" WHERE A.IDX = {iIDX}";

                SetTrans(trans);
                command.CommandText = sql;
                dataSet.Clear();
                dataAdapter.Fill(dataSet);
            }

            public void Fetch(int index = 0, int tableNo = 0)
            {
                if (index < GetRowCount(tableNo))
                {
                    Fetch(dataSet.Tables[tableNo].Rows[index]);
                }
                else
                {
                    iIDX = 0;
                    bPicture = null;
                }
            }

            public void Fetch(DataRow row)
            {
                iIDX = Convert.ToInt32(row["PK_IDX"]);

                if (row["PICTURE"] == DBNull.Value) bPicture = null;
                else
                {
                    byte[] pictureRaw = (byte[])row["PICTURE"];
                    bPicture = (pictureRaw == null) ? null : new Bitmap(new MemoryStream(pictureRaw));
                }
            }
        }

        public class frmFRSInquire_P1_DataSet : UlSqlDataSet
        {
            public Int64 iIDX { get; set; }
            public string sPOWERPLANT { get; set; }
            public string sBUILDING { get; set; }
            public string sHEIGHT { get; set; }
            public string sWAY { get; set; }
            public string sDAMPING { get; set; }
            public string sID { get; set; }
            public string sREGISTRANT { get; set; }
            public DateTime sREGISTRATIONDATE { get; set; }
            public string sLASTM_ID { get; set; }
            public string sLASTM_NAME { get; set; }
            public DateTime sLASTM_DATE { get; set; }

            public frmFRSInquire_P1_DataSet(SqlConnection connect, SqlCommand command, SqlDataAdapter adapter)
                : base(connect, command, adapter)
            {
            }

            public void Select(SqlTransaction trans = null)
            {
                SetTrans(trans);
                command.CommandText =
                    $" SELECT A.*, B.*" +
                    $" FROM FRS_P1 A " +
                    $" INNER JOIN [FRS_P1_REVIEW] AS B" +
                    $" ON (A.IDX = B.PK_IDX) " +
                    $" WHERE A.IDX = {iIDX}";
                dataSet.Clear();
                dataAdapter.Fill(dataSet);
            }

            public void Insert(SqlTransaction trans = null)
            {
                string sql =
                    $" INSERT INTO FRS_P1 VALUES " +
                    $" ('{sPOWERPLANT}', '{sBUILDING}', '{sHEIGHT}', '{sWAY}', '{sDAMPING}'," +
                    $" '{sID}', '{sREGISTRANT}', '{sREGISTRATIONDATE.ToString(AppRes.csDateTimeFormat)}', '{sLASTM_ID}', '{sLASTM_NAME}'," +
                    $" '{sLASTM_DATE.ToString(AppRes.csDateTimeFormat)}'); " +
                    $" select cast(scope_identity() as bigint); ";

                SetTrans(trans);

                try
                {
                    BeginTrans(trans);
                    command.CommandText = sql;
                    iIDX = (Int64)command.ExecuteScalar();
                    CommitTrans(trans);
                }
                catch (Exception e)
                {
                    RollbackTrans(trans, e);
                }
            }

            public void Fetch(int index = 0, int tableNo = 0)
            {
                if (index < GetRowCount(tableNo))
                {
                    Fetch(dataSet.Tables[tableNo].Rows[index]);
                }
                else
                {
                    iIDX = 0;
                    sPOWERPLANT = "";
                    sBUILDING = "";
                    sHEIGHT = "";
                    sWAY = "";
                    sDAMPING = "";
                    sID = "";
                    sREGISTRANT = "";
                    sREGISTRATIONDATE = new DateTime();
                    sLASTM_ID = "";
                    sLASTM_NAME = "";
                    sLASTM_DATE = new DateTime();
                }
            }

            public void Fetch(DataRow row)
            {
                iIDX = Convert.ToInt64(row["IDX"].ToString());
                sPOWERPLANT = row["POWERPLANT"].ToString();
                sBUILDING = row["BUILDING"].ToString();
                sHEIGHT = row["HEIGHT"].ToString();
                sWAY = row["WAY"].ToString();
                sDAMPING = row["DAMPING"].ToString();
                sID = row["ID"].ToString();
                sREGISTRANT = row["REGISTRANT"].ToString();
                sREGISTRATIONDATE = Convert.ToDateTime(row["REGISTRATIONDATE"].ToString());
            }
        }

        public class frmFRSInquire_P1_IMAGE_DataSet : UlSqlDataSet
        {
            public Int64 iP1_IDX { get; set; }
            public Bitmap bPicture { get; set; }
            private ImageConverter imageConvert;

            public frmFRSInquire_P1_IMAGE_DataSet(SqlConnection connect, SqlCommand command, SqlDataAdapter adapter)
                : base(connect, command, adapter)
            {
                imageConvert = new ImageConverter();
            }

            public void Select(SqlTransaction trans = null)
            {
                SetTrans(trans);
                command.CommandText =
                    $" SELECT * FROM FRS_P1_IMAGE " +
                    $" WHERE PK_IDX='{iP1_IDX}' ";
                dataSet.Clear();
                dataAdapter.Fill(dataSet);
            }

            public void Insert(SqlTransaction trans = null)
            {
                string sql =
                    $" insert into FRS_P1_IMAGE values " +
                    $" ('{iP1_IDX}', @PICTURE) ";

                SetTrans(trans);

                try
                {
                    BeginTrans(trans);

                    command.CommandText = sql;
                    command.Parameters.Clear();

                    if (bPicture == null)
                    {
                        SqlParameter pictureParam = new SqlParameter("@PICTURE", SqlDbType.Image);
                        pictureParam.Value = DBNull.Value;
                        command.Parameters.Add(pictureParam);
                    }
                    else
                    {
                        command.Parameters.Add("@PICTURE", SqlDbType.Image);
                        command.Parameters["@PICTURE"].Value = (byte[])imageConvert.ConvertTo(bPicture, typeof(byte[]));
                    }
                    command.ExecuteNonQuery();
                }
                catch (Exception e)
                {
                    RollbackTrans(trans, e);
                }
            }

            public void Delete(SqlTransaction trans = null)
            {
                string sql =
                    $" DELETE FROM FRS_P1_IMAGE " +
                    $" WHERE PK_IDX='{iP1_IDX}' ";

                SetTrans(trans);

                try
                {
                    BeginTrans(trans);
                    command.CommandText = sql;
                    command.ExecuteNonQuery();
                    CommitTrans(trans);
                }
                catch (Exception e)
                {
                    RollbackTrans(trans, e);
                }
            }

            public void Fetch(int index = 0, int tableNo = 0)
            {
                if (index < GetRowCount(tableNo))
                {
                    Fetch(dataSet.Tables[tableNo].Rows[index]);
                }
                else
                {
                    iP1_IDX = 0;
                    bPicture = null;
                }
            }

            public void Fetch(DataRow row)
            {
                iP1_IDX = Convert.ToInt32(row["PK_IDX"]);

                if (row["PICTURE"] == DBNull.Value) bPicture = null;
                else
                {
                    byte[] pictureRaw = (byte[])row["PICTURE"];
                    bPicture = (pictureRaw == null) ? null : new Bitmap(new MemoryStream(pictureRaw));
                }
            }
        }

        public class frmFRSInquire_FRS_P1_DATA_DataSet : UlSqlDataSet
        {
            public Int64 iIDX { get; set; }
            public Int64 iFRS_P1_IDX { get; set; }
            public string sHZ { get; set; }
            public string sG { get; set; }

            public frmFRSInquire_FRS_P1_DATA_DataSet(SqlConnection connect, SqlCommand command, SqlDataAdapter adapter)
                : base(connect, command, adapter)
            {
            }

            public void Select(SqlTransaction trans = null)
            {
                SetTrans(trans);
                command.CommandText =
                    $" SELECT * FROM FRS_P1_DATA " +
                    $" WHERE FRS_P1_IDX='{iFRS_P1_IDX}' " +
                    $" ORDER BY IDX ASC ";
                dataSet.Clear();
                dataAdapter.Fill(dataSet);
            }

            public void Insert(SqlTransaction trans = null)
            {
                string sql =
                    $" insert into FRS_P1_DATA values " +
                    $" ('{iFRS_P1_IDX}', '{sHZ}', '{sG}'); ";

                SetTrans(trans);

                try
                {
                    BeginTrans(trans);
                    command.CommandText = sql;
                    command.ExecuteNonQuery();
                }
                catch (Exception e)
                {
                    RollbackTrans(trans, e);
                }
            }

            public void Delete(SqlTransaction trans = null)
            {
                string sql =
                    $" DELETE FROM FRS_P1_DATA " +
                    $" WHERE FRS_P1_IDX='{iFRS_P1_IDX}' ";

                SetTrans(trans);

                try
                {
                    BeginTrans(trans);
                    command.CommandText = sql;
                    command.ExecuteNonQuery();
                    CommitTrans(trans);
                }
                catch (Exception e)
                {
                    RollbackTrans(trans, e);
                }
            }

            public void Fetch(int index = 0, int tableNo = 0)
            {
                if (index < GetRowCount(tableNo))
                {
                    Fetch(dataSet.Tables[tableNo].Rows[index]);
                }
                else
                {
                    iIDX = 0;
                    iFRS_P1_IDX = 0;
                    sHZ = "";
                    sG = "";
                }
            }

            public void Fetch(DataRow row)
            {
                iIDX = Convert.ToInt64(row["IDX"].ToString());
                iFRS_P1_IDX = Convert.ToInt64(row["FRS_P1_IDX"].ToString());
                sHZ = row["HZ"].ToString();
                sG = row["G"].ToString();
            }
        }

        public class frmFRSInquire_FRS_P1_REVIEW_DataSet : UlSqlDataSet
        {
            public Int64 iIDX { get; set; }
            public string sSTATUS { get; set; }
            public string sREVIEW1_ID { get; set; }
            public string sREVIEW2_ID { get; set; }
            public DateTime sModifiedDate { get; set; }

            public frmFRSInquire_FRS_P1_REVIEW_DataSet(SqlConnection connect, SqlCommand command, SqlDataAdapter adapter)
                : base(connect, command, adapter)
            {
            }

            public void Select(SqlTransaction trans = null)
            {
                SetTrans(trans);
                command.CommandText =
                    $" SELECT * FROM FRS_P1_REVIEW " +
                    $" WHERE PK_IDX='{iIDX}' ";
                dataSet.Clear();
                dataAdapter.Fill(dataSet);
            }

            public void Insert(SqlTransaction trans = null)
            {
                string sql =
                    $" insert into FRS_P1_REVIEW values " +
                    $" ('{iIDX}', '{sSTATUS}', '{sREVIEW1_ID}', '{sREVIEW2_ID}', '{sModifiedDate.ToString(AppRes.csDateTimeFormat)}'); ";

                SetTrans(trans);

                try
                {
                    BeginTrans(trans);
                    command.CommandText = sql;
                    command.ExecuteNonQuery();
                    CommitTrans(trans);
                }
                catch (Exception e)
                {
                    RollbackTrans(trans, e);
                }
            }

            public void Update(SqlTransaction trans = null)
            {
                string sql =
                    $" UPDATE FRS_P1_REVIEW" +
                    $" SET STATUS='{sSTATUS}', REVIEW1_ID='{sREVIEW1_ID}', REVIEW2_ID='{sREVIEW2_ID}'," +
                    $" LAST_M_DATE='{sModifiedDate.ToString(AppRes.csDateTimeFormat)}'" +
                    $" WHERE PK_IDX='{iIDX}' ";

                SetTrans(trans);

                try
                {
                    BeginTrans(trans);
                    command.CommandText = sql;
                    command.ExecuteNonQuery();
                    CommitTrans(trans);
                }
                catch (Exception e)
                {
                    RollbackTrans(trans, e);
                }
            }

            public void Delete(SqlTransaction trans = null)
            {
                string sql =
                    $" DELETE FROM FRS_P1_REVIEW " +
                    $" WHERE PK_IDX='{iIDX}' ";

                SetTrans(trans);

                try
                {
                    BeginTrans(trans);
                    command.CommandText = sql;
                    command.ExecuteNonQuery();
                    CommitTrans(trans);
                }
                catch (Exception e)
                {
                    RollbackTrans(trans, e);
                }
            }

            public void Fetch(int index = 0, int tableNo = 0)
            {
                if (index < GetRowCount(tableNo))
                {
                    Fetch(dataSet.Tables[tableNo].Rows[index]);
                }
                else
                {
                    iIDX = 0;
                    sSTATUS = "";
                }
            }

            public void Fetch(DataRow row)
            {
                iIDX = Convert.ToInt64(row["PK_IDX"].ToString());
                sSTATUS = row["STATUS"].ToString();
            }
        }        
    }
}
