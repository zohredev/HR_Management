
using FluentValidation;
using HR_Managment.Application.Contracts.Persistence;

namespace HR_Managment.Application.DTOs.LeaveAllocation.Validators
{
    public class CreateLeaveAllocationDTOValidator:AbstractValidator<CreateLeaveAllocationDTO>
    {
        private readonly ILeaveTypeRepository _leaveTypeRepository;

        public CreateLeaveAllocationDTOValidator(ILeaveTypeRepository leaveTypeRepository)
        {
            _leaveTypeRepository = leaveTypeRepository;

            Include(new LeaveAllocationDTOValidator(_leaveTypeRepository));
        }
    }
}
