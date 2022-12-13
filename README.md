# Asset Management Application
[![main](https://github.com/cbryce996/asset-management/actions/workflows/main.yml/badge.svg)](https://github.com/cbryce996/asset-management/actions/workflows/main.yml)

## Description
An Asset Management application developed for my Software Engineering module, the main goal of this project is to learn software engineering principles through the design and development of a full software project. The project has been developed using Agile methods and incremental development with a small set of requirements to initially outline the project.

## Project Structure
    .
    ├── docs                    # Documentation files
    ├── src                     # Source code
        ├── Domain              # Domain specific models
        ├── Application         # Use cases and interfaces
        ├── Infrastructure      # Persistence and implementations
        └── DesktopUI           # Desktop user interface
    ├── tests                   # Automated tests
    ├── LICENSE
    └── README.md

## Models

![Model](https://www.plantuml.com/plantuml/png/hLTTJzim57tlh_1ZojO_WAg8h4KiqXYCjkpP9BV5Qs9NjWDKK__xREVBTfp29Fg0Yk_nzRaVFjUz4X9pMPN5P7B0sHxl02rPYGb5VoSJf3xjwkee99JjgluqAxCPG-bzakSSX0WPRvF5gFK2hTXMlc8ElT-im4AqaFaysUquxB241yPa72i6oFfyQO0_SGb8_mbQqnobkMVfEAFqu9bwnkWMPvxn1n5othAEKKfL1ei2yYuG5_x4M86KjzOSjL-c7l25aHmzGCbUu0psvEUf3sC-VyH51NTFVo0B9Kf8JkZEZdRWp0hyWzu2nHruRQFugCz06HlB8t1161sXWccrnPciE72VpCbjveq0RhTopTEiljzmDnK9j5D3GlkWe_plrJ6lZES1UgV-0YQ7Gq4oB5Ma7SdELibdcxd-VmNyXMGWp6tJ19Rhkp70XG5qLYy33jYDUuRI3INoRlkRyJsgkgzUe8jdoFRfLXzo_QPkYeWQGbDqEU1s2bL00OQDmQLftSzEkftPb4hWgdzCv1tM3jeetGCSc22IyMCF8krM1-u7OMr5bfT0CYn_rXwBLJY292zxtJQrrmjETxHNqUcG8Sg8vdcC5UaewgBnv9VPnPthiyrOdzs0J8gYTYyYtLorBhVCuo6-jdqxfdbKTuRUDGorncl5DgQeGxm7RrAxPkt6FjTVaNLYe0IraoKK88VYR-yFxwZFyo6ZEXoyOSrmoFzNaeEgUrQqJ-5H_wci1YEzOvkTrzubYBraXqtQtgFlh8G5ev8pDUIvQNsdVMjK7OY7xQEPUIsF7GyMcIJBM4MbVw0bo_PvGxHpf2tcs7On33kbMuvLZYfJIF_j5nQXkcoMRJQBGyAcrNaS5Um5vy3GyykWuWOjpW-KzvnfJ6oGGKSUzNIS-vc3hgaaagWwD3grZaUUYT5w6kAuZf6IkyYt9KA0rDeMaNmQybY_9nrhU7RSwqkgaaapi6liJR_ba-urU9DZ0BzyOpYtBc5KxCmOlx3ZSxPEocMe5HlLRADGe654rcjyfNyRHS67-eAL1wszOUkI27MsRHnqPa_2vw_MgNeVwzUVcXP6jqAb_LK1FqQhu5mmWCPFD0qgtXNGNFti-mS0 "Model")


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