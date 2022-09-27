# Slink [🚧PoC🚧]

Do you like not having your project coupled to a specific Database vendor? Yeah, neither do us.

What about validating your code against schema and testing all your procedures on application startup? Nice, isn't?

Turn C# code into translated SQL procedures that can run in all supported databases out of the box:

- Postgres;
- MySQL;
- Oracle;
- SQL Server;

## Why not .NET Linq?

This project was born to satisfy a very specific business requirement to .NET developer teams:

- **Access to read and/or write on databases should always be done using Stored Procedures (to allow processes of revision and approval from DBAs);**

Besides that, Slink uses Dapper under the hood and has an efficiency first approach while keeping portability as the most important premise.

## Pillars of Slink

- Portability;
- Efficiency first (developer convenience is put after);
- CQRS orientation;
- Testability (WIP);

## Running Demonstration

- You are going to need Docker and Visual Studio or VS Code;

1. Clone this repository;
2. Run `docker-compose up -d --build` on $/source directory;
3. Open and Run the Solution on $/Slink.sln;

