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

Model of the Asset Management application.

![Model](https://www.plantuml.com/plantuml/png/dLJBReCm4BpxAtpiG_m1Ya9JgU6GDchLt5tOKbemo3QAgef_xouOFoebbN9YFVRExeozhBKHoWnjmrWlYYzH0R_lMb5B_kEHb-xT78K2mbpS9OdRo4l6YaPexO-cQLPL2YfXuBdhp6g5oVmsoE2OX80sgfOLVnGj1Ci3A5rtCa1sGWxleZ230iL6ndXS3_dIz22Q0PxUFg5mzMmsrKgMnTrGDsLUNbqpZaHZeFDR6sX9vKo-5QeaygtG7sVfwK2mV0092eKJZ5Mm0hFKasbJY1q5MBxFobA1rY6uopOBkhWxRvxorX9RPnqdptjQUpeqiw2kN09L2yN6zIxpTbn8V1zdMNgV4NHwBYNm9xx7NEAhRXgwo2MSJ9vZx7T1a-J6QemX-wYS0hjtmdV7QuqFtcGm8E45kISm_YdnlzMnqbSDYcHENz98WP_62JxHzNmodaB2P3o9U-GvTcewLKl3zw3QMjDmQj-zvRhibSIAihvlwa8OB13-WZOAi7y_eDpchK6M-FVw1G00 "Model")

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