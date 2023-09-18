
using AutoMapper;
using HR_Managment.Application.Contracts.Persistence;
using HR_Managment.Application.DTOs.LeaveType;
using HR_Managment.Application.Features.LeaveTypes.Handlers.Queries;
using HR_Managment.Application.Features.LeaveTypes.Requests.Queries;
using HR_Managment.Application.Profiles;
using HR_Managment.Application.UnitTest.Mocks;
using Moq;
using Shouldly;

namespace HR_Managment.Application.UnitTest.LeaveTypes.Queries
{
    public class GetLeaveAllocationListRequestHandlerTest
    {
        IMapper _mapper;
        Mock<ILeaveTypeRepository> _leaveTypeRepositoryMock;
        public GetLeaveAllocationListRequestHandlerTest()
        {
            _leaveTypeRepositoryMock = MockLeaveRepository.GetLeaveTypeRepository();
            var mapperConfig = new MapperConfiguration(m =>
            {
                m.AddProfile<MappingProfile>();
            });
            _mapper = mapperConfig.CreateMapper();
        }

        [Fact]
        public async Task GetLeaveTypeListTest()
        {
            var handler = new GetLeaveTypeListRequestHandler(_leaveTypeRepositoryMock.Object, _mapper);
            var result = await handler.Handle(new GetLeaveTypeListRequest(), CancellationToken.None);

            result.ShouldBeOfType<List<LeaveTypeDTO>>();
            result.Count.ShouldBe(2);
        }
    }
}
