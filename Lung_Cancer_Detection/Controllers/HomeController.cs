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
    public class HomeController : Controller
    {
        Canser_ProjectEntities db = new Canser_ProjectEntities(); 

        public ActionResult Index()
        {
            return View();
        }
        public ActionResult HomeUser()
        {
            return View();
        }

        #region  تقديم اختبار 
        public ActionResult Supmit_A_Test()
        {
            var Combo_Iteams = db.Genders.ToList();

            ViewBag.data = Combo_Iteams;

            var Combo_DesecesIteams = db.Deseces.Where(x => x.IS_Deleted == false).ToList();

            ViewBag.dataDeseces = Combo_DesecesIteams;


            ViewBag.CatigoryGropID = new SelectList("");
            return View();
        }
        int useri;

        public ActionResult InsertTestResult(Test_Result tr)
        {


            int uid = 0;
            var ff = db.Test_Result.OrderByDescending(x => x.C_id).FirstOrDefault();
            if (ff == null)
            {
                uid = 1;
            }
            else
            {
                uid = ff.C_id + 1;
            }
            VTSAuth auth = new VTSAuth();
            var sd = auth.LoadDataFromCookies();
            if (sd != null)
            {
                var ee = auth.CookieValues.UserId;
                var i = auth.CookieValues.UserName;
                useri = ee;

            }

            #region   Calc Menimum Result 

            int SMOKING = (int)tr.SMOKING;
            int WHEEZING = (int)tr.WHEEZING;
            int SWALLOWING_DIFFICULTY = (int)tr.SWALLOWING_DIFFICULTY;
            int ALCOHOL_CONSUMING = (int)tr.ALCOHOL_CONSUMING;
            int YELLOW_FINGERS = (int)tr.YELLOW_FINGERS;
            int SHORTNESS_OF_BREATH = (int)tr.SHORTNESS_OF_BREATH;
            int ALLERGY = (int)tr.ALLERGY;
            int ANXIETY = (int)tr.ANXIETY;
            int CHEST_PAIN = (int)tr.CHEST_PAIN;
            int CHRONIC_DISEASE = (int)tr.CHRONIC_DISEASE;
            int COUGHING = (int)tr.COUGHING;
            int FATIGUE = (int)tr.FATIGUE;
            int PEER_PRESSURE = (int)tr.PEER_PRESSURE;

            int Total_Deseces = SMOKING + WHEEZING + SWALLOWING_DIFFICULTY + ALCOHOL_CONSUMING + YELLOW_FINGERS +
                SHORTNESS_OF_BREATH + ALLERGY + ANXIETY + CHEST_PAIN + CHRONIC_DISEASE + COUGHING + FATIGUE + PEER_PRESSURE;
            #endregion

            Test_Result degrees_Of_Deseess = new Test_Result()
            {
                C_id = uid,
                age = tr.age,
                gender = tr.gender,
                username = tr.username,
                IS_Deleted = false,
                userid = useri,
                testid = tr.testid,
                SMOKING = tr.SMOKING,
                YELLOW_FINGERS = tr.YELLOW_FINGERS,
                WHEEZING = tr.WHEEZING,
                SWALLOWING_DIFFICULTY = tr.SWALLOWING_DIFFICULTY,
                ALCOHOL_CONSUMING = tr.ALCOHOL_CONSUMING,
                SHORTNESS_OF_BREATH = tr.SHORTNESS_OF_BREATH,
                ALLERGY = tr.ALLERGY,
                ANXIETY = tr.ANXIETY,
                CHEST_PAIN = tr.CHEST_PAIN,
                CHRONIC_DISEASE = tr.CHRONIC_DISEASE,
                COUGHING = tr.COUGHING,
                FATIGUE = tr.FATIGUE,
                PEER_PRESSURE = tr.PEER_PRESSURE,
                Datet = DateTime.Now.Date,
                Total_Degree = Total_Deseces
            };
            int tode = 0;
            var ssss = db.Degrees_Of_Deseess.Where(x => x.testid == tr.testid)
                .Sum(x=>x.Total);



            var rrr = "";
            if (ssss > Total_Deseces)
            {
                rrr = " (مصاب)  يرجى زيارة اقرب مركز طبي  ";
            }
            else if (ssss < Total_Deseces)
            {
                rrr = "غير مصاب بالمرض المحدد ";
            }
            else if (ssss == Total_Deseces)
            {
                rrr = " احتمالية الاصابة بالمرض هي 50 % ";
            }

            Result result = new Result()
            {
                Testid= uid,
                Desecesid = tr.testid,
                Userid = useri,
                Testdate = DateTime.Now.Date,
                ISWatinting = true,
                ISDone = false,
                Total_Degree = Total_Deseces,
                Result1 = rrr


            };
            db.Results.Add(result);
            db.Test_Result.Add(degrees_Of_Deseess);
            db.SaveChanges();

            if (ssss > Total_Deseces)
            {
                TempData["warning"] = " جاري مراجعة البيانات  ";

            }
            else if (ssss < Total_Deseces)
            {
                TempData["warning"] = " جاري مراجعة البيانات  ";

            }
            else if (ssss == Total_Deseces)
            {
                TempData["warning"] = " جاري مراجعة البيانات  ";

            }


            return RedirectToAction("TestSupmitListWhere", uid);
        }
        #endregion

        String USERNAME;

        public ActionResult PationtResult(int id)
        {
            VTSAuth auth = new VTSAuth();
            var sd = auth.LoadDataFromCookies();
            if (sd != null)
            {
                var ee = auth.CookieValues.UserId;
                var i = auth.CookieValues.UserName;
                useri = ee;

            }
            ViewBag.Desece = db.Test_Result.Where(x => x.C_id == id).ToList();
            //ViewBag.Desece = db. Results.Where(x => x.Desecesid == id).ToList();

                ViewBag.Desece22 = db.Results.Where(x => x.Testid == id).ToList();
            //ViewBag.Desece = db. Results.Where(x => x.Desecesid == id).ToList();


            ViewBag.asd = db.Results.Where(x => x.Testid == id)
           .Where(x => x.Userid == useri)
           .Sum(x => x.Total_Degree);




            return View();
         
        }

        #region  نتائج اختبار 
        public ActionResult Chat()
        {
        
            return View();
        }
        #endregion

        #region  نتائج اختبار 
        public ActionResult TestSupmitListWhere()
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
                .Where(x => x.Userid == useri)
                .Select(x => new ResultInfo
                {
                    _ID = x.id,
                    Testid = (int)x.Testid,
                    uid = useri,
                    name = x.User.name,
                    testType = x.Desece.name,
                    date = (DateTime)x.Testdate,
                    Result =x.Result1
                });
            ;
            return View(ViewBag.Results);
        }
        #endregion

        #region  
        public ActionResult ssss()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        #endregion
    }
}