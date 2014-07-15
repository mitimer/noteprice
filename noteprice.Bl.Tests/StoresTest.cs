using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using noteprice.Bl.Dto;
using System.Transactions;

namespace noteprice.Bl.Tests
{
	[TestClass]
	public class StoresTest
	{
	    private int _testStoreId;
	    private MainService _service;
        private TransactionScope _trans;

        [TestInitialize]
	    public void Init()
        {
            _service = new MainService();
            _trans = new TransactionScope(TransactionScopeOption.Required,
                      new TransactionOptions { IsolationLevel = IsolationLevel.ReadUncommitted });
        }

        [TestCleanup]
        public void Cleanup()
        {
            _trans.Dispose();
        }

	    [TestMethod]
	    public void GetStoreTest()
	    {
	        //Act
	        var storeDto = _service.GetStores().FirstOrDefault();

	        //Assert
	        Assert.IsNotNull(storeDto);
	        _testStoreId = storeDto.StoreId;

	        Assert.IsTrue(_testStoreId > 0);
	    }

	    [TestMethod]
	    public void CreatePriceTest()
	    {
	        //Arrange
	        GetStoreTest();
	        var price = new PriceDto
	        {
	            Text = "Ратибор варенье клубника",
	            Value = 115.30m,
	            Weight = 0.4m,
                StoreId = _testStoreId,
	        };

	        //Act
	        _service.CreatePrice(price);

	        //Assert
	        var pricies = _service.GetPricies().ToList();

	        Assert.IsTrue(pricies.Any(p => p.Text == price.Text));
	    }
	}
}
