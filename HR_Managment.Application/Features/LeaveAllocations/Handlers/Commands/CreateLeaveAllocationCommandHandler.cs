using AutoMapper;
using HR_Managment.Application.Contracts.Persistence;
using HR_Managment.Application.DTOs.LeaveAllocation.Validators;
using HR_Managment.Application.DTOs.LeaveRequest.Validators;
using HR_Managment.Application.Exceptions;
using HR_Managment.Application.Features.LeaveAllocations.Requests.Commands;
using HR_Managment.Domain;
using MediatR;

namespace HR_Managment.Application.Features.LeaveAllocations.Handlers.Commands
{
    public class CreateLeaveAllocationCommandHandler : IRequestHandler<CreateLeaveAllocationCommand, int>
    {
        private readonly ILeaveAllocationRepository allocationRepository;
        private readonly IMapper mapper;
        private readonly ILeaveTypeRepository _leaveTypeRepository;

        public CreateLeaveAllocationCommandHandler(ILeaveAllocationRepository allocationRepository, IMapper mapper,ILeaveTypeRepository leaveTypeRepository)
        {
            this.allocationRepository = allocationRepository;
            this.mapper = mapper;
            _leaveTypeRepository = leaveTypeRepository;
        }

        public async Task<int> Handle(CreateLeaveAllocationCommand request, CancellationToken cancellationToken)
        {
            var validator = new CreateLeaveAllocationDTOValidator(_leaveTypeRepository);
            var result = await validator.ValidateAsync(request.LeaveAllocationDTO);
            if (result.IsValid == false)
            {
                throw new ValidationException(result);
            }
            var leaveAllocation = mapper.Map<LeaveAllocation>(request.LeaveAllocationDTO);
            leaveAllocation = await allocationRepository.Add(leaveAllocation);
            return leaveAllocation.Id;
        }
    }
}
