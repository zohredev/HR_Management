using HR_Managment.Application.DTOs.LeaveRequest;
 using MediatR;

namespace HR_Managment.Application.Features.LeaveRequests.Requests.Queries
{
    public class GetLeaveRequestListRequest : IRequest<List<LeaveRequestListDTO>>
    {
    }
}
