using HR_Managment.Application.DTOs.LeaveRequest;
using HR_Managment.Application.Features.LeaveRequests.Requests.Commands;
using HR_Managment.Application.Features.LeaveRequests.Requests.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace HR_managment.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LeaveRequestsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public LeaveRequestsController(IMediator mediator)
        {
            _mediator = mediator;
        }
        // GET: api/<LeaveRequestsController>
        [HttpGet]
        public async Task<ActionResult<List<LeaveRequestListDTO>>> Get()
        {
            var leaveRequest = await _mediator.Send(new GetLeaveRequestListRequest());
            return Ok(leaveRequest);
        }

        // GET api/<LeaveRequestsController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<LeaveRequestDTO>> Get(int id)
        {
            var leaveRequest = await _mediator.Send(new GetLeaveRequestDetailRequest() { Id = id });

            return Ok(leaveRequest);
        }

        // POST api/<LeaveRequestsController>
        [HttpPost]
        public async Task<ActionResult> Post([FromBody] CreateLeaveRequestDTO leaveRequestDTO)
        {
            var command = new CreateLeaveRequestCommand() { LeaveRequestDTO = leaveRequestDTO };
            var response = await _mediator.Send(command);
            return Ok(response);
        }

        // PUT api/<LeaveRequestsController>/5
        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, [FromBody] UpdateLeaveRequestDTO updateLeaveRequest)
        {
            var command = new UpdateLeaveRequestCommand() { LeaveRequestDTO = updateLeaveRequest, Id = id };
            await _mediator.Send(command);
            return NoContent();
        }

        // DELETE api/<LeaveRequestsController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var command = new DeleteLeaveRequestCommand() { Id = id };
            await _mediator.Send(command);
            return NoContent();
        }

        // Put api/<LeaveRequestsController>/change-approval/5
        [HttpPut("change-approval/{id}")]
        public async Task<ActionResult> ChangeApproval(int id, [FromBody] ChangeLeaveRequestApprovalDTO changeLeaveRequest)
        {
            var command = new UpdateLeaveRequestCommand() { Id = id, ChangeLeaveRequestApprovalDTO = changeLeaveRequest };
            await _mediator.Send(command);
            return NoContent();
        }
    }
}
