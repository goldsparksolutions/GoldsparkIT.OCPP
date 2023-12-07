using Microsoft.AspNetCore.Mvc;

namespace GoldsparkIT.OCPP.SampleServer.Controllers;

public class WebsocketController : ControllerBase
{
    private readonly ILogger<WebsocketController> _logger;
    private readonly OcppServer _ocppServer;

    public WebsocketController(OcppServer server, ILogger<WebsocketController> logger)
    {
        _ocppServer = server;
        _logger = logger;
    }

    [Route("/ws/{clientId:regex(.*)}")]
    public async Task Websocket([FromRoute] string clientId)
    {
        if (HttpContext.WebSockets.IsWebSocketRequest)
        {
            _logger.LogInformation("Client connected: {clientId}", clientId);

            using var webSocket = await HttpContext.WebSockets.AcceptWebSocketAsync();

            _ocppServer.Start(webSocket);

            new ManualResetEvent(false).WaitOne();
        }
        else
        {
            _logger.LogInformation("Bad request for client ID {clientId}", clientId);

            HttpContext.Response.StatusCode = StatusCodes.Status400BadRequest;
        }
    }
}
