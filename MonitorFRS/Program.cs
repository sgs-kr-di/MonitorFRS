using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using MonitorFRS.Source.C.Units;
using MonitorFRS.Source.A.Forms.Metro.A.Main;

namespace MonitorFRS
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            bool isAlone;

            Spire.License.LicenseProvider.SetLicenseKey("PW4WWCj+ipgnqwEAlrladT+/jX7BO2oNVDv96mtEPFp8atF08FMpEwgPDZz3OOOErT1sPsmf4x9zyQ/KYFUx4xzRr5wctqPhvLwyvlODVvI/fr5JVLrxC8WAhqRDXuJHLMvvKGdvrSQoV1EwtSvH0fDKEmH9a+fZaaf9XZrqgO5BLhjy1JMSiv3Y3nxyeBMemSI+7EBTA1K/fnMmgeIZNpgzCgMngVQdA/o3MeKhqkw3oFQNTHZrnGKtAa8lV+sATt6t9jOw2elcA2j427SrljrGDx9GaWG6iXUScJShcM0zJi1aBtfjnTQmwOfAM4jit9iLT7SPqE/i6eSLpSye+SjdnHseUVlERNyx8Zv5VwinB/R5PzImg12vuk1m2wqOJEircPqOtjOd5LkCBCojTiXDBHG3RvZ5YiLUCq2n0wbzrOOeWCqnlECbSDUkY2ApLlUT952OD8a7VQ1bSeGxTe0+OCxyiZnf2u+oPTjli8hIS62I78lj/1++8I6gwO9E0lIC2IxemfLAwP1HJ8a9cE+ucthWini2d039dcwsT2Av7zVmC+xjGFWJ5bxW1tx8rwL3wnZIP38Jm4RCcj0WdlcsbA23VnHsMOiLVDabIedWeHdXWL6rK3dF0O/b3E2Dlg4PjsrRTVYZDiTiVDDGohC+F1zyOrMYuW9VTT3IwqsfFwnU3NfkXTIeDEjfcdVgCS9L3ycae3CFk3iAPik3xU4SMpa+GJ3xuWth3I7LYeLU4hQCQ7QsDtbQOWRcivoKxwplNII4v+jQZSbCFJDzAFMvn82s7S6H82WhBYPMzYxC61DKGBmBpLROHAys50PgWrymYezNDVk+/bjdALcvO72Y/QgIKr1wqnqhfkQ8oXJxKnIl+44P3YQzz+HNuJjUTDFDWYf4SbPEZfc+yB/gZ/ZgXy0xrgmw+w0/vSmcVbKEapcEqinWdYeJRkSXXzhAjBqJyYK5bzd3AAjV5TWWUQy+rgJ8vJ5ylE1NxW0Xp+ojy6O6W4dzNiuidwMKieaG//rxya+rjGpNqLuf6G4vbJ4cgakZV5f3LzpM1/ySLRW9vjF4QelxHoVYnfCOeJuf7SiCtZ0OlZRjja8PaNkWOxJkFtMTjjWDMH7vgDRf3rRU3jfH1xcKnChc0yLAdx+DXRjlZyoVf+V9HWgimd31ET4zgfzQVbtk3J6vvXyidIo4pnhR/UYNih8ijGs9ajEexDtFpSzaWsgpkN72az2fm4nfWFN04y5/UAhhXmjCtiKHUlX5C5vQGIL6p76zt0zljRtsqy9+xjUPEx/FWfKWtNnCkMfWUVuxs/nyxl313JPew3KVVw1YqEPH+Cx3BjU36QIL4jUdEUckNgRgUqYI8f2uHONvlKzAld0vUqXTtfwxvZOC8FGWo383vX3JSEdBYenqZKW6Ov+VdIsmvdnPf8nphWR09SF/g64gddoDj2RFT1QAPlomdWTfVjtd1PA2YDqe9GrS//c=");

            Mutex mutex = new Mutex(true, @"Global\Sgs.ReportIntegration", out isAlone);

            if (isAlone == true)
            {
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);

                try
                {
                    // DB Connect
                    AppRes.Create();
                    //Application.Run(new MainForm());
                    Application.Run(new frmMain());
                }
                catch (Exception e)
                {
                    MessageBox.Show(e.ToString());
                }
                finally
                {
                    AppRes.Destroy();
                    mutex.ReleaseMutex();
                }
            }
            else
            {
                MessageBox.Show(
                    "Cannot run this program because of running it already!",
                    "PQMS", MessageBoxButtons.OK, MessageBoxIcon.Stop);

                Application.Exit();
            }

            //Application.EnableVisualStyles();
            //Application.SetCompatibleTextRenderingDefault(false);
            //Application.Run(new frmMain());
        }
    }
}
