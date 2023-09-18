using AutoMapper;
using HR_Managment.Application.Contracts.Persistence;
using HR_Managment.Application.Exceptions;
using HR_Managment.Application.Features.LeaveAllocations.Requests.Commands;
using HR_Managment.Domain;
using MediatR;

namespace HR_Managment.Application.Features.LeaveAllocations.Handlers.Commands
{
    public class DeleteLeaveAllocationCommandHandler : IRequestHandler<DeleteLeaveAllocationCommand, Unit>
    {
        private readonly ILeaveAllocationRepository allocationRepository;
        private readonly IMapper mapper;

        public DeleteLeaveAllocationCommandHandler(ILeaveAllocationRepository allocationRepository,IMapper mapper)
        {
            this.allocationRepository = allocationRepository;
            this.mapper = mapper;
        }
        public async Task<Unit> Handle(DeleteLeaveAllocationCommand request, CancellationToken cancellationToken)
        {
            var allocation = await allocationRepository.Get(request.Id);
            if (allocation == null)
            {
                throw new NotFoundException(nameof(LeaveAllocation), request.Id);
            }
            await allocationRepository.Delete(allocation);
            return Unit.Value;
        }
    }
}
