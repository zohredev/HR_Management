using AutoMapper;
using HR_Managment.Application.Contracts.Persistence;
using HR_Managment.Application.DTOs.LeaveAllocation.Validators;
using HR_Managment.Application.DTOs.LeaveRequest.Validators;
using HR_Managment.Application.Exceptions;
using HR_Managment.Application.Features.LeaveRequests.Requests.Commands;
using MediatR;

namespace HR_Managment.Application.Features.LeaveRequests.Handlers.Commands
{
    public class UpdateLeaveRequestCommandHandler : IRequestHandler<UpdateLeaveRequestCommand, Unit>
    {
        private readonly ILeaveRequestRepository requestRepository;
        private readonly IMapper mapper;
        private readonly ILeaveTypeRepository _leaveTypeRepository;

        public UpdateLeaveRequestCommandHandler(ILeaveRequestRepository requestRepository, IMapper mapper
            ,ILeaveTypeRepository leaveTypeRepository)
        {
            this.requestRepository = requestRepository;
            this.mapper = mapper;
            _leaveTypeRepository = leaveTypeRepository;
        }
        public async Task<Unit> Handle(UpdateLeaveRequestCommand request, CancellationToken cancellationToken)
        {
            var validator = new UpdateLeaveRequestDTOValidator(_leaveTypeRepository);
            var result = await validator.ValidateAsync(request.LeaveRequestDTO);
            if (result.IsValid == false)
            {
                throw new ValidationException(result);
            }
            var leaveRequest = await requestRepository.Get(request.Id);
            if (request.LeaveRequestDTO != null)
            {

                mapper.Map(request.LeaveRequestDTO, leaveRequest);
                await requestRepository.Update(leaveRequest);
            }
            else if (request.ChangeLeaveRequestApprovalDTO != null)
            {
                 
                await requestRepository.ChangeApprovalStatus(leaveRequest,request.ChangeLeaveRequestApprovalDTO.IsAproved);
            }

            return Unit.Value;
        }
    }
}
