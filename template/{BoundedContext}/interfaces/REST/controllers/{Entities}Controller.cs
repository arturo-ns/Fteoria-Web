using System.Net.Mime;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Localization;
using Swashbuckle.AspNetCore.Annotations;
using pc217953u20231e795.API.{BoundedContext}.domain.services;
using pc217953u20231e795.API.{BoundedContext}.interfaces.REST.resources;
using pc217953u20231e795.API.Resources;

namespace pc217953u20231e795.API.{BoundedContext}.interfaces.REST.controllers;

/// <summary>
/// Controller for managing {Entities}.
/// </summary>
/// <remarks>Author: {AuthorName}</remarks>
[ApiController]
[Route("api/v1/{UrlSegment}")]
[Produces(MediaTypeNames.Application.Json)]
public class {Entities}Controller : ControllerBase
{
    private readonly I{Entity}CommandService _commandService;
    private readonly IStringLocalizer<SharedResource> _localizer;

    public {Entities}Controller(
        I{Entity}CommandService commandService,
        IStringLocalizer<SharedResource> localizer)
    {
        _commandService = commandService;
        _localizer = localizer;
    }

    /// <summary>
    /// Creates a new {Entity}.
    /// </summary>
    /// <param name="resource">The resource containing the input data.</param>
    /// <returns>The created {Entity} resource.</returns>
    [HttpPost]
    [SwaggerOperation(
        Summary = "Creates a new {Entity}",
        Description = "Adds a new {Entity} to the system.",
        OperationId = "Create{Entity}",
        Tags = new[] { "{Entities}" }
    )]
    [SwaggerResponse(StatusCodes.Status201Created, "The {Entity} was successfully created", typeof({Entity}Resource))]
    [SwaggerResponse(StatusCodes.Status400BadRequest, "The request is invalid")]
    [SwaggerResponse(StatusCodes.Status409Conflict, "A conflict occurred due to business rules")]
    [SwaggerResponse(StatusCodes.Status500InternalServerError, "An unexpected error occurred")]
    public async Task<IActionResult> CreateAsync([FromBody] Create{Entity}Resource resource)
    {
        try
        {
            var result = await _commandService.Handle(resource);
            return StatusCode(StatusCodes.Status201Created, result);
        }
        catch (ArgumentException)
        {
            return BadRequest(new { message = _localizer["InvalidEntityRequest"].Value });
        }
        catch (InvalidOperationException ex)
        {
            return Conflict(new { message = ex.Message });
        }
        catch (Exception)
        {
            return StatusCode(
                StatusCodes.Status500InternalServerError,
                new { message = _localizer["UnexpectedErrorCreatingEntity"].Value });
        }
    }
}
