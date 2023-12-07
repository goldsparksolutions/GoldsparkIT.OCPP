using Microsoft.AspNetCore.WebSockets;

namespace GoldsparkIT.OCPP.SampleServer;

public static class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        builder.WebHost.ConfigureKestrel(serverOptions => { serverOptions.ListenAnyIP(9400); });

        builder.Services.AddWebSockets(_ => { });

        builder.Services.AddControllers();

        builder.Services.AddOcpp();

        builder.Services.AddTransient<OcppServer>();

        var app = builder.Build();

        app.UseWebSockets();

        app.MapControllers();

        app.Run();
    }
}
