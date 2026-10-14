import { useState } from 'react';

export default function TodoForm({ onAdd }) {
  const [title, setTitle] = useState('');
  const [isSubmitting, setIsSubmitting] = useState(false);

  async function handleSubmit(e) {
    e.preventDefault();

    if (!title.trim()) return;

    setIsSubmitting(true);

    try {
      const success = await onAdd(title.trim());

      if (success) {
        setTitle('');
      }
    } finally {
      setIsSubmitting(false);
    }
  }

  return (
    <form onSubmit={handleSubmit}>
      <input
        type="text"
        value={title}
        onChange={(e) => setTitle(e.target.value)}
        placeholder="Enter a new todo"
        required
      />

      <button type="submit" disabled={isSubmitting}>
        {isSubmitting ? 'Adding...' : 'Add Todo'}
      </button>
    </form>
  );
}