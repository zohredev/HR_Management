
using HR_Managment.Application.DTOs.Common;

namespace HR_Managment.Application.DTOs.LeaveType
{
    public class CreateLeaveTypeDTO:BaseDTO, ILeaveTypeDTO
    {
        public string Name { get; set; }
        public int DefaultDay { get; set; }

    }
}
