using Microsoft.AspNetCore.Http;

namespace EasyTrain_P2Gr1.Controllers.Outils
{
    public class LayoutResolver
    {
        public static string GetRoleLayout(HttpContext httpContext)
        {
            if (httpContext.User.IsInRole("Client"))
            {
                return "_LayoutClient";
            }
            else if (httpContext.User.IsInRole("Coach"))
            {
                return "_LayoutCoach";
            }
            else if (httpContext.User.IsInRole("Gestionnaire"))
            {
                return "_LayoutGestionnaire";
            }
            return "";
        }
    }
}
