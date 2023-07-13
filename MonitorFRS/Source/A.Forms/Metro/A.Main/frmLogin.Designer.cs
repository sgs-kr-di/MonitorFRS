
namespace MonitorFRS.Source.A.Forms.Metro.A.Main
{
    partial class frmLogin
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmLogin));
            this.picLogo = new DevExpress.XtraEditors.PictureEdit();
            this.behaviorManager1 = new DevExpress.Utils.Behaviors.BehaviorManager(this.components);
            this.picMain = new DevExpress.XtraEditors.PictureEdit();
            this.lblId = new MetroFramework.Controls.MetroLabel();
            this.txtID = new DevExpress.XtraEditors.TextEdit();
            this.pictureEdit3 = new DevExpress.XtraEditors.PictureEdit();
            this.btnSignUp = new DevExpress.XtraEditors.SimpleButton();
            this.lblPw = new MetroFramework.Controls.MetroLabel();
            this.btnLogin = new DevExpress.XtraEditors.SimpleButton();
            this.txtPW = new DevExpress.XtraEditors.TextEdit();
            this.pictureEdit4 = new DevExpress.XtraEditors.PictureEdit();
            this.tablePanel1 = new DevExpress.Utils.Layout.TablePanel();
            this.tablePanel2 = new DevExpress.Utils.Layout.TablePanel();
            ((System.ComponentModel.ISupportInitialize)(this.picLogo.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.behaviorManager1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picMain.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtID.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureEdit3.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPW.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureEdit4.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tablePanel1)).BeginInit();
            this.tablePanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tablePanel2)).BeginInit();
            this.tablePanel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // picLogo
            // 
            this.picLogo.EditValue = ((object)(resources.GetObject("picLogo.EditValue")));
            this.picLogo.Location = new System.Drawing.Point(777, 5);
            this.picLogo.Name = "picLogo";
            this.picLogo.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.picLogo.Properties.ShowCameraMenuItem = DevExpress.XtraEditors.Controls.CameraMenuItemVisibility.Auto;
            this.picLogo.Properties.SizeMode = DevExpress.XtraEditors.Controls.PictureSizeMode.Zoom;
            this.picLogo.Size = new System.Drawing.Size(76, 62);
            this.picLogo.TabIndex = 2;
            this.picLogo.Visible = false;
            // 
            // picMain
            // 
            this.tablePanel1.SetColumn(this.picMain, 0);
            this.picMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.picMain.EditValue = ((object)(resources.GetObject("picMain.EditValue")));
            this.picMain.Location = new System.Drawing.Point(3, 3);
            this.picMain.Name = "picMain";
            this.picMain.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.picMain.Properties.ShowCameraMenuItem = DevExpress.XtraEditors.Controls.CameraMenuItemVisibility.Auto;
            this.picMain.Properties.SizeMode = DevExpress.XtraEditors.Controls.PictureSizeMode.Zoom;
            this.tablePanel1.SetRow(this.picMain, 0);
            this.picMain.Size = new System.Drawing.Size(327, 468);
            this.picMain.TabIndex = 1;
            // 
            // lblId
            // 
            this.lblId.AutoSize = true;
            this.tablePanel2.SetColumn(this.lblId, 0);
            this.lblId.Location = new System.Drawing.Point(3, 4);
            this.lblId.Name = "lblId";
            this.tablePanel2.SetRow(this.lblId, 0);
            this.lblId.Size = new System.Drawing.Size(28, 19);
            this.lblId.TabIndex = 3;
            this.lblId.Text = "ID :";
            // 
            // txtID
            // 
            this.tablePanel2.SetColumn(this.txtID, 1);
            this.txtID.Location = new System.Drawing.Point(46, 3);
            this.txtID.Name = "txtID";
            this.txtID.Properties.Appearance.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtID.Properties.Appearance.Options.UseFont = true;
            this.txtID.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.tablePanel2.SetRow(this.txtID, 0);
            this.txtID.Size = new System.Drawing.Size(392, 22);
            this.txtID.TabIndex = 7;
            this.txtID.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtID_KeyDown);
            // 
            // pictureEdit3
            // 
            this.tablePanel2.SetColumn(this.pictureEdit3, 1);
            this.pictureEdit3.EditValue = ((object)(resources.GetObject("pictureEdit3.EditValue")));
            this.pictureEdit3.Location = new System.Drawing.Point(46, 33);
            this.pictureEdit3.Name = "pictureEdit3";
            this.pictureEdit3.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.pictureEdit3.Properties.ShowCameraMenuItem = DevExpress.XtraEditors.Controls.CameraMenuItemVisibility.Auto;
            this.pictureEdit3.Properties.SizeMode = DevExpress.XtraEditors.Controls.PictureSizeMode.StretchHorizontal;
            this.tablePanel2.SetRow(this.pictureEdit3, 1);
            this.pictureEdit3.Size = new System.Drawing.Size(392, 10);
            this.pictureEdit3.TabIndex = 5;
            // 
            // btnSignUp
            // 
            this.btnSignUp.Appearance.Font = new System.Drawing.Font("Bahnschrift Condensed", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSignUp.Appearance.Options.UseFont = true;
            this.tablePanel2.SetColumn(this.btnSignUp, 1);
            this.btnSignUp.Location = new System.Drawing.Point(46, 174);
            this.btnSignUp.Name = "btnSignUp";
            this.tablePanel2.SetRow(this.btnSignUp, 6);
            this.btnSignUp.Size = new System.Drawing.Size(392, 36);
            this.btnSignUp.TabIndex = 9;
            this.btnSignUp.Text = "계정등록";
            this.btnSignUp.Visible = false;
            this.btnSignUp.Click += new System.EventHandler(this.btnSignUp_Click);
            // 
            // lblPw
            // 
            this.lblPw.AutoSize = true;
            this.tablePanel2.SetColumn(this.lblPw, 0);
            this.lblPw.Location = new System.Drawing.Point(3, 52);
            this.lblPw.Name = "lblPw";
            this.tablePanel2.SetRow(this.lblPw, 2);
            this.lblPw.Size = new System.Drawing.Size(37, 19);
            this.lblPw.TabIndex = 4;
            this.lblPw.Text = "PW :";
            // 
            // btnLogin
            // 
            this.btnLogin.Appearance.Font = new System.Drawing.Font("Bahnschrift Condensed", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLogin.Appearance.Options.UseFont = true;
            this.tablePanel2.SetColumn(this.btnLogin, 1);
            this.btnLogin.Location = new System.Drawing.Point(46, 129);
            this.btnLogin.Name = "btnLogin";
            this.tablePanel2.SetRow(this.btnLogin, 5);
            this.btnLogin.Size = new System.Drawing.Size(392, 36);
            this.btnLogin.TabIndex = 9;
            this.btnLogin.Text = "로그인";
            this.btnLogin.Click += new System.EventHandler(this.btnLogin_Click);
            // 
            // txtPW
            // 
            this.tablePanel2.SetColumn(this.txtPW, 1);
            this.txtPW.Location = new System.Drawing.Point(46, 51);
            this.txtPW.Name = "txtPW";
            this.txtPW.Properties.Appearance.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtPW.Properties.Appearance.Options.UseFont = true;
            this.txtPW.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.txtPW.Properties.UseSystemPasswordChar = true;
            this.tablePanel2.SetRow(this.txtPW, 2);
            this.txtPW.Size = new System.Drawing.Size(392, 22);
            this.txtPW.TabIndex = 8;
            this.txtPW.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtPW_KeyDown);
            // 
            // pictureEdit4
            // 
            this.tablePanel2.SetColumn(this.pictureEdit4, 1);
            this.pictureEdit4.EditValue = ((object)(resources.GetObject("pictureEdit4.EditValue")));
            this.pictureEdit4.Location = new System.Drawing.Point(46, 81);
            this.pictureEdit4.Name = "pictureEdit4";
            this.pictureEdit4.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.pictureEdit4.Properties.ShowCameraMenuItem = DevExpress.XtraEditors.Controls.CameraMenuItemVisibility.Auto;
            this.pictureEdit4.Properties.SizeMode = DevExpress.XtraEditors.Controls.PictureSizeMode.StretchHorizontal;
            this.tablePanel2.SetRow(this.pictureEdit4, 3);
            this.pictureEdit4.Size = new System.Drawing.Size(392, 10);
            this.pictureEdit4.TabIndex = 6;
            // 
            // tablePanel1
            // 
            this.tablePanel1.Columns.AddRange(new DevExpress.Utils.Layout.TablePanelColumn[] {
            new DevExpress.Utils.Layout.TablePanelColumn(DevExpress.Utils.Layout.TablePanelEntityStyle.Relative, 40F),
            new DevExpress.Utils.Layout.TablePanelColumn(DevExpress.Utils.Layout.TablePanelEntityStyle.Relative, 60F)});
            this.tablePanel1.Controls.Add(this.tablePanel2);
            this.tablePanel1.Controls.Add(this.picMain);
            this.tablePanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tablePanel1.Location = new System.Drawing.Point(20, 60);
            this.tablePanel1.Name = "tablePanel1";
            this.tablePanel1.Rows.AddRange(new DevExpress.Utils.Layout.TablePanelRow[] {
            new DevExpress.Utils.Layout.TablePanelRow(DevExpress.Utils.Layout.TablePanelEntityStyle.Absolute, 26F)});
            this.tablePanel1.Size = new System.Drawing.Size(833, 474);
            this.tablePanel1.TabIndex = 12;
            // 
            // tablePanel2
            // 
            this.tablePanel1.SetColumn(this.tablePanel2, 1);
            this.tablePanel2.Columns.AddRange(new DevExpress.Utils.Layout.TablePanelColumn[] {
            new DevExpress.Utils.Layout.TablePanelColumn(DevExpress.Utils.Layout.TablePanelEntityStyle.AutoSize, 10F),
            new DevExpress.Utils.Layout.TablePanelColumn(DevExpress.Utils.Layout.TablePanelEntityStyle.Relative, 450F),
            new DevExpress.Utils.Layout.TablePanelColumn(DevExpress.Utils.Layout.TablePanelEntityStyle.Relative, 60F)});
            this.tablePanel2.Controls.Add(this.lblId);
            this.tablePanel2.Controls.Add(this.btnSignUp);
            this.tablePanel2.Controls.Add(this.pictureEdit3);
            this.tablePanel2.Controls.Add(this.btnLogin);
            this.tablePanel2.Controls.Add(this.txtID);
            this.tablePanel2.Controls.Add(this.pictureEdit4);
            this.tablePanel2.Controls.Add(this.txtPW);
            this.tablePanel2.Controls.Add(this.lblPw);
            this.tablePanel2.Location = new System.Drawing.Point(336, 128);
            this.tablePanel2.Name = "tablePanel2";
            this.tablePanel1.SetRow(this.tablePanel2, 0);
            this.tablePanel2.Rows.AddRange(new DevExpress.Utils.Layout.TablePanelRow[] {
            new DevExpress.Utils.Layout.TablePanelRow(DevExpress.Utils.Layout.TablePanelEntityStyle.AutoSize, 26F),
            new DevExpress.Utils.Layout.TablePanelRow(DevExpress.Utils.Layout.TablePanelEntityStyle.AutoSize, 26F),
            new DevExpress.Utils.Layout.TablePanelRow(DevExpress.Utils.Layout.TablePanelEntityStyle.AutoSize, 26F),
            new DevExpress.Utils.Layout.TablePanelRow(DevExpress.Utils.Layout.TablePanelEntityStyle.AutoSize, 26F),
            new DevExpress.Utils.Layout.TablePanelRow(DevExpress.Utils.Layout.TablePanelEntityStyle.Absolute, 30F),
            new DevExpress.Utils.Layout.TablePanelRow(DevExpress.Utils.Layout.TablePanelEntityStyle.AutoSize, 26F),
            new DevExpress.Utils.Layout.TablePanelRow(DevExpress.Utils.Layout.TablePanelEntityStyle.AutoSize, 26F)});
            this.tablePanel2.Size = new System.Drawing.Size(494, 217);
            this.tablePanel2.TabIndex = 2;
            // 
            // frmLogin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(873, 554);
            this.Controls.Add(this.picLogo);
            this.Controls.Add(this.tablePanel1);
            this.ForeColor = System.Drawing.SystemColors.ControlText;
            this.IsMdiContainer = true;
            this.Name = "frmLogin";
            this.Text = "LOGIN";
            this.TransparencyKey = System.Drawing.Color.Empty;
            this.Load += new System.EventHandler(this.frmLogin_Load);
            ((System.ComponentModel.ISupportInitialize)(this.picLogo.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.behaviorManager1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picMain.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtID.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureEdit3.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPW.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureEdit4.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tablePanel1)).EndInit();
            this.tablePanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.tablePanel2)).EndInit();
            this.tablePanel2.ResumeLayout(false);
            this.tablePanel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private DevExpress.XtraEditors.PictureEdit picLogo;
        private DevExpress.Utils.Behaviors.BehaviorManager behaviorManager1;
        private DevExpress.XtraEditors.PictureEdit picMain;
        private MetroFramework.Controls.MetroLabel lblId;
        private DevExpress.XtraEditors.TextEdit txtID;
        private DevExpress.XtraEditors.PictureEdit pictureEdit3;
        private DevExpress.XtraEditors.SimpleButton btnSignUp;
        private MetroFramework.Controls.MetroLabel lblPw;
        private DevExpress.XtraEditors.SimpleButton btnLogin;
        private DevExpress.XtraEditors.TextEdit txtPW;
        private DevExpress.XtraEditors.PictureEdit pictureEdit4;
        private DevExpress.Utils.Layout.TablePanel tablePanel1;
        private DevExpress.Utils.Layout.TablePanel tablePanel2;
    }
}