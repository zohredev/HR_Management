using HR_Managment.Application.DTOs.Common;
 namespace HR_Managment.Application.DTOs.LeaveRequest
{
    public class UpdateLeaveRequestDTO :BaseDTO, ILeaveRequestDTO
    {
        public int LeaveTypeId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string RequestComments { get; set; }
        public bool? IsCancelled { get; set; }
    }
}
