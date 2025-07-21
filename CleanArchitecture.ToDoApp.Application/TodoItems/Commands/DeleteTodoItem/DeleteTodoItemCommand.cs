using MediatR;

namespace CleanArchitecture.ToDoApp.Application.TodoItems.Commands.DeleteTodoItem
{
    public class DeleteTodoItemCommand : IRequest<bool>
    {
        public Guid Id { get; set; }
    }
}
