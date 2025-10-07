using MongoDB.Bson.Serialization.Attributes;

namespace GettingStarted.Types;

[BsonIgnoreExtraElements]
public class GradeEntry
{
    public DateTime Date { get; set; }

    public string Grade { get; set; }

    public float? Score { get; set; }
}
