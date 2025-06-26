namespace Backend_Biblioteca.Core.Domain.Entities;

public class Notification
{
    public int Id { get; set; }

    public int BorrowedBookId { get; set; }
    public BorrowedBook BorrowedBook { get; set; }
}