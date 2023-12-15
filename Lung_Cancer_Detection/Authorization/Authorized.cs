using Paymentauthorization.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Paymentauthorization.Authorization
{
    public class Authorized : ActionFilterAttribute, IExceptionFilter
    {
        public Role Role { get; set; } = (Role.SystemAdmin);
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            var controller = filterContext.Controller as Controller;
            if (controller != null)
            {
                VTSAuth auth = new VTSAuth() { CookieValues = new UserInfo { } };
                if (!auth.LoadDataFromCookies())
                {
                    filterContext.Result = new RedirectToRouteResult(new RouteValueDictionary(new { controller = "Login", action = "Index", returnUrl = filterContext.HttpContext.Request.Url.ToString() }));
                    return;
                }
                else if (auth.CookieValues.RoleId != Role || !auth.CookieValues.IsActive)
                {
                    filterContext.Result = new RedirectToRouteResult(new RouteValueDictionary(new { controller = "Login", action = "Index", returnUrl = filterContext.HttpContext.Request.Url.ToString() }));

                }
                filterContext.Controller.TempData["UserInfo"] = auth.CookieValues;
                filterContext.Controller.TempData["UserId"] = auth.CookieValues.UserId;


                if (auth.CookieValues.RoleId == Role.SystemAdmin)
                    filterContext.Controller.TempData["Layout"] = "~/Views/Shared/_Layout.cshtml";
                else
                    filterContext.Controller.TempData["Layout"] = "~/Views/Shared/_Admin.cshtml";

            }
        }

        public void OnException(ExceptionContext filterContext)
        {
            filterContext.Result = new RedirectToRouteResult(new RouteValueDictionary(new { controller = "Login", action = "Index", returnUrl = filterContext.HttpContext.Request.Url.ToString() }));
        }
    }
    public class UserInfo
    {
        public int UserId { get; set; }
        public Role RoleId { get; set; }
        public string UserName { get; set; }
        public bool IsActive { get; set; }

        //public SettingsDto Settings { get; set; }
        public string Name { get; set; }
        public int OderID { get; set; }

    }
    public class PrunchOrder
    {
        public int OderID
        {
            get; set;
        }

    }
}