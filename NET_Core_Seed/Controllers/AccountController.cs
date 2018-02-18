using System.Threading.Tasks;
using AutoMapper;
using BusinessLogic.Interfaces;
using DataAccess;
using Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using NET_Core_Seed.Helpers;
using NET_Core_Seed.Models;

namespace NET_Core_Seed.Controllers
{
    [Produces("application/json")]
    [Route("api/Account")]
    public class AccountsController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly IMapper _mapper;
        private readonly ILogger _logger;


        public AccountsController(UserManager<AppUser> userManager, 
            IMapper mapper, ApplicationDbContext appDbContext,
            ILogger<AccountsController> logger)
        {
            _userManager = userManager;
            _mapper = mapper;
            _logger = logger;
        }

        // POST api/accounts
        [HttpPost]
        public async Task<IActionResult> Post([FromBody]RegistrationViewModel model)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                var userIdentity = _mapper.Map<AppUser>(model);

                //Create the user
                ILogicUsers lusers = Business.UsersLogic(_userManager);
                var result = await lusers.RegisterUser(userIdentity, model.Password);
                if (!result.Succeeded)
                    return new BadRequestObjectResult(Errors.AddErrorsToModelState(result, ModelState));

                //Create the customer
                ILogicCustomers lcust = Business.CustomersLogic();
                await lcust.RegisterCustomer(new Customer { IdentityId = userIdentity.Id });

                return new OkObjectResult("Account created");
            }
            catch (System.Exception ex)
            {
                _logger.LogError(LoggingEvents.GenericError, ex.Message);
                return StatusCode(500, ex);
            }
        }
    }
}