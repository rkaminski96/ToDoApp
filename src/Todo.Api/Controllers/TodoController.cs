using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Todo.Domain.Exceptions;

namespace Todo.Api.Controllers
{
    [Route("api/todo")]
    public class TodoController : ControllerBase
    {
        [HttpGet]
        public async Task<ActionResult> Test()
        {
            throw new TodoException(ErrorCode.TestError, "Test error message");
        }
    }
}
