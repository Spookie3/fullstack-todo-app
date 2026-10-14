# Fullstack Todo Application

A fullstack Todo application built with React, ASP.NET Core 10 Minimal APIs, Entity Framework Core, and SQLite.

## Tech Stack

**Frontend**
- React (JavaScript)
- Vite
- CSS

**Backend**
- C# / .NET 10
- ASP.NET Core Minimal APIs
- Entity Framework Core
- SQLite

## Features

- Create new todos
- View all todos
- Update todo completion status
- Delete todos
- Persistent database storage
- RESTful API with asynchronous CRUD operations
- Service layer with dependency injection
- DTOs for API requests and responses

## Getting Started

### Backend

Navigate to the backend directory:

```bash
cd backend
dotnet restore
dotnet ef database update
dotnet run
```

### Frontend

Navigate to the frontend directory:

```bash
cd frontend
npm install
npm run dev
```

This installs all dependancies and runs both the frontend and backend.
Now open the local URL provided by Vite.

## API Endpoints

| Method | Endpoint | Description |
|---|---|---|
| GET | /api/todos | Get all todos |
| GET | /api/todos/{id} | Get a todo |
| POST | /api/todos | Create a todo |
| PUT | /api/todos/{id} | Update a todo |
| DELETE | /api/todos/{id} | Delete a todo |

## Architecture

The backend uses Minimal API endpoints, DTOs, a service layer, and Entity Framework Core for database access.

The React frontend communicates with the API using the Fetch API.

## Author

Fullstack development portfolio project.
