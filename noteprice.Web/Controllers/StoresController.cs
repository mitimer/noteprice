using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using log4net;
using noteprice.Bl.DataModel;
using noteprice.Web.Classes;
using noteprice.Web.Models;

namespace noteprice.Web.Controllers
{
    public class StoresController : Controller
    {
        // GET: /Stores/
	    public ActionResult Index()
	    {
		    StoresListModel model = new StoresListModel();
		    using (var db = new MainDB())
		    {
			    model.StoresList = db.vwStoreStoreSets.ToList();
		    }
		    Log.Info("Stores list");

		    return View(model);
	    }
	    
    }
}
