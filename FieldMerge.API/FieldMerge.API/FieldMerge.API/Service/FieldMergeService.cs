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

    public Task<bool> SaveFieldMergePattern(FieldCodePattern fieldCodeConversionPattern)
    {
        throw new NotImplementedException();
    }

    public Task<bool> SaveFieldMergePatterns(List<FieldCodePattern> fieldCodeConversionPattern)
    {
        throw new NotImplementedException();
    }

    public async Task<List<FieldCodePattern>> LoadFieldCodeConversionPatterns()
    {
        return await _fieldCodeContext.FieldCodePatterns
            .ToListAsync();
    }
}