using Backend_Biblioteca.Core.Application.Interfaces.Repositories;
using Backend_Biblioteca.Infrastructure.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;

namespace Backend_Biblioteca.Infrastructure.Persistence.Repositories;

public class GenericRepository<T> : IGenericRepository<T> where T : class
{
    protected readonly DbContext _context;
    protected readonly DbSet<T> _dbSet;

    public GenericRepository(DbContext context)
    {
        _context = context;
        _dbSet = context.Set<T>();
    }

    public virtual async Task<IEnumerable<T>> GetAllAsync()
    {
        return await _dbSet.ToListAsync();
    }

    public virtual async Task<T?> GetByIdAsync(int id)
    {
        var entity = await _dbSet.FindAsync(id);
        if (entity == null)
            throw new IndexOutOfRangeException("Entity not found");
        
        return entity;
    }

    public virtual async Task AddAsync(T entity)
    {
        await _dbSet.AddAsync(entity);
        await _context.SaveChangesAsync();
    }

    public virtual async Task Update(T entity)
    {
        _dbSet.Update(entity);
        await _context.SaveChangesAsync();
    }

    public virtual async Task Delete(int id)
    {
        var entity = await GetByIdAsync(id);
        
        if(entity == null)
            throw new Exception("Entity not found");
        
        _dbSet.Remove(entity);
        await _context.SaveChangesAsync();
    }
}
