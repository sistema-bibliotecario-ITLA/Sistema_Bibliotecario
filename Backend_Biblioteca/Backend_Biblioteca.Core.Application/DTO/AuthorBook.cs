using Backend_Biblioteca.Core.Domain.Entities.Common;

namespace Backend_Biblioteca.Core.Application.ViewModels.Book;

public class AuthorBook : CommonUse
{
    public string GenreBookName { get; set; }
    public string ImgUrl { get; set; }
}