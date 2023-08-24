using Microsoft.EntityFrameworkCore;

namespace StuffSwapApi.Models;

public class StuffSwapApiContext : DbContext
{
    public DbSet<AppUser> AppUsers { get; set; }
    public DbSet<Tool> Tools { get; set; }
    public DbSet<ToolUser> ToolUsers { get; set; }

    public StuffSwapApiContext(DbContextOptions<StuffSwapApiContext> options) : base(options) { }

    //include seed data
    protected override void OnModelCreating(ModelBuilder builder)
    {

        builder.Entity<Tool>()
        .HasData(
        new Tool { ToolId = 1, ToolName = "Weedwacker", ToolDescription = "A good weedwacker", ToolStatus = "Available", ReturnDate = "None", ToolPhoto = "https://sgp1.digitaloceanspaces.com/fluxdigi/yourhousegarden/uploads/FI-best-weed-eater.jpg", AppUserId = 1 },
        new Tool { ToolId = 2, ToolName = "Roller Skates", ToolDescription = "Used Size 7 Rollerskates", ToolStatus = "Available", ReturnDate = "None", ToolPhoto = "https://s3-media0.fl.yelpcdn.com/bphoto/PBU2rkgpvKUrTVQyug0mfw/o.jpg", AppUserId = 2 },
        new Tool { ToolId = 3, ToolName = "Rope for rock climbing", ToolDescription = "A good climbing rope, only taken a few falls", ToolStatus = "Available", ReturnDate = "None", ToolPhoto = "www.photo.com/example3.png", AppUserId = 3 },
        new Tool { ToolId = 4, ToolName = "Kitchen Mixer", ToolDescription = "Kitchen Mixer with all attachemnts", ToolStatus = "Available", ReturnDate = "None", ToolPhoto = "https://i.ebayimg.com/images/g/vZ4AAOSwSm5f90tw/s-l500.jpg", AppUserId = 1 }
        );

        builder.Entity<AppUser>()
        .HasData(
          new AppUser { AppUserId = 1, UserName = "sampleUser@gmail.com", UserPassword = "samplePass" },
          new AppUser { AppUserId = 2, UserName = "taylor@gmail.com", UserPassword = "password" },
          new AppUser { AppUserId = 3, UserName = "coolguy@gmail.com", UserPassword = "password" }
        );
    }
}
