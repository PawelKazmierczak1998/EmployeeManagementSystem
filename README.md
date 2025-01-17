# EmployeeManagementSystem
This project is a Employee Management System implemented using ASP.NET Core 8 for the backend and Blazor for the frontend. 

## Project Structure
```
├─ EmployeeManagementSystem              # Root directory of the project
│  ├─ .gitignore                         # Git configuration file to specify untracked files
│  ├─ BaseLibrary                        # Shared library for common functionality
│  │  ├─ BaseLibrary.csproj              # Project file for the BaseLibrary
│  │  ├─ DTOs                            # Data Transfer Objects for data exchange
│  │  ├─ Entities                        # Database entities or domain models
│  │  └─ Responses                       # Standardized response models
│  ├─ Client                             # Blazor or frontend client application
│  │  ├─ ApplicationStates               # State management for the application
│  │  ├─ Layout                          # Shared layouts and components
│  │  ├─ Pages                           # Razor pages for the frontend
│  │  ├─ _Imports.razor                  # Global imports for Razor components
│  │  ├─ libman.json                     # Library manager configuration file
│  │  └─ wwwroot                         # Static files (e.g., CSS, JS, images)
│  ├─ ClientLibrary                      # Client-specific helper library
│  │  ├─ ClientLibrary.csproj            # Project file for the ClientLibrary
│  │  ├─ Helpers                         # Utility classes and helpers
│  │  └─ Services                        # Service layer for frontend logic
│  │     ├─ Contracts                    # Service interfaces
│  │     └─ Implementations              # Service implementations
│  ├─ EmployeeManagementSystem.sln       # Solution file for the entire project
│  ├─ Server                             # Backend server application
│  │  ├─ Controllers                     # API controllers for handling requests
│  │  └─ appsettings.json                # Application configuration file
│  └─ ServerLibrary                      # Server-specific helper library
│     ├─ Data                            # Database context and related classes
│     ├─ Helpers                         # Utility classes for backend operations
│     ├─ Repositories                    # Repository pattern implementation
│     └─ ServerLibrary.csproj            # Project file for the ServerLibrary
└─ README.md                             # README for the project
```
## Key Features

- User authentication and authorization
- Department, location, user, and employee management
- Overtime and vacation planning
- Sick leave system
- Sanction management

## Technology Stack

- **Backend:** ASP.NET Core 8
- **Frontend:** Blazor
- **Database:** MSSQL
- **Session Storage:** Blazored.LocalStorage
- **API:** RESTful

## Getting Started

### Prerequisites

- ASP.NET Core 8
- Package Manager Console
- SQL Server
### Data Base Migration and Update
- add-migration [name] -o Data/Migration # Before starting, make sure you select the correct project in the package manager console [ServerLibrary] and select the correct startup item [Server].(Applies only in cases where the Data folder does not contain mgration)
- update-database 
