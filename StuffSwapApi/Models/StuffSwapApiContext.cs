using Microsoft.EntityFrameworkCore;

namespace StuffSwapApi.Models;

public class StuffSwapApiContext : DbContext
{
    public DbSet<User> Users { get; set; }
    public DbSet<Tool> Tools { get; set; }

    public StuffSwapApiContext(DbContextOptions<StuffSwapApiContext> options) : base(options) { }

    //include seed data
    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.Entity<Restaurant>()
    .HasData(
      new Tool { ToolId = 1, ToolName = "Weedwacker", ToolDescription = "A good weedwacker", ToolStatus = "Available", ReturnDate = "None", ToolPhoto = "www.photo.com/example1.png", UserId = 1 },
      new Tool { ToolId = 2, ToolName = "Gardening Tools", ToolDescription = "Great gardening tools", ToolStatus = "Available", ReturnDate = "None", ToolPhoto = "www.photo.com/example2.png", UserId = 2 },
      new Tool { ToolId = 3, ToolName = "Rope for rock climbing", ToolDescription = "A good climbing rope", ToolStatus = "Available", ReturnDate = "None", ToolPhoto = "www.photo.com/example3.png", UserId = 3 },
      new Tool { ToolId = 4, ToolName = "Sprinkler", ToolDescription = "Great Sprinkler", ToolStatus = "Available", ReturnDate = "None", ToolPhoto = "www.photo.com/example4.png", UserId = 1 },
    );

        builder.Entity<User>()
        .HasData(
          new User { UserId = 1, UserName = "sampleUser@gmail.com", Password = "samplePass" },
          new User { UserId = 2, UserName = "taylor@gmail.com", Password = "password" },
          new User { UserId = 3, UserName = "coolguy@gmail.com", Password = "password" }
        );
    }
}
