using ToDo.Services;
using ToDo.Dtos;
using ToDo.Mappings;

namespace ToDo.Endpoints
{
    public static class TodoEndpoints
    {
        public static void MapTodoEndpoints(this WebApplication app)
        {
            var group = app.MapGroup("/api/todos");

            // GET All todos, parameter is the service interface, which is injected by DI. Does not need to be manually instantiated, DI does it automatically.
            group.MapGet("/", async (InterfaceTodoService service) =>
            {
                //Use Service
                var todos = await service.GetAllAsync();
                
                // Converts to DTO
                // Retruns DTO object
                return Results.Ok(todos.Select(t => t.ToDto()));
            });

            //GET a todo by id
            group.MapGet("/{id:int}", async (int id, InterfaceTodoService service) =>
            {
                //Use Service
                var todo = await service.GetByIdAsync(id);

                //Validator
                if (todo is null)
                {
                    return Results.NotFound();
                }

                return Results.Ok(todo.ToDto());
            });

            //POST a new todo
            group.MapPost("/", async (CreateTodoDto dto, InterfaceTodoService service) =>
            {
                //Converts DTO into internal Model, Mapping
                var todo = await service.CreateAsync(dto.Title);

                return Results.Created($"/api/todos/{todo.Id}", todo.ToDto());
            });

            //PUT update a todo by id
            group.MapPut("/{id:int}", async (int id, UpdateTodoDto dto, InterfaceTodoService service) =>
            {
                //Calling service
                var updated = await service.UpdateAsync(
                    id,
                    dto.Title,
                    dto.IsCompleted
                );

                //Validator
                if (!updated)
                    return Results.NotFound();

                return Results.NoContent();
            });

            //DELETE a todo by id
            group.MapDelete("/{id:int}", async (int id, InterfaceTodoService service) =>
            {
                //Calling service
                var deleted = await service.DeleteAsync(id);

                //Validator
                if (!deleted)
                {
                    return Results.NotFound();
                }

                return Results.NoContent();
            });
        }
    }
}
