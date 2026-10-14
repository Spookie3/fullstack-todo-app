using ToDo.Models;
using ToDo.Dtos;

//Mapping for when converting models to DTO. Reduces repeated mapping code
namespace ToDo.Mappings
{
    public static class TodoMappings
    {
        public static TodoDto ToDto(this Todo todo)
        {
            return new TodoDto
            {
                Id = todo.Id,
                Title = todo.Title,
                IsCompleted = todo.IsCompleted
            };
        }
    }
}
