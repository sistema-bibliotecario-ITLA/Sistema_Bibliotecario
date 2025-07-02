using Backend_Biblioteca.Core.Domain.Entities.Common;

namespace Backend_Biblioteca.Core.Domain.Entities;

public class Genre : CommonUse
{
    public ICollection<Book> Books { get; set; } = new List<Book>();
}