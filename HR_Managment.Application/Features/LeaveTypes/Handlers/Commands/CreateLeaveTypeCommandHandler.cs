using AutoMapper;
using HR_Managment.Application.Contracts.Persistence;
using HR_Managment.Application.DTOs.LeaveType.validators;
using HR_Managment.Application.Exceptions;
using HR_Managment.Application.Features.LeaveTypes.Requests.Commands;
using HR_Managment.Domain;
using MediatR;


namespace HR_Managment.Application.Features.LeaveTypes.Handlers.Commands
{
    public class CreateLeaveTypeCommandHandler : IRequestHandler<CreateLeaveTypeCommand, int>
    {
        private readonly ILeaveTypeRepository _typeRepository;
        private readonly IMapper _mapper;

        public CreateLeaveTypeCommandHandler(ILeaveTypeRepository typeRepository, IMapper mapper)
        {
            _typeRepository = typeRepository;
            _mapper = mapper;
        }
        public async Task<int> Handle(CreateLeaveTypeCommand request, CancellationToken cancellationToken)
        {
            var validator = new LeaveTypeDTOValidator();
            var result = await validator.ValidateAsync(request.LeaveTypeDTO);
            if (result.IsValid == false)
            {
                throw new ValidationException(result);
            }
            var leaveType = _mapper.Map<LeaveType>(request.LeaveTypeDTO);
            leaveType = await _typeRepository.Add(leaveType);
            return leaveType.Id;
        }
    }
}
