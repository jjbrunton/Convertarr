using Microsoft.EntityFrameworkCore;

namespace Convertarr.Data
{
   public class ConvertarrContext : DbContext
{
    public DbSet<MediaFile> Files { get; set; }

    public string DbPath { get; }

    public ConvertarrContext()
    {
        DbPath = "/config/convertarr.db";
    }

    // The following configures EF to create a Sqlite database file in the
    // special "local" folder for your platform.
    protected override void OnConfiguring(DbContextOptionsBuilder options)
        => options.UseSqlite($"Data Source={DbPath}");
}
}