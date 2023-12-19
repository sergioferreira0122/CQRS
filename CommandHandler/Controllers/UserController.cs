using CommandHandler.Domain;
using CommandHandler.Domain.Interfaces;
using CommandHandler.UseCases.CreateUser;
using Microsoft.AspNetCore.Mvc;

namespace CommandHandler.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        private readonly ILogger<UserController> _logger;
        private readonly ICommandHandler<CreateUserCommand> _commandHandler;

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

            if (result.IsSuccess)
            {
                return Ok();
            }

            return BadRequest(result);
        }
    }
}