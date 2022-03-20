using FieldMerge.Data.Models;

namespace FieldMerge.API.Interfaces;

public interface IFieldMergeService
{
    Task<bool> SaveFieldMergePattern(FieldCodePattern fieldCodeConversionPattern);

    Task<bool> SaveFieldMergePatterns(IEnumerable<FieldCodePattern> fieldCodeConversionPattern);

    Task<List<FieldCodePattern>> LoadFieldCodeConversionPatterns();

    Task<bool> DeleteFieldCodePattern(int id);
}