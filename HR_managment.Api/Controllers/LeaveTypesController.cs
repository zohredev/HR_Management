 using HR_Managment.Application.DTOs.LeaveType;
using HR_Managment.Application.Features.LeaveTypes.Requests.Commands;
using HR_Managment.Application.Features.LeaveTypes.Requests.Queries;
using HR_Managment.Application.Responces;
using MediatR;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace HR_managment.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LeaveTypesController : ControllerBase
    {
        private readonly IMediator _mediator;

        public LeaveTypesController(IMediator mediator)
        {
            _mediator = mediator;
        }
        // GET: api/<LeaveTypesController>
        [HttpGet]
        public async Task<ActionResult<List<LeaveTypeDTO>>> Get()
        {
            var leaveType = await _mediator.Send(new GetLeaveTypeListRequest());
            return Ok(leaveType);
        }

        // GET api/<LeaveTypesController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<LeaveTypeDTO>> Get(int id)
        {
            var leaveType = _mediator.Send(new GetLeaveTypeDetailRequest() { Id = id });
            return Ok(leaveType);
        }

        // POST api/<LeaveTypesController>
        [HttpPost]
        public async Task<ActionResult<BaseCommandResponse>> Post([FromBody] CreateLeaveTypeDTO leaveTypeDTO)
        {
            var command = new CreateLeaveTypeCommand() { LeaveTypeDTO = leaveTypeDTO };
            var response = await _mediator.Send(command);
            return Ok(response);
        }

        // PUT api/<LeaveTypesController>/5
        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, [FromBody] LeaveTypeDTO leaveType)
        {
            var command = new UpdateLeaveTypeCommand() { LeaveTypeDTO = leaveType };
            await _mediator.Send(command);
            return NoContent();
        }

        // DELETE api/<LeaveTypesController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var command = new DeleteLeaveTypeCommand() { Id = id };
            await _mediator.Send(command);
            return NoContent();
        }
    }
}
