using System.Net.WebSockets;
using System.Text;
using GoldsparkIT.OCPP.SampleServer.Exceptions;

namespace GoldsparkIT.OCPP.SampleServer;

public class WebSocketHandler
{
    public delegate Task ReceiveMessageHandler(byte[] data);

    private WebSocket? _webSocket;

    public event ReceiveMessageHandler? OnReceiveMessage;

    public void Start(WebSocket webSocket)
    {
        _webSocket = webSocket;
        _ = Task.Run(ReceiveTask);
    }

    private async Task? ReceiveTask()
    {
        if (_webSocket == null)
        {
            throw new NotStartedException();
        }

        var msgBuffer = new List<byte>();

        var buffer = new byte[1024];

        while (_webSocket.State == WebSocketState.Open)
        {
            Array.Clear(buffer);

            var result = await _webSocket.ReceiveAsync(buffer, CancellationToken.None);

            if (result.MessageType == WebSocketMessageType.Close)
            {
                await _webSocket.CloseAsync(WebSocketCloseStatus.NormalClosure, null, CancellationToken.None);
            }
            else
            {
                msgBuffer.AddRange(buffer);

                if (!result.EndOfMessage)
                {
                    continue;
                }

                if (OnReceiveMessage != null)
                {
                    await OnReceiveMessage(msgBuffer.ToArray());
                }

                msgBuffer.Clear();
            }
        }
    }

    public async Task Send(string data)
    {
        if (_webSocket == null)
        {
            throw new NotStartedException();
        }

        await _webSocket.SendAsync(Encoding.UTF8.GetBytes(data), WebSocketMessageType.Text, true, CancellationToken.None);
    }
}
