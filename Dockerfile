FROM mcr.microsoft.com/dotnet/core/sdk:3.1 AS installer-env

# Copy .env variables through to Azure Function container
ENV AzureWebJobsStorage=$AzureWebJobsStorage
ENV BlobContainerName=$BlobContainerName
ENV BlobOutputContainerName=$BlobOutputContainerName
ENV QueueName=$QueueName

COPY src ./src

RUN cd /src/Local.Functions && \
    mkdir -p /home/site/wwwroot && \
    dotnet publish *.csproj --output /home/site/wwwroot

# To enable ssh & remote debugging on app service change the base image to the one below
# FROM mcr.microsoft.com/azure-functions/dotnet:3.0-appservice
FROM mcr.microsoft.com/azure-functions/dotnet:3.0
ENV AzureWebJobsScriptRoot=/home/site/wwwroot \
    AzureFunctionsJobHost__Logging__Console__IsEnabled=true

COPY --from=installer-env ["/home/site/wwwroot", "/home/site/wwwroot"]