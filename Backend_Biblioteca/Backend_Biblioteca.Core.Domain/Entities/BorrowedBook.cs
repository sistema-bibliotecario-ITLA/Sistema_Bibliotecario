namespace Backend_Biblioteca.Core.Domain.Entities;

public class BorrowedBook
{
    public int Id { get; set; }
    public DateTime DateOrder { get; set; } = DateTime.UtcNow;
    public DateTime? ReturnDate { get; set; }

    public int UserId { get; set; }
    public User User { get; set; } = null!;

    public int BookId { get; set; }
    public Book Book { get; set; } = null!;

    public ICollection<Notification> Notifications { get; set; } = new List<Notification>();
}
