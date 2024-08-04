using MasterMechData;
using MasterMechPrj;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MasterMechWeb.Controllers
{
    public class CustomerController : Controller
    {
        // GET: Customer
        public ActionResult Index()
        {
            Customer lObjUser = new Customer();
            List<Customer> ListCust = lObjUser.ListData("");
            return View(ListCust);
            
        }

        // GET: Customer/Details/5
        public ActionResult Details(int id)
        {
            Customer lObjCust = new Customer();
            lObjCust.SearchSingleRecord(id);
            return View(lObjCust);
            
        }

        // GET: Customer/Create
        public ActionResult Create()
        {
            List<SelectListItem> SelectListStatus = new List<SelectListItem>();
            SelectListStatus.Add(new SelectListItem
            {
                Text = "Active",
                Value = "Active"
            });

            SelectListStatus.Add(new SelectListItem
            {
                Text = "Suspended",
                Value = "Suspended"
            });

            this.ViewBag.CustStatus = new SelectList(SelectListStatus, "Value", "Text");

            List<SelectListItem> SelectListType = new List<SelectListItem>();
            SelectListType.Add(new SelectListItem
            {
                Text = "IND",
                Value = "IND"
            });

            SelectListType.Add(new SelectListItem
            {
                Text = "BUS",
                Value = "BUS"
            });

            this.ViewBag.CustomerType = new SelectList(SelectListType, "Value", "Text");
            return View();
        }

        // POST: Customer/Create
        [HttpPost]
        public ActionResult Create(Customer iObjCust)
        {
            List<SelectListItem> SelectListStatus = new List<SelectListItem>();
            SelectListStatus.Add(new SelectListItem
            {
                Text = "Active",
                Value = "Active"
            });

            SelectListStatus.Add(new SelectListItem
            {
                Text = "Suspended",
                Value = "Suspended"
            });

            this.ViewBag.CustStatus = new SelectList(SelectListStatus, "Value", "Text");

            List<SelectListItem> SelectListType = new List<SelectListItem>();
            SelectListType.Add(new SelectListItem
            {
                Text = "IND",
                Value = "IND"
            });

            SelectListType.Add(new SelectListItem
            {
                Text = "BUS",
                Value = "BUS"
            });

            this.ViewBag.CustomerType = new SelectList(SelectListType, "Value", "Text");
            try
            {
                

                if (iObjCust.SaveSQL(MasterMechUtil.OPMode.New))
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

        // GET: Customer/Edit/5
        public ActionResult Edit(int id)
        {
            Customer lObjCust = new Customer();
            lObjCust.SearchSingleRecord(id);
            return View(lObjCust);
        }

        // POST: Customer/Edit/5
        [HttpPost]
        public ActionResult Edit(Customer iObjCust)
        {
            try
            {
                iObjCust.SaveSQL(MasterMechUtil.OPMode.Open);

                return RedirectToAction("Index");
               
            }
            catch
            {
                return View();
            }
        }

        // GET: Customer/Delete/5
        public ActionResult Delete(int id)
        {
            Customer lObjCust = new Customer();
            lObjCust.SearchSingleRecord(id);
            return View(lObjCust);

        }

        // POST: Customer/Delete/5
        [HttpPost]
        public ActionResult Delete(Customer lObjCust)
        {
            try
            {
                lObjCust.DeleteData(lObjCust.mnCustomerNo);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
