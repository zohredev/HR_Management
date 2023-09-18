using AutoMapper;
using HR_Managment.Application.Contracts.Persistence;
using HR_Managment.Application.DTOs.LeaveType.validators;
using HR_Managment.Application.Exceptions;
using HR_Managment.Application.Features.LeaveTypes.Requests.Commands;
using MediatR;

namespace HR_Managment.Application.Features.LeaveTypes.Handlers.Commands
{
    public class UpdateLeaveTypeCommandHandler : IRequestHandler<UpdateLeaveTypeCommand, Unit>
    {
        private readonly ILeaveTypeRepository typeRepository;
        private readonly IMapper mapper;

        public UpdateLeaveTypeCommandHandler(ILeaveTypeRepository typeRepository, IMapper mapper)
        {
            this.typeRepository = typeRepository;
            this.mapper = mapper;
        }
        public async Task<Unit> Handle(UpdateLeaveTypeCommand request, CancellationToken cancellationToken)
        {
            var validator = new LeaveTypeDTOValidator();
            var result = await validator.ValidateAsync(request.LeaveTypeDTO);
            if (result.IsValid == false)
            {
                throw new ValidationException(result);
            }

            var leaveType = await typeRepository.Get(request.LeaveTypeDTO.Id);
            //dto az voroodi miad va meghdare field hash ro doone be doone be soorate x.dto===>x.domain
            //mirize dakhele leaveType ke modele asli hast va 
            mapper.Map(request.LeaveTypeDTO, leaveType);
            await typeRepository.Update(leaveType);

            return Unit.Value;
        }
    }
}
