using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FieldMerge.Data.Models;

public class FieldCodePattern
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int PatternId { get; set; }

    public string PatternFrom { get; set; }
    public string PatternTo { get; set; }
}