
namespace NsIcon
{
    using System;
    using System.Windows.Forms;

    class Program
    {
        /// <summary>
        /// Reference to TrayIcon object.
        /// Only allow one instance.
        /// </summary>
        private static TrayIcon trayicon;

        /// <summary>
        /// Reference to FrmBloodsugar winform object.
        /// Only allow one instance.
        /// </summary>
        private static FrmBloodglucose frmbloodglucose;

        /// <summary>
        /// Reference to FrmSettings winform object.
        /// Only allow one instance.
        /// </summary>
        public static FrmSettings frmSettings;

        /// <summary>
        /// Reference to ConsoleBloodglucose object.
        /// </summary>
        //private static ConsoleBloodglucose conbloodglucose;

        /// <summary>
        /// Reference to GlucoseService.
        /// </summary>
        public static GlucoseService glucoseService;

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main(string[] arguments)
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(true);
            glucoseService = new GlucoseService();
            if (arguments.Length > 0)
            {
                foreach (string argument in arguments)
                {
                    switch (argument)
                    {
                        case "-w":
                        case "--window":
                            frmbloodglucose = new FrmBloodglucose();
                            frmbloodglucose.Show();
                            break;
                        case "-c":
                        case "--console":
                            //conbloodglucose = new ConsoleBloodglucose();
                            break;
                        case "-h":
                        case "--help":
                            Console.WriteLine("Command line arguments.");
                            Console.WriteLine("-h --help    Display all possible commandline options.");
                            Console.WriteLine("-w --window  Display window with current blood glucose value from nightscout.");
                            //Console.WriteLine("-c --console Print current blood glucose value and alarms from nightscout on console.");
                            break;
                    }
                }
            }

            trayicon = new TrayIcon();
            System.Windows.Forms.Application.Run();
        }
    }
}
