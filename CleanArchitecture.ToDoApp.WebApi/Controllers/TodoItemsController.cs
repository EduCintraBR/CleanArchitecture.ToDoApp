using CleanArchitecture.ToDoApp.Application.DTOs;
using CleanArchitecture.ToDoApp.Application.TodoItems.Commands.CompleteTodoItem;
using CleanArchitecture.ToDoApp.Application.TodoItems.Commands.CreateTodoItem;
using CleanArchitecture.ToDoApp.Application.TodoItems.Commands.DeleteTodoItem;
using CleanArchitecture.ToDoApp.Application.TodoItems.Commands.UpdateTodoItem;
using CleanArchitecture.ToDoApp.Application.TodoItems.Queries.GetAllTodoItems;
using CleanArchitecture.ToDoApp.Application.TodoItems.Queries.GetTodoItemById;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CleanArchitecture.ToDoApp.WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TodoItemsController : ControllerBase
    {
        private readonly IMediator _mediator;
        public TodoItemsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<TodoItemDto>>> GetAll()
        {
            var query = new GetAllTodoItemsQuery();
            var result = await _mediator.Send(query);
            return Ok(result);
        }

        [HttpPost]
        public async Task<ActionResult<TodoItemDto>> GetById(Guid id)
        {
            var query = new GetTodoItemByIdQuery { Id = id };
            var result = await _mediator.Send(query);

            if (result == null)
                return NotFound();

            return Ok(result);
        }

        [HttpPatch("{id}/complete")]
        public async Task<IActionResult> Complete(Guid id)
        {
            var command = new CompleteTodoItemCommand { Id = id };
            var result = await _mediator.Send(command);

            if (!result)
                return NotFound();

            return NoContent();
        }

        [HttpPost]
        public async Task<ActionResult<Guid>> Create(CreateTodoItemCommand command)
        {
            var result = await _mediator.Send(command);
            return CreatedAtAction(nameof(GetById), new { id = result }, result);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(Guid id, UpdateTodoItemCommand command)
        {
            if (id != command.Id)
                return BadRequest();

            var result = await _mediator.Send(command);

            if (!result)
                return NotFound();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var command = new DeleteTodoItemCommand { Id = id };
            var result = await _mediator.Send(command);

            if (!result)
                return NotFound();

            return NoContent();
        }
    }
}
