using FieldMerge.Data.DTO;

namespace FieldMerge.API.Interfaces;

public interface IFieldMergeService
{
    Task<bool> SaveFieldMergePattern(FieldCodeConversionPattern fieldCodeConversionPattern);
    
    Task<bool> SaveFieldMergePatterns(List<FieldCodeConversionPattern> fieldCodeConversionPattern);

    Task<List<FieldCodeConversionPattern>> LoadFieldCodeConversionPatterns();
}