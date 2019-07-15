using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Odyn.MotivationJournal
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

            ItemTask task = new ItemTask()
            {
                Name = "Forest"
            };

            var t2 = task.Clone;
            task.Name = "lanca2";

            Console.WriteLine("hey");
            Console.ReadLine();

        }
    }
}

