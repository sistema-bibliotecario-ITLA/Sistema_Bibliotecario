using Backend_Biblioteca.Core.Domain.Entities.Common;

namespace Backend_Biblioteca.Core.Application.ViewModels.Book;

public class BookViewModel : CommonUse
{
    public bool IsAvailable { get; set; }
    public string ImgUrl { get; set; }
    public int Quantity { get; set; }
    public decimal RentPrice { get; set; }
    public string AuthorName { get; set; }
    public string GenreName { get; set; }
    public string? Description { get; set; }
}