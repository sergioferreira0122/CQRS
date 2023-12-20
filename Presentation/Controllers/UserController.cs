using App.Abstractions;
using App.UserUseCases.CreateUser;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Presentation.Controllers;

[ApiController]
[Route("[controller]")]
public class UserController : ControllerBase
{
    private readonly ICommandHandler<CreateUserCommand> _commandHandler;
    private readonly ILogger<UserController> _logger;

    public UserController(ILogger<UserController> logger, ICommandHandler<CreateUserCommand> commandHandler)
    {
        _commandHandler = commandHandler;
        _logger = logger;
    }

    [HttpGet]
    public IActionResult Get()
    {
        return Ok();
    }

    [HttpPost]
    public async Task<IActionResult> AddUser([FromBody] CreateUserCommand createUserCommand)
    {
        var result = await _commandHandler.HandleAsync(createUserCommand);

        if (result.IsSuccess) return Ok();

        return BadRequest(result);
    }
}