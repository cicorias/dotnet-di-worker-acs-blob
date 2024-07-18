using Microsoft.Extensions.Azure;

namespace WorkerTask;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = Host.CreateApplicationBuilder(args);
        builder.Services.AddHostedService<Worker>();
        builder.Services.ConfigureAzureClients(builder.Configuration);
        var host = builder.Build();
        host.Run();
    }
}