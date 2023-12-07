using Microsoft.Extensions.DependencyInjection;

namespace GoldsparkIT.OCPP;

public static class IServiceCollectionExtensions
{
    public static void AddOcpp(this IServiceCollection serviceCollection)
    {
        serviceCollection.AddScoped<JsonServerHandler>();
        serviceCollection.AddScoped<JsonChargePointHandler>();
    }
}
