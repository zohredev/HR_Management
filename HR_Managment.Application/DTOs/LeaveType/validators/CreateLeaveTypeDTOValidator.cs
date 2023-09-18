using FluentValidation;

namespace HR_Managment.Application.DTOs.LeaveType.validators
{
    public class CreateLeaveTypeDTOValidator:AbstractValidator<CreateLeaveTypeDTO>
    {
        public CreateLeaveTypeDTOValidator()
        {
            Include(new LeaveTypeDTOValidator());
        }
    }
}
