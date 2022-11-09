# Asset Management Application

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