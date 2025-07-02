using Backend_Biblioteca.Core.Application.ViewModels.Book;

namespace Backend_Biblioteca.Core.Application.ViewModels.Genre;

public class GenreViewModel
{
    public int Id { get; set; }
    public string GenreName { get; set; }
    public ICollection<GenreBook> Books { get; set; } = new List<GenreBook>();
}