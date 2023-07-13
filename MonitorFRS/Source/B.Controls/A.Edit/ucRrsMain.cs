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
using DevExpress.XtraCharts;
using MonitorFRS.Source.C.Units;
using System.IO;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraGrid;
using System.Collections;

namespace MonitorFRS.Source.B.Controls.A.Edit
{
    public partial class ucRrsMain : DevExpress.XtraEditors.XtraUserControl
    {
        private AppDatabase.frmFrsMain_P1_DataSet frmFrsMain_P1_Set;
        private AppDatabase.frmFrsImage_Image_DataSet frmFrsImage_Image_Set;
        private AppDatabase.frmFRSInquire_FRS_P1_DATA_DataSet frmFrsMain_P1_Data_Set;
        private frmFRSInquire frmFRSInquire_Main;
        private UnitCommon uCommon;
        ArrayList rows_RRS;
        List<DataTable> Listdt_SelectedTable;
        DataTable dt_SelectedTable;
        DataTable dt_MultiPercentMaxTable;
        //DataTable dt_CopyMaxTable;

        public ucRrsMain()
        {
            InitializeComponent();
            Initialize();
        }

        private void Initialize()
        {
            frmFrsMain_P1_Set = new AppDatabase.frmFrsMain_P1_DataSet(AppRes.DB.Connect, null, null);
            frmFrsImage_Image_Set = new AppDatabase.frmFrsImage_Image_DataSet(AppRes.DB.Connect, null, null);
            frmFrsMain_P1_Data_Set = new AppDatabase.frmFRSInquire_FRS_P1_DATA_DataSet(AppRes.DB.Connect, null, null);
            frmFRSInquire_Main = new frmFRSInquire();
            uCommon = new UnitCommon();
            rows_RRS = new ArrayList();
            Listdt_SelectedTable = new List<DataTable>();
            dt_MultiPercentMaxTable = new DataTable();
            //dt_CopyMaxTable = new DataTable();
        }

        private void BarItemFRSInsert_ItemClick(object sender, TileItemEventArgs e)
        {
            try
            {
                Listdt_SelectedTable.Clear();
                rows_RRS.Clear();
                int iDTidx = 0;

                // Add the selected rows to the list.
                Int32[] selectedRowHandles = RRS_Data_GridView.GetSelectedRows();

                if (selectedRowHandles.Length < 1) 
                {
                    return;
                }

                for (int i = 0; i < selectedRowHandles.Length; i++)
                {
                    dt_SelectedTable = new DataTable();
                    dt_SelectedTable.Columns.Add("IDX");
                    dt_SelectedTable.Columns.Add("FRS_IDX");
                    dt_SelectedTable.Columns.Add("HZ");
                    dt_SelectedTable.Columns.Add("G");

                    int selectedRowHandle = selectedRowHandles[i];
                    if (selectedRowHandle >= 0)
                        rows_RRS.Add(RRS_Data_GridView.GetDataRow(selectedRowHandle));
                    Listdt_SelectedTable.Add(dt_SelectedTable);
                }

                foreach (DataRow row in rows_RRS)
                {
                    frmFrsMain_P1_Data_Set.iFRS_P1_IDX = Convert.ToInt64(row[0].ToString());
                    frmFrsMain_P1_Data_Set.Select();

                    for (int i = 0; i < frmFrsMain_P1_Data_Set.RowCount; i++)
                    {
                        frmFrsMain_P1_Data_Set.Fetch(i);
                        double dG = Convert.ToDouble(frmFrsMain_P1_Data_Set.sG);
                        double dHZ = Convert.ToDouble(frmFrsMain_P1_Data_Set.sHZ);

                        //Listdt_SelectedTable[iDTidx].Rows.Add(frmFrsMain_P1_Data_Set.iIDX, frmFrsMain_P1_Data_Set.iFRS_P1_IDX, frmFrsMain_P1_Data_Set.sHZ, frmFrsMain_P1_Data_Set.sG);
                        Listdt_SelectedTable[iDTidx].Rows.Add(frmFrsMain_P1_Data_Set.iIDX, frmFrsMain_P1_Data_Set.iFRS_P1_IDX, dHZ.ToString("F1"), Math.Round(dG, 2));
                    }
                    iDTidx += 1;
                }
                SetLineChartData(RRS_Chart_Ctrl, ViewType.Line, Listdt_SelectedTable);
            }
            catch (Exception f)
            {
                MessageBox.Show(f.Message + Environment.NewLine + f.Source);
            }
            //try
            //{
            //    RRS_Data_GridView.BeginUpdate();
            //    for (int i = 0; i < rows.Count; i++)
            //    {
            //        DataRow row = rows[i] as DataRow;
            //        // Change the field value.
            //        row["Discontinued"] = true;
            //    }
            //}
            //finally
            //{
            //    RRS_Data_GridView.EndUpdate();
            //}

            //frmFRSInquire_Main.ShowDialog();
            //ColumnView view = RRS_Data_GridView;
            //GridColumn colIDX = view.Columns["IDX"];
            //if (colIDX == null) return;

            //// Enable multiple row selection mode.
            //view.OptionsSelection.MultiSelect = true;
            //view.ClearSelection();
            //int rowHandle = -1;
            //// Select rows that contain 'Mexico' in the Country column.
            //while (rowHandle != GridControl.InvalidRowHandle)
            //{
            //    rowHandle = view.LocateByDisplayText(rowHandle + 1, colIDX, "Mexico");
            //    view.SelectRow(rowHandle);
            //}
            //int[] selectedRowHandles = view.GetSelectedRows();
            //if (selectedRowHandles.Length > 0)
            //{
            //    // Move focus to the first selected row.
            //    view.FocusedRowHandle = selectedRowHandles[0];
            //    // Copy the selection to the clipboard
            //    view.CopyToClipboard();
            //    // Copy the selected company names to a Console Write.
            //    for (int i = 0; i < selectedRowHandles.Length; i++) 
            //    {
            //        Console.WriteLine(view.GetRowCellDisplayText(selectedRowHandles[i], colIDX));
            //    }   
            //}
        }
        /*
        private void SetChartData(ChartControl chart, ViewType viewType, DataTable dt)
        {
            #region LineChart
            if (viewType == ViewType.Line)
            {
                Dictionary<string, Series> seriesList = new Dictionary<string, Series>();
                
                foreach (DataRow row in dt.Rows)
                {
                    string G = row["G"].ToString();
                    string HZ = row["HZ"].ToString();

                    Series series;
                    if (seriesList.TryGetValue(G, out series) == false)
                    {
                        seriesList.Add(G, series = new Series(G, viewType));
                        chart.Series[""].LabelsVisibility = DevExpress.Utils.DefaultBoolean.True;

                        chart.Series.Add(series);                        
                    }
                    
                    SeriesPoint point = new SeriesPoint(G, HZ);
                    series.Points.Add(point);
                    
                    // Access the view-type-specific options of the series.
                    ((LineSeriesView)series.View).MarkerVisibility = DevExpress.Utils.DefaultBoolean.True;
                    ((LineSeriesView)series.View).LineMarkerOptions.Size = 20;
                    ((LineSeriesView)series.View).LineMarkerOptions.Kind = MarkerKind.Circle;
                    ((LineSeriesView)series.View).LineStyle.DashStyle = DashStyle.Dash;

                    // Access the view-type-specific options of the series.
                    ((XYDiagram)chart.Diagram).AxisY.Interlaced = true;
                    ((XYDiagram)chart.Diagram).AxisY.InterlacedColor = Color.FromArgb(20, 60, 60, 60);
                    ((XYDiagram)chart.Diagram).AxisX.NumericScaleOptions.AutoGrid = true;
                    ((XYDiagram)chart.Diagram).AxisX.NumericScaleOptions.GridSpacing = 1;
                }
            }
            #endregion
        }
        */

        private void SetLineChartData(ChartControl chart, ViewType viewType, List<DataTable> dt)
        {
            //ChartTitle 생성
            ChartTitle title = new ChartTitle();

            chart.Titles.Clear();
            chart.DataSource = null;
            chart.Series.Clear();

            try
            {
                Dictionary<string, Series> seriesList = new Dictionary<string, Series>();
                title.Text = "RRS";
                chart.Titles.Add(title);

                foreach (DataTable ListDt in dt)
                {
                    foreach (DataRow row in ListDt.Rows)
                    {
                        //string IDX = "FRS " + row["IDX"].ToString();
                        string FRS_IDX = "FRS " + row["FRS_IDX"].ToString();
                        string HZ = row["HZ"].ToString();
                        string G = row["G"].ToString();

                        Series series;
                        if (seriesList.TryGetValue(FRS_IDX, out series) == false)
                        {
                            seriesList.Add(FRS_IDX, series = new Series(FRS_IDX, viewType));
                            //Label 표시
                            series.LabelsVisibility = DevExpress.Utils.DefaultBoolean.False;
                            chart.Series.Add(series);
                        }
                        //SeriesPoint 생성
                        SeriesPoint point = new SeriesPoint(HZ, G);
                        series.Points.Add(point);

                        ((LineSeriesView)series.View).MarkerVisibility = DevExpress.Utils.DefaultBoolean.True;
                        ((LineSeriesView)series.View).LineMarkerOptions.Size = 5;
                        ((LineSeriesView)series.View).LineMarkerOptions.Kind = MarkerKind.Triangle;
                    }

                    AxisX axisX = ((XYDiagram)chart.Diagram).AxisX;
                    axisX.Logarithmic = true;
                    axisX.LogarithmicBase = 10;
                    axisX.WholeRange.AlwaysShowZeroLevel = false;

                    AxisY axisY = ((XYDiagram)chart.Diagram).AxisY;
                    axisY.Logarithmic = true;
                    axisY.LogarithmicBase = 10;
                    axisY.WholeRange.AlwaysShowZeroLevel = false;
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message + Environment.NewLine + e.Source);
            }
        }

        private void SetLineMaxChartData(ChartControl chart, ViewType viewType, DataTable dt)
        {
            //ChartTitle 생성
            ChartTitle title = new ChartTitle();

            chart.Titles.Clear();
            //chart.DataSource = null;
            //chart.Series.Clear();

            try
            {
                Dictionary<string, Series> seriesList = new Dictionary<string, Series>();
                title.Text = "RRS";
                chart.Titles.Add(title);

                foreach (DataRow row in dt.Rows)
                {
                    string FRS_IDX = "MAX RRS";
                    string HZ = row["HZ"].ToString();
                    string G = row["G"].ToString();

                    Series series;
                    if (seriesList.TryGetValue(FRS_IDX, out series) == false)
                    {
                        seriesList.Add(FRS_IDX, series = new Series(FRS_IDX, viewType));
                        //Label 표시
                        series.LabelsVisibility = DevExpress.Utils.DefaultBoolean.False;
                        chart.Series.Add(series);
                    }
                    //SeriesPoint 생성
                    SeriesPoint point = new SeriesPoint(HZ, G);
                    series.Points.Add(point);

                    ((LineSeriesView)series.View).MarkerVisibility = DevExpress.Utils.DefaultBoolean.True;
                    ((LineSeriesView)series.View).LineMarkerOptions.Size = 5;
                    ((LineSeriesView)series.View).LineMarkerOptions.Kind = MarkerKind.Triangle;
                }

                AxisY axisY = ((XYDiagram)chart.Diagram).AxisY;
                axisY.Logarithmic = true;
                axisY.LogarithmicBase = 10;
                axisY.WholeRange.AlwaysShowZeroLevel = false;

                AxisX axisX = ((XYDiagram)chart.Diagram).AxisX;
                axisX.Logarithmic = true;
                axisX.LogarithmicBase = 10;
                axisX.WholeRange.AlwaysShowZeroLevel = false;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message + Environment.NewLine + e.Source);
            }
        }

        private void SetLineMaxPercentChartData(ChartControl chart, ViewType viewType, DataTable dt, string spercent)
        {
            //ChartTitle 생성
            ChartTitle title = new ChartTitle();

            chart.Titles.Clear();
            //chart.DataSource = null;
            //chart.Series.Clear();

            try
            {
                Dictionary<string, Series> seriesList = new Dictionary<string, Series>();
                title.Text = "RRS";
                chart.Titles.Add(title);

                foreach (DataRow row in dt.Rows)
                {
                    //string IDX = "FRS " + row["IDX"].ToString();
                    string FRS_IDX = "MAX " + spercent +"% RRS";
                    string HZ = row["HZ"].ToString();
                    string G = row["G"].ToString();

                    Series series;
                    if (seriesList.TryGetValue(FRS_IDX, out series) == false)
                    {
                        seriesList.Add(FRS_IDX, series = new Series(FRS_IDX, viewType));
                        //Label 표시
                        series.LabelsVisibility = DevExpress.Utils.DefaultBoolean.False;
                        chart.Series.Add(series);
                    }
                    //SeriesPoint 생성
                    SeriesPoint point = new SeriesPoint(HZ, G);
                    series.Points.Add(point);

                    ((LineSeriesView)series.View).MarkerVisibility = DevExpress.Utils.DefaultBoolean.True;
                    ((LineSeriesView)series.View).LineMarkerOptions.Size = 5;
                    ((LineSeriesView)series.View).LineMarkerOptions.Kind = MarkerKind.Triangle;
                }
                AxisY axisY = ((XYDiagram)chart.Diagram).AxisY;
                axisY.Logarithmic = true;
                axisY.LogarithmicBase = 10;
                axisY.WholeRange.AlwaysShowZeroLevel = false;

                AxisX axisX = ((XYDiagram)chart.Diagram).AxisX;
                axisX.Logarithmic = true;
                axisX.LogarithmicBase = 10;
                axisX.WholeRange.AlwaysShowZeroLevel = false;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message + Environment.NewLine + e.Source);
            }
        }

        private void InitialChartData(ChartControl chart)
        {
            try
            {
                //ChartTitle 생성
                ChartTitle title = new ChartTitle();

                chart.Titles.Clear();
                chart.DataSource = null;
                chart.Series.Clear();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message + Environment.NewLine + e.Source);
            }
        }

        private void ucRrsMain_Load(object sender, EventArgs e)
        {
            //string csv_file = string.Empty;
            //csv_file = @"C:\Users\hiel_kim\OneDrive - SGS\Documents\test.csv";
            //uCommon.GetCSVData(csv_file); //CSV 파일 내용 읽어오기

            //SetChartData(RRS_Chart_Ctrl, ViewType.Line, uCommon.GetDataTable());
            //test();
        }

        private void BarItemRRSSearch_ItemClick(object sender, TileItemEventArgs e)
        {
            // FRS 조회
            try
            {
                frmFrsMain_P1_Set.sBUILDING = txtBUILDING.Text;
                frmFrsMain_P1_Set.sFROM = RrsFromDateEdit.Value.ToString(AppRes.csDateFormat);
                frmFrsMain_P1_Set.sTO = RrsToDateEdit.Value.ToString(AppRes.csDateFormat);
                frmFrsMain_P1_Set.sREGISTRANT = txtREGISTRANT.Text;
                frmFrsMain_P1_Set.sHEIGHT = txtHEIGHT.Text;
                frmFrsMain_P1_Set.sPOWERPLANT = txtPOWERPLANT.Text;
                //frmFrsMain_P1_Set.sSTATUS = cbmSTATUS.Text;
                frmFrsMain_P1_Set.SelectReviewOK();

                if (frmFrsMain_P1_Set.Empty == false)
                {
                    //AppHelper.RefreshGridData(FRS_Data_InquireGridView);
                    AppHelper.SetGridDataSource(RRS_Data_Grid, frmFrsMain_P1_Set);
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

        private void RRS_P1_IMAGE_PictureGroup_DoubleClick(object sender, EventArgs e)
        {
            if (RRS_Data_GridView.DataRowCount == 0) return;

            frmFrsImage_Image_Set.iIDX = Convert.ToInt64(RRS_Data_GridView.GetFocusedDataRow()["IDX"].ToString());
            frmFrsImage_Image_Set.Select();
            frmFrsImage_Image_Set.Fetch();

            frmFRSImage view = new frmFRSImage();
            view.ImageBox = frmFrsImage_Image_Set.bPicture;

            view.ShowDialog();
        }

        private void BarItemRRSMaxCurve_ItemClick(object sender, TileItemEventArgs e)
        {
            if (Listdt_SelectedTable.Count < 1) 
            {
                MessageBox.Show("RRS 데이터를 추가해주세요.");
                return;
            }

            try
            {
                DataTable dt_NullTable;
                DataTable dt_MaxTable;
                DataTable dt_distinctTable;
                List<DataTable> Listdt_selectedTableCopyNull;
                Listdt_selectedTableCopyNull = new List<DataTable>();
                Listdt_selectedTableCopyNull.Clear();
                int iDTidx = 0;

                dt_MaxTable = new DataTable();
                dt_MaxTable.Columns.Add("IDX");
                dt_MaxTable.Columns.Add("HZ");
                dt_MaxTable.Columns.Add("G");

                dt_distinctTable = new DataTable();

                // Zero Table 생성
                for (int i = 0; i < Listdt_SelectedTable.Count; i++)
                {
                    float dHZ = 0.1f;

                    dt_NullTable = new DataTable();
                    dt_NullTable.Columns.Add("IDX");
                    dt_NullTable.Columns.Add("FRS_IDX");
                    dt_NullTable.Columns.Add("HZ");
                    dt_NullTable.Columns.Add("G");

                    Listdt_selectedTableCopyNull.Add(dt_NullTable);

                    for (int j = 0; j < 1000; j++)
                    {
                        frmFrsMain_P1_Data_Set.Fetch(i);
                        Listdt_selectedTableCopyNull[iDTidx].Rows.Add(j, Listdt_SelectedTable[i].Rows[0]["FRS_IDX"].ToString(), dHZ.ToString("F1"), "");
                        dHZ += 0.1f;
                    }
                    iDTidx += 1;
                }

                float dHZz = 0.1f;

                // Max Table 생성
                for (int j = 0; j < Listdt_selectedTableCopyNull[0].Rows.Count; j++)
                {
                    dt_MaxTable.Rows.Add(j, dHZz.ToString("F1"), "");
                    dHZz += 0.1f;
                }

                iDTidx = 0;

                // Zero Table에 값 넣기
                foreach (DataTable ListDt in Listdt_SelectedTable)
                {
                    foreach (DataTable ListDtNull in Listdt_selectedTableCopyNull)
                    {
                        foreach (DataRow row in ListDt.Rows)
                        {
                            foreach (DataRow rowNull in ListDtNull.Rows)
                            {
                                if (row["FRS_IDX"].ToString().Equals(rowNull["FRS_IDX"].ToString()) && row["HZ"].ToString().Equals(rowNull["HZ"].ToString()))
                                {
                                    //double dG = Convert.ToDouble(row["G"].ToString());
                                    //rowNull["G"] = Math.Round(dG, 2);
                                    rowNull["G"] = row["G"].ToString();
                                }
                            }
                        }
                    }
                }

                bool bChkData = false;
                string sPreExistColumnHZ = string.Empty;
                string sPreExistColumnG = string.Empty;
                string sAfterExistColumnHZ = string.Empty;
                string sAfterExistColumnG = string.Empty;
                string sPreColumnHZ = string.Empty;
                string sPreColumnG = string.Empty;
                double dLastG = 0;

                int iEmptyCount = 0;
                int z = 1;
                int c = 1;

                // Table에서 0HZ와 100HZ에 값 넣기
                foreach (DataTable ListDtNull in Listdt_selectedTableCopyNull)
                {
                    foreach (DataRow rowNull in ListDtNull.Rows)
                    {
                        // 마지막 값을 넣기 위한 작업
                        if (!rowNull["G"].Equals("") && !rowNull["HZ"].Equals("100.0"))
                        {
                            dLastG = Convert.ToDouble(rowNull["G"]);
                        }

                        if (rowNull["HZ"].Equals("0.1") && rowNull["G"].Equals(""))
                        {
                            rowNull["G"] = "0";
                        }

                        // 마지막 값 소수 둘째자리 반올림
                        if (rowNull["HZ"].Equals("100.0") && rowNull["G"].Equals(""))
                        {
                            //rowNull["G"] = Math.Truncate(dLastG * 1000000000) / 1000000000;
                            rowNull["G"] = Math.Round(dLastG, 2);
                        }
                    }
                }

                // Table에서 Zero 값에 선형보간
                foreach (DataTable ListDtNull in Listdt_selectedTableCopyNull)
                {
                First:  // Row를 처음부터 다시 시작하기 위한 곳.
                    foreach (DataRow rowNull in ListDtNull.Rows)
                    {
                        if (bChkData == false)
                        {
                            // 값이 없는 row의 전 값(값이 있음)
                            if (!rowNull["G"].Equals("") && iEmptyCount == 0)
                            {
                                sPreExistColumnHZ = rowNull["HZ"].ToString();
                                sPreExistColumnG = rowNull["G"].ToString();
                            }

                            // 값이 없는 row의 값 Count
                            if (rowNull["G"].Equals("") && iEmptyCount >= 0)
                            {
                                iEmptyCount += 1;
                            }

                            // 값이 없는 row의 값 이후의 row값
                            if (!rowNull["G"].Equals("") && iEmptyCount > 0)
                            {
                                sAfterExistColumnHZ = rowNull["HZ"].ToString();
                                sAfterExistColumnG = rowNull["G"].ToString();
                            }

                            // Pre, After 값이 모두 있는 경우
                            if (!sAfterExistColumnHZ.Equals("") && !sPreExistColumnHZ.Equals("") && iEmptyCount > 0)
                            {
                                bChkData = true;
                                goto First;
                            }

                            if (rowNull["HZ"].Equals("100.0") && !rowNull["G"].Equals(""))
                            {
                                Console.WriteLine(c.ToString() + "/" + Listdt_selectedTableCopyNull.Count.ToString() + " 완료!");
                                c += 1;
                            }
                        }
                        else if (bChkData == true && rowNull["G"].ToString().Equals("") && z <= iEmptyCount)
                        {
                            double dG = Convert.ToDouble(sPreExistColumnG) + (Convert.ToDouble(sAfterExistColumnG) - Convert.ToDouble(sPreExistColumnG)) / (iEmptyCount + 1) * z;
                            //rowNull["G"] = Math.Truncate(dG * 1000000000) / 1000000000;
                            rowNull["G"] = Math.Round(dG, 2);
                            z += 1;
                        }
                        else if (z > iEmptyCount)
                        {
                            iEmptyCount = 0;
                            z = 1;
                            sPreExistColumnHZ = "";
                            sAfterExistColumnHZ = "";
                            bChkData = false;
                            goto First;
                        }
                    }
                }

                //int iMaxCnt = 0;
                // 최대값 Table에 0 넣기
                //foreach (DataTable ListDtNull in Listdt_selectedTableCopyNull)
                //{   
                //    double[] numbers = new double[Listdt_selectedTableCopyNull[0].Rows.Count];
                //    dMaxList.Add(numbers);

                //    for (int iMax = 0; iMax < Listdt_selectedTableCopyNull[0].Rows.Count; iMax++)
                //    {
                //        dMaxList[iMaxCnt][iMax] = 0.0;
                //    }
                //    iMaxCnt += 1;
                //}
                //    iMaxCnt =0;

                // Table에서 최대값 넣기
                //foreach (DataTable ListDtNull in Listdt_selectedTableCopyNull)
                //{
                //    for (int iMax = 0; iMax < ListDtNull.Rows.Count; iMax++) 
                //    {       
                //        if (dMaxList[iMaxCnt][iMax] < Convert.ToDouble(ListDtNull.Rows[iMax]["G"].ToString())) 
                //        {
                //            dMaxList[iMaxCnt][iMax] = Convert.ToDouble(ListDtNull.Rows[iMax]["G"].ToString());
                //        }
                //    }
                //    iMaxCnt += 1;
                //}
                //    iMaxCnt =0;


                // 배열에 초기값 0 넣기
                double[] numbers = new double[Listdt_selectedTableCopyNull[0].Rows.Count];
                foreach (DataTable ListDtNull in Listdt_selectedTableCopyNull)
                {
                    for (int iMax = 0; iMax < Listdt_selectedTableCopyNull[0].Rows.Count; iMax++)
                    {
                        numbers[iMax] = 0;
                    }
                }

                // 배열에 최대값 넣기
                foreach (DataTable ListDtNull in Listdt_selectedTableCopyNull)
                {
                    for (int iMax = 0; iMax < ListDtNull.Rows.Count; iMax++)
                    {
                        if (numbers[iMax] < Convert.ToDouble(ListDtNull.Rows[iMax]["G"].ToString()))
                        {
                            numbers[iMax] = Convert.ToDouble(ListDtNull.Rows[iMax]["G"].ToString());
                        }
                    }
                }

                // Max Table에 최대값 넣기
                for (int i = 0; i < dt_MaxTable.Rows.Count; i++)
                {
                    dt_MaxTable.Rows[i]["G"] = Math.Round(numbers[i], 2);
                }

                // DataView 인스턴스 얻기
                //DataView view = dt_MaxTable.DefaultView;
                
                // 중복 제거(중복제거 후 다른 컬럼들도 표시됨)
                dt_distinctTable = dt_MaxTable.AsEnumerable().GroupBy(row => row.Field<string>("G")).Select(group => group.First()).CopyToDataTable();
                
                // Line Chart Data 생성하기
                SetLineChartData(RRS_Chart_Ctrl, ViewType.Line, Listdt_SelectedTable);

                // Max Chart Data 생성하기
                //SetLineMaxChartData(RRS_Chart_Ctrl, ViewType.Line, dt_MaxTable);
                SetLineMaxChartData(RRS_Chart_Ctrl, ViewType.Line, dt_distinctTable);

                // Max Percent DT 생성하기 (중복제거된 값)
                dt_MultiPercentMaxTable = new DataTable();
                dt_MultiPercentMaxTable = dt_distinctTable;
                //dt_MultiPercentMaxTable = dt_MaxTable;

                // Copy MaxTable
                //dt_CopyMaxTable = new DataTable();
                //dt_CopyMaxTable = dt_MaxTable;
            }
            catch (Exception f) 
            {
                MessageBox.Show(f.Message + Environment.NewLine + f.Source);
            }
        }

        private void BarItemRRSMaxCurvePercent_ItemClick(object sender, TileItemEventArgs e)
        {
            try
            {
                if (!string.IsNullOrWhiteSpace(txtMaxPercentCurve.Text) || !string.IsNullOrEmpty(txtMaxPercentCurve.Text))
                {
                    BarItemRRSMaxCurve.PerformItemClick();

                    foreach (DataRow dtMax in dt_MultiPercentMaxTable.Rows)
                    {
                        double dMax = 0;

                        dMax = Convert.ToDouble(dtMax["G"]) * (1 + Convert.ToDouble(txtMaxPercentCurve.Text) / 100);
                        dtMax["G"] = Math.Round(dMax,2);
                    }

                    // Max Percent Chart Data 생성하기
                    SetLineMaxPercentChartData(RRS_Chart_Ctrl, ViewType.Line, dt_MultiPercentMaxTable, txtMaxPercentCurve.Text);
                }
            }
            catch (Exception f)
            {
                MessageBox.Show(f.Message + Environment.NewLine + f.Source);
            }
        }

        private void BarItemRRSInitial_ItemClick(object sender, TileItemEventArgs e)
        {
            // Chart 초기화
            InitialChartData(RRS_Chart_Ctrl);

            // Grid 초기화
            RRS_Data_Grid.DataSource = null;

            // Text Box 초기화
            txtBUILDING.Text = string.Empty;
            txtDAMPING.Text = string.Empty;
            txtHEIGHT.Text = string.Empty;
            txtPOWERPLANT.Text = string.Empty;
            txtREGISTRANT.Text = string.Empty;
            txtWAY.Text = string.Empty;
            txtMaxPercentCurve.Text = string.Empty;
        }

        private void BarItemRRSImage_ItemClick(object sender, TileItemEventArgs e)
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
                RRS_Chart_Ctrl.ExportToImage(sFilePath, System.Drawing.Imaging.ImageFormat.Jpeg);
            }
        }

        private void BarItemRRSXlsx_ItemClick(object sender, TileItemEventArgs e)
        {
            uCommon.ExportCSV_MAX(dt_MultiPercentMaxTable);
        }
    }
}

//frmFrsMain_P1_Data_Set.iFRS_P1_IDX = Convert.ToInt64(row[1].ToString());
//frmFrsMain_P1_Data_Set.Select();

//for (int i = 0; i < frmFrsMain_P1_Data_Set.RowCount; i++)
//{
//    frmFrsMain_P1_Data_Set.Fetch(i);
//    Listdt_SelectedTable[iDTidx].Rows.Add(frmFrsMain_P1_Data_Set.iIDX, frmFrsMain_P1_Data_Set.iFRS_P1_IDX, frmFrsMain_P1_Data_Set.sHZ, frmFrsMain_P1_Data_Set.sG);
//}
//iDTidx += 1;