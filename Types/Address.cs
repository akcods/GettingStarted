using MongoDB.Bson.Serialization.Attributes;

namespace GettingStarted.Types;

[BsonIgnoreExtraElements]
public class Address
{
    [BsonElement("building")]
    public string Building { get; set; }

    [BsonElement("coord")]
    public double[] Coordinates { get; set; }

    [BsonElement("street")]
    public string Street { get; set; }

    [BsonElement("zipcode")]
    public string ZipCode { get; set; }
}
