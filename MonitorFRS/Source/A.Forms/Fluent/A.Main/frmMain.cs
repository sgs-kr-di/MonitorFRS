using DevExpress.XtraBars;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading.Tasks;
//using DevExpress.DXperience.Demos;
using DevExpress.XtraEditors;
using MonitorFRS.Source.A.Forms.Metro.A.Main;
using MonitorFRS.Source.B.Controls.A.Edit;
using MonitorFRS.Source.C.Units;

using Ulee.Controls;
using Ulee.Utils;

namespace MonitorFRS
{
    public partial class frmMain : DevExpress.XtraBars.FluentDesignSystem.FluentDesignForm
    {
        private UnitCommon uCommon;
        private frmLogin frmLogin_Main;
        private ucFrsMain ucFrsInquire_Main;
        private ucRrsMain ucRrs_Main;
        private ucAccountRegistration ucAccount_Registration;

        public frmMain()
        {
            InitializeComponent();
            Initialize();
        }

        private void Initialize()
        {
            WindowState = FormWindowState.Minimized;
            ShowInTaskbar = false;
            Opacity = 0;

            accordionControlElementAccount.Visible = false;

            frmLogin_Main = new frmLogin();
            ucFrsInquire_Main = new ucFrsMain();
            ucRrs_Main = new ucRrsMain();
            ucAccount_Registration = new ucAccountRegistration();
            uCommon = new UnitCommon();
            fluentDesignFormContainer.Controls.Clear();

            uCommon.Initialize_LoginInfo();

        }

        //async Task LoadModuleAsync(XtraUserControl module) 
        //{
        //    await Task.Factory.StartNew(() =>
        //    {
        //        if (!fluentDesignFormContainer.Controls.ContainsKey(module.Name))
        //        {
        //            XtraUserControl control = module as XtraUserControl;
        //            //TutorialControlBase control2 = module.TModule as TutorialControlBase;
        //            if (control != null)
        //            {
        //                control.Dock = DockStyle.Fill;
        //                //control2.CreateWaitDialog();
        //                control.CreateControl();
        //                fluentDesignFormContainer.Invoke(new MethodInvoker(delegate ()
        //                {
        //                    fluentDesignFormContainer.Controls.Add(control);
        //                    control.BringToFront();
        //                }));
        //            }
        //        }
        //        else 
        //        {
        //            var control = fluentDesignFormContainer.Controls.Find(module.Name, true);
        //            if (control.Length == 1) 
        //            {
        //                fluentDesignFormContainer.Invoke(new MethodInvoker(delegate () { control[0].BringToFront(); }));
        //            }
        //        }
        //    });
        //}

        private void SetControl(XtraUserControl ctrl)
        {
            fluentDesignFormContainer.Controls.Clear();
            fluentDesignFormContainer.Controls.Remove(ctrl);
            ctrl.Refresh();

            if (ctrl == null)
            {
                //fluentDesignFormContainer.BevelOuter = EUlBevelStyle.Single;
            }
            else
            {
                fluentDesignFormContainer.Controls.Add(ctrl);
                //reportPagePanel.BevelInner = EUlBevelStyle.None;
                //reportPagePanel.BevelOuter = EUlBevelStyle.None;
                ctrl.Dock = DockStyle.Fill;
            }
        }

        private void frmMain_Load(object sender, EventArgs e)
        {   
            frmLogin_Main.ShowDialog();

            // 정상적으로 로그인이 안되었을 경우 폼 종료
            if (frmLogin_LoginInfo.bChkLogin == false)
            {
                this.Close();
            }
            else
            {
                WindowState = FormWindowState.Maximized;
                ShowInTaskbar = true;
                Opacity = 1;

                if (frmLogin_LoginInfo.sGroupName.ToUpper().Contains("SUPER")) 
                {
                    accordionControlElementAccount.Visible = true;
                }
            }
        }

        private void accordionControlElementFrsInquire_Click(object sender, EventArgs e)
        {
            this.barStaticMainNav.Caption = "FRS " + $"{accordionControlElementFrsSearchAndInquire.Text}";

            SetControl(ucFrsInquire_Main);

            //if ( ModulesInfo.GetItem("ucFrsInquire") == null) 
            //{
            //    ModulesInfo.Add(new ModuleInfo("ucFrsInquire", "MonitorFRS.Source.A.Forms.Fluent.A.Main.ucFrsInquire"));
            //}
            //await LoadModuleAsync(ModulesInfo.GetItem("ucFrsInquire"));
        }

        private void accordionControlElementRrsSearchAndInquire_Click(object sender, EventArgs e)
        {
            this.barStaticMainNav.Caption = "RRS " + $"{accordionControlElementRrsSearchAndInquire.Text}";

            SetControl(ucRrs_Main);
        }

        private void accordionControlElementAccountRegistration_Click(object sender, EventArgs e)
        {
            this.barStaticMainNav.Caption = $"{accordionControlElementAccountRegistration.Text}";

            SetControl(ucAccount_Registration);
        }

        private void barHeaderItemLogout_ItemClick(object sender, ItemClickEventArgs e)
        {
            Initialize();
            frmLogin_Main.ShowDialog();

            // 정상적으로 로그인이 안되었을 경우 폼 종료
            if (frmLogin_LoginInfo.bChkLogin == false)
            {
                this.Close();
            }
            else
            {
                WindowState = FormWindowState.Maximized;
                ShowInTaskbar = true;
                Opacity = 1;

                if (frmLogin_LoginInfo.sGroupName.ToUpper().Contains("SUPER"))
                {
                    accordionControlElementAccount.Visible = true;
                }
            }
        }
    }
}