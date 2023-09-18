using AutoMapper;
using HR_Managment.Application.Contracts.Persistence;
using HR_Managment.Application.Exceptions;
using HR_Managment.Application.Features.LeaveRequests.Requests.Commands;
using MediatR;

namespace HR_Managment.Application.Features.LeaveRequests.Handlers.Commands
{
    public class DeleteLeaveRequestCommandHandler : IRequestHandler<DeleteLeaveRequestCommand, Unit>
    {
        private readonly ILeaveRequestRepository requestRepository;
        private readonly IMapper mapper;

        public DeleteLeaveRequestCommandHandler(ILeaveRequestRepository requestRepository,IMapper mapper)
        {
            this.requestRepository = requestRepository;
            this.mapper = mapper;
        }
        public async Task<Unit> Handle(DeleteLeaveRequestCommand request, CancellationToken cancellationToken)
        {
            var leaveRequest = await requestRepository.Get(request.Id);
            if (leaveRequest == null)
            {
                throw new NotFoundException(nameof(LeaveRequest),request.Id); 
            }  
            await requestRepository.Delete(leaveRequest);
            

            return Unit.Value;
        }
    }
}
