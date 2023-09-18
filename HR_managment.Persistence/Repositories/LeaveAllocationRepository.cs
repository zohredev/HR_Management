using HR_Managment.Application.Contracts.Persistence;
using HR_Managment.Domain;
using Microsoft.EntityFrameworkCore;

namespace HR_managment.Persistence.Repositories
{
    public class LeaveAllocationRepository : GenericRepository<LeaveAllocation>, ILeaveAllocationRepository
    {
        private readonly LeaveManagmentDBContext _dBContext;

        public LeaveAllocationRepository(LeaveManagmentDBContext dBContext) : base(dBContext)
        {
            _dBContext = dBContext;
        }

        public async Task<List<LeaveAllocation>> GetLeaveAllocationsWithDetails()
        {
           return await _dBContext.LeaveAllocations.Include(l=>l.LeaveType)
                .ToListAsync();
        }

        public async Task<LeaveAllocation> GetLeaveAllocationWithDetails(int id)
        {
            return await _dBContext.LeaveAllocations.Include(l => l.LeaveType)
               .FirstOrDefaultAsync(l => l.Id == id);
        }
    }
}
