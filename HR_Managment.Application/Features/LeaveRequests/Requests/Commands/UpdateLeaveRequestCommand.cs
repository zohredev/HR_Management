using HR_Managment.Application.DTOs.LeaveRequest;
using MediatR;

namespace HR_Managment.Application.Features.LeaveRequests.Requests.Commands
{
    public class UpdateLeaveRequestCommand:IRequest<Unit>
    {
        public int Id { get; set; }
        public UpdateLeaveRequestDTO LeaveRequestDTO { get; set; }

        public ChangeLeaveRequestApprovalDTO ChangeLeaveRequestApprovalDTO { get; set; }
    }
}
