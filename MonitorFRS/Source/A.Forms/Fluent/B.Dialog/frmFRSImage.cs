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

namespace MonitorFRS.Source.A.Forms.Fluent.B.Dialog
{
    public partial class frmFRSImage : DevExpress.XtraEditors.XtraForm
    {
        public frmFRSImage()
        {
            InitializeComponent();
        }

        public Bitmap ImageBox
        {
            set { picFrsPicture.Image = value; }
        }
    }
}