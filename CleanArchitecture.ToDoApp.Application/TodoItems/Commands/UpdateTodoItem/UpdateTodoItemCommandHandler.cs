using CleanArchitecture.ToDoApp.Domain.Repositories;
using MediatR;

namespace CleanArchitecture.ToDoApp.Application.TodoItems.Commands.UpdateTodoItem
{
    public class UpdateTodoItemCommandHandler : IRequestHandler<UpdateTodoItemCommand, bool>
    {
        private readonly ITodoItemRepository _todoItemRepository;
        private readonly IUnitOfWork _unitOfWork;

        public UpdateTodoItemCommandHandler(ITodoItemRepository todoItemRepository, IUnitOfWork unitOfWork)
        {
            _todoItemRepository = todoItemRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<bool> Handle(UpdateTodoItemCommand request, CancellationToken cancellationToken)
        {
            var todoItem = await _todoItemRepository.GetByIdAsync(request.Id, cancellationToken);

            if (todoItem == null)
            {
                return false; // Item nao encontrado
            }

            todoItem.UpdateTitle(request.Title);
            todoItem.UpdateDescription(request.Description);

            await _todoItemRepository.UpdateAsync(todoItem, cancellationToken);
            await _unitOfWork.SaveChangesAsync(cancellationToken);

            return true;
        }
    }
}
