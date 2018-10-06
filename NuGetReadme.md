# Introduction

OnionArch.Mvc is an ASP.NET Core project template which uses the onion architecture and domain driven design to scaffold an ASP.NET Core MVC application using feature folders.

## Installation

To install this project template, use the following command:

    dotnet new --install OnionArch.Mvc

## Usage

Issuing the following command will create a new project with the name `testProject`:

    dotnet new onionArch --name testProject

OnionArch.Mvc also has a number of parameterised command line switches, details on these can be displayed by running the following command:

    dotnet new onionArch --help

The output of which should look similar to the following:

    Onion Architecture MVC (C#)
    Author: Jamie Taylor
    Options:                                                                                                                                 
      -egp|--enable-gnu-pratchett   Whether to include and activate middleware which will include the X-GNU-Pratchett header in all requests 
                                bool - Optional                                                                                          
                                Default: false / (*) true                                                                                

      -esh|--enable-secure-headers  Whether to include and activate middleware which will include a range of OWASP suggested security headers
                                bool - Optional                                                                                          
                                Default: false / (*) true  