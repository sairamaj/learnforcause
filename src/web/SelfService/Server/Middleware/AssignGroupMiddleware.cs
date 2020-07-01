using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using SelfService.Shared;

namespace SelfService.Server.Middleware
{
    class AssignGroupMiddleware
    {
        private readonly RequestDelegate next;
        private readonly ILogger<AssignGroupMiddleware> logger;

        public AssignGroupMiddleware(RequestDelegate next, ILogger<AssignGroupMiddleware> logger)
        {
            this.next = next ?? throw new System.ArgumentNullException(nameof(next));
            this.logger = logger ?? throw new System.ArgumentNullException(nameof(logger));
        }

        public async Task InvokeAsync(HttpContext context)
        {
            await Task.Delay(0);
            this.logger.LogInformation($"InvokeAsync ...{context.User.GetEmail()}");
            if( context.User.GetEmail() == "sairamaj@gmail.com"
            || context.User.GetEmail() == "srijamalapuram@gmail.com")
            {
                this.logger.LogInformation("Adding administrators role");
                ((ClaimsIdentity)context.User.Identity)
                        .AddClaim(new Claim(ClaimTypes.Role, "Administrators", ClaimValueTypes.String));
            }

            // Call the next delegate/middleware in the pipeline
            await next(context);
        }
    }
}