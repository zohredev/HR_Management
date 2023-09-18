using AutoMapper;
using HR_Managment.Application.Contracts.Persistence;
using HR_Managment.Application.DTOs.LeaveAllocation.Validators;
using HR_Managment.Application.Exceptions;
using HR_Managment.Application.Features.LeaveAllocations.Requests.Commands;
using MediatR;

namespace HR_Managment.Application.Features.LeaveAllocations.Handlers.Commands
{
    public class UpdateLeaveAllocationCommandHandler : IRequestHandler<UpdateLeaveAllocationCommand, Unit>
    {
        private readonly ILeaveAllocationRepository allocationRepository;
        private readonly IMapper mapper;
        private readonly ILeaveTypeRepository _leaveTypeRepository;

        public UpdateLeaveAllocationCommandHandler(ILeaveAllocationRepository allocationRepository, IMapper mapper,ILeaveTypeRepository leaveTypeRepository)
        {
            this.allocationRepository = allocationRepository;
            this.mapper = mapper;
            _leaveTypeRepository = leaveTypeRepository;
        }

        public async Task<Unit> Handle(UpdateLeaveAllocationCommand request, CancellationToken cancellationToken)
        {
            var validator = new UpdateLeaveAllocationDTOValidator(_leaveTypeRepository);
            var result = await validator.ValidateAsync(request.LeaveAllocationDTO);
            if (result.IsValid == false)
            {
                throw new ValidationException(result);
            }
            var leaveAllocation = await allocationRepository.Get(request.LeaveAllocationDTO.Id);
            mapper.Map(request.LeaveAllocationDTO, leaveAllocation);
            await allocationRepository.Update(leaveAllocation);

            return Unit.Value;
        }
    }
}
