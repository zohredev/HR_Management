using AutoMapper;
using HR_Managment.Application.Contracts.Persistence;
using HR_Managment.Application.DTOs.LeaveRequest;
using HR_Managment.Application.Features.LeaveRequests.Requests.Queries;
using MediatR;

namespace HR_Managment.Application.Features.LeaveRequest.Handlers.Queries
{
    internal class GetLeaveRequestDetailRequestHandler : IRequestHandler<GetLeaveRequestDetailRequest, LeaveRequestDTO>
    {
        private readonly ILeaveRequestRepository _requestRepository;
        private readonly IMapper _mapper;

        public GetLeaveRequestDetailRequestHandler(ILeaveRequestRepository requestRepository,IMapper mapper)
        {
            _requestRepository = requestRepository;
            _mapper = mapper;
        }
        public async Task<LeaveRequestDTO> Handle(GetLeaveRequestDetailRequest request, CancellationToken cancellationToken)
        {
            var leaveRequest = await _requestRepository.GetLeaveRequestWithDetails(request.Id);
            return _mapper.Map<LeaveRequestDTO>(leaveRequest);
        }
    }
}
