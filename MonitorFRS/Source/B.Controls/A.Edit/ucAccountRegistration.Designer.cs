
namespace MonitorFRS.Source.B.Controls.A.Edit
{
    partial class ucAccountRegistration
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ucAccountRegistration));
            this.pnlAccountRightBackground = new DevExpress.Utils.Layout.TablePanel();
            this.tablePanel2 = new DevExpress.Utils.Layout.TablePanel();
            this.lblId = new MetroFramework.Controls.MetroLabel();
            this.btnSignUp = new DevExpress.XtraEditors.SimpleButton();
            this.pictureEdit3 = new DevExpress.XtraEditors.PictureEdit();
            this.txtID = new DevExpress.XtraEditors.TextEdit();
            this.pictureEdit4 = new DevExpress.XtraEditors.PictureEdit();
            this.txtPW = new DevExpress.XtraEditors.TextEdit();
            this.lblPw = new MetroFramework.Controls.MetroLabel();
            this.picMain = new DevExpress.XtraEditors.PictureEdit();
            ((System.ComponentModel.ISupportInitialize)(this.pnlAccountRightBackground)).BeginInit();
            this.pnlAccountRightBackground.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tablePanel2)).BeginInit();
            this.tablePanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureEdit3.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtID.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureEdit4.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPW.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picMain.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlAccountRightBackground
            // 
            this.pnlAccountRightBackground.Appearance.BackColor = System.Drawing.Color.White;
            this.pnlAccountRightBackground.Appearance.Options.UseBackColor = true;
            this.pnlAccountRightBackground.Columns.AddRange(new DevExpress.Utils.Layout.TablePanelColumn[] {
            new DevExpress.Utils.Layout.TablePanelColumn(DevExpress.Utils.Layout.TablePanelEntityStyle.Relative, 40F),
            new DevExpress.Utils.Layout.TablePanelColumn(DevExpress.Utils.Layout.TablePanelEntityStyle.Relative, 60F)});
            this.pnlAccountRightBackground.Controls.Add(this.tablePanel2);
            this.pnlAccountRightBackground.Controls.Add(this.picMain);
            this.pnlAccountRightBackground.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlAccountRightBackground.Location = new System.Drawing.Point(0, 0);
            this.pnlAccountRightBackground.Name = "pnlAccountRightBackground";
            this.pnlAccountRightBackground.Rows.AddRange(new DevExpress.Utils.Layout.TablePanelRow[] {
            new DevExpress.Utils.Layout.TablePanelRow(DevExpress.Utils.Layout.TablePanelEntityStyle.Absolute, 26F)});
            this.pnlAccountRightBackground.Size = new System.Drawing.Size(800, 600);
            this.pnlAccountRightBackground.TabIndex = 13;
            // 
            // tablePanel2
            // 
            this.pnlAccountRightBackground.SetColumn(this.tablePanel2, 1);
            this.tablePanel2.Columns.AddRange(new DevExpress.Utils.Layout.TablePanelColumn[] {
            new DevExpress.Utils.Layout.TablePanelColumn(DevExpress.Utils.Layout.TablePanelEntityStyle.AutoSize, 10F),
            new DevExpress.Utils.Layout.TablePanelColumn(DevExpress.Utils.Layout.TablePanelEntityStyle.Relative, 450F),
            new DevExpress.Utils.Layout.TablePanelColumn(DevExpress.Utils.Layout.TablePanelEntityStyle.Relative, 60F)});
            this.tablePanel2.Controls.Add(this.lblId);
            this.tablePanel2.Controls.Add(this.btnSignUp);
            this.tablePanel2.Controls.Add(this.pictureEdit3);
            this.tablePanel2.Controls.Add(this.txtID);
            this.tablePanel2.Controls.Add(this.pictureEdit4);
            this.tablePanel2.Controls.Add(this.txtPW);
            this.tablePanel2.Controls.Add(this.lblPw);
            this.tablePanel2.Location = new System.Drawing.Point(323, 191);
            this.tablePanel2.Name = "tablePanel2";
            this.pnlAccountRightBackground.SetRow(this.tablePanel2, 0);
            this.tablePanel2.Rows.AddRange(new DevExpress.Utils.Layout.TablePanelRow[] {
            new DevExpress.Utils.Layout.TablePanelRow(DevExpress.Utils.Layout.TablePanelEntityStyle.AutoSize, 26F),
            new DevExpress.Utils.Layout.TablePanelRow(DevExpress.Utils.Layout.TablePanelEntityStyle.AutoSize, 26F),
            new DevExpress.Utils.Layout.TablePanelRow(DevExpress.Utils.Layout.TablePanelEntityStyle.AutoSize, 26F),
            new DevExpress.Utils.Layout.TablePanelRow(DevExpress.Utils.Layout.TablePanelEntityStyle.AutoSize, 26F),
            new DevExpress.Utils.Layout.TablePanelRow(DevExpress.Utils.Layout.TablePanelEntityStyle.AutoSize, 30F),
            new DevExpress.Utils.Layout.TablePanelRow(DevExpress.Utils.Layout.TablePanelEntityStyle.AutoSize, 20F)});
            this.tablePanel2.Size = new System.Drawing.Size(474, 217);
            this.tablePanel2.TabIndex = 2;
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
            // btnSignUp
            // 
            this.btnSignUp.Appearance.Font = new System.Drawing.Font("Bahnschrift Condensed", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSignUp.Appearance.Options.UseFont = true;
            this.tablePanel2.SetColumn(this.btnSignUp, 1);
            this.btnSignUp.Location = new System.Drawing.Point(46, 148);
            this.btnSignUp.Name = "btnSignUp";
            this.tablePanel2.SetRow(this.btnSignUp, 5);
            this.btnSignUp.Size = new System.Drawing.Size(374, 36);
            this.btnSignUp.TabIndex = 9;
            this.btnSignUp.Text = "계정등록";
            this.btnSignUp.Click += new System.EventHandler(this.btnSignUp_Click);
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
            this.pictureEdit3.Size = new System.Drawing.Size(374, 10);
            this.pictureEdit3.TabIndex = 5;
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
            this.txtID.Size = new System.Drawing.Size(374, 22);
            this.txtID.TabIndex = 7;
            this.txtID.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtID_KeyDown);
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
            this.pictureEdit4.Size = new System.Drawing.Size(374, 10);
            this.pictureEdit4.TabIndex = 6;
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
            this.txtPW.Size = new System.Drawing.Size(374, 22);
            this.txtPW.TabIndex = 8;
            this.txtPW.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtPW_KeyDown);
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
            // picMain
            // 
            this.pnlAccountRightBackground.SetColumn(this.picMain, 0);
            this.picMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.picMain.EditValue = ((object)(resources.GetObject("picMain.EditValue")));
            this.picMain.Location = new System.Drawing.Point(3, 3);
            this.picMain.Name = "picMain";
            this.picMain.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.picMain.Properties.ShowCameraMenuItem = DevExpress.XtraEditors.Controls.CameraMenuItemVisibility.Auto;
            this.picMain.Properties.SizeMode = DevExpress.XtraEditors.Controls.PictureSizeMode.Zoom;
            this.pnlAccountRightBackground.SetRow(this.picMain, 0);
            this.picMain.Size = new System.Drawing.Size(314, 594);
            this.picMain.TabIndex = 1;
            // 
            // ucAccountRegistration
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.pnlAccountRightBackground);
            this.Name = "ucAccountRegistration";
            this.Size = new System.Drawing.Size(800, 600);
            ((System.ComponentModel.ISupportInitialize)(this.pnlAccountRightBackground)).EndInit();
            this.pnlAccountRightBackground.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.tablePanel2)).EndInit();
            this.tablePanel2.ResumeLayout(false);
            this.tablePanel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureEdit3.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtID.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureEdit4.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPW.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picMain.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.Utils.Layout.TablePanel pnlAccountRightBackground;
        private DevExpress.Utils.Layout.TablePanel tablePanel2;
        private MetroFramework.Controls.MetroLabel lblId;
        private DevExpress.XtraEditors.SimpleButton btnSignUp;
        private DevExpress.XtraEditors.PictureEdit pictureEdit3;
        private DevExpress.XtraEditors.TextEdit txtID;
        private DevExpress.XtraEditors.PictureEdit pictureEdit4;
        private DevExpress.XtraEditors.TextEdit txtPW;
        private MetroFramework.Controls.MetroLabel lblPw;
        private DevExpress.XtraEditors.PictureEdit picMain;
    }
}
