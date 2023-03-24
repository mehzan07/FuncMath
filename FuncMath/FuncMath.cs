using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Microsoft.Azure.WebJobs.Host;
using Newtonsoft.Json.Linq;
using System.Xml.Linq;

namespace FuncMath
{
    public static class Multiple
    {
        [FunctionName("Multiple")]
        public static IActionResult Run(
             [HttpTrigger(AuthorizationLevel.Function, "get",
            Route = null)] HttpRequest req,
             ILogger log)
        {
            log.LogInformation("C# HTTP trigger function processed a request.");

            int x = Convert.ToInt32(req.Query["x"]);
            int y = Convert.ToInt32(req.Query["y"]);

            var multiple = x * y;
            string responseMessage = string.Empty;

            if (x == 0 && y == 0)
            {
                responseMessage = "This HTTP triggered function executed successfully. Pass x and y  in the query string for a personalized response.";
                return new OkObjectResult(responseMessage);
            }
            else
            {
                responseMessage = "Result =" + multiple.ToString() + " This HTTP triggered function executed successfully.";
                return new OkObjectResult(responseMessage);
            }
        }

    }
}

