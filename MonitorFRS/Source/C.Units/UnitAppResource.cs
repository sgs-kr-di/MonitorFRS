using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ulee.Utils;
using System.Data;

namespace MonitorFRS.Source.C.Units
{
    class UnitAppResource
    {
    }

    public static class AppRes
    {
        public static bool Busy { get; set; }
        public static string UserId { get; set; }
        public static UlIniFile Ini { get; private set; }
        public static UlLogger TotalLog { get; private set; }
        public static UlLogger DbLog { get; private set; }
        public static AppDatabase DB { get; private set; }

        private static UlStringCrypto crypto;

        public const string csDateFormat = "yyyy-MM-dd";

        public const string csDateTimeFormat = "yyyy-MM-dd HH:mm:ss.fff";

        public const string csDateTimeFormatSec = "yyyy-MM-dd HH:mm:ss";

        //private const string csIniFName = @"C:\\Users\\hiel_kim\\OneDrive - SGS\\Documents\\All\\C#\\Seoul\\Quality\\PQMS\\Config\\Sgs.PQMS.ini";

        public static void Create()
        {
            Busy = false;
            crypto = new UlStringCrypto("!rpting@");
            //Ini = new UlIniFile(csIniFName);

            //DbLog = new UlLogger();
            //DbLog.Path = Path.GetFullPath(Ini.GetString("Log", "DatabasePath"));
            //DbLog.FName = Ini.GetString("Log", "DatabaseFileName");

            //DB = new AppDatabase(crypto.Decrypt(Ini.GetString("Database", "ConnectString")));            

            // Connect DB Information
            // Data Source=KRSEC001;Initial Catalog=PQMS;User ID=pqms;Password=PQMS;Connection Timeout=600;

            // crypto 암호화
            //DB = new AppDatabase(crypto.Decrypt("qpFvq8W8GPfrD6pa6zQbtN//IVovZDerNB8Wu/yHIvVYEbDs11hmUExpgJgHqM2OUlBgqc5bv7h8ZkCa7rtpJwtCEdn2xsmSmToY0tmfBaUodQ8xKQDneCDt/JKQkftH"));

            // crypto 암호화
            DB = new AppDatabase(crypto.Decrypt("qpFvq8W8GPf2CGpTBxKQPeXTJnoDISz0usR+blG54T+EOcAXDOGLQyLIHNXjwLOHo5oXpivi3t1j3PkYk61YbPQCJq4Zrt2Z20B7oQGUNJGj+njsOY9E6FbbJ/HoOFg3z02FwsxaYstbWdQr/gFkxkzbfqBSqank"));

            DB.Open();
        }

        public static void Destroy()
        {
            if (DB.Connect.State == ConnectionState.Open)
            {
                DB.Close();
            }
        }
    }
}
