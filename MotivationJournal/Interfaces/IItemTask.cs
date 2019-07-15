using System;

namespace Odyn.MotivationJournal
{
    interface IItemTask : ITextInformations, ITimeInformations
    {    
        double Points { get; set; }
    }

}