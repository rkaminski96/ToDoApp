using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
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
    }
}
