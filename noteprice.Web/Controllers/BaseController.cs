using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using noteprice.Bl;
using noteprice.Web.Classes;

namespace noteprice.Web.Controllers
{
    public class BaseController : Controller
    {
        private readonly bool disposeAppContext;
        protected AppContext AppContext { get; private set; }

        public BaseController()
        {
            this.AppContext = AppContext.Current;
            if (this.AppContext == null)
            {
                this.disposeAppContext = true;
                AppContext.Current = this.AppContext = new AppContext();
            }
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (this.AppContext != null)
                {
                    if (this.disposeAppContext)
                    {
                        AppContext.Current = null;
                        this.AppContext.Dispose();
                    }
                    this.AppContext = null;
                }
            }
            base.Dispose(disposing);
        }

    }
}