using GettingStarted.Types;
using MongoDB.Driver;

namespace GettingStarted.Query;

[QueryType]
public class Query
{
    private readonly IMongoCollection<User> _users;
    private readonly IMongoCollection<Book> _books;
    private readonly IMongoCollection<Restaurant> _restaurantsCollection;
    
    public Query(IMongoDatabase mongoDatabase)
    {
        _books = mongoDatabase.GetCollection<Book>("books");
        _users = mongoDatabase.GetCollection<User>("users");
        _restaurantsCollection = mongoDatabase.GetCollection<Restaurant>("restaurants");
    }
    public async Task<List<Book>> GetBooks()
    {
        var allBooks = await _books.Find(_ => true).ToListAsync();
        return allBooks;
    }

    public async Task<Book> GetBookById(string id)
    {
        var book = _books.Find(b => b.Id!.Equals(id));
        return await book.FirstOrDefaultAsync();
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
