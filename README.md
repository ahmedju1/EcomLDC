# 🛒 Ecom - Clean Architecture Project

This project is a sample **ASP.NET Core Web API** that demonstrates **Clean Architecture** principles, **OOP**, and **SOLID** in practice.  

---
Domain: Core entities, rules, events.

Application: UseCases, DTOs, contracts.

Infrastructure: EF Core + repositories.

SharedKernel: Shared base classes.

Api: Controllers (entry point).

Tests: Unit & Integration tests.


---

## 📂 Project Structure


Ecom.sln
│
├─ src/

│ ├─ Ecom.Domain/

│ │ ├─ Entities/

│ │ │ ├─ Product.cs

│ │ │ ├─ Order.cs

│ │ │ └─ OrderItem.cs

│ │ ├─ ValueObjects/

│ │ │ └─ Money.cs

│ │ ├─ Rules/

│ │ │ └─ OrderMustHaveAtLeastOneItemRule.cs

│ │ └─ Events/

│ │ └─ OrderPlacedEvent.cs

│ │
│ ├─ Ecom.Application/

│ │ ├─ Interfaces/

│ │ │ ├─ IProductRepository.cs

│ │ │ ├─ IOrderRepository.cs

│ │ │ └─ IUnitOfWork.cs

│ │ ├─ DTOs/

│ │ │ ├─ ProductDto.cs

│ │ │ └─ OrderDto.cs

│ │ └─ UseCases/

│ │ ├─ GetProductsHandler.cs

│ │ └─ CreateOrderHandler.cs

│ │

│ ├─ Ecom.Infrastructure/

│ │ ├─ Persistence/

│ │ │ ├─ EcomDbContext.cs

│ │ │ ├─ Configurations/

│ │ │ │ └─ ProductConfig.cs

│ │ │ └─ Migrations/

│ │ ├─ Repositories/

│ │ │ ├─ ProductRepository.cs

│ │ │ └─ OrderRepository.cs

│ │ └─ UnitOfWork.cs

│ │

│ ├─ Ecom.SharedKernel/

│ │ ├─ BaseEntity.cs

│ │ ├─ Result.cs

│ │ └─ DomainEvent.cs

│ │

│ └─ Ecom.Api/

│ ├─ Controllers/

│ │ ├─ ProductsController.cs

│ │ └─ OrdersController.cs

│ ├─ DTOs/

│ │ └─ OrderRequest.cs

│ └─ Program.cs

│

└─ tests/

├─ Ecom.UnitTests/

│ └─ OrderTests.cs

└─ Ecom.IntegrationTests/

└─ ProductRepositoryTests.cs



---

## 🧩 Layer Responsibilities

- **Ecom.Domain**  
  Core business logic. Contains:
  - Entities (`Product`, `Order`, `OrderItem`)
  - ValueObjects (`Money`)
  - Business Rules (`OrderMustHaveAtLeastOneItemRule`)
  - Domain Events (`OrderPlacedEvent`)

- **Ecom.Application**  
  Application logic (use cases, contracts, DTOs). Contains:
  - Interfaces (`IProductRepository`, `IOrderRepository`, `IUnitOfWork`)
  - DTOs (`ProductDto`, `OrderDto`)
  - UseCases (`GetProductsHandler`, `CreateOrderHandler`)

- **Ecom.Infrastructure**  
  Technical details (EF Core, database). Contains:
  - `EcomDbContext` and configurations
  - Repositories implementing application interfaces
  - UnitOfWork implementation

- **Ecom.SharedKernel**  
  Common reusable building blocks:
  - `BaseEntity` (Id + DomainEvents)
  - `Result` (Success/Failure wrapper)
  - `DomainEvent` base class

- **Ecom.Api**  
  Presentation layer (entry point for clients). Contains:
  - Controllers (`ProductsController`, `OrdersController`)
  - API DTOs (`OrderRequest`)
  - `Program.cs` (startup and DI configuration)

- **Tests**  
  Ensures correctness and reliability:
  - UnitTests: Domain and Application logic
  - IntegrationTests: Repositories and API endpoints

---

