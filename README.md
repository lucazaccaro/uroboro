# uroboro
An always-updated full stack solution built in .NET

## Project info
> What will uroboro be like when it's done?

First of all, it will never "be done".
It's meant to be an ever-rolling collection of projects always updated to the latest framework version and with the best practices for every *tier*.

> Ok, but what will uroboro really be?

Better question.
It will be a multi-layer and multi-tier Visual Studio solution representing a full stack project with **Data management**, **Business Logic**, **Services** and some **Frontend** alternatives. 

Every component will have its own version, with all pieces aliging on a solution-wide major version.
Semantic version will be used to handle updates.

Let's try to build a TODO list for the first version of uroboro

## TODO
This is a list of things to be included in the first relese:
- [x] An Entity Framework Core project to handle Data access (maybe with In-Memory)
- [x] A .NET 5+ project to centralize Business Logic
- [x] A .NET 5+ project to write REST APIs with WebAPI
- [x] A .NET 5+ project to define ASP.NET Core SignalR hubs
- [x] A .NET 5+ Blazor WebAssembly project to build the main Frontend

Other things that may come at a later stage are:
- [ ] A SQL Server Database project to handle DB stuff (maybe with LocalDB)
- [ ] A .NET 5+ project to write gRPC Services
- [ ] Other Frontend alternatives in Angular, React and Vue
- [ ] Better microservices architecture patterns
- [ ] Some sort of Azure integration
- [ ] Some sort of GitHub CI/CD integration

## Contributions
- VisualStudio.gitignore from https://github.com/github/gitignore/blob/master/VisualStudio.gitignore
- DI helpers from afj88