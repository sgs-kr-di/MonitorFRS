
namespace MonitorFRS
{
    partial class frmMain
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMain));
            this.fluentDesignFormContainer = new DevExpress.XtraBars.FluentDesignSystem.FluentDesignFormContainer();
            this.accordionControlMenu = new DevExpress.XtraBars.Navigation.AccordionControl();
            this.accordionControlElementFRS = new DevExpress.XtraBars.Navigation.AccordionControlElement();
            this.accordionControlElementFrsSearchAndInquire = new DevExpress.XtraBars.Navigation.AccordionControlElement();
            this.accordionControlElementRRS = new DevExpress.XtraBars.Navigation.AccordionControlElement();
            this.accordionControlElementRrsSearchAndInquire = new DevExpress.XtraBars.Navigation.AccordionControlElement();
            this.accordionControlElementAccount = new DevExpress.XtraBars.Navigation.AccordionControlElement();
            this.accordionControlElementAccountRegistration = new DevExpress.XtraBars.Navigation.AccordionControlElement();
            this.fluentDesignFormControl1 = new DevExpress.XtraBars.FluentDesignSystem.FluentDesignFormControl();
            this.barStaticMainNav = new DevExpress.XtraBars.BarStaticItem();
            this.barHeaderItemLogout = new DevExpress.XtraBars.BarHeaderItem();
            this.fluentFormDefaultManager1 = new DevExpress.XtraBars.FluentDesignSystem.FluentFormDefaultManager(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.accordionControlMenu)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fluentDesignFormControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fluentFormDefaultManager1)).BeginInit();
            this.SuspendLayout();
            // 
            // fluentDesignFormContainer
            // 
            this.fluentDesignFormContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.fluentDesignFormContainer.Location = new System.Drawing.Point(260, 31);
            this.fluentDesignFormContainer.Name = "fluentDesignFormContainer";
            this.fluentDesignFormContainer.Size = new System.Drawing.Size(513, 495);
            this.fluentDesignFormContainer.TabIndex = 0;
            // 
            // accordionControlMenu
            // 
            this.accordionControlMenu.Dock = System.Windows.Forms.DockStyle.Left;
            this.accordionControlMenu.Elements.AddRange(new DevExpress.XtraBars.Navigation.AccordionControlElement[] {
            this.accordionControlElementFRS,
            this.accordionControlElementRRS,
            this.accordionControlElementAccount});
            this.accordionControlMenu.Location = new System.Drawing.Point(0, 31);
            this.accordionControlMenu.Name = "accordionControlMenu";
            this.accordionControlMenu.ScrollBarMode = DevExpress.XtraBars.Navigation.ScrollBarMode.Touch;
            this.accordionControlMenu.Size = new System.Drawing.Size(260, 495);
            this.accordionControlMenu.TabIndex = 1;
            this.accordionControlMenu.ViewType = DevExpress.XtraBars.Navigation.AccordionControlViewType.HamburgerMenu;
            // 
            // accordionControlElementFRS
            // 
            this.accordionControlElementFRS.Elements.AddRange(new DevExpress.XtraBars.Navigation.AccordionControlElement[] {
            this.accordionControlElementFrsSearchAndInquire});
            this.accordionControlElementFRS.Expanded = true;
            this.accordionControlElementFRS.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("accordionControlElementFRS.ImageOptions.SvgImage")));
            this.accordionControlElementFRS.Name = "accordionControlElementFRS";
            this.accordionControlElementFRS.Text = "FRS";
            // 
            // accordionControlElementFrsSearchAndInquire
            // 
            this.accordionControlElementFrsSearchAndInquire.HeaderTemplate.AddRange(new DevExpress.XtraBars.Navigation.HeaderElementInfo[] {
            new DevExpress.XtraBars.Navigation.HeaderElementInfo(DevExpress.XtraBars.Navigation.HeaderElementType.Text),
            new DevExpress.XtraBars.Navigation.HeaderElementInfo(DevExpress.XtraBars.Navigation.HeaderElementType.Image),
            new DevExpress.XtraBars.Navigation.HeaderElementInfo(DevExpress.XtraBars.Navigation.HeaderElementType.HeaderControl),
            new DevExpress.XtraBars.Navigation.HeaderElementInfo(DevExpress.XtraBars.Navigation.HeaderElementType.ContextButtons)});
            this.accordionControlElementFrsSearchAndInquire.Name = "accordionControlElementFrsSearchAndInquire";
            this.accordionControlElementFrsSearchAndInquire.Style = DevExpress.XtraBars.Navigation.ElementStyle.Item;
            this.accordionControlElementFrsSearchAndInquire.Text = "조회 및 등록";
            this.accordionControlElementFrsSearchAndInquire.Click += new System.EventHandler(this.accordionControlElementFrsInquire_Click);
            // 
            // accordionControlElementRRS
            // 
            this.accordionControlElementRRS.Elements.AddRange(new DevExpress.XtraBars.Navigation.AccordionControlElement[] {
            this.accordionControlElementRrsSearchAndInquire});
            this.accordionControlElementRRS.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("accordionControlElementRRS.ImageOptions.SvgImage")));
            this.accordionControlElementRRS.Name = "accordionControlElementRRS";
            this.accordionControlElementRRS.Text = "RRS";
            // 
            // accordionControlElementRrsSearchAndInquire
            // 
            this.accordionControlElementRrsSearchAndInquire.HeaderTemplate.AddRange(new DevExpress.XtraBars.Navigation.HeaderElementInfo[] {
            new DevExpress.XtraBars.Navigation.HeaderElementInfo(DevExpress.XtraBars.Navigation.HeaderElementType.Text),
            new DevExpress.XtraBars.Navigation.HeaderElementInfo(DevExpress.XtraBars.Navigation.HeaderElementType.Image),
            new DevExpress.XtraBars.Navigation.HeaderElementInfo(DevExpress.XtraBars.Navigation.HeaderElementType.HeaderControl),
            new DevExpress.XtraBars.Navigation.HeaderElementInfo(DevExpress.XtraBars.Navigation.HeaderElementType.ContextButtons)});
            this.accordionControlElementRrsSearchAndInquire.Name = "accordionControlElementRrsSearchAndInquire";
            this.accordionControlElementRrsSearchAndInquire.Style = DevExpress.XtraBars.Navigation.ElementStyle.Item;
            this.accordionControlElementRrsSearchAndInquire.Text = "조회 및 생성";
            this.accordionControlElementRrsSearchAndInquire.Click += new System.EventHandler(this.accordionControlElementRrsSearchAndInquire_Click);
            // 
            // accordionControlElementAccount
            // 
            this.accordionControlElementAccount.Elements.AddRange(new DevExpress.XtraBars.Navigation.AccordionControlElement[] {
            this.accordionControlElementAccountRegistration});
            this.accordionControlElementAccount.Expanded = true;
            this.accordionControlElementAccount.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("accordionControlElementAccount.ImageOptions.SvgImage")));
            this.accordionControlElementAccount.Name = "accordionControlElementAccount";
            this.accordionControlElementAccount.Text = "Account";
            this.accordionControlElementAccount.Visible = false;
            // 
            // accordionControlElementAccountRegistration
            // 
            this.accordionControlElementAccountRegistration.Name = "accordionControlElementAccountRegistration";
            this.accordionControlElementAccountRegistration.Style = DevExpress.XtraBars.Navigation.ElementStyle.Item;
            this.accordionControlElementAccountRegistration.Text = "계정등록";
            this.accordionControlElementAccountRegistration.Click += new System.EventHandler(this.accordionControlElementAccountRegistration_Click);
            // 
            // fluentDesignFormControl1
            // 
            this.fluentDesignFormControl1.FluentDesignForm = this;
            this.fluentDesignFormControl1.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.barStaticMainNav,
            this.barHeaderItemLogout});
            this.fluentDesignFormControl1.Location = new System.Drawing.Point(0, 0);
            this.fluentDesignFormControl1.Manager = this.fluentFormDefaultManager1;
            this.fluentDesignFormControl1.Name = "fluentDesignFormControl1";
            this.fluentDesignFormControl1.Size = new System.Drawing.Size(773, 31);
            this.fluentDesignFormControl1.TabIndex = 2;
            this.fluentDesignFormControl1.TabStop = false;
            this.fluentDesignFormControl1.TitleItemLinks.Add(this.barStaticMainNav);
            this.fluentDesignFormControl1.TitleItemLinks.Add(this.barHeaderItemLogout);
            // 
            // barStaticMainNav
            // 
            this.barStaticMainNav.Caption = " ";
            this.barStaticMainNav.Id = 0;
            this.barStaticMainNav.Name = "barStaticMainNav";
            // 
            // barHeaderItemLogout
            // 
            this.barHeaderItemLogout.Caption = "로그아웃";
            this.barHeaderItemLogout.Id = 1;
            this.barHeaderItemLogout.Name = "barHeaderItemLogout";
            this.barHeaderItemLogout.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barHeaderItemLogout_ItemClick);
            // 
            // fluentFormDefaultManager1
            // 
            this.fluentFormDefaultManager1.DockingEnabled = false;
            this.fluentFormDefaultManager1.Form = this;
            this.fluentFormDefaultManager1.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.barStaticMainNav,
            this.barHeaderItemLogout});
            this.fluentFormDefaultManager1.MaxItemId = 2;
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(773, 526);
            this.ControlContainer = this.fluentDesignFormContainer;
            this.Controls.Add(this.fluentDesignFormContainer);
            this.Controls.Add(this.accordionControlMenu);
            this.Controls.Add(this.fluentDesignFormControl1);
            this.FluentDesignFormControl = this.fluentDesignFormControl1;
            this.Name = "frmMain";
            this.NavigationControl = this.accordionControlMenu;
            this.Text = "Monitor FRS";
            this.Load += new System.EventHandler(this.frmMain_Load);
            ((System.ComponentModel.ISupportInitialize)(this.accordionControlMenu)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fluentDesignFormControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fluentFormDefaultManager1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private DevExpress.XtraBars.FluentDesignSystem.FluentDesignFormContainer fluentDesignFormContainer;
        private DevExpress.XtraBars.Navigation.AccordionControl accordionControlMenu;
        private DevExpress.XtraBars.FluentDesignSystem.FluentDesignFormControl fluentDesignFormControl1;
        private DevExpress.XtraBars.Navigation.AccordionControlElement accordionControlElementFRS;
        private DevExpress.XtraBars.FluentDesignSystem.FluentFormDefaultManager fluentFormDefaultManager1;
        private DevExpress.XtraBars.Navigation.AccordionControlElement accordionControlElementFrsSearchAndInquire;
        private DevExpress.XtraBars.Navigation.AccordionControlElement accordionControlElementRRS;
        private DevExpress.XtraBars.Navigation.AccordionControlElement accordionControlElementRrsSearchAndInquire;
        private DevExpress.XtraBars.BarStaticItem barStaticMainNav;
        private DevExpress.XtraBars.Navigation.AccordionControlElement accordionControlElementAccount;
        private DevExpress.XtraBars.Navigation.AccordionControlElement accordionControlElementAccountRegistration;
        private DevExpress.XtraBars.BarHeaderItem barHeaderItemLogout;
    }
}