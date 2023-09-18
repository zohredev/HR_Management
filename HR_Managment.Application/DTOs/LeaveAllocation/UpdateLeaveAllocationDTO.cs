using HR_Managment.Application.DTOs.Common;

namespace HR_Managment.Application.DTOs.LeaveAllocation
{
    public class UpdateLeaveAllocationDTO : BaseDTO, ILeaveAllocationDTO
    {
        public int NumberOfDays { get; set; }
        public int LeaveTypeId { get; set; }
        public int Period { get; set; }
    }
}
