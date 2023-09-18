
using AutoMapper;
using HR_Managment.Application.Contracts.Persistence;
using HR_Managment.Application.DTOs.LeaveType;
using HR_Managment.Application.Features.LeaveTypes.Handlers.Commands;
using HR_Managment.Application.Features.LeaveTypes.Requests.Commands;
using HR_Managment.Application.Profiles;
using HR_Managment.Application.UnitTest.Mocks;
using Moq;
using Shouldly;

namespace HR_Managment.Application.UnitTest.LeaveTypes.Commands
{
    public class CreateLeaveTypeCommandHandlerTests
    {
        IMapper _mapper;
        Mock<ILeaveTypeRepository> _leaveTypeRepositoryMock;
        CreateLeaveTypeDTO _leaveTypeDTO;
        public CreateLeaveTypeCommandHandlerTests()
        {
            _leaveTypeRepositoryMock = MockLeaveRepository.GetLeaveTypeRepository();
            var mappingProfile = new MapperConfiguration(m =>
            {
                m.AddProfile<MappingProfile>();
            }
                );
            _mapper = mappingProfile.CreateMapper();
            _leaveTypeDTO = new CreateLeaveTypeDTO()
            {

                DefaultDay = 15,
                Name = "test Name"
            };
        }

        [Fact]
        public async Task CreateLeaveType()
        {
            var handler = new CreateLeaveTypeCommandHandler(_leaveTypeRepositoryMock.Object, _mapper);
            var result = await handler.Handle(new CreateLeaveTypeCommand()
            {
                LeaveTypeDTO = _leaveTypeDTO
            }, CancellationToken.None);
            result.ShouldBeOfType<int>();
            var leaveTypes = await _leaveTypeRepositoryMock.Object.GetAll();
            leaveTypes.Count().ShouldBe(4);
            leaveTypes.Any().ShouldBeTrue();
        }

    }
}
