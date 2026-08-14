using GameStore.API.Models;
using Microsoft.EntityFrameworkCore;

namespace GameStore.API.Database;

public class AppDbContext : DbContext
{
    public AppDbContext(
        DbContextOptions<AppDbContext> options
    ) : base(options)
    {
    }

    public DbSet<User> User => Set<User>();
}