using System;
using System.Collections.Generic;
using System.Linq;
using DocumentFormat.OpenXml;
using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Wordprocessing;
using FieldMerge.DTO;

namespace FieldMerge;

/***
 The class is a bit crappy and hacky, threw something together quickly. Can be refactored but as it's a simple application it seems fine for now.
 TODO: 1 - Create UI and allow this path to be set via a browse button (add some validation on document type) - potentially allow for importing of multiple documents to iterate over
 TODO: 2 - Create UI allowing for patterns to be added in bulk and then be executed against documents
 TODO: 3 - Could potentially set a location to output the file and have a before / after file instead of overwriting the original (removes risk and also good for manual comparisons to see if desired logic applied
 TODO: Refactor the whole code and add some unit tests to ensure full coverage 

***/
internal static class Program
{
    //TODO: 1
    private const string FileToOpen = @"C:\\Users\georg\Documents\WordDoc\George.docx";
    private static readonly List<FieldCodePatternFromToDTO> PatternsToChange = new();
    private static readonly Dictionary<string, FieldCodePatternFromToDTO> ToChange = new();

    private static void Main()
    {
        //TODO: 2
        PatternsToChange.Add(new FieldCodePatternFromToDTO
        {
            FromPattern = "FIELDCODE1/FIELDCODE2/FIELDCODE4/",
            ToPattern = "FIELDCODE2/FIELDCODE4/FIELDCODE1/"
        });


        using var document = WordprocessingDocument.Open(FileToOpen, true);
        document.ChangeDocumentType(WordprocessingDocumentType.Document);

        if (SetToChangeDictionary(document)) return;

        UpdateDocumentBasedOnPatterns(document);
    }

    private static void UpdateDocumentBasedOnPatterns(WordprocessingDocument document)
    {
        if (document.MainDocumentPart == null) return;

        foreach (var topLevelDescendents in document.MainDocumentPart.Document.Descendants<Paragraph>()
                     .Where(o => o.ParagraphId != null && ToChange.ContainsKey(o.ParagraphId)))
        foreach (var secondLevelDescendents in topLevelDescendents.Descendants<Run>())
        foreach (var fieldCode in secondLevelDescendents.Descendants<FieldCode>())
        {
            var (_, value) = ToChange.FirstOrDefault(o => o.Key == topLevelDescendents.ParagraphId);
            var patternToChangeTo = PatternsToChange.FirstOrDefault(o => o.FromPattern.Equals(value.FromPattern));
            if (patternToChangeTo is null) continue;

            var left = value.FromPattern.Split('/').Where(o => o.Length > 0).ToList();
            var right = patternToChangeTo.ToPattern.Trim().Split('/').Where(o => o.Length > 0).ToList();
            if (left.Count != right.Count) throw new ApplicationException("Pattern has to be same length");

            for (var i = 0; i < left.Count; i++)
            {
                var leftItem = left[i];
                if (fieldCode.Text != leftItem) continue;

                var textToChangeTo = right[i];
                Console.WriteLine($"{fieldCode.Text} has been changed to {textToChangeTo}");
                fieldCode.Text = textToChangeTo;
            }
        }

        //TODO: 3 
        document.MainDocumentPart.Document.Save();
    }

    private static bool SetToChangeDictionary(WordprocessingDocument document)
    {
        if (document.MainDocumentPart == null) return true;
        foreach (var topLevelDescendents in document.MainDocumentPart.Document.Descendants<Paragraph>())
        foreach (var secondLevelDescendents in topLevelDescendents.Descendants<Run>())
        foreach (var fieldCode in secondLevelDescendents.Descendants<FieldCode>())
            if (topLevelDescendents.ParagraphId != null && ToChange.ContainsKey(topLevelDescendents.ParagraphId))
                ToChange.First(o => o.Key.Equals(topLevelDescendents.ParagraphId)).Value.FromPattern +=
                    $"{fieldCode.Text.Trim()}/";
            else if (topLevelDescendents.ParagraphId != null)
                ToChange.Add(topLevelDescendents.ParagraphId,
                    new FieldCodePatternFromToDTO { FromPattern = $"{fieldCode.Text.Trim()}/", ToPattern = "" });
        return false;
    }
}