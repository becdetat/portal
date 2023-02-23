using Microsoft.AspNetCore.Mvc;
using Domain;
using Domain.Dtos;
using Api.Controllers.Requests;

namespace Api.Controllers;

[ApiController]
[Route("api/navigation-item")]
public class NavigationItemController : ControllerBase
{
    private readonly INavigationItemRepository _repo;

    public NavigationItemController(INavigationItemRepository repo) => _repo = repo;

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(NavigationItemDto))]
    public async Task<IActionResult> CreateNavigationItem([FromBody] CreateNavigationItemRequest request)
    {
        var navigationItem = await _repo.CreateNavigationItem(
            request.ProfileId, 
            request.Title, 
            request.Icon, 
            request.Url);

        return Ok(navigationItem);
    }
}


