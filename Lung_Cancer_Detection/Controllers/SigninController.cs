using Lung_Cancer_Detection.Models;
using Paymentauthorization.Authorization;
using Paymentauthorization.Enums;
using Paymentauthorization.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Lung_Cancer_Detection.Controllers
{
    public class SigninController : Controller
    {
        // GET: Signin
        Canser_ProjectEntities db = new Canser_ProjectEntities();
        public ActionResult singPage()
        {
            VTSAuth auth = new VTSAuth();
            var check = auth.CheckCookies();

            return View();
        }
        [HttpPost]
        public ActionResult Loginpage(User u)
        {
            var pass = Security.Encrypt(u.Password);
            var FindUsername = db.Users.Where(x => x.UserName == u.UserName && x.Password == pass).FirstOrDefault();
            if (FindUsername != null)
            {
                VTSAuth auth = new VTSAuth();
                var user = new UserInfo
                {
                    UserId = FindUsername.id,
                    RoleId = (Role)FindUsername.RoleId,
                    UserName = FindUsername.UserName,
                };

                auth.SaveToCookies(user);
                var sd = auth.LoadDataFromCookies();
                
                    var ee = auth.CookieValues.UserId;
                    var i = auth.CookieValues.UserName;

                
                string returnUrl = Request.QueryString["returnUrl"];
                if (!string.IsNullOrWhiteSpace(returnUrl))
                    return Redirect(returnUrl);

                else if (user.RoleId == Role.SystemAdmin)
                {
                    TempData["success"] = "تم حفظ البيانات بنجاح";
                    return RedirectToAction("Index", "Admin");
                }
                else
                {
                    TempData["success"] = "تم حفظ البيانات بنجاح";
                    return RedirectToAction("HomeUser", "Home");
                }

            }
            else
            {
                return RedirectToAction("Loginpage", "Login");

            }
        }

    }
}