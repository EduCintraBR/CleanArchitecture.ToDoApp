using MediatR;

namespace CleanArchitecture.ToDoApp.Application.TodoItems.Commands.CompleteTodoItem
{
    public class CompleteTodoItemCommand : IRequest<bool>
    {
        public Guid Id { get; set; }
    }
}
