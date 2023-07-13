
namespace MonitorFRS.Source.A.Forms.Fluent.B.Dialog
{
    partial class frmFRSImage
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
            this.pnlFrsPicture = new DevExpress.Utils.Layout.TablePanel();
            this.picFrsPicture = new DevExpress.XtraEditors.PictureEdit();
            ((System.ComponentModel.ISupportInitialize)(this.pnlFrsPicture)).BeginInit();
            this.pnlFrsPicture.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picFrsPicture.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlFrsPicture
            // 
            this.pnlFrsPicture.AutoScroll = true;
            this.pnlFrsPicture.AutoSize = true;
            this.pnlFrsPicture.Columns.AddRange(new DevExpress.Utils.Layout.TablePanelColumn[] {
            new DevExpress.Utils.Layout.TablePanelColumn(DevExpress.Utils.Layout.TablePanelEntityStyle.Relative, 5F)});
            this.pnlFrsPicture.Controls.Add(this.picFrsPicture);
            this.pnlFrsPicture.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlFrsPicture.Location = new System.Drawing.Point(0, 0);
            this.pnlFrsPicture.Name = "pnlFrsPicture";
            this.pnlFrsPicture.Rows.AddRange(new DevExpress.Utils.Layout.TablePanelRow[] {
            new DevExpress.Utils.Layout.TablePanelRow(DevExpress.Utils.Layout.TablePanelEntityStyle.Absolute, 26F)});
            this.pnlFrsPicture.Size = new System.Drawing.Size(798, 568);
            this.pnlFrsPicture.TabIndex = 0;
            // 
            // picFrsPicture
            // 
            this.pnlFrsPicture.SetColumn(this.picFrsPicture, 0);
            this.picFrsPicture.Dock = System.Windows.Forms.DockStyle.Fill;
            this.picFrsPicture.Location = new System.Drawing.Point(3, 3);
            this.picFrsPicture.Name = "picFrsPicture";
            this.picFrsPicture.Properties.ShowCameraMenuItem = DevExpress.XtraEditors.Controls.CameraMenuItemVisibility.Auto;
            this.picFrsPicture.Properties.SizeMode = DevExpress.XtraEditors.Controls.PictureSizeMode.Zoom;
            this.pnlFrsPicture.SetRow(this.picFrsPicture, 0);
            this.picFrsPicture.Size = new System.Drawing.Size(792, 562);
            this.picFrsPicture.TabIndex = 0;
            // 
            // frmFRSImage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(798, 568);
            this.Controls.Add(this.pnlFrsPicture);
            this.Name = "frmFRSImage";
            this.Text = "사진";
            ((System.ComponentModel.ISupportInitialize)(this.pnlFrsPicture)).EndInit();
            this.pnlFrsPicture.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picFrsPicture.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.Utils.Layout.TablePanel pnlFrsPicture;
        private DevExpress.XtraEditors.PictureEdit picFrsPicture;
    }
}