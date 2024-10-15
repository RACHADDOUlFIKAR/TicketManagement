using System.ComponentModel.DataAnnotations;

namespace ManageTickets.Models.Enums
{
    public enum Status
    {
        [Display(Name = "Open")]
        Open,

        [Display(Name = "Closed")]
        Closed,
    }
}
