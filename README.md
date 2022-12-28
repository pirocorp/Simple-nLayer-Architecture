# Simple N-Layer Architecture with CQRS

## Layers

### Presentation Layer (nLayer.Api)

This is the topmost level of the application. The presentation layer displays information related to such services as browsing merchandise, purchasing and shopping cart contents. In simple terms, it is a layer that users can access directly (such as a web page, or an operating system's GUI).

### Application Layer (nLayer.Application)

The application layer contains [CQRS](https://github.com/pirocorp/CSharp-Masterclass/tree/main/09.%20CQRS) and [MediatR](https://github.com/jbogard/MediatR). **CQRS stands for Command and Query Responsibility Segregation**, a pattern that separates read and update operations for a data store. The flexibility created by migrating to CQRS allows a system to better evolve over time and prevents update commands from causing merge conflicts at the domain level.

### Data Layer (nLayer.Data)

The data access layer encapsulates the persistence mechanisms and exposes the data. The data access layer should provide an API to the service layer that exposes methods of managing the stored data without exposing or creating dependencies on the data storage mechanisms. As with the separation of any layer, there are costs for implementation and often costs to performance in exchange for improved maintainability.

## MediatR Pipeline Behaviours

### What are Pipelines

**Requests**/**Responses** travel back and forth through Pipelines in ASP.net Core. When an Actor sends a request it passes the through a pipeline to the application, where an operation is performed using data contained in the request message. Once, the operation is completed a Response is sent back through the Pipeline containing the relevant data.

Pipelines are only aware of what the Request or Response are, and this is an important concept to understand when thinking about **ASP.net Core Middleware**.

Pipelines are also extremely handy when it comes to wanting implement common logic like Validation and Logging, primarily because we can write code that executes during the request enabling you to validate or perform logging duties etc.

### MediatR Pipeline Behaviour

MediatR Pipeline behaviours, enabling you execute validation or logging logic before and after your Command or Query Handlers execute, resulting in your handlers only having to deal with Valid requests in your CQRS implementation, and you don't have to clutter your Handler methods with repetitive logging or validation logic!

### Logging Pipeline Behaviour

Logging is area, where you don't really want to pollute your code with logging statements. Weaving logging code in amongst your business logic actually just adds to the complexity and ironically can often become the source of bugs when the primary reason to add logging to code is in order to help you troubleshoot and analyse the cause of bugs in your code.


# Technologies

- [ASP.NET Core 7](https://learn.microsoft.com/en-us/aspnet/core/introduction-to-aspnet-core?view=aspnetcore-7.0)
- [Entity Framework Core 7](https://learn.microsoft.com/en-us/ef/core/)
- [AutoMapper](https://automapper.org/)
- [NUnit](https://nunit.org/)
- [FluentAssertions](https://fluentassertions.com/)
- [Moq](https://github.com/moq)
- [MediatR](https://github.com/jbogard/MediatR)

