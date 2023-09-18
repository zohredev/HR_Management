using AutoMapper;
using HR_Managment.Application.DTOs.LeaveAllocation;
using HR_Managment.Application.DTOs.LeaveRequest;
using HR_Managment.Application.DTOs.LeaveType;
using HR_Managment.Domain;

namespace HR_Managment.Application.Profiles
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            #region LeaveRequest mapping

            CreateMap<LeaveRequest, LeaveRequestDTO>().ReverseMap();
            CreateMap<LeaveRequest, LeaveRequestListDTO>().ReverseMap();
            CreateMap<LeaveRequest, CreateLeaveRequestDTO>().ReverseMap();
            CreateMap<LeaveRequest, UpdateLeaveRequestDTO>().ReverseMap();

            #endregion

            #region LeaveAllocation mapping

            CreateMap<LeaveAllocation, LeaveAllocationDTO>().ReverseMap();
            CreateMap<LeaveAllocation, CreateLeaveAllocationDTO>().ReverseMap();
            CreateMap<LeaveAllocation, UpdateLeaveAllocationDTO>().ReverseMap();

            #endregion

            #region LeaveType

            CreateMap<LeaveType, LeaveTypeDTO>().ReverseMap();
            CreateMap<LeaveType, CreateLeaveTypeDTO>().ReverseMap();

            #endregion

        }
    }
}
