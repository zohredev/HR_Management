
using FluentValidation;
using HR_Managment.Application.Contracts.Persistence;

namespace HR_Managment.Application.DTOs.LeaveRequest.Validators
{
    public class LeaveRequestDTOValidator:AbstractValidator<ILeaveRequestDTO>
    {
        private readonly ILeaveTypeRepository leaveTypeRepository;

        public LeaveRequestDTOValidator(ILeaveTypeRepository leaveTypeRepository)
        {
            this.leaveTypeRepository = leaveTypeRepository;


            RuleFor(o => o.StartDate).LessThan(o => o.EndDate).WithMessage("{propertyName} must be before {comparisonValue}");

            RuleFor(l => l.EndDate).GreaterThan(l => l.StartDate).WithMessage("{propertyName} must be after {comparisonValue}");

            RuleFor(l => l.LeaveTypeId).GreaterThan(0).WithMessage("{propertyName} must be greater than 0")
                .MustAsync(async (id, token) =>
                {
                    var leaveType = await this.leaveTypeRepository.Exist(id);
                    return !leaveType;
                })
                .WithMessage("{propertyName} does not exist.");
        }   
    }
}
