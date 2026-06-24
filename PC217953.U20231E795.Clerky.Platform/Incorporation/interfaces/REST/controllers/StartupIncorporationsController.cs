using System.Net.Mime;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Localization;
using Swashbuckle.AspNetCore.Annotations;
using PC217953.U20231E795.Clerky.Platform.Incorporation.domain.services;
using PC217953.U20231E795.Clerky.Platform.Incorporation.interfaces.REST.resources;
using PC217953.U20231E795.Clerky.Platform.Resources;

namespace PC217953.U20231E795.Clerky.Platform.Incorporation.interfaces.REST.controllers;

/// <summary>
/// REST controller for managing Startup Incorporations.
/// Exposes endpoints under <c>/api/v1/startup-incorporations</c>.
/// </summary>
/// <remarks>Author: PC217953 U20231E795</remarks>
[ApiController]
[Route("api/v1/startup-incorporations")]
[Produces(MediaTypeNames.Application.Json)]
public class StartupIncorporationsController : ControllerBase
{
    private readonly IStartupIncorporationCommandService _commandService;
    private readonly IStringLocalizer<SharedResource> _localizer;

    /// <summary>
    /// Initializes a new instance of <see cref="StartupIncorporationsController"/>.
    /// </summary>
    /// <param name="commandService">The command service for startup incorporation operations.</param>
    /// <param name="localizer">The string localizer for localized response messages.</param>
    public StartupIncorporationsController(
        IStartupIncorporationCommandService commandService,
        IStringLocalizer<SharedResource> localizer)
    {
        _commandService = commandService;
        _localizer = localizer;
    }

    /// <summary>
    /// Creates a new Startup Incorporation.
    /// </summary>
    /// <param name="resource">The flat resource containing the incorporation data.</param>
    /// <returns>The created startup incorporation including its generated identifier.</returns>
    [HttpPost]
    [SwaggerOperation(
        Summary = "Creates a new Startup Incorporation",
        Description = "Adds a new Startup Incorporation to the Stripe Atlas system. " +
                      "The incorporation identifier must be unique. " +
                      "The completion date must be greater than the start date. " +
                      "The registered capital value must be greater than or equal to zero and the currency must not be blank.",
        OperationId = "CreateStartupIncorporation",
        Tags = new[] { "StartupIncorporations" }
    )]
    [SwaggerResponse(StatusCodes.Status201Created, "The startup incorporation was successfully created", typeof(StartupIncorporationResource))]
    [SwaggerResponse(StatusCodes.Status400BadRequest, "The request contains invalid values")]
    [SwaggerResponse(StatusCodes.Status409Conflict, "A startup incorporation with the same incorporation identifier already exists")]
    [SwaggerResponse(StatusCodes.Status500InternalServerError, "An unexpected error occurred")]
    public async Task<IActionResult> CreateAsync([FromBody] CreateStartupIncorporationResource resource)
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
