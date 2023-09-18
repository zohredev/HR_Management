using HR_Managment.Application.DTOs.Common;
using HR_Managment.Application.DTOs.LeaveType;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR_Managment.Application.DTOs.LeaveAllocation
{
    public class CreateLeaveAllocationDTO:BaseDTO,ILeaveAllocationDTO
    {
        public int NumberOfDays { get; set; } 
        public int LeaveTypeId { get; set; }
        public int Period { get; set; }
    }
}
