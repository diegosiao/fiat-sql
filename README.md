# Slink [🚧PoC🚧]

Turn C# code into translated SQL Stored Procedures that can run in all supported databases out of the box:

- Postgres;
- MySQL;
- Oracle;
- SQL Server;

## What are the benefits of using Slink?

This project was born to satisfy two specific business requirements:

- **🟢 The application needs to be portable to all major SQL Database vendors;**
- **⛔ Access to read or write operations on databases should ONLY be done using Stored Procedures (for security reasons and to allow processes of revision and approval from DBAs);**

Besides that, Slink uses Dapper under the hood and has an efficiency first approach while keeping portability as the most important premise.

Stored Procedures are created in files that DBAs can easily track and apply in different environments after revision.

A smart versions' control of your code and the compiled procedures prevent errors at runtime.

## Quick Start/Demonstration

You are going to need Docker and Visual Studio 2022 or VS Code to follow these steps;

1. Clone this repository;
2. Run `docker-compose up -d --build` on root directory;
3. Open and Run the Solution on root directory (run a second time with 'mysql' as argument in $/source/Slink.Cli/Properties/launchSettings.json);

Check data and Stored Procedures created on both MySQL and Postgres databases (for connection information refer to $/source/Slink.Cli/App.config);

Neat, huh? 😎
