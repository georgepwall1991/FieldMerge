namespace FieldMerge.DTO
{
    public class FieldCodePatternFromToDTO
    {
        public string FromPattern { get; set; }
        public string ToPattern { get; init; } // Make init, only ever set in constructor (will save ui to db and just load up in constructor
    }
}