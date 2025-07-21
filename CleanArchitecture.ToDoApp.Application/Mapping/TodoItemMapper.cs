using CleanArchitecture.ToDoApp.Application.DTOs;
using CleanArchitecture.ToDoApp.Domain.Entities;

namespace CleanArchitecture.ToDoApp.Application.Mapping
{
    public static class TodoItemMapper
    {
        public static TodoItemDto ToDto(this TodoItem entity)
        {
            return new TodoItemDto
            {
                Id = entity.Id,
                Title = entity.Title,
                Description = entity.Description,
                IsCompleted = entity.IsCompleted,
                CreatedAt = entity.CreatedAt,
                CompletedAt = entity.CompletedAt
            };
        }
    }
}
