using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using log4net;
using log4net.Config;
using noteprice.Web.Classes;

namespace noteprice.Web
{
    public class MvcApplication : System.Web.HttpApplication
    {
		public const string EmergencyLoggerName = "CommonEmergency";

		protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);
			XmlConfigurator.Configure();
			AppDomain.CurrentDomain.UnhandledException += AppDomain_UnhandledException;
			Log.Info("Application_Start");
        }

		protected void Application_Error()
		{
			Exception exception = Server.GetLastError();
			if (!IsPageNotFoundException(exception))
				WriteEmergency("Application_Error", exception);
		}

		private static bool IsPageNotFoundException(Exception exception)
		{
			var httpException = exception as HttpException;
			return (null != httpException) &&
					(httpException.GetHttpCode() == (int)HttpStatusCode.NotFound);
		}

		private void AppDomain_UnhandledException(object sender, UnhandledExceptionEventArgs e)
		{
			WriteEmergency("AppDomain_UnhandledException", (Exception)e.ExceptionObject);
		}
		
		public static void WriteEmergency(string message, Exception exception)
		{
			ILog logger = LogManager.Exists("CommonEmergency");
			ILog log = logger;
			if (log != null)
				log.Error(message, exception);
		}
    }
}
