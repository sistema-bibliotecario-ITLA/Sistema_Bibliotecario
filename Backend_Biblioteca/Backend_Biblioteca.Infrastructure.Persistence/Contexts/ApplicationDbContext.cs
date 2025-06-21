using Backend_Biblioteca.Core.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Backend_Biblioteca.Infrastructure.Persistence.Contexts;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {
    }
    
    public DbSet<User> Users { get; set; }
}