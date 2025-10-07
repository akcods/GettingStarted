using GettingStarted.Types;
namespace GettingStarted.Data;
public record StaticData
{
    public int id = 1;
    public List<Book> Books = new List<Book>() {
        new Book(1, "Hello Javascript", new Author("John")),
        new Book(2, "Hello Python", new Author("Tony")),
        new Book(3, "Hello CSharp", new Author("Harry")),
    };
}