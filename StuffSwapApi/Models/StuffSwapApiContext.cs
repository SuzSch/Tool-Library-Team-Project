using Microsoft.EntityFrameworkCore;

namespace StuffSwapApi.Models;

    public class StuffSwapApiContext : DbContext
{
    public DbSet<User> Users { get; set; }

    public StuffSwapApiContext(DbContextOptions<StuffSwapApiContext> options) : base(options) { }

    //include seed data
    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.Entity<User>()
        .HasData(
          new User { UserId = 1, UserName = "sampleUser@gmail.com", Password = "samplePass" }
        );
    }
}
