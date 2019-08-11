using System;

namespace Odyn.MotivationJournal
{
    public interface IItemTask : ITextInformations, ITimeInformations
    {    
        double Points { get; set; }
    }

}