using GettingStarted.Data;
using GettingStarted.Types;
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
        return new Book(4, "C# in depth.", new Author("Jon Skeet"));
    }

    public Book GetBookById(int id)
    {
        return new StaticData().Books.FirstOrDefault(b => b.id == id) ?? throw new GraphQLException($"Book id: {id} not found");
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
