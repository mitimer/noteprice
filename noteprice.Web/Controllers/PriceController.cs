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
        // GET: Price/Search/
        public ActionResult Search(string filter)
        {
            filter = filter.ToLower();
            var model = new PriciesListModel { Pricies = AppContext.Service.GetPricies().Where(p => p.Text.ToLower().Contains(filter)).ToList() };
            return View("Index",model);
        }

        // GET: Price
        public ActionResult Index()
        {
            var model = new PriciesListModel {Pricies = AppContext.Service.GetPricies().ToList()};
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
            return View();
        }

        // POST: Price/Create
        [HttpPost]
        public ActionResult Create(PriceAddModel model)
        {
            try
            {
                AppContext.Service.CreatePrice(model.GetDto());

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
            PriceDto price = AppContext.Service.GetPrice(id);
            var model = new PriceEditModel();
            model.Init(price);
            return View(model);
        }

        // POST: Price/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, PriceEditModel model)
        {
            try
            {
                PriceDto priceDto = model.GetDto();
                priceDto.Id = id;

                AppContext.Service.PriceUpdate(priceDto);

                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                return View(ex);
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
