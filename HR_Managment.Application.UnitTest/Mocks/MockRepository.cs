
using HR_Managment.Application.Contracts.Persistence;
using HR_Managment.Domain;
using Moq;

namespace HR_Managment.Application.UnitTest.Mocks
{
    public static class MockLeaveRepository
    {
        public static Mock<ILeaveTypeRepository> GetLeaveTypeRepository()
        {
            var leaveTypes = new List<LeaveType>
            {
                new LeaveType { Id = 1,DefaultDay=10,Name="Test Vacation" },
                   new LeaveType { Id = 2,DefaultDay=12,Name="Test Sick" }
            };
            var mockRepo = new Mock<ILeaveTypeRepository>();
            mockRepo.Setup(r => r.GetAll()).ReturnsAsync(leaveTypes);

            mockRepo.Setup(r => r.Add(It.IsAny<LeaveType>()))
                .ReturnsAsync((LeaveType leaveType) =>
            {
                leaveTypes.Add(leaveType);
                return leaveType;
            });

            return mockRepo;
        }
    }
}
