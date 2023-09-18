using HR_Managment.Application.DTOs.Common;
using HR_Managment.Application.DTOs.LeaveType;

namespace HR_Managment.Application.DTOs.LeaveRequest
{
    public class LeaveRequestDTO : BaseDTO
    {

        public int LeaveTypeId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public LeaveTypeDTO LeaveType { get; set; }
        public DateTime DateRequested { get; set; }
        public string RequestComments { get; set; }
        public DateTime? DateActioned { get; set; }
        public bool? IsAproved { get; set; }
        public bool? IsCancelled { get; set; }


    }
}
