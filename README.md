### Presentation Layer (nLayer.Api)

This is the topmost level of the application. The presentation layer displays information related to such services as browsing merchandise, purchasing and shopping cart contents. In simple terms, it is a layer that users can access directly (such as a web page, or an operating system's GUI).

### Service Layer (nLayer.Services)

The service layer is pulled out from the presentation layer and, as its layer, it controls an application’s functionality by performing detailed processing.

### Data Layer (nLayer.Data)

The data access layer encapsulates the persistence mechanisms and exposes the data. The data access layer should provide an API to the service layer that exposes methods of managing the stored data without exposing or creating dependencies on the data storage mechanisms. As with the separation of any layer, there are costs for implementation and often costs to performance in exchange for improved maintainability.

# Technologies

- [ASP.NET Core 7](https://learn.microsoft.com/en-us/aspnet/core/introduction-to-aspnet-core?view=aspnetcore-7.0)
- [Entity Framework Core 7](https://learn.microsoft.com/en-us/ef/core/)
- [AutoMapper](https://automapper.org/)
- [NUnit](https://nunit.org/)
- [FluentAssertions](https://fluentassertions.com/)
- [Moq](https://github.com/moq)

