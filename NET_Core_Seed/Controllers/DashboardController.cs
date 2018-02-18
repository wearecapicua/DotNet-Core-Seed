using System;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using DataAccess;
using Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using NET_Core_Seed.Helpers;

namespace NET_Core_Seed.Controllers
{
    [Produces("application/json")]
    [Route("api/Dashboard")]
    [Authorize(Policy = "ApiUser")]
    [Route("api/[controller]/[action]")]
    public class DashboardController : Controller
    {
        private readonly ClaimsPrincipal _caller;
        private readonly ApplicationDbContext _appDbContext;
        private readonly ILogger _logger;

        public DashboardController(UserManager<AppUser> userManager,
            ApplicationDbContext appDbContext,
            IHttpContextAccessor httpContextAccessor,
            ILogger<DashboardController> logger)
        {
            _caller = httpContextAccessor.HttpContext.User;
            _appDbContext = appDbContext;
            _logger = logger;
        }

        // GET api/dashboard/home
        [HttpGet]
        public async Task<IActionResult> Home()
        {
            try
            {
                // retrieve the user info
                var user = _caller.Claims.Single(c => c.Type == "id");

                //verify userId is not null
                if (user != null && !String.IsNullOrWhiteSpace(user.Value))
                {
                    Customer c = await Business.CustomersLogic().GetCustomer(user.Value);
                    if (c != null)
                    {
                        return new OkObjectResult(new
                        {
                            c.Identity.FirstName,
                            c.Identity.LastName,
                            c.Gender
                        });
                    }
                }

                return new NotFoundResult();
            }
            catch (System.Exception ex)
            {
                _logger.LogError(LoggingEvents.GenericError, ex.Message);
                return StatusCode(500, ex);
            }
        }

        [HttpPost]
        public async Task<IActionResult> TestEmail()
        {
            try
            {
                throw new Exception();
                int test = await Business.ProvidersLogic().SendEmail();

                return Ok();
            }
            catch (Exception ex)
            {
                await Errors.LogError(ex, _logger);
                //_logger.LogError(LoggingEvents.GenericError, ex.Message);
                return StatusCode(500, ex);
            }
        }
    }
}