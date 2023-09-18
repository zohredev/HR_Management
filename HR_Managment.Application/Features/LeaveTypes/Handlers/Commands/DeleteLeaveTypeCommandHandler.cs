using AutoMapper;
using HR_Managment.Application.Contracts.Persistence;
using HR_Managment.Application.Exceptions;
using HR_Managment.Application.Features.LeaveTypes.Requests.Commands;
using HR_Managment.Domain;
using MediatR;

namespace HR_Managment.Application.Features.LeaveTypes.Handlers.Commands
{
    public class DeleteLeaveTypeCommandHandler : IRequestHandler<DeleteLeaveTypeCommand, Unit>
    {
        private readonly ILeaveTypeRepository typeRepository;
        private readonly IMapper mapper;

        public DeleteLeaveTypeCommandHandler(ILeaveTypeRepository typeRepository, IMapper mapper)
        {
            this.typeRepository = typeRepository;
            this.mapper = mapper;
        }
        public async Task<Unit> Handle(DeleteLeaveTypeCommand request, CancellationToken cancellationToken)
        {
            var leaveType = await typeRepository.Get(request.Id);
            if (leaveType == null)
            {
                throw new NotFoundException(nameof(LeaveType), request.Id);
            }
            await typeRepository.Delete(leaveType);

            return Unit.Value;
        }
    }
}
