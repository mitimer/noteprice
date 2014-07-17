using System;
using System.Linq;
using EntityFramework.Extensions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using noteprice.Bl.DataModel;
using noteprice.Bl.Dto;
using System.Transactions;

namespace noteprice.Bl.Tests
{
	[TestClass]
	public class StoresTest
	{
	    private const bool RollbackData = true;

        private MainService _service;
        private TransactionScope _trans;

        private int _testStoreId;
        private int _testPriceId;
        
        [TestInitialize]
	    public void Init()
        {
            _service = new MainService();
            if (RollbackData)
            {
                _trans = new TransactionScope(TransactionScopeOption.Required,
                          new TransactionOptions { IsolationLevel = IsolationLevel.ReadUncommitted });    
            }
        }

        [TestCleanup]
        public void Cleanup()
        {
            if (RollbackData)
            {
                _trans.Dispose();    
            }
        }

	    [TestMethod]
	    public void GetStoreTest()
	    {
	        //Act
	        var storeDto = _service.GetStores().FirstOrDefault();

	        //Assert
	        Assert.IsNotNull(storeDto);
	        _testStoreId = storeDto.Id;

	        Assert.IsTrue(_testStoreId > 0);
	    }

	    [TestMethod]
	    public void CreatePriceTest()
	    {
	        //Arrange
            using (var db = new MainDB())
            {
                db.Prices.Delete();
            }

            GetStoreTest();

	        decimal value = 115.30m;
	        decimal weight = 0.4m;
	        var price = new PriceDto
	        {
	            Text = "Ратибор варенье клубника",
                ValueStr = value.ToString(),
	            WeightStr = weight.ToString(),
                StoreId = _testStoreId,
	        };

	        //Act
	        _service.CreatePrice(price);

	        //Assert
	        var pricies = _service.GetPricies().ToList();

            Assert.IsTrue(pricies.Count>0);
	        var actualPrice = pricies.FirstOrDefault(p => p.Text == price.Text);
            
            Assert.IsNotNull(actualPrice);
            _testPriceId = actualPrice.Id;

            Assert.AreEqual(price.ValueStr,actualPrice.ValueStr);
            Assert.AreEqual(price.WeightStr, actualPrice.WeightStr);
            
            Assert.AreEqual(_testStoreId, actualPrice.StoreId);
            Assert.IsTrue(actualPrice.DateCreated>=DateTime.Today.Date);

            Assert.AreEqual(value, actualPrice.Value);
            Assert.AreEqual(weight,actualPrice.Weight);
	    }

	    [TestMethod]
	    public void UpdatePriceTest()
	    {
	        //Arrange
	        CreatePriceTest();
	        var price = _service.GetPrice(_testPriceId);
	        decimal newValue = 110;
	        decimal newWeight = 0.380m;
            price.ValueStr = newValue.ToString();
            price.WeightStr = newWeight.ToString();
	        price.Text = "Печенки";

            var anotherStore = _service.GetStores().FirstOrDefault(s => s.Id!= _testStoreId);
            Assert.IsNotNull(anotherStore);
	        price.StoreId = anotherStore.Id;
            //Act
            _service.PriceUpdate(price);

            //Assert

            var actualPrice = _service.GetPrice(_testPriceId);
            Assert.IsNotNull(actualPrice);
            _testPriceId = actualPrice.Id;

            Assert.AreEqual(price.ValueStr, actualPrice.ValueStr);
            Assert.AreEqual(price.WeightStr, actualPrice.WeightStr);

            Assert.AreEqual(anotherStore.Id, actualPrice.StoreId);

            Assert.AreEqual(newValue, actualPrice.Value);
            Assert.AreEqual(newWeight, actualPrice.Weight);
	    }

		[TestMethod]
		public void UpdatePriceCustomWeightTest()
		{
			//Arrange
			CreatePriceTest();
			var price = _service.GetPrice(_testPriceId);
			price.WeightStr = "10 таблеток";

			//Act
			_service.PriceUpdate(price);

			//Assert
			var actualPrice = _service.GetPrice(_testPriceId);
			Assert.IsNotNull(actualPrice);
			Assert.AreEqual(price.WeightStr, actualPrice.WeightStr);
			Assert.AreEqual(0, actualPrice.Weight);
		}
	}
}
