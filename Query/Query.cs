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
        _users = mongoDatabase.GetCollection<User>("users");
        _restaurantsCollection = mongoDatabase.GetCollection<Restaurant>("restaurants");
    }
    public Book GetBook()
    {
        return new Book
        {
            Id = ObjectId.GenerateNewId().ToString(),
            Title = "Hello dotnet",
            Author = new Author
            {
                Name = "John"
            }
        };
    }

    public Book GetBookById(ObjectId id)
    {
        return new StaticData().Books.FirstOrDefault(b => b.Id == id.ToString()) ?? throw new GraphQLException($"Book id: {id} not found");
    }

    public async Task<Restaurant> GetRestaurantAsync()
    {
        var restaurant = await _restaurantsCollection.Find(_ => true).FirstOrDefaultAsync();
        return restaurant;
    }
    
    public async Task<List<Restaurant>> GetRestaurantsAsync()
    {
        var allRestaurants = await _restaurantsCollection.Find(_ => true).ToListAsync();
        return allRestaurants;

    }

    public async Task<List<User>> GetUsers()
    {
        var users = await _users.Find(_ => true).ToListAsync();
        return users;
    }
}
