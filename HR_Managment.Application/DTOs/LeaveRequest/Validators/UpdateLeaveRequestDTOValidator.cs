
using FluentValidation;
using HR_Managment.Application.Contracts.Persistence;

namespace HR_Managment.Application.DTOs.LeaveRequest.Validators
{
    public class UpdateLeaveRequestDTOValidator : AbstractValidator<UpdateLeaveRequestDTO>
    {
        private readonly ILeaveTypeRepository _leaveTypeRepository;

        public UpdateLeaveRequestDTOValidator(ILeaveTypeRepository leaveTypeRepository)
        {
            _leaveTypeRepository = leaveTypeRepository;
            Include(new LeaveRequestDTOValidator(_leaveTypeRepository));

            RuleFor(l => l.Id).NotEmpty().WithMessage("LeaveType cannot be null or empty");
        }
    }
}
