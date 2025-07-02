using Backend_Biblioteca.Core.Domain.Entities.Common;

namespace Backend_Biblioteca.Core.Domain.Entities;

public class Book : CommonUse
{
    public bool IsAvailable { get; set; }
    public string? ImgUrl { get; set; }
    public int Quantity { get; set; }
    public string? Description { get; set; }
    public decimal RentPrice { get; set; }
    public int AuthorId { get; set; }
    public Author? Author { get; set; }
    public int GenreId { get; set; }
    public Genre? Genre { get; set; }
}