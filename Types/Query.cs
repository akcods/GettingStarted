using GettingStarted.Data;
using MongoDB.Bson;
using MongoDB.Driver;

namespace GettingStarted.Types;

[QueryType]
public class Query
{
    private readonly IMongoCollection<User> _users;
    public Query(IMongoDatabase mongoDatabase)
    {
        _users = mongoDatabase.GetCollection<User>("users");
    }
    public Book GetBook()
    {
        return new Book(4, "C# in depth.", new Author("Jon Skeet"));
    }

    public Book GetBookById(int id)
    {
        return new StaticData().Books.FirstOrDefault(b => b.id == id) ?? throw new GraphQLException($"Book id: {id} not found");
    }

    public async Task<List<User>> GetUsers()
    {
        var docs = await _users.Database
            .GetCollection<BsonDocument>(_users.CollectionNamespace.CollectionName)
            .Find(new BsonDocument())
            .FirstOrDefaultAsync();

        Console.WriteLine(docs.ToJson());

        var bsonDocs = await _users.Database
            .GetCollection<BsonDocument>(_users.CollectionNamespace.CollectionName)
            .Find(_ => true)
            .ToListAsync();

        foreach (var doc in bsonDocs)
        {
            Console.WriteLine(doc.ToJson());
        }

        var users = await _users.Find(_ => true).ToListAsync();
        return users;
    }
}
