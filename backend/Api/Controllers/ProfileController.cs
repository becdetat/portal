using Microsoft.AspNetCore.Mvc;
using Domain;
using Domain.Dtos;
using Api.Controllers.Requests;

namespace Api.Controllers;

[ApiController]
[Route("api/profile")]
public class ProfileController : ControllerBase
{
    private readonly IPortalRepository _repo;

    public ProfileController(IPortalRepository repo) => _repo = repo;

    [HttpGet("all")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<ProfileDto>))]
    public async Task<IActionResult> GetAllProfiles(CancellationToken cancellationToken)
    {
        var profiles = await _repo.GetAllProfiles(cancellationToken);

        return Ok(profiles);
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ProfileDto))]
    public async Task<IActionResult> CreateProfile([FromBody] CreateProfileRequest request, CancellationToken cancellationToken)
    {
        var profile = await _repo.CreateProfile(request.Name);

        return Ok(profile);
    }

    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(FullProfileDto))]
    public async Task<IActionResult> GetProfile(int id)
    {
        var profile = await _repo.GetFullProfile(id);

        return Ok(profile);
    }
}


