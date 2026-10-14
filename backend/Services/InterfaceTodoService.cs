using ToDo.Models;

namespace ToDo.Services
{
    public interface InterfaceTodoService
    {
        // Return type and Method
        Task<List<Todo>> GetAllAsync();
        Task<Todo?> GetByIdAsync(int id);
        Task<Todo> CreateAsync(string title);
        Task<bool> UpdateAsync(int id, string title, bool isCompleted);
        Task<bool> DeleteAsync(int id);
    }
}
