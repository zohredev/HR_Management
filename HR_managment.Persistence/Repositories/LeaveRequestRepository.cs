using HR_Managment.Application.Contracts.Persistence;
using HR_Managment.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR_managment.Persistence.Repositories
{
    public class LeaveRequestRepository : GenericRepository<LeaveRequest>, ILeaveRequestRepository
    {
        private readonly LeaveManagmentDBContext _dBContext;

        public LeaveRequestRepository(LeaveManagmentDBContext dBContext) : base(dBContext)
        {
            _dBContext = dBContext;
        }

        public async Task ChangeApprovalStatus(LeaveRequest request, bool? approvalStatus)
        {
            request.IsAproved = approvalStatus;
            _dBContext.Entry(request).State=EntityState.Modified;
            await _dBContext.SaveChangesAsync();
        }

        public async Task<List<LeaveRequest>> GetLeaveRequestsWithDetails()
        {
             var leaveRequests= await _dBContext.LeaveRequests.Include(l=>l.LeaveType)
                .ToListAsync();
            return leaveRequests;
        }

        public async Task<LeaveRequest> GetLeaveRequestWithDetails(int id)
        {
            var leaveRequest = await _dBContext.LeaveRequests.Include(l => l.LeaveType)
                .FirstOrDefaultAsync(l => l.Id == id);
            return leaveRequest;
        }
    }
}
