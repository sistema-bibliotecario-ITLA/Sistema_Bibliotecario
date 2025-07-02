using Backend_Biblioteca.Core.Application.Interfaces;
using Backend_Biblioteca.Core.Domain.Entities;
using Backend_Biblioteca.Infrastructure.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;

namespace Backend_Biblioteca.Infrastructure.Persistence.Repositories;

public class GenreRepository : GenericRepository<Genre>, IGenreRepository
{
    private readonly ApplicationDbContext _context;

    public GenreRepository(ApplicationDbContext context) : base(context)
    {
        _context = context;
    }

    public override async Task<IEnumerable<Genre>> GetAllAsync()
    {
        var genres = await _context.Genres
            .Include(b => b.Books)
            .ToListAsync();
        
        return genres;
    }
    public async Task<Genre> GetByNameAsync(string name)
    {
        var genre = await _context.Genres
            .Include(b => b.Books)
            .FirstOrDefaultAsync(g => g.Name == name);
        return genre;
    }
}