using FluentValidation;
using HR_Managment.Application.Contracts.Persistence;

namespace HR_Managment.Application.DTOs.LeaveAllocation.Validators
{
    public class UpdateLeaveAllocationDTOValidator:AbstractValidator<UpdateLeaveAllocationDTO>
    {
        private readonly ILeaveTypeRepository _leaveTypeRepository;

        public UpdateLeaveAllocationDTOValidator(ILeaveTypeRepository leaveTypeRepository)
        {
            _leaveTypeRepository = leaveTypeRepository;

            Include(new LeaveAllocationDTOValidator(_leaveTypeRepository));

            RuleFor(l => l.Id).NotEmpty().WithMessage("LeaveType cannot be null or empty");
        }
    }
}
