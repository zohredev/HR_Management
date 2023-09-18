using MediatR;

namespace HR_Managment.Application.Features.LeaveRequests.Requests.Commands
{
    public class DeleteLeaveRequestCommand :IRequest<Unit>
    {
        public int Id { get; set; }
    }
}
