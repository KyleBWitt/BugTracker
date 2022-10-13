using System;

namespace BugTracker.Interfaces
{
    public interface IBoardItemModel
    {
        int BugID { get; set; }
        string BugStatus { get; set; }
        string BugDescription { get; set; }
        DateTime CreatedOn { get; set; }
        string CreatedBy { get; set; }
    }
}
