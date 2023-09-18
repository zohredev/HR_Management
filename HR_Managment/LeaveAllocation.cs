﻿using HR_Managment.Domain.Common;

namespace HR_Managment.Domain
{
    public class LeaveAllocation:BaseDomainEntity
    {
        public int NumberOfDays { get; set; }
        public LeaveType LeaveType { get; set; }
        public int LeaveTypeId { get; set; }
        private int Period { get; set; }
    }
}
