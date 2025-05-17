using Microsoft.EntityFrameworkCore;
using SimTimer.Models;

namespace SimTimer.Data.DbContexts;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    { }

    public DbSet<TimerModel> Timers { get; set; }
}
