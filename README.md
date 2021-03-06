# ApprovalCenter
Single unified server application for approvals of several types, developed with multiples technologys how  DDD, CQRS and Event Sourcing

[![Lisence](https://img.shields.io/github/license/OliveiraMarcos/BaseFoundationProject)](LICENSE)

## How to use:
- You will need the latest Visual Studio 2019 and the latest .NET Core SDK.
- The latest SDK and tools can be downloaded from https://dot.net/core.

Also you can run the Apprval Center Project in Visual Studio Code (Windows, Linux or MacOS).

To know more about how to setup your enviroment visit the [Microsoft .NET Download Guide](https://www.microsoft.com/net/download)

To access of Demo click [here](https://approvalcenter.azurewebsites.net/swagger/index.html)

The PWA front-end application can be found in repository [here](https://github.com/OliveiraMarcos/ApprovalCenterPWA)

## Technologies implemented:

- ASP.NET Core 3.1 (with .NET Core 3.1)
 - ASP.NET WebApi Core with JWT Bearer Authentication
 - ASP.NET Identity Core
- Entity Framework Core 3.1
- .NET Core Native DI
- AutoMapper
- FluentValidator
- MediatR
- Swagger UI with JWT support

## Architecture:

- Full architecture with responsibility separation concerns, SOLID and Clean Code
- Domain Driven Design (Layers and Domain Model Pattern)
- Domain Events
- Domain Notification
- CQRS (Imediate Consistency)
- Event Sourcing
- Unit of Work
- Repository and Generic Repository

## References

- https://www.eduardopires.net.br/2016/12/apresentando-o-equinox-project/
- https://medium.com/@renato.groffe/jwt-asp-net-core-2-2-exemplo-de-implementa%C3%A7%C3%A3o-3e10058c1a73
- https://www.eduardopires.net.br/2014/10/tutorial-asp-net-mvc-5-ddd-ef-automapper-ioc-dicas-e-truques/
