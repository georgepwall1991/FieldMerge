using FieldMerge.API.Interfaces;
using FieldMerge.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace FieldMerge.API.Service;

public class FieldMergeService : IFieldMergeService
{
    private readonly FieldCodeContext _fieldCodeContext;

    public FieldMergeService(FieldCodeContext fieldCodeContext)
    {
        _fieldCodeContext = fieldCodeContext;
    }

    public async Task<bool> SaveFieldMergePattern(FieldCodePattern fieldCodeConversionPattern)
    {
        await _fieldCodeContext.FieldCodePatterns.AddAsync(fieldCodeConversionPattern);
        await _fieldCodeContext.SaveChangesAsync();
        return true;
    }

    public async Task<bool> SaveFieldMergePatterns(List<FieldCodePattern> fieldCodeConversionPattern)
    {
        await _fieldCodeContext.FieldCodePatterns.AddRangeAsync(fieldCodeConversionPattern);
        await _fieldCodeContext.SaveChangesAsync();
        return true;
    }

    public async Task<List<FieldCodePattern>> LoadFieldCodeConversionPatterns()
    {
        return await _fieldCodeContext.FieldCodePatterns
            .ToListAsync();
    }
}