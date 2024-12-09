# Company Management Application

This repository contains a robust company management application built using **.NET Core 8**. The application is designed with scalability, performance, and maintainability in mind, leveraging modern architectural patterns and technologies.

## Features

- **User Authentication & Authorization**: Powered by ASP.NET Identity with JWT for secure API authentication.
- **Comapany management Functionality**: Users can create, edit, read and delete companies.
- **Branch management Functionality**: Users can edit, read and delete companies.
- **Scalable and Maintainable Architecture**: Implements Clean Architecture with CQRS and the Mediator pattern using MediatR.
- **Database Management**: Utilizes PostgreSQL with Entity Framework Core (Code-First Migrations).

---

## Technologies and Tools

### Backend Technologies

- **ASP.NET Core 8**: Provides the framework for building the API.
- **Clean Architecture**: Ensures a separation of concerns and promotes modularity.
- **CQRS (Command Query Responsibility Segregation)**: Separates read and write operations for better performance and scalability.
- **MediatR**: Implements the Mediator pattern to handle requests and notifications.
- **Entity Framework Core**: Used as the Object-Relational Mapper (ORM) for PostgreSQL.
- **ASP.NET Identity**: Manages user authentication and authorization.
- **JWT (JSON Web Tokens)**: Secures API endpoints.

### Database

- **PostgreSQL**: Serves as the primary database for storing application data.
- **Code-First Migrations**: Ensures database schema evolves seamlessly with the codebase.

---

## Getting Started

### Prerequisites

1. Install [.NET SDK 8](https://dotnet.microsoft.com/download).
2. Set up PostgreSQL and Seq on your local machine or in the cloud.

### Installation

1. run docker compose
    you will find file dock-compose file run docker compose up to get Seq - postgresl instance with configurations used at code

## Project Structure

The project is structured following *Clean Architecture* principles, promoting separation of concerns and modularity.

```plaintext
├── API
│   ├── Controllers           # Handles HTTP requests and responses
│   ├── Middlewares           # Custom middleware for handling cross-cutting concerns
│   └── Startup.cs            # Configures services and middleware
│
├── Application
│   ├── Commands              # Write operations (CQRS)
│   ├── Queries               # Read operations (CQRS)
│   ├── Validators            # FluentValidation for input validation
│   └── Interfaces            # Abstractions used across the application
│
├── Domain
│   ├── Entities              # Core domain models
│   └── Enums                 # Enumerations used in the domain
│
├── Infrastructure
│   ├── Data                  # Data access using Entity Framework Core
│   ├── Caching               # Redis caching implementations
│   ├── Authentication        # ASP.NET Identity and JWT setup
│   └── FileStorage           # Azure Blob Storage integration
│
├── README.md                 # Project documentation
└── appsettings.json          # Configuration settings
```
