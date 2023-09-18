using HR_Managment.Application.DTOs.Common;
using HR_Managment.Application.DTOs.LeaveType;

namespace HR_Managment.Application.DTOs.LeaveRequest
{
    public class LeaveRequestListDTO : BaseDTO
    {

        public LeaveTypeDTO LeaveType { get; set; }
        public DateTime DateRequested { get; set; } 
        public bool? IsAproved { get; set; } 


    }
}
