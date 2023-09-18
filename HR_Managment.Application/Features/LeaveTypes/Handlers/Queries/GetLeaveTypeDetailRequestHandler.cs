using AutoMapper;
using HR_Managment.Application.Contracts.Persistence;
using HR_Managment.Application.DTOs.LeaveType;
using HR_Managment.Application.Features.LeaveTypes.Requests.Queries;
using MediatR;

namespace HR_Managment.Application.Features.LeaveTypes.Handlers.Queries
{
    internal class GetLeaveTypeDetailRequestHandler : IRequestHandler<GetLeaveTypeDetailRequest, LeaveTypeDTO>
    {
        private readonly ILeaveTypeRepository _typeRepository;
        private readonly IMapper _mapper;

        public GetLeaveTypeDetailRequestHandler(ILeaveTypeRepository typeRepository,IMapper mapper)
        {
            _typeRepository = typeRepository;
            _mapper = mapper;
        }
        public async Task<LeaveTypeDTO> Handle(GetLeaveTypeDetailRequest request, CancellationToken cancellationToken)
        {
            var leaveType = await _typeRepository.Get(request.Id);
            return _mapper.Map<LeaveTypeDTO>(leaveType);
        }
    }
}
