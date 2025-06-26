namespace Backend_Biblioteca.Core.Application.ViewModels.Book;

public class SaveBookViewModel
{
    public string BookName { get; set; }
    public bool IsAvailable { get; set; }
    public int Quantity { get; set; }
    public decimal RentPrice { get; set; }
    public string AuthorName { get; set; }
    public string GenreName { get; set; }
    public string? Description { get; set; }
}