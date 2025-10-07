using MongoDB.Bson.Serialization.Attributes;

namespace GettingStarted.Types;

[BsonIgnoreExtraElements]
public class GradeEntry
{
    [BsonElement("date")]
    public DateTime Date { get; set; }

    [BsonElement("grade")]
    public string Grade { get; set; }

    [BsonElement("score")]
    public float Score { get; set; }
}
