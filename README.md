# N-Layer Architecture 

In software engineering N-Layer architecture is a client–server architecture in which presentation, application processing and data management functions are physically separated. The most widespread use of multitier architecture is the **three-tier/layer architecture**.

N-layer application architecture provides a model by which developers can create flexible and reusable applications. By segregating an application into layers, developers acquire the option of modifying or adding a specific layer, instead of reworking the entire application. A three-layer architecture is typically composed of a **presentation layer**, a **logic (Services) layer**, and a **data layer**.

While the concepts of **layer** and **tier** are often used interchangeably, one fairly common point of view is that there is indeed a difference. This view holds that a **layer is a logical structuring mechanism for the conceptual elements that make up the software solution**, while a **tier is a physical structuring mechanism for the hardware elements that make up the system infrastructure**.

![image](https://user-images.githubusercontent.com/34960418/205287285-4da1e84e-d886-4952-8ea5-ca47b928cab7.png)

## Layers

- Presentation layer (a.k.a. UI layer, view layer, presentation tier in multitier architecture)
- Business layer (a.k.a. business logic layer (BLL), domain logic layer)
- Data access layer (a.k.a. persistence layer, logging, networking, and other services which are required to support a particular business layer)

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

