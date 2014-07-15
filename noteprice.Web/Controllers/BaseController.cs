using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using noteprice.Bl;

namespace noteprice.Web.Controllers
{
    public class BaseController : Controller
    {
        private MainService _service;

        protected MainService Service
        {
            get { return _service ?? (_service = new MainService()); }
        }
    }
}