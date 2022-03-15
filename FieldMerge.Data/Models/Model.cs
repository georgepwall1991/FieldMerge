using Microsoft.EntityFrameworkCore;

namespace FieldMerge.Data.Models;

public class FieldCodeContext : DbContext
{
    public FieldCodeContext()
    {
        const Environment.SpecialFolder folder = Environment.SpecialFolder.LocalApplicationData;
        var path = Environment.GetFolderPath(folder);
        DbPath = Path.Join(@"C:\Users\georg\OneDrive\Documents\SQLLite", "blogging.db");
    }

    public DbSet<FieldCodePattern> FieldCodePatterns { get; set; }
    private string DbPath { get; }

    // The following configures EF to create a Sqlite database file in the
    // special "local" folder for your platform.
    protected override void OnConfiguring(DbContextOptionsBuilder options)
    {
        options.UseSqlite($"Data Source={DbPath}");
    }
}