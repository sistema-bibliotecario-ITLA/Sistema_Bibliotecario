using Backend_Biblioteca.Core.Application.Interfaces.Repositories;
using Backend_Biblioteca.Core.Domain.Entities;
using Backend_Biblioteca.Infrastructure.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;

namespace Backend_Biblioteca.Infrastructure.Persistence.Repositories;

public class AutorRepository : GenericRepository<Author>, IAutorRepository
{
    private readonly ApplicationDbContext _context;
    
    public AutorRepository(ApplicationDbContext context) : base(context)
    {
        _context = context;
    }

    public override async Task<IEnumerable<Author>> GetAllAsync()
    {
        return await _context.Authors
            .Include(b => b.Books)
            .ThenInclude(g => g.Genre)
            .ToListAsync();
    }
    

    public async Task<Author> GetWithBooks(int id)
    {
        var author = await _context.Authors
            .Include(a => a.Books)
            .ThenInclude(b => b.Genre)
            .FirstOrDefaultAsync(a => a.Id == id);
        
        return author;
    }

    public async Task<Author> GetWithBooksByName(string name)
    {
        var author = await _context.Authors
            .Include(a => a.Books)
            .ThenInclude(b => b.Genre)
            .FirstOrDefaultAsync(a => a.Name == name);
        
        return author;
    }
}