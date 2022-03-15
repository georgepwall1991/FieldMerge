using FieldMerge.Data.Models;

namespace FieldMerge.API.Interfaces;

public interface IFieldMergeService
{
    Task<bool> SaveFieldMergePattern(FieldCodePattern fieldCodeConversionPattern);

    Task<bool> SaveFieldMergePatterns(List<FieldCodePattern> fieldCodeConversionPattern);

    Task<List<FieldCodePattern>> LoadFieldCodeConversionPatterns();
}