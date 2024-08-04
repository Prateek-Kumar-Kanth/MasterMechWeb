using MasterMechData;
using MasterMechPrj;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MasterMechWeb.Controllers
{
    public class ItemController : Controller
    {
        // GET: Item
        public ActionResult Index()
        {
            Items lObjItems = new Items();
            List<Items> ListItems = lObjItems.ListData("");
            return View(ListItems);
          
        }

        // GET: Item/Details/5
        public ActionResult Details(int id)
        {
            Items lObjItem = new Items();
            lObjItem.SearchSingleRecord(id);
            return View(lObjItem);
           
        }

        // GET: Item/Create
        public ActionResult Create()
        {
            List<SelectListItem> lObjItemTypes = new List<SelectListItem>();
            lObjItemTypes.Add(
                new SelectListItem
                {
                    Text = "LABOUR",
                    Value = "LABOUR"
                });
            lObjItemTypes.Add(
                new SelectListItem
                {
                    Text = "PARTS",
                    Value = "PARTS"
                });

            this.ViewBag.ItemTypes = new SelectList(lObjItemTypes, "Value", "Text");

            List<SelectListItem> lObjItemCtg = new List<SelectListItem>();
            lObjItemCtg.Add(new SelectListItem
            {
                Text = "ENGINE",
                Value = "ENGINE"
            });
            lObjItemCtg.Add(new SelectListItem
            {
                Text = "BODY",
                Value = "BODY"
            }); lObjItemCtg.Add(new SelectListItem
            {
                Text = "DRIVE",
                Value = "DRIVE"
            }); lObjItemCtg.Add(new SelectListItem
            {
                Text = "ELECTRIC",
                Value = "ELECTRIC"
            }); lObjItemCtg.Add(new SelectListItem
            {
                Text = "FRAME",
                Value = "FRAME"
            }); lObjItemCtg.Add(new SelectListItem
            {
                Text = "SUSPENSION",
                Value = "SUSPENSION"
            }); lObjItemCtg.Add(new SelectListItem
            {
                Text = "BREAK",
                Value = "BREAK"
            });

            ViewBag.ItemCatg = new SelectList(lObjItemCtg, "Value", "Text");

            List<SelectListItem> lObjItemSts = new List<SelectListItem>();
            lObjItemSts.Add(
                new SelectListItem
                {
                    Text = "ACTIVE",
                    Value = "ACTIVE"
                });
            lObjItemSts.Add(
                new SelectListItem
                {
                    Text = "SUSPENDED",
                    Value = "SUSPENDED"
                });

            this.ViewBag.ItemSts = new SelectList(lObjItemSts, "Value", "Text");

            return View();
           
        }

        // POST: Item/Create
        [HttpPost]
        public ActionResult Create(Items iObjItem)
        {
            List<SelectListItem> lObjItemTypes = new List<SelectListItem>();
            lObjItemTypes.Add(
                new SelectListItem
                {
                    Text = "LABOUR",
                    Value = "LABOUR"
                });
            lObjItemTypes.Add(
                new SelectListItem
                {
                    Text = "PARTS",
                    Value = "PARTS"
                });

            this.ViewBag.ItemTypes = new SelectList(lObjItemTypes, "Value", "Text");

            List<SelectListItem> lObjItemCtg = new List<SelectListItem>();
            lObjItemCtg.Add(new SelectListItem
            {
                Text = "ENGINE",
                Value = "ENGINE"
            });
            lObjItemCtg.Add(new SelectListItem
            {
                Text = "BODY",
                Value = "BODY"
            }); lObjItemCtg.Add(new SelectListItem
            {
                Text = "DRIVE",
                Value = "DRIVE"
            }); lObjItemCtg.Add(new SelectListItem
            {
                Text = "ELECTRIC",
                Value = "ELECTRIC"
            }); lObjItemCtg.Add(new SelectListItem
            {
                Text = "FRAME",
                Value = "FRAME"
            }); lObjItemCtg.Add(new SelectListItem
            {
                Text = "SUSPENSION",
                Value = "SUSPENSION"
            }); lObjItemCtg.Add(new SelectListItem
            {
                Text = "BREAK",
                Value = "BREAK"
            });

            ViewBag.ItemCatg = new SelectList(lObjItemCtg, "Value", "Text");

            List<SelectListItem> lObjItemSts = new List<SelectListItem>();
            lObjItemSts.Add(
                new SelectListItem
                {
                    Text = "ACTIVE",
                    Value = "ACTIVE"
                });
            lObjItemSts.Add(
                new SelectListItem
                {
                    Text = "SUSPENDED",
                    Value = "SUSPENDED"
                });

            this.ViewBag.ItemSts = new SelectList(lObjItemSts, "Value", "Text");

            try
            {

                if (iObjItem.SaveSQL(MasterMechUtil.OPMode.New))
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

        // GET: Item/Edit/5
        public ActionResult Edit(int id)
        {
            Items lObjItem = new Items();
            lObjItem.SearchSingleRecord(id);
            return View(lObjItem);
           
        }

        // POST: Item/Edit/5
        [HttpPost]
        public ActionResult Edit(Items iObjItem)
        {
            try
            {
                iObjItem.SaveSQL(MasterMechUtil.OPMode.Open);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Item/Delete/5
        public ActionResult Delete(int id)
        {
            Items lObjItem = new Items();
            lObjItem.SearchSingleRecord(id);
            return View(lObjItem);
        }

        // POST: Item/Delete/5
        [HttpPost]
        public ActionResult Delete(Items iObjItem)
        {
            try
            {
                iObjItem.DeleteData(iObjItem.mnItemNo);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
