using Microsoft.AspNetCore.Authorization;

namespace AspNetCoreIdentityApp.Web.Requirements
{
    public class ExchangeExpireRequirement:IAuthorizationRequirement
    {
    }


    public class ExchangeExpireRequirementHandler : AuthorizationHandler<ExchangeExpireRequirement>
    {
        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, ExchangeExpireRequirement requirement)
        {            
            if (!context.User.HasClaim(x => x.Type == "ExchangeExpireDate"))
            {
                context.Fail();
            }

            var ExchangeExpireDate = context.User.FindFirst("ExchangeExpireDate");

            //ExchangeExpireDate


            return Task.CompletedTask;
        }
    }
}
