using System.Linq;
using System.Web.Mvc;
using noteprice.Web.Classes;
using noteprice.Web.Models;

namespace noteprice.Web.Controllers
{
    public class StoresController : BaseController
    {
        // GET: /Stores/
	    public ActionResult Index()
	    {
		    StoresListModel model = new StoresListModel();

            model.StoresList = AppContext.Service.GetStores().ToList();
		 
		    Log.Info("Stores list");

		    return View(model);
	    }
    }
}
