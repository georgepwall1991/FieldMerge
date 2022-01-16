using FieldMerge.Data.DTO;
using Microsoft.EntityFrameworkCore;

namespace FieldMerge.Data.DbContext;

public class FieldMergeDbContext : Microsoft.EntityFrameworkCore.DbContext
{
    public FieldMergeDbContext() : base()
    {
        
    }
    
    public DbSet<FieldCodeConversionPattern> FieldCodeConversionPatterns { get; set; }

}