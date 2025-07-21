using CleanArchitecture.ToDoApp.Domain.Repositories;
using MediatR;

namespace CleanArchitecture.ToDoApp.Application.TodoItems.Commands.CompleteTodoItem
{
    public class CompleteTodoItemCommandHandler : IRequestHandler<CompleteTodoItemCommand, bool>
    {
        private readonly ITodoItemRepository _todoItemRepository;
        private readonly IUnitOfWork _unitOfWork;

        public CompleteTodoItemCommandHandler(ITodoItemRepository todoItemRepository, IUnitOfWork unitOfWork)
        {
            _todoItemRepository = todoItemRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<bool> Handle(CompleteTodoItemCommand request, CancellationToken cancellationToken)
        {
            var todoItem = await _todoItemRepository.GetByIdAsync(request.Id, cancellationToken);

            if (todoItem == null)
                return false;

            todoItem.MarkAsComplete();

            await _todoItemRepository.UpdateAsync(todoItem, cancellationToken);
            await _unitOfWork.SaveChangesAsync(cancellationToken);

            return true;
        }
    }
}
