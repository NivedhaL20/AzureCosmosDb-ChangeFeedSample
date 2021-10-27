using System;
using System.Collections.Generic;
using Microsoft.Azure.Documents;
using Microsoft.Azure.WebJobs;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using SendGrid;
using SendGrid.Helpers.Mail;
using Tracker.Models.ViewModel;

namespace Tracker.ChangeFeedFuncApp
{
    public static class SendEmailCosmosDbTrigger
    {
        [FunctionName("SendEmailCosmosDbTrigger")]
        public static void Run([CosmosDBTrigger(
            databaseName: "changefeed-db",
            collectionName: "order",
            ConnectionStringSetting = "DbConnection",
            CreateLeaseCollectionIfNotExists = true,
            LeaseCollectionName = "lease",
            LeaseCollectionPrefix = "sendemail-")]IReadOnlyList<Document> inputs, ILogger log)
        {
            if (inputs != null && inputs.Count > 0)
            {
                log.LogInformation("First document Id " + inputs[0].Id);
                foreach (var input in inputs)
                {
                    SendEmail(input, log);
                }
                log.LogInformation("Executed Cosmos db trigger successfully");
            }
        }

        private static void SendEmail(Document input, ILogger log)
        {
            var order = JsonConvert.DeserializeObject<OrderViewModel>(input.ToString());
            
            var apiKey = Environment.GetEnvironmentVariable("SendGridKey"); 

            var client = new SendGridClient(apiKey);
            
            var from = new EmailAddress("vignesh.gnd@gmail.com");
            var subject = "Order Status";
            var to = new EmailAddress("nivebiju11@gmail.com");
            var htmlContent = $"Your order status is {order.Status} and the product is <strong> {order.ProductName}</strong>";
            
            var msg = MailHelper.CreateSingleEmail(from, to, subject, "", htmlContent);
            
            var response = client.SendEmailAsync(msg).GetAwaiter().GetResult();
            log.LogInformation("Response from SendGrid " + response.ToString());
        }
    }
}
