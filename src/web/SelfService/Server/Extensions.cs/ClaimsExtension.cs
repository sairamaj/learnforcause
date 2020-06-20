using System.Linq;
using System.Security.Claims;

namespace SelfService.Server.Extensions
{
    public static class ClaimsExtension {
        public static string GetName(this ClaimsPrincipal principal){
            if( principal == null){
                return "NA";
            }

            var nameClaim = principal.Claims.FirstOrDefault(c => c.Type == "name");
            return nameClaim == null ? "unknown" : nameClaim.Value;
        }
    }
}