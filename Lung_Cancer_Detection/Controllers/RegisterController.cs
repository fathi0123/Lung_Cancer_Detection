using Lung_Cancer_Detection.Models;
using Paymentauthorization.Utilities;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Lung_Cancer_Detection.Controllers
{
    public class RegisterController : Controller
    {
        Canser_ProjectEntities db = new Canser_ProjectEntities();
        // GET: Register
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Index(User u)
        {
            var pass = Security.Encrypt(u.Password);
            var ff = db.Users.OrderByDescending(x => x.id).FirstOrDefault();


            HttpPostedFileBase ProPicture = Request.Files["ImageLink"];
            if (ff == null)
            {
                u.ImageLink = "/Uploads/ServicesAtt/" + "1";
            }
            else
            {
                u.ImageLink = "/Uploads/ServicesAtt/" + (ff.id + 1);

            }
            if (!Directory.Exists(Server.MapPath(u.ImageLink)))
                Directory.CreateDirectory(Server.MapPath(u.ImageLink));
            u.ImageLink = u.ImageLink + "/" + u.name + ".jpg";
            ProPicture.SaveAs(Server.MapPath(u.ImageLink));

            var Role = 2;
            User user = new User()
            {
                name = u.name,
                pho = u.pho,
                UserName = u.UserName,
                Password = pass,
                RoleId = Role,
                ISDeleted = false,
                ImageLink = u.ImageLink

            };


            db.Users.Add(user);
            db.SaveChanges();
            TempData["success"] = "تم حفظ البيانات بنجاح";

            return RedirectToAction("singPage", "Signin");

        }


    }
}