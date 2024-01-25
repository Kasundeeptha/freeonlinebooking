using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Configuration;
using DataModule;
using BusinessLogic;

namespace HotelReservation.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
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

        public ActionResult Reservation()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public JsonResult Register(string IN_JSON, string In_Email, string In_Password, string IN_STATUS)
        {

            var model = new BLCustomer();
            try
            {

                return Json((Customer)model.Register("xample@gmail.com", "hdhhii",
                        ConfigurationManager.ConnectionStrings["sql_constr"].ConnectionString), JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex) { return Json(ex); }
        }

        public JsonResult GetLocation()
        {

            var model = new BLLocation();
            try
            {

                return Json((Location)model.GetLocation(
                        ConfigurationManager.ConnectionStrings["sql_constr"].ConnectionString), JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex) { return Json(ex); }
        }

        public JsonResult Reserve(string In_Location, string In_Date_From, string In_Date_To, string In_Adults, string In_Children)
        {

            var model = new BLLocation();
            try
            {

                return Json((Location)model.Reserve(In_Location, In_Date_From, In_Date_To, 
                    In_Adults, In_Children, ConfigurationManager.ConnectionStrings["sql_constr"].ConnectionString), JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex) { return Json(ex); }
        }

        public JsonResult GetUrgence()
        {

            var model = new BLLServices();
            try
            {

                return Json((Urgence)model.GetUrgence(
                        ConfigurationManager.ConnectionStrings["sql_constr"].ConnectionString), JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex) { return Json(ex); }
        }

        public JsonResult GetServices()
        {

            var model = new BLLServices();
            try
            {

                return Json((Services)model.GetServices(
                        ConfigurationManager.ConnectionStrings["sql_constr"].ConnectionString), JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex) { return Json(ex); }
        }

        public JsonResult SaveServiceRequest(string In_ServiceId, string In_UrgencyId, string In_Name,
             string In_RoomNo, string In_Mobile)
        {

            var model = new BLLocation();
            try
            {

                return Json((Services)model.SaveServiceRequest(In_ServiceId, In_UrgencyId, In_Name,
                    In_RoomNo, In_Mobile, ConfigurationManager.ConnectionStrings["sql_constr"].ConnectionString), JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex) { return Json(ex); }
        }
    }
}