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

        public PartialViewResult CreateAjax(PriceModel priceModel)
        {
            PriceDto priceDto = priceModel.GetDto();
            AppContext.Service.CreatePrice(priceDto);

            List<PricieViewModel> model = new List<PricieViewModel>();
            try
            {
                model = AppContext.Service.GetPricies()
                    .Select(PricieViewModel.SelectException).ToList();
            }
            catch (Exception e)
            {

            }
            return PartialView("PriceList", model);
        }

        // GET: Price/Search/
		public PartialViewResult Search(string filter)
		{
			filter = filter.ToLower();
			var model = AppContext.Service.GetPricies(filter)
				.Select(PricieViewModel.SelectException);
			return PartialView("PriceList", model);
		}

        // GET: Price
        public ActionResult Index()
        {
            var model = new List<PricieViewModel>();
            return View(model);
        }
		
        // GET: Price/Create
        public ActionResult Create()
        {
			var model = new PriceModel{EditMode = PriceEditMode.Create};
			return View("Edit");
        }
		
		// GET: Price/Edit/5
		public ActionResult Edit(int id)
		{
			PriceDto price = AppContext.Service.GetPrice(id);
			var model = new PriceModel();
			model.Init(price,PriceEditMode.Update);
			return View("Edit",model);
		}

		// GET: Price/MakeCopy/5
		public ActionResult MakeCopy(int id)
		{
			PriceDto price = AppContext.Service.GetPrice(id);
			var model = new PriceModel();
			model.Init(price, PriceEditMode.MakeCopy);
			return View("Edit", model);
		}
      
        // POST: Price/Edit/5
        [HttpPost]
        public ActionResult Edit(PriceModel model)
        {
            try
            {
                PriceDto priceDto = model.GetDto();

				switch (model.EditMode)
				{
					case PriceEditMode.Create:
						AppContext.Service.CreatePrice(priceDto);
						break;
					case PriceEditMode.Update:
						AppContext.Service.PriceUpdate(priceDto);
						break;
					case PriceEditMode.MakeCopy:
						AppContext.Service.CreatePrice(priceDto);
						break;
					default:
						break;
				}

                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                return View(ex);
            }
        }

     

    }
}
