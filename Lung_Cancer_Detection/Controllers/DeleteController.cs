using Lung_Cancer_Detection.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Lung_Cancer_Detection.Controllers
{
    public class DeleteController : Controller
    {
        // GET: Delete
        Canser_ProjectEntities db = new Canser_ProjectEntities();

        public ActionResult DeleteClass(int id, Desece schoolClass)
        {
            var School = db.Deseces.FirstOrDefault(x => x.id == id);
            School.IS_Deleted = true;
            db.SaveChanges();
            TempData["success"] = "تم حذف البيانات  بنجاح";

            return RedirectToAction("Desece", "Admin");
        }
          public ActionResult DeleteDegree(int id, Degrees_Of_Deseess schoolClass)
        {
            var School = db.Degrees_Of_Deseess.FirstOrDefault(x => x.id == id);
            School.IS_Deleted = true;
            db.SaveChanges();
            TempData["success"] = "تم حذف البيانات  بنجاح";

            return RedirectToAction("DegreePersentlist", "Admin");
        }

    }
}