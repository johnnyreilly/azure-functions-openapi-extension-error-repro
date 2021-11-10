using System;
using System.Net;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.Azure.WebJobs.Extensions.OpenApi.Core.Attributes;
using Microsoft.Azure.WebJobs.Extensions.OpenApi.Core.Enums;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;

namespace NetCoreApp31.FunctionApp.IoC
{
    public class Alias : System.Collections.Generic.Dictionary<string, string> {
    }

    public partial class IsBroken {
        public Alias? Attributes { get; set; } = default!;
    }

    public partial class IsWorking {
        public System.Collections.Generic.Dictionary<string, string>? Attributes { get; set; } = default!;
    }

    public class NetCoreApp31HttpTrigger
    {

        public NetCoreApp31HttpTrigger()
        {
        }

        // [OpenApiOperation(operationId: "greeting", tags: new[] { "greeting" }, Summary = "Greetings", Description = "This shows a welcome message.", Visibility = OpenApiVisibilityType.Important)]
        // [OpenApiParameter("name", Type = typeof(string), In = ParameterLocation.Query, Visibility = OpenApiVisibilityType.Important)]
        // [OpenApiResponseWithBody(statusCode: HttpStatusCode.OK, contentType: "application/json", bodyType: typeof(IsBroken), Summary = "The response", Description = "This returns the response")]
        // [OpenApiResponseWithBody(statusCode: HttpStatusCode.OK, contentType: "application/json", bodyType: typeof(IsWorking), Summary = "The response", Description = "This returns the response")]

        [OpenApiOperation(operationId: nameof(Run), Summary = "Creates a bank account", Description = "Creates a bank account", Visibility = OpenApiVisibilityType.Important)]
        // [OpenApiParameter("name", Type = typeof(string), In = ParameterLocation.Query, Visibility = OpenApiVisibilityType.Important)]
        [OpenApiResponseWithBody(statusCode: HttpStatusCode.OK, contentType: "application/json", bodyType: typeof(IsBroken), Summary = "The response", Description = "This returns the response")]

        [FunctionName("NetCoreApp31HttpTrigger")]
        public async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Function, "get", Route = "greetings")] HttpRequest req,
            ILogger log)
        {
            await Task.Yield();

            log.LogInformation("C# HTTP trigger function processed a request.");

            string name = req.Query["name"];

            return new OkObjectResult("instance");
        }
    }
}
