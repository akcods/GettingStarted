using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

[BsonIgnoreExtraElements]
public class User
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public ObjectId Id { get; init; }
    [BsonElement]
    public required string Name { get; init; }
    [BsonElement]
    public required string Email { get; init; }
    [BsonElement]
    public required string Password { get; init; }
};