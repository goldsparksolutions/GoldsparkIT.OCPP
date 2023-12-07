namespace GoldsparkIT.OCPP.Exceptions;

internal class NoActiveRequestFoundException : Exception
{
    public NoActiveRequestFoundException(string uniqueId)
    {
        UniqueId = uniqueId;
    }

    public string UniqueId { get; set; }

    public override string Message => $"No active request could be found with ID {UniqueId}";
}
