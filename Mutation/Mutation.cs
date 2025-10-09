using GettingStarted.Types;
using MongoDB.Bson;
using MongoDB.Driver;

namespace GettingStarted.Mutation;

[MutationType]
public class Mutation
{
    private readonly IMongoCollection<Book> _books;

    public Mutation(IMongoDatabase mongoDatabase)
    {
        _books = mongoDatabase.GetCollection<Book>("books");
    }
    public async Task<Book> AddBookAsync(Book book)
    {
        await _books.InsertOneAsync(book);
        return book;
    }

    public async Task<Book> UpdateBookAsync(Book book)
    {
        var filter = Builders<Book>.Filter.Eq(b => b.Id, book.Id);
        await _books.ReplaceOneAsync(filter, book);
        return book;
    }

    public async Task<bool> DeleteBookAsync(string id)
    {
        var result = await _books.DeleteOneAsync(b => b.Id.Equals(id));
        return result.DeletedCount > 0;
    }
}