using CleanArchitecture.ToDoApp.Application.DTOs;
using MediatR;

namespace CleanArchitecture.ToDoApp.Application.TodoItems.Queries.GetTodoItemById
{
    public class GetTodoItemByIdQuery : IRequest<TodoItemDto>
    {
        public Guid Id { get; set; }
    }
}
