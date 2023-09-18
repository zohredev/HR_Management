﻿using HR_Managment.Application.DTOs.LeaveAllocation;
using HR_Managment.Application.Features.LeaveAllocations.Requests.Commands;
using HR_Managment.Application.Features.LeaveAllocations.Requests.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace HR_managment.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LeaveAllocationsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public LeaveAllocationsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        // GET: api/<LeaveAllocationsController>
        [HttpGet]
        public async Task<ActionResult<List<LeaveAllocationDTO>>> Get()
        {
            var leaveAllocations = await _mediator.Send(new GetLeaveAllocationListRequest());

            return Ok(leaveAllocations);
        }

        // GET api/<LeaveAllocationsController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<LeaveAllocationDTO>> Get(int id)
        {
            var leaveAllocation = await _mediator.Send(new GetLeaveAllocationDetailRequest() { Id = id });
            return Ok(leaveAllocation);
        }

        // POST api/<LeaveAllocationsController>
        [HttpPost]
        public async Task<ActionResult> Post([FromBody] CreateLeaveAllocationDTO createLeaveAllocation)
        {
            var command = new CreateLeaveAllocationCommand() { LeaveAllocationDTO = createLeaveAllocation };
            var request = await _mediator.Send(command);
            return Ok(request);
        }

        // PUT api/<LeaveAllocationsController>/5
        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, [FromBody] UpdateLeaveAllocationDTO updateLeaveAllocation)
        {
            var command = new UpdateLeaveAllocationCommand() { LeaveAllocationDTO= updateLeaveAllocation };
            await _mediator.Send(command);
            return NoContent();
        }

        // DELETE api/<LeaveAllocationsController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var command = new DeleteLeaveAllocationCommand() { Id = id };
            await _mediator.Send(command);
            return NoContent();
        }
  
    }
}
