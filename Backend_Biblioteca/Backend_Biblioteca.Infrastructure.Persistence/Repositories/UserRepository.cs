using Backend_Biblioteca.Core.Application.Interfaces.Repositories;
using Backend_Biblioteca.Core.Domain.Entities;
using Backend_Biblioteca.Infrastructure.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;

namespace Backend_Biblioteca.Infrastructure.Persistence.Repositories;

public class UserRepository : GenericRepository<User>, IUserRepository
{
    private readonly ApplicationDbContext _context;
    public UserRepository(ApplicationDbContext context) : base(context)
    {
        _context = context;
    }

    public Task<User> GetByEmail(string email)
    {
        var user = _context.Users.FirstOrDefaultAsync(e => e.Email == email);
        return user;
    }
}