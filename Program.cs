using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp2
{
    // Define an internal static class named Program within the WindowsFormsApp2 namespace
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        // Main method, the entry point of the application
        static void Main()
        {
            // Enable visual styles for the application
            Application.EnableVisualStyles();
            // Set the default text rendering to be compatible with the application
            Application.SetCompatibleTextRenderingDefault(false);
            // Run the application by creating and displaying an instance of Form1
            Application.Run(new Form1());
        }
    }
}

