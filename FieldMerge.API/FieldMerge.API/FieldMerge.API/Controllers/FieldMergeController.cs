using FieldMerge.API.Interfaces;
using FieldMerge.Data.DTO;
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
    public async Task<ActionResult<List<FieldCodeConversionPattern>>> GetAllPatterns()
    {
        var fieldConversionPatterns = await _fieldMergeService.LoadFieldCodeConversionPatterns();
        if (fieldConversionPatterns.Any())
            return Ok(fieldConversionPatterns);

        return BadRequest("No patterns available");
    }
}