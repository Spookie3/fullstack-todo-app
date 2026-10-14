const API_URL = '/api/todos';

// reusable function
async function checkResponse(response) {
  if (!response.ok) {
    throw new Error(`API request failed: ${response.status}`);
  }
}

export const todoService = {
  // GET all todos
  async getAll() {
    const response = await fetch(API_URL);
    await checkResponse(response);

    return response.json();
  },

  // GET todo by ID
  async getById(id) {
    const response = await fetch(`${API_URL}/${id}`);
    await checkResponse(response);

    return response.json();
  },

  // POST create todo
  async create(title) {
    const response = await fetch(API_URL, {
      method: 'POST',
      headers: {
        'Content-Type': 'application/json',
      },
      body: JSON.stringify({ title }),
    });

    await checkResponse(response);

    return response.json();
  },

  // PUT update todo
  async update(id, title, isCompleted) {
    const response = await fetch(`${API_URL}/${id}`, {
      method: 'PUT',
      headers: {
        'Content-Type': 'application/json',
      },
      body: JSON.stringify({ title, isCompleted }),
    });

    await checkResponse(response);
  },

  // DELETE todo
  async delete(id) {
    const response = await fetch(`${API_URL}/${id}`, {
      method: 'DELETE',
    });

    await checkResponse(response);
  },
};