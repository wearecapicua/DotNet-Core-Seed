using System.Security.Claims;
using System.Threading.Tasks;
using BusinessLogic.Interfaces;
using Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using NET_Core_Seed.Auth;
using NET_Core_Seed.Helpers;
using NET_Core_Seed.Models;
using Newtonsoft.Json;

namespace NET_Core_Seed.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    public class AuthController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly IJwtFactory _jwtFactory;
        private readonly JwtIssuerOptions _jwtOptions;
        private readonly ILogger _logger;

        public AuthController(UserManager<AppUser> userManager, 
            IJwtFactory jwtFactory, 
            IOptions<JwtIssuerOptions> jwtOptions, 
            ILogger<AuthController> logger)
        {
            _userManager = userManager;
            _jwtFactory = jwtFactory;
            _jwtOptions = jwtOptions.Value;
            _logger = logger;
        }

        // POST api/auth/login
        [HttpPost("login")]
        public async Task<IActionResult> Post([FromBody]CredentialsViewModel credentials)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                var identity = await GetClaimsIdentity(credentials.UserName, credentials.Password);
                if (identity == null)
                {
                    // Credentials are invalid, or account doesn't exist
                    _logger.LogInformation(LoggingEvents.InvalidCredentials, "Invalid Credentials");
                    return BadRequest(Errors.AddErrorToModelState("login_failure", "Invalid username or password.", ModelState));
                }

                var jwt = await Tokens.GenerateJwt(identity, _jwtFactory, credentials.UserName, _jwtOptions, new JsonSerializerSettings { Formatting = Formatting.Indented });
                return new OkObjectResult(jwt);
            }
            catch (System.Exception ex)
            {
                _logger.LogError(LoggingEvents.GenericError, ex.Message);
                return StatusCode(500, ex);
            }
        }

        private async Task<ClaimsIdentity> GetClaimsIdentity(string userName, string password)
        {
            try
            {
                if (string.IsNullOrEmpty(userName) || string.IsNullOrEmpty(password))
                    return await Task.FromResult<ClaimsIdentity>(null);

                // get the user to verifty
                ILogicUsers lusers = Business.UsersLogic(_userManager);
                AppUser userToVerify = await lusers.FindByNameAsync(userName);

                if (userToVerify == null)
                    return await Task.FromResult<ClaimsIdentity>(null);

                // check the credentials
                if (await lusers.CheckPasswordAsync(userToVerify, password))
                {
                    return await Task.FromResult(_jwtFactory.GenerateClaimsIdentity(userName, userToVerify.Id));
                }

                // Credentials are invalid, or account doesn't exist
                _logger.LogInformation(LoggingEvents.InvalidCredentials,"Invalid Credentials");
                return await Task.FromResult<ClaimsIdentity>(null);
            }
            catch
            {
                throw;
            }
        }
    }
}