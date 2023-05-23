// <copyright file="Program.cs" company="Jillian Plahn 11713440">
// Copyright (c) Jillian Plahn. All rights reserved.
// </copyright>

using System;
using System.Windows.Forms;

namespace HW3
{
    /// <summary>
    /// Program class where application will begin to run from.
    /// </summary>
    static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }
    }
}
