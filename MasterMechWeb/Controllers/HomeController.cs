using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MasterMechData;
using MasterMechPrj;

namespace MasterMechWeb.Controllers
{
    public class HomeController : Controller
    {
        
        public static bool CheckEmpty(User iObjUser)
        {
            if(iObjUser.msPassword == null || iObjUser.msUserID == null )
                return false;
            return true;
        }
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

        
        public ActionResult Login()
        {
            User lObjUser = new User();

            lObjUser.msUserName = "Temp";
            ViewBag.FYList = MasterMechUtil.FYList();
            ViewBag.CurrFY = MasterMechUtil.CurrFY();
            return View(lObjUser);
        }

        [HttpPost]
        public ActionResult Login(User iObjUser)
        {
           
            if (ModelState.IsValid)
            {
                iObjUser.msPassword = MasterMechUtil.Encrypt(iObjUser.msPassword);
                

                string lsConStr = ConfigurationManager.ConnectionStrings["MasterMechDB"].ConnectionString;
                string lsCoState = ConfigurationManager.AppSettings["STATE"].ToString();

                if (CheckEmpty(iObjUser))
                { 
                    if (iObjUser.ValidLogin(lsConStr))
                    {
                        Session["UserID"] = iObjUser.msUserID;
                        Session["UserName"] = iObjUser.msUserName;
                        Session["UserType"] = iObjUser.msUserType;
                        Session["FYR"] = iObjUser.FYr;
                        MasterMechUtil.sFY = iObjUser.FYr;
                        Session["FYRTXT"] = MasterMechUtil.FYrText(iObjUser.FYr);
                        Session["STATE"] = lsCoState;
                        MasterMechUtil.msConnStr = lsConStr; // Setting Conn Str for subsequent use
                        MasterMechUtil.msUserID = iObjUser.msUserID;

                        ViewBag.UserType = iObjUser.msUserType; // To check Admin or Regular User
                        return RedirectToAction("Main");
                    }
                    else
                    {
                        ModelState.AddModelError("", "Invalid login credentials.");
                    }
                }
                else
                {
                    ViewBag.EmptyOrNot = true;
                    return Login(); // to call Login Action Method of httpGET
                }
            }
            
            ViewBag.FYList = MasterMechUtil.FYList();
            ViewBag.CurrFY = MasterMechUtil.CurrFY();
            return View(iObjUser);
            
        }
        
        public ActionResult Main()
        {
            return View();
        }
        public ActionResult Test()
        {
            return View();
        }

    }
}