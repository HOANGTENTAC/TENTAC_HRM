﻿using System;
using System.Windows.Forms;
using TENTAC_HRM.Forms.Main;

namespace TENTAC_HRM
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            //Application.Run(new frm_tuychon());
            Application.Run(new frm_login());
            //Application.Run(new Main.frm_main());
        }
    }
}
