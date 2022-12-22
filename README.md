# Simple N-Layer Architecture with CQRS

## Layers

### Presentation Layer (nLayer.Api)

This is the topmost level of the application. The presentation layer displays information related to such services as browsing merchandise, purchasing and shopping cart contents. In simple terms, it is a layer that users can access directly (such as a web page, or an operating system's GUI).

### Application Layer (nLayer.Application)

The application layer contains [CQRS](https://github.com/pirocorp/CSharp-Masterclass/tree/main/09.%20CQRS) and [MediatR](https://github.com/jbogard/MediatR). **CQRS stands for Command and Query Responsibility Segregation**, a pattern that separates read and update operations for a data store. The flexibility created by migrating to CQRS allows a system to better evolve over time and prevents update commands from causing merge conflicts at the domain level.

### Data Layer (nLayer.Data)

The data access layer encapsulates the persistence mechanisms and exposes the data. The data access layer should provide an API to the service layer that exposes methods of managing the stored data without exposing or creating dependencies on the data storage mechanisms. As with the separation of any layer, there are costs for implementation and often costs to performance in exchange for improved maintainability.

# Technologies

- [ASP.NET Core 7](https://learn.microsoft.com/en-us/aspnet/core/introduction-to-aspnet-core?view=aspnetcore-7.0)
- [Entity Framework Core 7](https://learn.microsoft.com/en-us/ef/core/)
- [AutoMapper](https://automapper.org/)
- [NUnit](https://nunit.org/)
- [FluentAssertions](https://fluentassertions.com/)
- [Moq](https://github.com/moq)
- [MediatR](https://github.com/jbogard/MediatR)

