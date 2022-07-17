using MassTransit;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Directory.ReportBusConfigurator;
using Directory.ReportBusConfigurator.Models;
using Directory.ReportService.Business.DTOs;
using Directory.ReportService.DataAccess.RSContext;



namespace Directory.ReportService.Presentation.Events
{
    public class ReportConsumer : IConsumer<IReportConsumer>
    {
       public ReportConsumer()
        {
            var bus = BusConfigurator.ConfigureBus(factory =>
            {
                factory.ReceiveEndpoint(RabbitMqConstants.ConsumerQueue, endpoint =>
                {
                    endpoint.Consumer<ReportConsumer>();
                });
            });

            bus.StartAsync();
        }
        public async Task Consume(ConsumeContext<IReportConsumer> context)
        {

            Console.WriteLine($"The report has been saved in the database.");

            using (var reportContext = new ReportServiceContext())
            {
                var report = reportContext.Reports.FirstOrDefault(x => x.ID == context.Message.ID);

                if (report != null)
                {
                    var client = new RestClient("https://localhost:44311/api/userservice/userservice/createReport");
                    client.Timeout = -1;
                    var request = new RestRequest(Method.POST);
                    request.AddHeader("Content-Type", "application/json");
                    var data = new AddressDto();
                    data.Address = report.Location;
                    request.AddParameter("application/json", JsonConvert.SerializeObject(data), ParameterType.RequestBody);
                    IRestResponse response = client.Execute(request);
                    var responsedata = JsonConvert.DeserializeObject<ReportInfoFromUserDto>(response.Content);
                    report.PhoneCount = responsedata.PhoneCount;
                    report.PersonCount = responsedata.UserCount;
                    report.status = DataAccess.Entities.ReportEnum.Completed;
                    reportContext.Reports.Update(report);
                    await reportContext.SaveChangesAsync();
                }
            }
        }
    }
}

