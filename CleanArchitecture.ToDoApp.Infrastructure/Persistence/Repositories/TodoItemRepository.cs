using CleanArchitecture.ToDoApp.Domain.Entities;
using CleanArchitecture.ToDoApp.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace CleanArchitecture.ToDoApp.Infrastructure.Persistence.Repositories
{
    public class TodoItemRepository : ITodoItemRepository
    {
        private readonly ApplicationDbContext _context;

        public TodoItemRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(TodoItem todoItem, CancellationToken cancellationToken = default)
        {
            await _context.ToDoItems.AddAsync(todoItem, cancellationToken);
        }

        public Task DeleteAsync(TodoItem todoItem, CancellationToken cancellationToken = default)
        {
            _context.ToDoItems.Remove(todoItem);
            return Task.CompletedTask;
        }

        public async Task<IEnumerable<TodoItem>> GetAllAsync(CancellationToken cancellationToken = default)
        {
            return await _context.ToDoItems.AsNoTracking().ToListAsync(cancellationToken);
        }

        public async Task<TodoItem> GetByIdAsync(Guid id, CancellationToken cancellationToken = default)
        {
            return await _context.ToDoItems.FindAsync(new object[] { id }, cancellationToken);
        }

        public async Task<IEnumerable<TodoItem>> GetCompletedAsync(CancellationToken cancellationToken = default)
        {
            return await _context.ToDoItems
                .AsNoTracking()
                .Where(t => t.IsCompleted)
                .ToListAsync(cancellationToken);
        }

        public async Task<IEnumerable<TodoItem>> GetIncompleteAsync(CancellationToken cancellationToken = default)
        {
            return await _context.ToDoItems
                .AsNoTracking()
                .Where(t => !t.IsCompleted)
                .ToListAsync(cancellationToken);
        }

        public Task UpdateAsync(TodoItem todoItem, CancellationToken cancellationToken = default)
        {
            _context.Entry(todoItem).State = EntityState.Modified;
            return Task.CompletedTask;
        }
    }
}
