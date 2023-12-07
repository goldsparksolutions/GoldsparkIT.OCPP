namespace GoldsparkIT.OCPP.Exceptions;

internal class NoSendMessageHandlerSetException : Exception
{
    public override string Message => "No send message handler has been set";
}
