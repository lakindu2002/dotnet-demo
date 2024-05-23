dotnet new sln = Created a Solution

CSProject - Similar to Package.json written using XML

After CSProject is created, it needs to be associated to the sln file. - dotnet sln Tutorial.sln add ./Administration

Program.cs is the entry point for a Solution in dotnet.

Package Manager for dotnet is nuget - https://www.nuget.org/packages.

TO add a package - dotnet add package
To Remove a package - dotnet remove package

DI - https://www.nuget.org/packages/Microsoft.Extensions.DependencyInjection/9.0.0-preview.3.24172.9

DI uses Service Collections
Service collections manage the services in DI
Three ways to add Services

- AddSingleton - Only one instance of the service is created
- AddScoped - A new instance of the service is created for each scope
- AddTransient - A new instance of the service is created each time it is requested

use var when the type is defined after the =
for ex: var collection = new ServiceCollection();

use types when type isn't defined
for ex: int number = 0;
string text = "";


Run DLLs using dotnet CLI ->
dotnet bin/Debug/net8.0/Administration.dll

- Hosting Packages: https://www.nuget.org/packages/Microsoft.Extensions.Hosting/9.0.0-preview.3.24172.9

## Clean Architecture

1. Presentation 
2. Application - How the domain is implemented (Authorize requests using JWT)
3. Domain - Business related aspects (Eg, in distribution companies there are dealers, Supply Chain Managers, etc)
4. Persistence


Requests originate from presentation and come to application, then to domain.

Aggregates - 


dotnet add references - project reference can refer to other csprojs across solution to share code.