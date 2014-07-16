using System;
using System.Web;
using noteprice.Bl;

namespace noteprice.Web.Classes
{
    public sealed class AppContext : IDisposable
    {
        private static readonly object HttpContextKey = new object();

        private MainService service;

        public static AppContext Current
        {
            get { return (AppContext)HttpContext.Current.Items[HttpContextKey]; }
            set { HttpContext.Current.Items[HttpContextKey] = value; }
        }

        public AppContext()
        {
            this.service = new MainService();
        }
     
        public MainService Service { get { return this.service; } }

        public void Dispose()
        {
            if (this.service != null)
            {
                this.service.Dispose();
                this.service = null;
            }
        }
    }
}