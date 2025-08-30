# EcomLDC
Domain: Core entities, rules, events.

Application: UseCases, DTOs, contracts.

Infrastructure: EF Core + repositories.

SharedKernel: Shared base classes.

Api: Controllers (entry point).

Tests: Unit & Integration tests.


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

