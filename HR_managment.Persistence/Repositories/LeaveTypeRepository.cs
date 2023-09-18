using HR_Managment.Application.Contracts.Persistence;
using HR_Managment.Domain;

namespace HR_managment.Persistence.Repositories
{
    public class LeaveTypeRepository : GenericRepository<LeaveType>, ILeaveTypeRepository
    {
        private readonly LeaveManagmentDBContext _dBContext;

        public LeaveTypeRepository(LeaveManagmentDBContext dBContext) : base(dBContext)
        {
            _dBContext = dBContext;
        }

    }
}
