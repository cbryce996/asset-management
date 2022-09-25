# Asset management application

## Description
Asset management application for CMP307, porject uses ASP.NET Core MVC App with Electron.NET to create a desktop application.

## Setup

### ASP.NET Core

Project requires ASP.NET Core 5 to be installed, recommended to install .NET Core 5 SDK

````
sudo apt-get install dotnet-sdk-5.0
````

Note: Configure your OS package manager to downlaod the SDK from packages.microsoft.com to ensure you have the correct version.

## Usage

### Electron.NET
The project uses Electron.NET to create a desktop interface, it runs an ASP.NET Core process within an Electron process and opens a local port for communication with the Electron interface. To start the application use the following command from /src.

### Run:
````
electronize start
````