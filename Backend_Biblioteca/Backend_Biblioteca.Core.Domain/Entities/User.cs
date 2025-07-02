using Backend_Biblioteca.Core.Domain.Entities.Common;

namespace Backend_Biblioteca.Core.Domain.Entities;

public class User : CommonUse
{
    public string Email { get; set; }
    public string PasswordHash { get; set; }
    public string Role { get; set; } = "User";

    public ICollection<BorrowedBook> BorrowedBooks { get; set; } = new List<BorrowedBook>();
}
