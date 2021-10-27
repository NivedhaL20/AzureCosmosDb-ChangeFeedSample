using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Tracker.Services.Interface;
using Tracker.Models.ViewModel;

namespace Tracker.ChangeFeedFuncApp
{
    public class PostTrackerDataHttpTrigger
    {
        private readonly IOrderService _orderService;
        public PostTrackerDataHttpTrigger(IOrderService orderService)
        {
            _orderService = orderService;
        }

        [FunctionName("PostTrackerDataHttpTrigger")]
        public async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Function, "get", "post", Route = null)] HttpRequest req,
            ILogger log)
        {
            log.LogInformation("C# HTTP trigger function processed a request.");

            var requestBody = await new StreamReader(req.Body).ReadToEndAsync();

            var data = JsonConvert.DeserializeObject<OrderViewModel>(requestBody);

            var order = await _orderService.AddOrUpdateAsync(data);
            
            return new OkObjectResult(order);
        }
    }
}
