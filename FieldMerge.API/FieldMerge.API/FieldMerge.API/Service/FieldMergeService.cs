using FieldMerge.API.Interfaces;
using FieldMerge.Data.DTO;

namespace FieldMerge.API.Service;

public class FieldMergeService : IFieldMergeService
{
    public Task<bool> SaveFieldMergePattern(FieldCodeConversionPattern fieldCodeConversionPattern)
    {
        throw new NotImplementedException();
    }

    public Task<bool> SaveFieldMergePatterns(List<FieldCodeConversionPattern> fieldCodeConversionPattern)
    {
        throw new NotImplementedException();
    }

    public Task<List<FieldCodeConversionPattern>> LoadFieldCodeConversionPatterns()
    {
        throw new NotImplementedException();
    }
}