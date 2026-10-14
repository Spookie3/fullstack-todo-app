export default function TodoItem({ todo, onToggle, onDelete }) {
  return (
    <li>
      <input
        type="checkbox"
        checked={todo.isCompleted}
        onChange={() => onToggle(todo)}
      />

      <span
        style={{
          textDecoration: todo.isCompleted
            ? 'line-through'
            : 'none',
        }}
      >
        {todo.title}
      </span>

      <button onClick={() => onDelete(todo.id)}>
        Delete
      </button>
    </li>
  );
}