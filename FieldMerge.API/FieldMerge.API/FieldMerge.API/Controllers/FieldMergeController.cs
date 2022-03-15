using FieldMerge.API.Interfaces;
using FieldMerge.API.Request;
using FieldMerge.Data.Models;
using Microsoft.AspNetCore.Mvc;

namespace FieldMerge.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class FieldMergeController : ControllerBase
{
    private readonly IFieldMergeService _fieldMergeService;

    public FieldMergeController(IFieldMergeService fieldMergeService)
    {
        _fieldMergeService = fieldMergeService;
    }

    [HttpGet]
    public async Task<ActionResult<List<FieldCodePattern>>> GetAllPatterns()
    {
        var fieldConversionPatterns = await _fieldMergeService.LoadFieldCodeConversionPatterns();
        if (fieldConversionPatterns.Any())
            return Ok(fieldConversionPatterns);

        return BadRequest("No patterns available");
    }

    [HttpPost]
    [Route("SavePattern")]
    public async Task<ActionResult> SavePattern([FromBody] PatternRequest patternRequest)
    {
        var (patternFrom, patternTo) = patternRequest;
        var saved = await _fieldMergeService.SaveFieldMergePattern(new FieldCodePattern
        {
            PatternFrom = patternFrom,
            PatternTo = patternTo
        });
        if (saved)
            return Ok("Saved Successfully");

        return BadRequest("Pattern already exists");
    }

    [HttpPost]
    [Route("SavePatterns")]
    public async Task<ActionResult> SavePatterns([FromBody] List<PatternRequest> patternRequests)
    {
        var saved = await _fieldMergeService
            .SaveFieldMergePatterns(patternRequests.Select(o => new FieldCodePattern
            {
                PatternFrom = o.PatternFrom,
                PatternTo = o.PatternTo
            }).ToList());
        if (saved)
            return Ok("Saved Successfully");

        return BadRequest("Pattern already exists");
    }
}