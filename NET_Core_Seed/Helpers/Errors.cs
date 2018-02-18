using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.Extensions.Logging;
using System;
using Providers;
using System.Threading.Tasks;

namespace NET_Core_Seed.Helpers
{
    public static class Errors
    {
        private static ProvidersFactory factory = new ProvidersFactory();

        public static ModelStateDictionary AddErrorsToModelState(IdentityResult identityResult, ModelStateDictionary modelState)
        {
            foreach (var e in identityResult.Errors)
            {
                modelState.TryAddModelError(e.Code, e.Description);
            }

            return modelState;
        }

        public static ModelStateDictionary AddErrorToModelState(string code, string description, ModelStateDictionary modelState)
        {
            modelState.TryAddModelError(code, description);
            return modelState;
        }


        public static Task LogError(Exception ex, ILogger logger)
        {
            logger.LogError(LoggingEvents.GenericError, ex.Message);
            //we send error to Loggly
            return factory.getLogService().LogError(ex);
        }
    }
}
