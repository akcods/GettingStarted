using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace GettingStarted.Types;

[BsonIgnoreExtraElements]
public class Restaurant
{
    public ObjectId Id { get; set; }

    [BsonElement("name")]
    public string Name { get; set; }

    [BsonElement("restaurant_id")]
    public string RestaurantId { get; set; }

    [BsonElement("cuisine")]
    public string Cuisine { get; set; }

    [BsonElement("address")]
    public Address Address { get; set; }

    [BsonElement("borough")]
    public string Borough { get; set; }

    [BsonElement("grades")]
    public List<GradeEntry>? Grades { get; set; }
}