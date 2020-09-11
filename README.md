# Run a Azure Functions locally inside a Docker container using Docker Compose!

## Prerequisites
- Docker
- Docker Compose
- [Azure Storage Explorer](https://docs.microsoft.com/en-us/azure/vs-azure-tools-storage-manage-with-storage-explorer)

## Getting started
1. Clone this Repo
2. Run all the containers using docker-compose up (this will pull and build the containers initially)
```
docker-compose up
```
3. Create the Azure Storage artifacts
Run Azure Storage Explorer and create the following Blob Containers:
- input-container
- output-container

4. Create the following queue:
- queue
5. Try out the HTTP calls from the *http* directory using the [VS Code REST Client extension](https://marketplace.visualstudio.com/items?itemName=humao.rest-client) and see it get processed by the HttpTriggeredFunction
6. Add a new message to the *queue* and see it get processed by the QueueTriggeredFunction
7. Add a new file to the *input-container* and see it get copied to the *output-container* by the BlobTriggeredFunction
8. Press CTRL-C to stop the docker-compose command
9. To debug the application in VS CODE, press F5 from inside the cloned directory, this will start the storage emulator container first
10. Cleanup every running container using docker-compose down
```
docker-compose down
```