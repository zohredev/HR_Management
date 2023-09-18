using HR_Managment.Application.DTOs.Common;

namespace HR_Managment.Application.DTOs.LeaveRequest
{
    public class ChangeLeaveRequestApprovalDTO:BaseDTO
    {
        public bool? IsAproved { get; set; }
    }
}
