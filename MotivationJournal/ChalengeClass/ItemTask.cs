using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Odyn.MotivationJournal
{
    class ItemTask :TextData, IItemTask, IClone<ItemTask>
    {
        DateTime start;
        DateTime end;
        double points;
        bool isTimeSensitive;

        public ItemTask()
        {
            start = DateTime.Now;
            end = start.AddHours(12);
            isTimeSensitive = false;
        }
        public ItemTask(string name) : this()
        {

        }

        
        public DateTime Start { get => start; set => start = value; }
        public DateTime End { get => end; set => end = value; }
        public double Points { get => points; set => points = value; }
        public bool IsTimeSensitive { get => isTimeSensitive; set => isTimeSensitive = value; }

        public ItemTask Clone
        {
            get
            {
                return this.MemberwiseClone() as ItemTask;
            }
        }

        public override string ToString()
        {
            if (IsTimeSensitive)
                return Name + " " + End.ToString("dd.MM");
            else
                return Name;
        }
    }
}