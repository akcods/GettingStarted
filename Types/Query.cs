namespace GettingStarted.Types;

[QueryType]
public class Query
{
    public Book GetBook() { 
        return new Book(4, "C# in depth.", new Author("Jon Skeet"));
    }

    public Book GetBookById(int id)
    {
        return new Data().Books.FirstOrDefault(b => b.id == id) ?? throw new GraphQLException($"Book id: {id} not found");
    }
}
