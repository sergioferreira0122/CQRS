using App;
using App.Abstractions;
using App.UserHandler;
using App.UserHandler.Commands.CreateUser;
using App.UserHandler.Queries.GetByIdUser;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Presentation.Controllers;

[ApiController]
[Route("api/[controller]")]
public class UsersController : ControllerBase
{
    private readonly ILogger<UsersController> _logger;
    private readonly ISender _sender;

    public UsersController(
        ILogger<UsersController> logger,
        ISender sender)
    {
        _logger = logger;
        _sender = sender;
    }

    [HttpGet]
    public async Task<IActionResult> GetById(
        int userId,
        CancellationToken cancellationToken)
    {
        var response = await _sender.Send(new GetByIdUserQuery { Id = userId }, cancellationToken);

        if (response == null) return StatusCode(404, UserErrors.UserNotFound);

        return Ok(response);
    }

    [HttpPost]
    public async Task<IActionResult> AddUser(
        [FromBody] CreateUserCommand createUserCommand,
        CancellationToken cancellationToken)
    {
        var result = await _sender.Send(createUserCommand, cancellationToken);

        if (result.IsSuccess) return StatusCode(201);

        return HandleUserErrors(result);
    }

    private IActionResult HandleUserErrors(Result result)
    {
        var resultError = result.Error;

        if (resultError.Equals(UserErrors.EmailNotMatch)) return StatusCode(400, result);
        if (resultError.Equals(UserErrors.PasswordNotMatch)) return StatusCode(400, result);
        if (resultError.Equals(UserErrors.EmailUsed)) return StatusCode(409, result);

        throw new Exception($"Unexpected error: {resultError}");
    }
}