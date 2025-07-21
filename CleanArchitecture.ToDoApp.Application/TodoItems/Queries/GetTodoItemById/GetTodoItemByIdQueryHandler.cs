using CleanArchitecture.ToDoApp.Application.DTOs;
using CleanArchitecture.ToDoApp.Application.Mapping;
using CleanArchitecture.ToDoApp.Domain.Repositories;
using MediatR;

namespace CleanArchitecture.ToDoApp.Application.TodoItems.Queries.GetTodoItemById
{
    public class GetTodoItemByIdQueryHandler : IRequestHandler<GetTodoItemByIdQuery, TodoItemDto>
    {
        private readonly ITodoItemRepository _todoItemRepository;

        public GetTodoItemByIdQueryHandler(ITodoItemRepository todoItemRepository)
        {
            _todoItemRepository = todoItemRepository;
        }

        public async Task<TodoItemDto> Handle(GetTodoItemByIdQuery request, CancellationToken cancellationToken)
        {
            var todoItem = await _todoItemRepository.GetByIdAsync(request.Id, cancellationToken);
            
            if (todoItem == null) return null;

            return todoItem.ToDto();
        }
    }
}
