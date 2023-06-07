# Manual Deployment

Deploy the api from /apps/config-api to an Azure App Service manually

- Create the Azure App Service Ressource by executing `/deploy/cli/create-app-service.azcli`
- Build App manually using .NET CLI
- Deploy App manually using [Azure App Service Extension for VS Code](https://marketplace.visualstudio.com/items?itemName=ms-azuretools.vscode-azureappservice)

    >Note: As an alternative on could use [az webapp up](https://learn.microsoft.com/en-us/cli/azure/webapp?view=azure-cli-latest#az-webapp-up) to create the app service and deploy the app. 
