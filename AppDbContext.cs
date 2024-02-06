using Microsoft.EntityFrameworkCore;

public class AppDbContext : DbContext
{
    public DbSet<Channel> Channels { get; set; }
    public DbSet<Video> Videos { get; set; }
    public DbSet<Tag> Tags { get; set; }
    public DbSet<Show> Shows { get; set; }
    public DbSet<Episode> Episodes { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite("Filename=db.sqlite3");
    }
}
