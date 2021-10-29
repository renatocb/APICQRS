namespace CQRS.Domain.Dtos
{
    public enum JsonIgnoreCondition
{
    // Property is never ignored during serialization or deserialization.
    Never = 0,
    // Property is always ignored during serialization and deserialization.
    Always = 1,
    // If the value is the default, the property is ignored during serialization.
    // This is applied to both reference and value-type properties and fields.
    WhenWritingDefault = 2,
    // If the value is null, the property is ignored during serialization.
    // This is applied only to reference-type properties and fields.
    WhenWritingNull = 3,
}
}