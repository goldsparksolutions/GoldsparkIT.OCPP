using GoldsparkIT.OCPP.Enums;

namespace GoldsparkIT.OCPP.Exceptions;

internal class RemoteOperationException : Exception
{
    public RemoteOperationException(ErrorCode errorCode, string errorDescription, object? errorDetails = null)
    {
        ErrorCode = errorCode;
        ErrorDescription = errorDescription;
        ErrorDetails = errorDetails;
    }

    public object? ErrorDetails { get; set; }

    public ErrorCode ErrorCode { get; set; }

    public string ErrorDescription { get; set; }

    public override string Message => $"[{ErrorCode}] {ErrorDescription}";
}
