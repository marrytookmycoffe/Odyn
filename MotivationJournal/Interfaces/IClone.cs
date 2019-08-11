using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Odyn.MotivationJournal
{
    interface IClone<T> where T : class
    {
        T Clone { get; }
    }
}