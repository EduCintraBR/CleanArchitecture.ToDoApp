using CleanArchitecture.ToDoApp.Domain.Entities;

namespace CleanArchitecture.ToDoApp.Domain.Repositories
{
    public interface ITodoItemRepository
    {
        Task<TodoItem> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);
        Task<IEnumerable<TodoItem>> GetAllAsync(CancellationToken cancellationToken = default);
        Task<IEnumerable<TodoItem>> GetCompletedAsync(CancellationToken cancellationToken = default);
        Task<IEnumerable<TodoItem>> GetIncompleteAsync(CancellationToken cancellationToken = default);
        Task AddAsync(TodoItem todoItem, CancellationToken cancellationToken = default);
        Task UpdateAsync(TodoItem todoItem, CancellationToken cancellationToken = default);
        Task DeleteAsync(Guid id, CancellationToken cancellationToken = default);
    }
}
