using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Odyn.MotivationJournal
{
public class TextData
    {
        protected TextData()
        {

        }
        protected string name;
        protected string opis;

        public string Name { get => name; set => name = value; }
        public string Description { get => opis; set => opis = value; }
    }
}