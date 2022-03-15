using System.ComponentModel.DataAnnotations;

namespace FieldMerge.Data.Models;

public class FieldCodePattern
{
    [Key] public int PatternId { get; set; }

    public string PatternFrom { get; set; }
    public string PatternTo { get; set; }
}