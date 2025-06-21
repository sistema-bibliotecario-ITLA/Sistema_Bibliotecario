using Backend_Biblioteca.Core.Application.Interfaces.Repositories;
using Backend_Biblioteca.Infrastructure.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;

namespace Backend_Biblioteca.Infrastructure.Persistence.Repositories;

public class GenericRepository<T> : IGenericRepository<T> where T : class
{
    private readonly ApplicationDbContext _context;
    private readonly DbSet<T> _dbSet;
    public GenericRepository(ApplicationDbContext context)
    {
        _context = context;
        _dbSet = context.Set<T>();
    }
    public async Task<IEnumerable<T>> GetAll()
    {
        var entities = await _dbSet.ToListAsync();
        return entities;
    }

    public async Task<T> GetByIdAsync(int id)
    {
        var entity = await _dbSet.FindAsync(id);
        return entity;
    }

    public async Task CreateAsync(T entity)
    {
        await _dbSet.AddAsync(entity);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateAsync(T entity)
    {
        _dbSet.Update(entity);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(int id)
    {
        var entity = await GetByIdAsync(id);

        if (entity == null)
            throw new IndexOutOfRangeException("Entity not found");
        
        _dbSet.Remove(entity);
        await _context.SaveChangesAsync();
    }
}