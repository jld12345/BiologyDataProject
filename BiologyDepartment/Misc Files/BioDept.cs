﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data;
using System.Threading;
using cef;
using CefSharp;
using BiologyDepartment.Login;

namespace BiologyDepartment
{
    class BioDept
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        /// 
        [STAThread]
        static void Main()
        {
            try
            {
                MessageBox.Show("Step1", "Step1", MessageBoxButtons.OK);
                Application.EnableVisualStyles();
                MessageBox.Show("Step2", "Step1", MessageBoxButtons.OK);
                Application.SetCompatibleTextRenderingDefault(false);
                MessageBox.Show("Step3", "Step1", MessageBoxButtons.OK);
                // Add the event handler for handling UI thread exceptions to the event.
                //Application.ThreadException += new ThreadExceptionEventHandler(MainForm.Form1_UIThreadException);

                // Set the unhandled exception mode to force all Windows Forms errors to go through 
                // our handler.
                MessageBox.Show("Step4", "Step1", MessageBoxButtons.OK);
                Application.SetUnhandledExceptionMode(UnhandledExceptionMode.CatchException);
                MessageBox.Show("Step5", "Step1", MessageBoxButtons.OK);
                // Add the event handler for handling non-UI thread exceptions to the event. 
                AppDomain.CurrentDomain.UnhandledException +=
                        new UnhandledExceptionEventHandler(CurrentDomain_UnhandledException);
                MessageBox.Show("Step6", "Step1", MessageBoxButtons.OK);
                Cef.Initialize();
                MessageBox.Show("Step7", "Step1", MessageBoxButtons.OK);
                Application.Run(new MainForm());
            }
            catch(Exception e)
            {
                MessageBox.Show(e.Message, "Step1", MessageBoxButtons.OK);
            }

        }

        // Handle the UI exceptions by showing a dialog box, and asking the user whether 
        // or not they wish to abort execution. 
        private static void Form1_UIThreadException(object sender, ThreadExceptionEventArgs t)
        {
            DialogResult result = DialogResult.Cancel;
            try
            {
                result = ShowThreadExceptionDialog("Windows Forms Error", t.Exception);
            }
            catch
            {
                try
                {
                    MessageBox.Show("Fatal Windows Forms Error",
                        "Fatal Windows Forms Error", MessageBoxButtons.AbortRetryIgnore, MessageBoxIcon.Stop);
                }
                finally
                {
                    Application.Exit();
                }
            }

            // Exits the program when the user clicks Abort. 
            if (result == DialogResult.Abort)
                Application.Exit();
        }

        // Handle the UI exceptions by showing a dialog box, and asking the user whether 
        // or not they wish to abort execution. 
        // NOTE: This exception cannot be kept from terminating the application - it can only  
        // log the event, and inform the user about it.  
        private static void CurrentDomain_UnhandledException(object sender, UnhandledExceptionEventArgs e)
        {
            try
            {
                Exception ex = (Exception)e.ExceptionObject;
                /*string errorMsg = "An application error occurred. Please contact the adminstrator " +
                    "with the following information:\n\n";

                /*Since we can't prevent the app from terminating, log this to the event log. 
                if (!EventLog.SourceExists("ThreadException"))
                {
                    EventLog.CreateEventSource("ThreadException", "Application");
                }

                // Create an EventLog instance and assign its source.
                EventLog myLog = new EventLog();*
                myLog.Source = "ThreadException";
                myLog.WriteEntry(errorMsg + ex.Message + "\n\nStack Trace:\n" + ex.StackTrace);*/
            }
            catch (Exception exc)
            {
                try
                {
                    MessageBox.Show("Fatal Non-UI Error",
                        "Fatal Non-UI Error. Could not write the error to the event log. Reason: "
                        + exc.Message, MessageBoxButtons.OK, MessageBoxIcon.Stop);
                }
                finally
                {
                    Application.Exit();
                }
            }
        }

        // Creates the error message and displays it. 
        private static DialogResult ShowThreadExceptionDialog(string title, Exception e)
        {
            string errorMsg = "An application error occurred. Please contact the adminstrator " +
                "with the following information:\n\n";
            errorMsg = errorMsg + e.Message + "\n\nStack Trace:\n" + e.StackTrace;
            return MessageBox.Show(errorMsg, title, MessageBoxButtons.AbortRetryIgnore,
                MessageBoxIcon.Stop);
        }
    }
}
