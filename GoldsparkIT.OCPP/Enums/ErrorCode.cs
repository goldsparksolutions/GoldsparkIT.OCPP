using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace GoldsparkIT.OCPP.Enums;

[JsonConverter(typeof(StringEnumConverter))]
public enum ErrorCode
{
    NotImplemented,
    NotSupported,
    InternalError,
    ProtocolError,
    SecurityError,
    FormationViolation,
    PropertyConstraintViolation,
    OccurrenceConstraintViolation,
    TypeConstraintViolation,
    GenericError
}
