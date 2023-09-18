using HR_Managment.Application.DTOs.LeaveRequest;
using HR_Managment.Domain;

namespace HR_Managment.Application.Contracts.Persistence
{
    public interface ILeaveRequestRepository : IGenericRepository<LeaveRequest>
    {
        Task<LeaveRequest> GetLeaveRequestWithDetails(int id);
        Task<List<LeaveRequest>> GetLeaveRequestsWithDetails();
        Task ChangeApprovalStatus(LeaveRequest request, bool? approvalStatus);

    }
}
