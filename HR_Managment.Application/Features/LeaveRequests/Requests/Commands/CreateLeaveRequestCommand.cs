﻿using HR_Managment.Application.DTOs.LeaveRequest;
using MediatR;

namespace HR_Managment.Application.Features.LeaveRequests.Requests.Commands
{
    public class CreateLeaveRequestCommand:IRequest<int>
    {
        public CreateLeaveRequestDTO LeaveRequestDTO { get; set; }
    }
}
