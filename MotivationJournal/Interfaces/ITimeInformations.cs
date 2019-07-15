using System;

namespace Odyn.MotivationJournal
{
interface ITimeInformations
    {
        bool IsTimeSensitive { get; set; }
        DateTime Start { get; set; }
        DateTime End { get; set; }
    }
}