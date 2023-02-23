using Microsoft.AspNetCore.Mvc;
using Domain;
using Domain.Dtos;
using Api.Controllers.Requests;

namespace Api.Controllers;

[ApiController]
[Route("api/bookmark")]
public class BookmarkController : ControllerBase
{
    private readonly IBookmarkRepository _repo;

    public BookmarkController(IBookmarkRepository repo) => _repo = repo;

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(BookmarkDto))]
    public async Task<IActionResult> CreateBookmark([FromBody] CreateBookmarkRequest request)
    {
        var bookmark = await _repo.CreateBookmark(
            request.ProfileId, 
            request.Title, 
            request.Url);

        return Ok(bookmark);
    }

    [HttpPatch("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(BookmarkDto))]
    public async Task<IActionResult> UpdateBookmark(int id, [FromBody] UpdateBookmarkRequest request)
    {
        var bookmark = await _repo.UpdateBookmark(
            id,
            request.Title,
            request.Url
        );

        return Ok(bookmark);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteBookmark(int id)
    {
        await _repo.DeleteBookmark(id);

        return Ok();
    }
}


