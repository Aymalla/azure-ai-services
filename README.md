# Azure AI Services

This repository is used for applying learning examples of Azure AI services throughout my journey to explore the Azure AI capabilities, and to prepare for `Certification Exam AI-102: Designing and Implementing a Microsoft Azure AI Solution`

## Prerequisites

- Azure subscription
- .NET Framework
- VSCode

> **Note:** If you are using dev-container, you don't need to install any of the above. Just open the project in VSCode and it will install all the required tools for you.

## Documentation

- 
- 

## Running

Before running the application, make sure you have 
- Installed the Pre-requisites mentioned above.
- Created the environment file `.env` under root folder based on the template file [.env.template](.env.template).
- the environment file [http-client.env.json](e2e-test/http-client.env.json) under `e2e-test` folder is up to date.

To build the service source code and run unit-tests, use:
-  `make build`

To run the service in development mode, use:
- `make run`

 The following is a list of make commands should be run from root folder.

```bash
help                   💬 This help message :)
build                  🔨 build the application and run unit-test 
run                    🏃 Run the application
e2e-init               🔨 Initialize e2e test environment by installing httpyac CLI
e2e-local              💻 Run e2e-test on your local environment
e2e-dev                💻 Run e2e-test on Backbase-msft-dev environment
```



