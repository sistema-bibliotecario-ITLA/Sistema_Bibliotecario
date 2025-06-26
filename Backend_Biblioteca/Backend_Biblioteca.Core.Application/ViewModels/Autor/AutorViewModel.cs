using System.Collections;
using Backend_Biblioteca.Core.Application.ViewModels.Book;
using Backend_Biblioteca.Core.Domain.Entities;

namespace Backend_Biblioteca.Core.Application.ViewModels.Autor;

public class AutorViewModel
{
    public int Id { get; set; }
    public string AutorName { get; set; }
    public ICollection<AuthorBook> Books { get; set; } = new List<AuthorBook>();
}