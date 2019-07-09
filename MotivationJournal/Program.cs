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
        }

    }


    interface IItemTask
    {

    }

    class ItemTask
    {
        string name;
        string opis;
        DateTime start;
        DateTime end;
        double points;
        bool isTimeSensitive;

        public ItemTask()
        {

            start = DateTime.Now;
            end = start.AddDays(1);
            isTimeSensitive = false;
        }

        public string Name { get => name; set => name = value; }
        public string Opis { get => opis; set => opis = value; }
        public DateTime Start { get => start; set => start = value; }
        public DateTime End { get => end; set => end = value; }
        public double Points { get => points; set => points = value; }
        public bool IsTimeSensitive1 { get => isTimeSensitive; set => isTimeSensitive = value; }
    }
}

