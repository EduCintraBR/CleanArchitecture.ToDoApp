using CleanArchitecture.ToDoApp.Application.DTOs;
using MediatR;

namespace CleanArchitecture.ToDoApp.Application.TodoItems.Queries.GetAllTodoItems
{
    public class GetAllTodoItemsQuery : IRequest<IEnumerable<TodoItemDto>> { }
}
