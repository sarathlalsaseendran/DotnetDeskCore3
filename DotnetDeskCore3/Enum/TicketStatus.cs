using System.ComponentModel.DataAnnotations;

namespace DotnetDeskCore3.Enum
{
    public enum TicketStatus
    {
        Unassigned = 1,
        Open = 2,
        [Display(Name = "On Hold")]
        OnHold = 3,
        Escalated = 4,
        Closed = 5
    }
}
