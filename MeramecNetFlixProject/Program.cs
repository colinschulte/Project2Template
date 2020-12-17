using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using MeramecNetFlixProject.UI;

namespace MeramecNetFlixProject
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            //Application.Run(new RentalSearchForm(1));
            //Application.Run(new RentalDetailsForm(1, 1));
            //Application.Run(new SplashForm());
            Application.Run(new MovieForm());
        }
    }
}
