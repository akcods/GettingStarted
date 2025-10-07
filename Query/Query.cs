using GettingStarted.Data;
using GettingStarted.Types;
using MongoDB.Bson;
using MongoDB.Driver;

namespace GettingStarted.Query;

[QueryType]
public class Query
{
    private readonly IMongoCollection<User> _users;
    private readonly IMongoCollection<Restaurant> _restaurantsCollection;
    
    public Query(IMongoDatabase mongoDatabase)
    {
        _restaurantsCollection = mongoDatabase.GetCollection<Restaurant>("restaurants");
    }
    public Book GetBook()
    {
        return new Book(4, "C# in depth.", new Author("Jon Skeet"));
    }

    public Book GetBookById(int id)
    {
        return new StaticData().Books.FirstOrDefault(b => b.id == id) ?? throw new GraphQLException($"Book id: {id} not found");
    }

    public async Task<Restaurant> GetRestaurantAsync()
    {
        var doc = await _restaurantsCollection.Database
            .GetCollection<BsonDocument>(_restaurantsCollection.CollectionNamespace.CollectionName)
            .Find(new BsonDocument())
            .FirstOrDefaultAsync();

        var filter = Builders<Restaurant>.Filter.Empty;
        var restaurant = await _restaurantsCollection.FindAsync(filter);
        return restaurant.FirstOrDefault();

        //Restaurant res = doc.ToJson();
        //Console.WriteLine(doc.ToJson());

        //return new Restaurant();
    }
    
    public async Task<List<Restaurant>> GetRestaurantsAsync()
    {
        var doc = await _restaurantsCollection.Database
            .GetCollection<BsonDocument>(_restaurantsCollection.CollectionNamespace.CollectionName)
            .Find(new BsonDocument())
            .FirstOrDefaultAsync();

        Console.WriteLine(doc.ToJson());

        try
        {
            var filter = Builders<Restaurant>.Filter.Empty;
            var allRestaurants = await _restaurantsCollection.FindAsync(filter);
            return allRestaurants.ToList();
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message.ToString());
        }

        return new List<Restaurant>();

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
