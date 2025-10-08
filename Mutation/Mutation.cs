using GettingStarted.Types;
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
        var newBook = new Book
        {
            Title = book.Title,
            Author = new Author
            {
                Name = book.Author.Name
            }
        };

        await _books.InsertOneAsync(newBook);
        return book;
    }
}