using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using noteprice.Bl.Dto;
using noteprice.Web.Models;

namespace noteprice.Web.Controllers
{
    public class PriceController : BaseController
    {
        // GET: Price
        public ActionResult Index()
        {
            var model = new PriciesListModel {Pricies = Service.GetPricies().ToList()};
            return View(model);
        }

        // GET: Price/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Price/Create
        public ActionResult Create()
        {
            var model = new PriceAddModel(Service.GetStores().ToList());
            return View(model);
        }

        // POST: Price/Create
        [HttpPost]
        public ActionResult Create(PriceAddModel model)
        {
            try
            {
                Service.CreatePrice(model.GetDto());

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Price/Edit/5
        public ActionResult Edit(int id)
        {
            PriceDto price = Service.GetPrice(id);
            return View(new PriceEditModel(price, Service.GetStores().ToList()));
        }

        // POST: Price/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, PriceEditModel model)
        {
            try
            {
                Service.UpdatePrice(model.GetDto());

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Price/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Price/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
