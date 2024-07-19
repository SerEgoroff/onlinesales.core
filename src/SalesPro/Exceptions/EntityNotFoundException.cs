using System.Runtime.Serialization;

namespace SalesPro.Exceptions;

[Serializable]
public class EntityNotFoundException : Exception
{
    public EntityNotFoundException(string entityType, string entityUid)
    {
        EntityType = entityType;
        EntityUid = entityUid;
    }

    public string EntityType { get; init; }

    public string EntityUid { get; init; }
}