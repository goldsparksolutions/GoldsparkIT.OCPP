namespace GoldsparkIT.OCPP.SampleServer.Exceptions;

public class NotStartedException : Exception
{
    public override string Message => "The OCPP server has not been started";
}
