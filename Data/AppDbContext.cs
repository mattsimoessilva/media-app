using Microsoft.EntityFrameworkCore;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }

    public DbSet<Channel> Channels { get; set; }
    public DbSet<Video> Videos { get; set; }
    public DbSet<Tag> Tags { get; set; }
    public DbSet<Show> Shows { get; set; }
    public DbSet<Episode> Episodes { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite("Filename=db.sqlite3");
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        // Configure the Tag entity to use "meu_aplicativo_tag" as the table name
        modelBuilder.Entity<Tag>()
            .ToTable("meu_aplicativo_tag");

        modelBuilder.Entity<Channel>()
            .ToTable("meu_aplicativo_channel");

        modelBuilder.Entity<Episode>()
            .ToTable("meu_aplicativo_episode");

        modelBuilder.Entity<Show>()
            .ToTable("meu_aplicativo_show");

        modelBuilder.Entity<Video>()
            .ToTable("meu_aplicativo_video");

        
    }
}



