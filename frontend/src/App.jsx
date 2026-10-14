import { useEffect, useState } from 'react';
import TodoForm from './components/TodoForm';
import TodoItem from './components/TodoItem';
import { todoService } from './services/todoService';
import './App.css';

export default function App() {
  const [todos, setTodos] = useState([]);
  const [loading, setLoading] = useState(true);
  const [error, setError] = useState(null);

  // GET all todos on initial render
  useEffect(() => {
    let active = true;

    async function loadTodos() {
      try {
        const data = await todoService.getAll();

        if (active) {
          setTodos(data);
        }
      } catch {
        if (active) {
          setError('Failed to load todos');
        }
      } finally {
        if (active) {
          setLoading(false);
        }
      }
    }

    loadTodos();

    return () => {
      active = false;
    };
  }, []);

  // POST create todo
  async function addTodo(title) {
    try {
      setError(null);

      const newTodo = await todoService.create(title);

      setTodos((prev) => [...prev, newTodo]);

      return true;
    } catch {
      setError('Failed to create todo');
      return false;
    }
  }

  // PUT update completion status
  async function toggleTodo(todo) {
    try {
      setError(null);

      await todoService.update(
        todo.id,
        todo.title,
        !todo.isCompleted
      );

      setTodos((prev) =>
        prev.map((t) =>
          t.id === todo.id
            ? { ...t, isCompleted: !todo.isCompleted }
            : t
        )
      );
    } catch {
      setError('Failed to update todo');
    }
  }

  // DELETE todo
  async function deleteTodo(id) {
    try {
      setError(null);

      await todoService.delete(id);

      setTodos((prev) => prev.filter((t) => t.id !== id));
    } catch {
      setError('Failed to delete todo');
    }
  }

  return (
    <main>
      <h1>My Todos</h1>

      <TodoForm onAdd={addTodo} />

      {error && <p role="alert">{error}</p>}

      {loading ? (
        <p>Loading todos...</p>
      ) : (
        <ul>
          {todos.map((todo) => (
            <TodoItem
              key={todo.id}
              todo={todo}
              onToggle={toggleTodo}
              onDelete={deleteTodo}
            />
          ))}
        </ul>
      )}
    </main>
  );
}