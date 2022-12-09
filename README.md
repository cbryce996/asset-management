# Asset Management Application
[![main](https://github.com/cbryce996/asset-management/actions/workflows/main.yml/badge.svg)](https://github.com/cbryce996/asset-management/actions/workflows/main.yml)

## Description
An Asset Management application developed for my Software Engineering module, the main goal of this project is to learn software engineering principles through the design and development of a full software project. The project has been developed using Agile methods and incremental development with a small set of requirements to initially outline the project.

## Project Structure
    .
    ├── build                   # Compiled builds
    ├── docs                    # Documentation files
    ├── src                     # Source code
        ├── Domain              # Domain specific models
        ├── Application         # Use cases and interfaces
        ├── Infrastructure      # Services, persistence and implementations
        └── Presentation        # User interfaces
    ├── test                    # Automated tests
    ├── LICENSE
    └── README.md

## Models

![Design](https://www.plantuml.com/plantuml/png/dLNRZfim47tdA_oOjE87AeIM9bKNgTjDivS-Ep2XxeADRBFRgCg_TsoCRP2IIliKpvcPCtToepILUkZQ9EbfzK8R85lHKSR9tu0yYAD-en8CvjzfAhoYh9EaQgbImJJBYgQHq50DUo5qdgCp-HXv47H2G6d9U4E-qmuYyHcaOe97o1tbmv5MUf0WatEIa7ayvCkoPzeES7_u3PMFvxnDh7GIFW-ihSjwjKu84fsZEazAGsUg7CblgQmD-IrLlwxI6uD8_0eS91PkO8o24H97RPjcdvXHX9MxegubA1M3TyLcGgVkZifBlNN4hhEUavIzaGCTDhCoMNa7aQQpOkVntjVRyqGIyhZAqWUFADDhBb5_vdCiEMvrsvf1Ja_RvF6D-GRqWwjn3hcbyXKutOM-UrxN-6WdemE91-HNuBm8yVzMpojzKY1DcVRNJD4ymZLQ-4BMe-Ny2Wt6vvUuGvut8QqLuvhiG7PCcUDK8Nl7zRujMSxkA2cQ3VRKuw_G7dgXc1RoPD12AT0HbAPvP34bjhIo6LbGVIBVcDAP5V9GojBu2zTCCr34sJ_c1Zq8qH9SljNZseXEGugsNQrz2FmEw1MhrzvX3vru1GlDYzwPpnsk1AzinK-SwVlZJo5VxDvk3nl1DVpHIyMYEZ-DO1NgnVmZIqGzAsf215Iy2eORQluMnbgil15TtuA62DeoXNmGdthWj85HuBW9k2iOuy6EtlVYnm3oj1h1q27d4It63V0Q_vx-0G00 "Design")

## Setup

### ASP.NET Core

Project requires ASP.NET Core 5 to be installed, recommended to install .NET Core 5 SDK.

````
sudo apt-get install dotnet-sdk-5.0
````

Note: Configure your OS package manager to download the SDK from packages.microsoft.com to ensure you have the correct version.

Restore dependencies and tools by running.

````
dotnet restore
````

### NPM and Node.JS

Project requires NPM and NodeJS for Electron to work, install using the following commands.

````
sudo apt-get install npm
````
````
sudo apt-get install node
````

Note: Check latest versions are provided by your OS package manager, breaking typescript changes in older versions of NPM.

## Usage

### Electron.NET
The project uses Electron.NET to create a desktop interface, it runs an ASP.Net Core process within an Electron process which opens a local port for communication with the Electron interface. To start the application use the following command.

### Run
To run the project as a desktop application.

````
dotnet electronize start
````

Alternatively run the project as an ASP.Net web server.

````
dotnet watch run
````