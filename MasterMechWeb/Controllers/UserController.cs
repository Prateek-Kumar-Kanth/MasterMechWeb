using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Mvc;
using MasterMechData;
using MasterMechPrj;

namespace MasterMechWeb.Controllers
{
    
    public class UserController : Controller
    {
        // GET: User
        public ActionResult Index()
        {
            User lObjUser = new User();
            List<User> ListUser = lObjUser.ListData("");
            return View(ListUser);
        }
        
        public ActionResult SearchUserName(string isUserid)
        {
            User lObjUser = new User();
            List<User> mObjUsers = lObjUser.ListData(isUserid);

            if (mObjUsers.Count==0)
            {
                ModelState.AddModelError("", "Users Not Found");
            }
            else
            {
                ModelState.AddModelError("", "Users Found");
            }
            ViewBag.SearchName = isUserid;

            return View("Index", mObjUsers);
        }

        // GET: User/Details/5
        public ActionResult Details(string id)
        {
            User lObjUser = new User();
            lObjUser.SearchSingleRecord(id);
            return View(lObjUser);
        }

        // GET: User/Create
        public ActionResult Create()
        {
            List<SelectListItem> lObjUserDtlType = new List<SelectListItem>();
            lObjUserDtlType.Add(new SelectListItem
            {
                Text = "Administrator",
                Value = "ADMIN"
            });

            lObjUserDtlType.Add(new SelectListItem
            {
                Text = "Regular User",
                Value = "REGLR"
            });

            this.ViewBag.UserType = new SelectList(lObjUserDtlType, "Value", "Text");
            return View();
        }
      

        // POST: User/Create
        [HttpPost]
        public ActionResult Create(User iObjUser)
        {
            List<SelectListItem> lObjUserDtlType = new List<SelectListItem>();
            lObjUserDtlType.Add(new SelectListItem
            {
                Text = "Administrator",
                Value = "ADMIN"
            });

            lObjUserDtlType.Add(new SelectListItem
            {
                Text = "Regular User",
                Value = "REGLR"
            });

            this.ViewBag.UserType = new SelectList(lObjUserDtlType, "Value", "Text");
            try
            {
                iObjUser.msPassword = MasterMechUtil.Encrypt(iObjUser.msPassword);

                if (iObjUser.SaveSQL(MasterMechUtil.OPMode.New))
                {
                    ViewBag.InsertMsg = "Successfully Inserted";
                    ModelState.Clear(); // Clear All TextBoxes, ModelState is predefined
                }
                else
                {
                    ViewBag.InsertMsg = "Failed";
                }
                return View();
            }
            catch
            {
                return View();
            }
        }

        // GET: User/Edit/5
        public ActionResult Edit(string id) // Choose View Template = Details
        {
            User lObjUser = new User();
            lObjUser.SearchSingleRecord(id);
            return View(lObjUser);
           
            
        }

        // POST: User/Edit/5
        [HttpPost]
        public ActionResult Edit(User iObj)
        {
            try
            {
                iObj.SaveSQL(MasterMechUtil.OPMode.Open);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: User/Delete/5
        public ActionResult Delete(string id)
        {
            User lObjUser = new User();
            lObjUser.SearchSingleRecord(id);
            return View(lObjUser);
           
        }

        // POST: User/Delete/5
        [HttpPost]
        public ActionResult Delete(User iObjUser)
        {
            try
            {
                iObjUser.DeleteData(iObjUser.msUserID);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
        public ActionResult ValidUser(string isUserID)
        {
            bool lbValidUser = false;
            User lObjUser = new User();
            lObjUser.msUserID = isUserID;
            lbValidUser = lObjUser.SearchUniqueID(isUserID);

            //this below var is creating temporary Object
            var lObjData = new
            {
                msValidUser = lbValidUser ? "Y" : "N"
            };
            return Json(lObjData, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult ValidateEmail(string email) // It is called from Create view from <script>
        {
            // Regex pattern for email validation
            string emailPattern = @"^[^\s@]+@[^\s@]+\.[^\s@]+$";

            // Check if the email matches the regex pattern
            bool isValidEmail = Regex.IsMatch(email, emailPattern);

            // Return JSON response indicating whether email is valid
            return Json(new { isValid = isValidEmail });
        }

    }
}
