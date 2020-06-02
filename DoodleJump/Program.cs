using DoodleJumpEngine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DoodleJump
{
    static class Program
    {
        public static AppSettings appSettings;
        public static Form MainForm = new Form_Main();
        


        
        [STAThread]
        static void Main()
        {
            Init();
            Application.EnableVisualStyles();
            //Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(MainForm);
        }


        static void Init()
        {
            appSettings = new AppSettings();
            appSettings.Load();
            appSettings.Save();
        }
    }
}