using Microsoft.EntityFrameworkCore;
using ToDo.Data;
using ToDo.Models;

namespace ToDo.Services
{
    public class TodoService : InterfaceTodoService
    {
        //EF core DB context
        private readonly AppDbContext context;

        public TodoService(AppDbContext _context)
        {
            context = _context;
        }

        //Get all
        public async Task<List<Todo>> GetAllAsync()
        {
            return await context.Todos.AsNoTracking().ToListAsync();
        }

        //Get by id
        public async Task<Todo?> GetByIdAsync(int id)
        {
            return await context.Todos.AsNoTracking().FirstOrDefaultAsync(i => i.Id == id);
        }

        //POST create todo
        public async Task<Todo> CreateAsync(string title)
        {
            var todo = new Todo
            {
                Title = title,
                IsCompleted = false
            };

            context.Todos.Add(todo);

            await context.SaveChangesAsync();

            return todo;
        }

        //PUT update a todo
        public async Task<bool> UpdateAsync(int id, string title, bool isCompleted)
        {
            var todo = await context.Todos.FindAsync(id);

            if (todo == null)
                return false;

            if (!string.IsNullOrWhiteSpace(title))
                todo.Title = title;

            todo.IsCompleted = isCompleted;

            await context.SaveChangesAsync();

            return true;
        }

        //DELETE a todo
        public async Task<bool> DeleteAsync(int id)
        {
            var todo = await context.Todos.FindAsync(id);

            if (todo == null)
                return false;

            context.Todos.Remove(todo);

            await context.SaveChangesAsync();
            
            return true;
        }
    }
}
