# Run a Azure Functions locally inside a Docker container using Docker Compose!

## Prerequisites
- Docker
- Docker Compose
- [Azure Storage Explorer](https://docs.microsoft.com/en-us/azure/vs-azure-tools-storage-manage-with-storage-explorer)

## Getting started
1. Clone this Repo
2. Build the containers
```
sudo docker-compose build
```
3. Run all the containers
```
sudo docker-compose up
```
4. Create the Azure Storage artifacts
Run Azure Storage Explorer and create the following Blob Containers:
- input-container
- output-container

Create the following queue:
- queue
5. Stop the Containers
```
sudo docker-compose stop
```
6. Run all containers again (required for the Function to hook into the newly create blob containers and queue)
```
sudo docker-compose up
```
7. Try out the HTTP calls from the *http* directory using the [VS Code REST Client extension](https://marketplace.visualstudio.com/items?itemName=humao.rest-client)
8. Add a new message to the *queue*
9. Add a new file to the *input-container* and see the copy inside of the *output-container*