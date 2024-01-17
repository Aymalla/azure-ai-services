# Azure AI Services

This repository is used for applying learning examples of Azure AI services throughout my journey to explore the Azure AI capabilities, and to prepare for `Certification Exam AI-102: Designing and Implementing a Microsoft Azure AI Solution`

## Prerequisites

- Azure AI service resource
- Azure Language resource
- .NET Framework
- VSCode
- [Speech SDK](https://learn.microsoft.com/en-us/azure/ai-services/speech-service/quickstarts/setup-platform?tabs=linux%2Cubuntu%2Cdotnetcli%2Cdotnet%2Cjre%2Cmaven%2Cnodejs%2Cmac%2Cpypi&pivots=programming-language-csharp)

> **Note:** If you are using dev-container, you don't need to install any of the above. Just open the project in VSCode and it will install all the required tools for you.

## Documentation

- 
- 

## Running

Before running the application, make sure you have:

- Installed the Pre-requisites mentioned above.
- Created the environment file `.env` under root folder based on the template file [.env.template](.env.template).
- Created the http environment file [http-client.env.json](testing/e2e-test/http-client.env.json) based on the template file [http-client.env.template.json](testing/e2e-test/http-client.env.template.json).

To build the service source code and run unit-tests, use:

- `make build`

To run the service in development mode, use:

- `make run`

 The following is a list of make commands should be run from root folder.

```bash
help                   💬 This help message :)
build                  🔨 build the application and run unit-test 
run                    🏃 Run the API application
e2e-init               🔨 Initialize e2e test environment by installing httpyac CLI
e2e                    💻 Run e2e-test for both rest and sdk integration
e2e-rest               🏃 Run e2e-test for the rest integration
e2e-sdk                💻 Run e2e-test for the sdk integration
```
