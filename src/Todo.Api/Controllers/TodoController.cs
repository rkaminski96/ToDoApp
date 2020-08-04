using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
using System.Threading.Tasks;
using TodoApp.Application.Commands.Models;
using TodoApp.Application.Queries.Models;

namespace TodoApp.Api.Controllers
{
    [Route("api/todo/")]
    public class TodoController : ControllerBase
    {
        private readonly IMediator mediator;

        public TodoController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get([FromRoute] int id)
        {
            var todoDto = await mediator.Send(new GetTodoQuery(id));
            return Ok(todoDto);
        }

        [HttpGet]
        public async Task<IActionResult> GetAll([FromQuery] GetTodosQuery getTodosQuery)
        {
            var todoListPreview = await mediator.Send(getTodosQuery);
            
            Response.Headers.Add("X-Pagination",
                JsonSerializer.Serialize(todoListPreview.PaginationMetadata));

            return Ok(todoListPreview.TodoPreviewDtos);
        }

        [HttpPost]
        public async Task<IActionResult> Add([FromBody] AddTodoCommand command)
        {
            await mediator.Send(command);
            return Ok();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update([FromRoute] int id, [FromBody] UpdateTodoCommand command)
        {
            await mediator.Send(command.SetTodoId(id));
            return Ok();
        }

        [HttpPut("status/{id}")]
        public async Task<IActionResult> ChangeStatus([FromRoute] int id, [FromBody] ChangeTodoStatusCommand command)
        {
            await mediator.Send(command.SetTodoId(id));
            return Ok();
        }

        [HttpPut("priority/{id}")]
        public async Task<IActionResult> ChangePriority([FromRoute] int id, [FromBody] ChangeTodoPriorityCommand command)
        {
            await mediator.Send(command.SetTodoId(id));
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            await mediator.Send(new DeleteTodoCommand(id));
            return Ok();
        }
    }
}
