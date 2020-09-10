using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;

namespace Local.Functions
{
    public static class HttpTriggeredFunction
    {
        [FunctionName("Http")]
        public static async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Anonymous, "get", "post")] HttpRequest request,
            ILogger log)
        {
            string name = request.Query["name"];

            string requestBody = await new StreamReader(request.Body).ReadToEndAsync();
            if (!String.IsNullOrEmpty(requestBody))
            {
                var data = System.Text.Json.JsonSerializer.Deserialize<Dictionary<string, string>>(requestBody);
                if (data.ContainsKey("name"))
                {
                    name = data["name"];
                }
            }

            return new OkObjectResult($"Received HTTP {request.Method}: {name}");
        }
    }
}
