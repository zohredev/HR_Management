using AutoMapper;
using HR_Managment.Application.Contracts.Infrastructure;
using HR_Managment.Application.Contracts.Persistence;
using HR_Managment.Application.DTOs.LeaveRequest.Validators;
using HR_Managment.Application.Exceptions;
using HR_Managment.Application.Features.LeaveRequests.Requests.Commands;
using HR_Managment.Application.Models;
using MediatR;

namespace HR_Managment.Application.Features.LeaveRequests.Handlers.Commands
{
    public class CreateLeaveRequestCommandHandler : IRequestHandler<CreateLeaveRequestCommand, int>
    {
        private readonly ILeaveRequestRepository _requestRepository;
        private readonly IMapper _mapper;
        private readonly ILeaveTypeRepository _leaveTypeRepository;
        private readonly IEmailSender _emailSender;

        public CreateLeaveRequestCommandHandler(ILeaveRequestRepository requestRepository, IMapper mapper
            ,ILeaveTypeRepository leaveTypeRepository,IEmailSender emailSender)
        {
            _requestRepository = requestRepository;
            _mapper = mapper;
            _leaveTypeRepository = leaveTypeRepository;
            _emailSender = emailSender;
        }
        public async Task<int> Handle(CreateLeaveRequestCommand request, CancellationToken cancellationToken)
        {
            var validator = new CreateLeaveRequestDTOValidator(_leaveTypeRepository);
            var result = await validator.ValidateAsync(request.LeaveRequestDTO);
            if (result.IsValid == false)
            {
                throw new ValidationException(result);
            }
            var leaveRequest = _mapper.Map<Domain.LeaveRequest>(request.LeaveRequestDTO);
            leaveRequest = await _requestRepository.Add(leaveRequest);

            var email = new Email()
            {
                To="info@vitagallery.ir",
                Subject="leave request submitted",
                Body=$"your leave request for {request.LeaveRequestDTO.StartDate} "+
                $"to {request.LeaveRequestDTO.EndDate} "+
                $"has been submited"
            };
            try
            {
                await _emailSender.SendEmail(email);
            }
            catch (Exception ex)
            {

                throw;
            }
            return leaveRequest.Id;
        }
    }
}
