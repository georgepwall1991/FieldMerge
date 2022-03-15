using FieldMerge.Data.Models;

Console.WriteLine("Hello, World!");
var fieldCodeContext = new FieldCodeContext();
fieldCodeContext.FieldCodePatterns.RemoveRange(fieldCodeContext.FieldCodePatterns);
await fieldCodeContext.SaveChangesAsync();
await fieldCodeContext.FieldCodePatterns.AddAsync(new FieldCodePattern
{
    PatternFrom = "FIELDCODE1/FIELDCODE2/FIELDCODE4",
    PatternTo = "FIELDCODE2/FIELDCODE4/FIELDCODE1"
});
await fieldCodeContext.SaveChangesAsync();