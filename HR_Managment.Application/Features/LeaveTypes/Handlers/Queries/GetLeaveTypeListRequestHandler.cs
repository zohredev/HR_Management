using AutoMapper;
using HR_Managment.Application.Contracts.Persistence;
using HR_Managment.Application.DTOs.LeaveType;
using HR_Managment.Application.Features.LeaveTypes.Requests.Queries;
using MediatR;

namespace HR_Managment.Application.Features.LeaveTypes.Handlers.Queries
{
    public class GetLeaveTypeListRequestHandler : IRequestHandler<GetLeaveTypeListRequest, List<LeaveTypeDTO>>
    {
        private readonly ILeaveTypeRepository _typeRepository;
        private readonly IMapper _mapper;

        public GetLeaveTypeListRequestHandler(ILeaveTypeRepository typeRepository,IMapper mapper)
        {
            _typeRepository = typeRepository;
            _mapper = mapper;
        }

        public async Task<List<LeaveTypeDTO>> Handle(GetLeaveTypeListRequest request, CancellationToken cancellationToken)
        {
            var leaveTypeList = await _typeRepository.GetAll();
            return _mapper.Map<List<LeaveTypeDTO>>(leaveTypeList);
        }
    }
}
