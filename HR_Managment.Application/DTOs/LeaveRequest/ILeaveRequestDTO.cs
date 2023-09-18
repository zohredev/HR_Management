 
namespace HR_Managment.Application.DTOs.LeaveRequest
{
    public interface ILeaveRequestDTO
    {
        public int LeaveTypeId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
    }
}
