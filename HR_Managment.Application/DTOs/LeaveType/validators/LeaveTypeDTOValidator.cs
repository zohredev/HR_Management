
using FluentValidation;

namespace HR_Managment.Application.DTOs.LeaveType.validators
{
    public class LeaveTypeDTOValidator:AbstractValidator<ILeaveTypeDTO>
    {
        public LeaveTypeDTOValidator()
        {
            RuleFor(o => o.Name).NotEmpty().WithMessage("{propertyName} is required.")
                .MaximumLength(100).WithMessage("{propertyName} should be at least 100 character.")
                ;
            RuleFor(o => o.DefaultDay).NotEmpty().WithMessage("{propertyName} is required.")
                .GreaterThan(0).WithMessage("{propertyName} should be grater than 0")
                .LessThan(100).WithMessage("{propertyName} should be less than 100.");
        }
    }
}
