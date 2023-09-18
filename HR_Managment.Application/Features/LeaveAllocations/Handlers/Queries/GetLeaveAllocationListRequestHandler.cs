using AutoMapper;
using HR_Managment.Application.Contracts.Persistence;
using HR_Managment.Application.DTOs.LeaveAllocation;
using HR_Managment.Application.Features.LeaveAllocations.Requests.Queries;
using MediatR;

namespace HR_Managment.Application.Features.LeaveAllocations.Handlers.Queries
{
    public class GetLeaveAllocationListRequestHandler : IRequestHandler<GetLeaveAllocationListRequest, List<LeaveAllocationDTO>>
    {
        private readonly ILeaveAllocationRepository _allocationRepository;
        private readonly IMapper _mapper;

        public GetLeaveAllocationListRequestHandler(ILeaveAllocationRepository allocationRepository, IMapper mapper)
        {
            _allocationRepository = allocationRepository;
            _mapper = mapper;
        }

        public async Task<List<LeaveAllocationDTO>> Handle(GetLeaveAllocationListRequest request, CancellationToken cancellationToken)
        {
            var allocationList = await _allocationRepository.GetAll();
            return _mapper.Map<List<LeaveAllocationDTO>>(allocationList);
        }
    }
}
