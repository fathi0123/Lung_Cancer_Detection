using Paymentauthorization.Authorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Lung_Cancer_Detection.Controllers
{
    public class BaseController : Controller
    {

        protected override void OnActionExecuting(ActionExecutingContext filterContext)
        {

            var controller = filterContext.Controller as Controller;
            if (controller != null)
            {
                VTSAuth auth = new VTSAuth();

                if (auth.LoadDataFromCookies() != null)
                {
                    filterContext.Controller.ViewBag.User_NAme = auth.CookieValues.UserName;

                }
                filterContext.Controller.ViewBag.User_NAme = auth.CookieValues.UserName;




            }

        }

    }
}