# OnionArch
A .NET Core demo application which uses the Onion Architecture

## Licence Used
[![License: MIT](https://img.shields.io/badge/License-MIT-yellow.svg)](https://opensource.org/licenses/MIT)

See the contents of the LICENSE file for details

## Pull Requests

[![PRs Welcome](https://img.shields.io/badge/PRs-welcome-brightgreen.svg?style=flat-square)](http://makeapullrequest.com)

Pull requests are welcome, but please take a moment to read the Code of Conduct before submitting them or commenting on any work in this repo.

## Code of Conduct
OnionArch has a Code of Conduct which all contributors, maintainers and forkers must adhere to. When contributing, maintaining, forking or in any other way changing the code presented in this repository, all users must agree to this Code of Conduct.

See [Code of Conduct.md](Code-of-Conduct.md) for details.

## Installing the Template

To use the template locally, it will need to be installed. You can do this from either the NuGet package (see the next section) or by installing it from source. To install from source, please seen the [NuGetReadMe.md](NuGetReadme) file for instructions.

## NuGet Package

This project is now available as a [NuGet package](https://www.nuget.org/packages/OnionArch.Mvc)

## Running The Application

1. Ensure that the `appsettings.json` file contains a valid `ConnectionStrings` section.

You will need two connection strings:

* onionDataConnection

This is the database which will contain all of the Book and Series information

* onionAuthConnection

This is the database which will contain all of the ASP.NET MVC Core auth information.

Example ConnectionStrings section:

    "ConnectionStrings": {
      "onionDataConnection": "DataSource=onionData.db",
      "onionAuthConnection": "DataSource=onionAuth.db"
    },

2. Open a command prompt in the `Onion.Web` directory

Issue the following commands to set up the databases:

    dotnet restore

Check for migrations in the `Onion.Repo.Identity` directory. If there isn't a directory labelled `Migrations`, then run the following (from the `Onion.Web`) directory to generate them:

    dotnet ef migrations add CreateIdentitySchema -c AppIdentityDbContext -p ../Onion.Repo/Onion.Repo.csproj -s Onion.Web.csproj

Similarly, check for migrations in the `Onion.Repo.Data` directory. If there isn't a directory labelled `Migrations`, then run the following (from the `Onion.Web`) directory to generate them:

    dotnet ef migrations add InitialMigration -c DataContext -p ../Onion.Repo/Onion.Repo.csproj -s Onion.Web.csproj

Apply all migrations to the databases by running the following commands (from the `Onion.Web` directory):

    dotnet ef database update -c DataContext -p ../Onion.Repo/Onion.Repo.csproj -s Onion.Web.csproj
    dotnet ef database update -c AppIdentityDbContext -p ../Onion.Repo/Onion.Repo.csproj -s Onion.Web.csproj

3. Run the application and seed the database

Issue the following command from the `Onion.Web` directory:

    dotnet run
