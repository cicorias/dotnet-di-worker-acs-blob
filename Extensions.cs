
using Azure.Identity;
using Microsoft.Extensions.Azure;

public static class HostExtensions
{

    internal static IServiceCollection ConfigureAzureClients(this IServiceCollection services, IConfiguration configuration)
    {
        var endpointStorage = configuration[Constants.StorageEndpoint];
        var endpointAcs = configuration[Constants.AcsEndpoint];
        ArgumentNullException.ThrowIfNull(endpointStorage, nameof(endpointStorage));
        ArgumentNullException.ThrowIfNull(endpointAcs, nameof(endpointAcs));
        services.AddAzureClients(builder =>
        {
            builder.AddBlobServiceClient(new Uri(endpointStorage)).WithCredential(new DefaultAzureCredential());
            builder.AddEmailClient(new Uri(endpointAcs)).WithCredential(new DefaultAzureCredential());
        });
        return services;
    }
}