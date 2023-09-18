using HR_Managment.Application.DTOs.LeaveAllocation;
using HR_Managment.Domain;

namespace HR_Managment.Application.Contracts.Persistence
{
    public interface ILeaveAllocationRepository : IGenericRepository<LeaveAllocation>
    {
        Task<List<LeaveAllocation>> GetLeaveAllocationsWithDetails();
        Task<LeaveAllocation> GetLeaveAllocationWithDetails(int id);
    }
}
