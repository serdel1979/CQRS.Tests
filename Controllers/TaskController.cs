using CQRSPractica.Application.DTOs;
using CQRSPractica.Infraestructure.Command;
using CQRSPractica.Infraestructure.Queries;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.FileProviders;

namespace CQRSPractica.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TaskController : ControllerBase
    {
        private readonly IMediator _mediator;

        public TaskController(IMediator mediator)
        {
            this._mediator = mediator;
        }

        [HttpGet]
        public async Task<IEnumerable<TaskItemDTO>> GetAll() {
            return await _mediator.Send(new GetAllTasksQuery());
        }


        [HttpGet("{Id}")]
        public async Task<ActionResult<TaskItemDTO>> GetById(int Id) {
            var query = new GetTaskByIdQuery(Id);
            var task = await _mediator.Send(query);
            if (query == null) {
                return NotFound();
            }
            return task;
        }

        [HttpPost]
        public async Task<ActionResult> Create(CreateTaskCommand command) {
            var taskItem = await _mediator.Send(command);
            return CreatedAtAction(nameof(GetById), new { Id = taskItem.Id},taskItem);
        }

        [HttpDelete("{Id}")]
        public async Task<IActionResult> Delete(int Id) {

            var result = await _mediator.Send(new DeleteTaskCommand(Id));
            if (!result)
            {
                return NotFound();
            }
            return NoContent();
        }

        [HttpPut]
        public async Task<IActionResult> Update(int Id, UpdateTaskCommand command) { 
        
            if(Id != command.Id)
            {
                return BadRequest();
            }

            var taskItem = await _mediator.Send(command);
            if (taskItem == null)
            {
                return NotFound();
            }

            return NoContent();
        }



    }
}
