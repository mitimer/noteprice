using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using noteprice.Bl.DataModel;

namespace noteprice.Bl.Tests
{
	[TestClass]
	public class StoresTest
	{
	
		[TestMethod]
		public void GetFirstStoresTest()
		{
			//Act
			Store stroreset;
			using (var db = new MainDB())
			{
				stroreset = db.Stores.FirstOrDefault();
			}
			//Assert
			Assert.IsNotNull(stroreset);
		}

	}
}
