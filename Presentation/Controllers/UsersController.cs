using App;
using App.Abstractions;
using App.UserHandler;
using App.UserHandler.Commands.CreateUser;
using App.UserHandler.Queries.GetByIdUser;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Presentation.Controllers;

[ApiController]
[Route("api/[controller]")]
public class UsersController : ControllerBase
{
    private readonly ICommandHandler<CreateUserCommand> _createUserCommandHandler;
    private readonly IQueryHandler<GetByIdUserQuery, GetByIdUserResponse> _getByIdUserQueryHandler;
    private readonly ILogger<UsersController> _logger;

    public UsersController(ILogger<UsersController> logger,
        ICommandHandler<CreateUserCommand> createUserCommand,
        IQueryHandler<GetByIdUserQuery, GetByIdUserResponse> getByIdUserQueryHandler)
    {
        _logger = logger;
        _createUserCommandHandler = createUserCommand;
        _getByIdUserQueryHandler = getByIdUserQueryHandler;
    }

    [HttpGet]
    public async Task<IActionResult> GetById(int userId, CancellationToken cancellationToken)
    {
        var response = await _getByIdUserQueryHandler.HandleAsync(new GetByIdUserQuery { Id = userId }, cancellationToken);

        if (response == null) return NotFound();

        return Ok(response);
    }

    [HttpPost]
    public async Task<IActionResult> AddUser([FromBody] CreateUserCommand createUserCommand, CancellationToken cancellationToken)
    {
        var result = await _createUserCommandHandler.HandleAsync(createUserCommand, cancellationToken);

        if (result.IsSuccess) return Ok();

        return HandleUserErrors(result);
    }

    private IActionResult HandleUserErrors(Result result)
    {
        var resultError = result.Error;

        if (resultError.Equals(UserErrors.EmailNotMatch)) return BadRequest(result);
        if (resultError.Equals(UserErrors.PasswordNotMatch)) return BadRequest(result);
        if (resultError.Equals(UserErrors.EmailUsed)) return Conflict(result);

        throw new Exception($"Unexpected error: {resultError}");
    }
}