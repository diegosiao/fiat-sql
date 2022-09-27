# Slink [🚧PoC🚧]

Turn C# code into translated SQL Stored Procedures that can run in all supported databases out of the box:

- Postgres;
- MySQL;
- Oracle;
- SQL Server;

## Why not .NET Entity Framework?

This project was born to satisfy a two very specific business requirements that could not be fully achieved using .NET EF:

- **🟢 The application needs to be portable to all major SQL Database vendors;**
- **⛔ Access to read or write operations on databases should ONLY be done using Stored Procedures (for security reasons and to allow processes of revision and approval from DBAs);**

Besides that, Slink uses Dapper under the hood and has an efficiency first approach while keeping portability as the most important premise.

## Pillars of Slink

- Portability;
- Efficiency first (developer convenience is put after);
- CQRS orientation;
- Testability (WIP);

## Quick Start/Demonstration

You are going to need Docker and Visual Studio 2022 or VS Code to follow these steps;

1. Clone this repository;
2. Run `docker-compose up -d --build` on root directory;
3. Open and Run the Solution on root directory (run a second time with 'mysql' as argument in $/source/Slink.Cli/Properties/launchSettings.json);

Check data and Stored Procedures created on both MySQL and Postgres databases;

Neat, huh? 😎
