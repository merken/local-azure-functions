using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using Microsoft.Azure.Storage.Blob;

namespace Local.Functions
{
    public static class BlobTriggeredFunction
    {
        [FunctionName("Blob")]
        public static async Task Run(
            [BlobTrigger("%BlobContainerName%/{filename}", Connection = "AzureWebJobsStorage")] Stream blob, string filename,
            [Blob("%BlobOutputContainerName%", FileAccess.Write, Connection = "AzureWebJobsStorage")] CloudBlobContainer outputContainer,
            ILogger log)
        {
            log.LogInformation($"Received blob {System.Environment.GetEnvironmentVariable("BlobContainerName")}: {filename}");

            var copyFileName = $"{Path.GetFileNameWithoutExtension(filename)}.copy.{Path.GetExtension(filename)}";
            log.LogInformation($"Copying blob to {System.Environment.GetEnvironmentVariable("BlobOutputContainerName")}: {copyFileName}");

            var copy = outputContainer.GetBlockBlobReference($"{Path.GetFileNameWithoutExtension(filename)}.copy.{Path.GetExtension(filename)}");
            await copy.UploadFromStreamAsync(blob);

            log.LogInformation($"Copied blob {copyFileName}");
        }
    }
}