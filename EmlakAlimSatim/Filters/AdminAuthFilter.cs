using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace EmlakAlimSatim.Filters
{
    public class AdminAuthFilter : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            var admin = context.HttpContext.Session.GetString("AdminUsername");

            if (admin == null)
            {
                context.Result = new RedirectToActionResult("Index", "Login", new { area = "Admin" });
            }
        }
    }
}