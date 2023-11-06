using Microsoft.AspNetCore.Http;

namespace EasyTrain_P2Gr1.Controllers.Outils
{
    public class RoleResolver 
    {
        public static string GetRoleLayout(HttpContext httpContext)
        {
            string role = GetRole(httpContext);
            if (role.Length != 0)
            {
                return $"_Layout{role}";
            }
            return "";
        }

        public static string GetRole(HttpContext httpContext)
        {
            if (httpContext.User.IsInRole("Client"))
            {
                return "Client";
            }
            else if (httpContext.User.IsInRole("Coach"))
            {
                return "Coach";
            }
            else if (httpContext.User.IsInRole("Gestionnaire"))
            {
                return "Gestionnaire";
            }
            return "";
        }
    }
}
