\# Community Version API (.NET 8 Clean Architecture)



\## Overview



Community Version API is a production-ready REST API built with:



\* .NET 8

\* Clean Architecture

\* Entity Framework Core

\* PostgreSQL

\* MediatR (CQRS)

\* FluentValidation

\* Redis Caching

\* Serilog

\* Global Exception Middleware

\* xUnit Tests



\## Architecture



```text

src/



JobMarketPlace.API

JobMarketPlace.Application

JobMarketPlace.Domain

JobMarketPlace.Infrastructure



tests/


API.Test

Application.Test

Domain.Test

Infrastructure.Test
```



\## Prerequisites



Install the following:



\* .NET SDK 8

\* PostgreSQL 16+

\* Redis 7+

\* Docker Desktop (optional)

\* Visual Studio 2022 / VS Code



Verify installation:



```bash

dotnet --version

psql --version

```



Expected:



```text

8.x.x

```



\---



\## Clone the repository



```bash

git clone https://github.com/<your-account>/community-version-api.git



cd community-version-api

```



\---



\## Restore packages



```bash

dotnet restore

```



\---



\## Configure appsettings.json



```json

{

\\\&#x20; "ConnectionStrings": {

\\\&#x20;   "DefaultConnection": "Host=localhost;Port=5432;Database=communitydb;Username=postgres;Password=password",

\\\&#x20;   "Redis": "localhost:6379"

\\\&#x20; },



\\\&#x20; "Jwt": {

\\\&#x20;   "Key": "your-secret-key",

\\\&#x20;   "Issuer": "JobMarketPlace",

\\\&#x20;   "Audience": "JobMarketPlace"

\\\&#x20; },



\\\&#x20; "AllowedHosts": "\\\\\\\*"

}

```



\---



\## Install PostgreSQL



Create a database:



```sql

CREATE DATABASE communitydb;

```



Verify connection.



\---



\## Create EF Core migrations



```bash

dotnet ef migrations add InitialCreate \\\\\\\\

\\\\-p src/JobMarketPlace.Infrastructure \\\\\\\\

\\\\-s src/JobMarketPlace.API

```



Apply migrations:



```bash

dotnet ef database update \\\\\\\\

\\\\-p src/JobMarketPlace.Infrastructure \\\\\\\\

\\\\-s src/JobMarketPlace.API

```



\---



\## Database Seeder



The application automatically:



\* Applies pending migrations

\* Checks if data exists

\* Seeds initial data



Startup sequence:



```csharp

using var scope = app.Services.CreateScope();



var context = scope.ServiceProvider

\\\&#x20;   .GetRequiredService<AppDbContext>();



await AppDbInitializer.SeedAsync(context);

```



\---



\## Run the application



```bash

dotnet run \\\\\\\\

\\\\--project src/JobMarketPlace.API

```



Default URL:



```text

https://localhost:7001



http://localhost:5000

```



Swagger:



```text

https://localhost:7001/swagger

```



\## Redis Caching



Caching is enabled for read operations.



Example flow:



```text

Client

\\\&#x20;↓

Controller

\\\&#x20;↓

MediatR

\\\&#x20;↓

Query Handler

\\\&#x20;↓

Redis

\\\&#x20;↓

PostgreSQL

```



Cache expiration:



```text

10 minutes

```



Example:



```csharp

var cached =

await \\\\\\\_cache.GetAsync<SearchCustomersResponse>(cacheKey);



if (cached is not null)

{

\\\&#x20;   return cached;

}



await \\\\\\\_cache.SetAsync(

\\\&#x20;   cacheKey,

\\\&#x20;   response,

\\\&#x20;   TimeSpan.FromMinutes(10));

```



\## Pipeline Behaviors



Implemented:



```text

ValidationBehavior

LoggingBehavior

PerformanceBehavior

```



Execution order:



```text

Request



↓



Validation



↓



Logging



↓



Performance



↓



Handler

```



\---



\## Logging



Serilog logs:



\* Request information

\* Exceptions

\* Performance metrics



Example:



```text

\\\\\\\[INF] Handling SearchCustomersQuery



\\\\\\\[INF] Handled SearchCustomersQuery



\\\\\\\[WRN] SearchCustomersQuery took 650ms

```



\---



\## Custom Exceptions



Supported:



```text

400 BadRequest



401 Unauthorized



403 Forbidden



404 NotFound



409 Conflict



429 TooManyRequests



500 InternalServerError

```



Response:



```json

{

\\\&#x20; "success": false,

\\\&#x20; "statusCode": 404,

\\\&#x20; "message": "Customer was not found.",

\\\&#x20; "traceId": "..."

}

```



\---



\## Run Tests



```bash

dotnet test

```



\---



\## Docker



Start PostgreSQL and Redis:



```bash

docker compose up -d

```



Stop containers:



```bash

docker compose down

```



\---



\## Recommended NuGet Packages



Application



```text

MediatR

FluentValidation

FluentValidation.DependencyInjectionExtensions

```



Infrastructure



```text

Microsoft.EntityFrameworkCore

Microsoft.EntityFrameworkCore.Design

Microsoft.EntityFrameworkCore.Tools

Npgsql.EntityFrameworkCore.PostgreSQL

Microsoft.Extensions.Caching.StackExchangeRedis

StackExchange.Redis

```



API



```text

Swashbuckle.AspNetCore

Serilog.AspNetCore

Microsoft.AspNetCore.Authentication.JwtBearer

```



\---



\## Technology Stack



```text

.NET 8



PostgreSQL



Redis



EF Core



MediatR



CQRS



FluentValidation



Serilog



Swagger



Clean Architecture



xUnit

```

