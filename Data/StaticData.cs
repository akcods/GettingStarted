using GettingStarted.Types;
namespace GettingStarted.Data;
public record StaticData
{
    public int id = 1;
    public List<Book> Books = new List<Book>();
}