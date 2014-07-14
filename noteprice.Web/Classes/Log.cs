using System;
using log4net;

namespace noteprice.Web.Classes
{
	public static class Log
	{
		/// <summary>
		/// Writes info message to the log.
		/// </summary>
		/// <param name="message">Message to write.</param>
		public static void Info(string message)
		{
			LogManager.GetLogger("CommonEvent").InfoFormat(message);
		}
		/// <summary>
		/// Writes info message to the log.
		/// </summary>
		/// <param name="message">Message to write.</param>
		/// <param name="args">Optional list of arguments if message contains string format options.</param>
		public static void Info(string message, params object[] args)
		{
			LogManager.GetLogger("CommonEvent").InfoFormat(message, args);
		}

		/// <summary>
		/// Writes error message to the log.
		/// </summary>
		/// <param name="message">Message to write.</param>
		public static void Error(string message)
		{
			LogManager.GetLogger("CommonEmergency").Error(message);
		}
		/// <summary>
		/// Writes exception to the log.
		/// </summary>
		/// <param name="ex">Error to log.</param>
		public static void Error(Exception ex)
		{
			LogManager.GetLogger("CommonEmergency").Error(ex);
		}
		/// <summary>
		/// Writes error message and erorr information to the log.
		/// </summary>
		/// <param name="message">Message to write.</param>
		/// <param name="ex">Error to parse.</param>
		public static void Error(Exception ex, string message)
		{
			LogManager.GetLogger("CommonEmergency").Error(message, ex);
		}
	}
}