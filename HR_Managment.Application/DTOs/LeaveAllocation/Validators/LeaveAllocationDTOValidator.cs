
using FluentValidation;
using HR_Managment.Application.Contracts.Persistence;

namespace HR_Managment.Application.DTOs.LeaveAllocation.Validators
{
    public class LeaveAllocationDTOValidator:AbstractValidator<ILeaveAllocationDTO>
    {
        private readonly ILeaveTypeRepository _leaveTypeRepository;

        public LeaveAllocationDTOValidator(ILeaveTypeRepository leaveTypeRepository)
        {
            _leaveTypeRepository = leaveTypeRepository;

            RuleFor(l => l.NumberOfDays).GreaterThan(0).WithMessage("{propertyName} should be grater than 0");

            RuleFor(l => l.Period)
                .GreaterThanOrEqualTo(DateTime.Now.Year).WithMessage("{propertyName} must be after {comparisonValue}");

            RuleFor(l => l.LeaveTypeId).GreaterThan(0).WithMessage("{propertyName} must be greater than 0")
              .MustAsync(async (id, token) =>
              {
                  var leaveType = await _leaveTypeRepository.Exist(id);
                  return !leaveType;
              })
              .WithMessage("{propertyName} does not exist.");
        }
    }
}
