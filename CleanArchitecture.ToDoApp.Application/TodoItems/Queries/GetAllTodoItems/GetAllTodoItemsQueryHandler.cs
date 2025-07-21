using CleanArchitecture.ToDoApp.Application.DTOs;
using CleanArchitecture.ToDoApp.Application.Mapping;
using CleanArchitecture.ToDoApp.Domain.Repositories;
using MediatR;

namespace CleanArchitecture.ToDoApp.Application.TodoItems.Queries.GetAllTodoItems
{
    public class GetAllTodoItemsQueryHandler : IRequestHandler<GetAllTodoItemsQuery, IEnumerable<TodoItemDto>>
    {
        private readonly ITodoItemRepository _todoItemRepository;
        public GetAllTodoItemsQueryHandler(ITodoItemRepository todoItemRepository)
        {
            _todoItemRepository = todoItemRepository;
        }
        public async Task<IEnumerable<TodoItemDto>> Handle(GetAllTodoItemsQuery request, CancellationToken cancellationToken)
        {
            var todoItems = await _todoItemRepository.GetAllAsync(cancellationToken);
            return todoItems.Select(item => item.ToDto());
        }
    }
}
