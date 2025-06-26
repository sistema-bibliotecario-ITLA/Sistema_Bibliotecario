using Backend_Biblioteca.Core.Application.Interfaces.Repositories;
using Backend_Biblioteca.Core.Domain.Entities;
using Backend_Biblioteca.Infrastructure.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;

namespace Backend_Biblioteca.Infrastructure.Persistence.Repositories;

public class BookRepository : GenericRepository<Book>, IBookRepository
{
    private readonly ApplicationDbContext _context;

    public BookRepository(ApplicationDbContext context) : base(context)
    {
        _context = context;
    }

    public override async Task<IEnumerable<Book>> GetAllAsync()
    {
        var books = await _context.Books
            .Include(g => g.Genre)
            .Include(a => a.Author)
            .ToListAsync();
        
        return books;
    }

    public override async Task<Book> GetByIdAsync(int id)
    {
        var book = await _context.Books
            .Include(g => g.Genre)
            .Include(a => a.Author)
            .FirstOrDefaultAsync(b => b.Id == id);
        
        return book;
    }
    
}