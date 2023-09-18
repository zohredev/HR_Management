using HR_Managment.Application.DTOs.Common;
using HR_Managment.Application.DTOs.LeaveType;

namespace HR_Managment.Application.DTOs.LeaveAllocation
{
    public class LeaveAllocationDTO : BaseDTO
    {
        public int NumberOfDays { get; set; }
        public LeaveTypeDTO LeaveType { get; set; }
        public int LeaveTypeId { get; set; }
        public int Period { get; set; }
    }
}
