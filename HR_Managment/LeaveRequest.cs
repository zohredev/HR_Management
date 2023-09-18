using HR_Managment.Domain.Common;

namespace HR_Managment.Domain
{
    public class LeaveRequest: BaseDomainEntity
    {
 
        public int LeaveTypeId { get; set;}
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public LeaveType LeaveType { get; set; }
        public DateTime DateRequested { get; set; }
        public string? RequestComments { get; set; }
        public DateTime? DateActioned { get; set; }
        public bool? IsAproved { get; set; }
        public bool? IsCancelled  { get; set; }


    }
}
