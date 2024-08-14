# MoneyBuilder

MoneyBuilder is an educational website designed to teach children about financial literacy. The platform includes various learning levels, each with lectures and quizzes to ensure knowledge retention. The project is a backend implementation using .NET Web API, providing the core functionality to manage authentication, authorization, and the learning modules.

## Features

### 1. Authentication and Authorization
- **User Registration & Login:** Secure user authentication.
- **Role-Based Access Control:** Different levels of access based on user roles.

### 2. Learning Module
- **Levels and Lectures:** Add and manage multiple learning levels.
- **Quizzes:** Each lecture comes with a quiz featuring multiple-choice questions.
- **Completion Tracking System:**
  - Lectures are unlocked sequentially. The next lecture remains locked until the current one and its quiz are completed.
  - Levels are also locked until all preceding levels are completed.

## Technologies Used
- **Language:** C#
- **Framework:** .NET Web API
- **Database:** SQL Server
- **ORM:** Entity Framework
- **Query Language:** LINQ

## Installation

### Prerequisites
- [.NET SDK](https://dotnet.microsoft.com/download)
- [SQL Server](https://www.microsoft.com/en-us/sql-server/sql-server-downloads)

### Setup

1. **Clone the repository:**
   ```bash
   git clone https://github.com/yourusername/moneybuilder.git
   cd moneybuilder
