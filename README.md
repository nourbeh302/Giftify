# Giftify - Crafting Memorable Moments, One Gift at a Time
Giftify is a sophisticated .NET Web API solution, meticulously designed to redefine the e-commerce gifting experience. By seamlessly combining creativity with technology, Giftify empowers users to curate personalized gifts from a wide range of products, manage orders with ease, and complete transactions securely through Paymob's payment gateway. Whether it's a simple token of appreciation or an elaborate gift set, Giftify ensures that every gift is memorable and every transaction is effortless.

## Key Features
- Intuitive Gift Creation: Enable users to craft personalized gifts by selecting from an extensive catalog of products. The flexible gift creation process allows for endless combinations, catering to a variety of occasions and preferences.
- Comprehensive Order Management: Streamline the order process by allowing users to provide precise shipping and billing details, accompanied by their chosen gifts. Orders are handled with precision, ensuring timely delivery and a seamless customer experience.
- Seamless Payment Integration: Benefit from secure and efficient transactions through Paymob’s payment gateway, integrated directly into the platform for a smooth checkout experience.

## Technologies Used
- .NET 8 Web API: A powerful and scalable framework for building robust RESTful APIs.
- Entity Framework Core: An industry-leading Object-Relational Mapper (ORM) that simplifies data access and management.
- MediatR: A library that implements the mediator pattern, enabling clean and decoupled code by handling communication between components.
- SMTP Protocol Integration: Integrated support for sending emails, such as order confirmations and notifications, directly from the platform.
- Paymob Payment Gateway Integration: A secure payment solution for processing transactions, ensuring a seamless and trustworthy user experience.

## Methodologies
- Repository Pattern: Promotes a clean separation of concerns by abstracting data access logic, allowing for better maintainability and scalability.
- Template Method Pattern: Defines the skeleton of an algorithm in a base class while allowing subclasses to override specific steps, promoting code reuse and flexibility.
- Domain-Driven Design (DDD): Focuses on creating a rich and meaningful domain model that reflects the core business concepts and logic.
- Clean Architecture: Ensures the independence of business logic from external concerns, allowing for a more modular and testable codebase.
- Minimal API: A modern approach to building lightweight APIs with minimal configuration, focusing on performance and simplicity.


## Getting Started
### Prequisites: 
- [.NET 8 SDK](https://dotnet.microsoft.com/en-us/download/dotnet/8.0/)
- [Paymob Accept Account](https://accept.paymob.com/portal2/)

### Installation
1. Clone the repository:
```bash
git clone https://github.com/nourbeh302/giftify.git
cd giftify
```

2. Configure your appsettings.json

3. Apply EF Core migrations:
```bash
dotnet ef database update
```

3. Run the application
```bash
dotnet run
```
