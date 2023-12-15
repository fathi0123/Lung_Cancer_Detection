using Lung_Cancer_Detection.DTO;
using Lung_Cancer_Detection.Models;
using Paymentauthorization.Authorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Lung_Cancer_Detection.Controllers
{
    public class AdminController : Controller
    {
        Canser_ProjectEntities db = new Canser_ProjectEntities();

        // GET: Admin
        public ActionResult Index()
        {
            return View();
        }

        #region  المرض 

        public ActionResult Desece()
        {
            ViewBag.Desece = db.Deseces.Where(x => x.IS_Deleted == false).ToList();
            return View(ViewBag.Desece);
        }
        public ActionResult ADD_Desece()
        {
            return View();
        }
        public ActionResult insertDe(Desece D)
        {
            Desece desece = new Desece()
            {
                name = D.name,
                IS_Deleted = false,
                ImageLink = null
            };
            db.Deseces.Add(desece);
            db.SaveChanges();
            return RedirectToAction("Desece", "Admin");
        }

        #endregion

        #region  تعريف النسب  

        public ActionResult DegreePersentlist()
        {

            var Combo_DesecesIteams = db.Degrees_Of_Deseess.Select(x => new DeseeseInfo
            {
                id = x.id,
                name = x.Desece.name
            });

            ViewBag.dataDeseces = Combo_DesecesIteams;

            return View(ViewBag.dataDeseces);
        }
        public ActionResult DegreePersent()
        {

            var Combo_DesecesIteams = db.Deseces.Where(x => x.IS_Deleted == false).ToList();

            ViewBag.dataDeseces = Combo_DesecesIteams;

            return View();
        }
        [HttpPost]
        public ActionResult insertPersents(Degrees_Of_Deseess DOD)
        {
            int uid = 0;
            var ff = db.Degrees_Of_Deseess.OrderByDescending(x => x.id).FirstOrDefault();
            if (ff == null)
            {
                uid = 1;
            }
            else
            {
                uid = ff.id + 1;
            }

            #region   Calc Menimum Result 

            int SMOKING = (int)DOD.SMOKING;
            int WHEEZING = (int)DOD.WHEEZING;
            int SWALLOWING_DIFFICULTY = (int)DOD.SWALLOWING_DIFFICULTY;
            int ALCOHOL_CONSUMING = (int)DOD.ALCOHOL_CONSUMING;
            int YELLOW_FINGERS = (int)DOD.YELLOW_FINGERS;
            int SHORTNESS_OF_BREATH = (int)DOD.SHORTNESS_OF_BREATH;
            int ALLERGY = (int)DOD.ALLERGY;
            int ANXIETY = (int)DOD.ANXIETY;
            int CHEST_PAIN = (int)DOD.CHEST_PAIN;
            int CHRONIC_DISEASE = (int)DOD.CHRONIC_DISEASE;
            int COUGHING = (int)DOD.COUGHING;
            int FATIGUE = (int)DOD.FATIGUE;
            int PEER_PRESSURE = (int)DOD.PEER_PRESSURE;

            int Total_Deseces = SMOKING + WHEEZING + SWALLOWING_DIFFICULTY + ALCOHOL_CONSUMING + YELLOW_FINGERS +
                SHORTNESS_OF_BREATH + ALLERGY + ANXIETY + CHEST_PAIN + CHRONIC_DISEASE + COUGHING + FATIGUE + PEER_PRESSURE;
            #endregion

            Degrees_Of_Deseess degrees_Of_Deseess = new Degrees_Of_Deseess()
            {
                id = uid,
                testid = DOD.testid,
                SMOKING = DOD.SMOKING,
                YELLOW_FINGERS = DOD.YELLOW_FINGERS,
                WHEEZING = DOD.WHEEZING,
                SWALLOWING_DIFFICULTY = DOD.SWALLOWING_DIFFICULTY,
                ALCOHOL_CONSUMING = DOD.ALCOHOL_CONSUMING,
                SHORTNESS_OF_BREATH = DOD.SHORTNESS_OF_BREATH,
                ALLERGY = DOD.ALLERGY,
                ANXIETY = DOD.ANXIETY,
                CHEST_PAIN = DOD.CHEST_PAIN,
                CHRONIC_DISEASE = DOD.CHRONIC_DISEASE,
                COUGHING = DOD.COUGHING,
                Desece = DOD.Desece,
                FATIGUE = DOD.FATIGUE,
                PEER_PRESSURE = DOD.PEER_PRESSURE,
                Total= Total_Deseces
            };
            db.Degrees_Of_Deseess.Add(degrees_Of_Deseess);
            db.SaveChanges();
            return RedirectToAction("DegreePersent", "Admin");
        }
        //public ActionResult insertDe(Desece D)
        //{
        //    Desece desece = new Desece()
        //    {
        //        name = D.name,
        //        IS_Deleted = false,
        //        ImageLink =null
        //    };
        //    db.Deseces.Add(desece);
        //    db.SaveChanges();   
        //    return RedirectToAction("Desece","Admin");
        //}

        #endregion

        String USERNAME;
        int useri;

        #region  نتائج اختبار 
        public ActionResult TestSupmitList()
        {
            VTSAuth auth = new VTSAuth();
            var sd = auth.LoadDataFromCookies();
            if (sd != null)
            {
                var ee = auth.CookieValues.UserId;
                var i = auth.CookieValues.UserName;
                useri = ee;
                USERNAME = i;

            }
            ViewBag.Results = db.Results.Where(x => x.ISWatinting == true)
                .Select(x => new ResultInfo
                {
                    _ID = x.id,
                    uid = x.Userid,
                    name = x.User.name,
                    testType = x.Desece.name,
                    date = (DateTime)x.Testdate,
                    Result = (bool)x.ISDone
                });
            ;
            var rr = ViewBag.Results;
            return View(ViewBag.Results);
        }
        #endregion
        
        #region  محدد  نتائج اختبار 
        public ActionResult PationtResult(int id )
        {
            ViewBag.Desece = db.Test_Result.Where(x => x.C_id == id).ToList();
            return View(ViewBag.Desece);
        }
        #endregion


        #region الحالات 
        // GET: Admin
        public ActionResult CustomarsList()
        {

            ViewBag.Customars = db.Users.Where(x => x.ISDeleted == false)
                .Where(x => x.RoleId == 2)
                .ToList();
            return View();
        }
        public ActionResult CustomarsListWhere(User u)
        {

            ViewBag.Customars = db.Users.Where(x => x.name.Contains(u.name)).Where(x => x.ISDeleted == false)
                .Where(x => x.RoleId == 2)
                .ToList();
            return View();
        }
        #endregion
    }
}