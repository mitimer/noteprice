using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.SqlServer.Server;
using noteprice.Bl.DataModel;
using noteprice.Bl.Dto;

namespace noteprice.Bl
{
    public class MainService : IDisposable
    {
        protected MainDB dbContext;

        public MainService()
        {
            this.dbContext = new MainDB();
        }
        public MainDB DbContext
        {
            get { return this.dbContext; }
        }

        public IQueryable<StoreDto> GetStores()
        {
            return DbContext.vwStoreStoreSets
				.Where(s=>s.StoreIsActive)
				.Select(StoreDto.SelectExpression);
        }

		public IQueryable<PriceDto> GetPricies(string filter="")
        {
            return DbContext.vwPriceStores
				.Where(p=>p.PriceText.Contains(filter))
				.OrderByDescending(p=>p.PriceDateCreated).ThenBy(p=>p.PriceNormalValue)
				.Select(PriceDto.SelectException);
        }
        
        public PriceDto GetPrice(int id)
        {
            return DbContext.vwPriceStores
                .Where(p => p.PriceId == id)
                .Select(PriceDto.SelectException).FirstOrDefault();
        }

        public void PriceUpdate(PriceDto priceDto)
        {
            if (priceDto == null || priceDto.Id==0)
            {
                throw new ArgumentException("price");
            }

            var price = DbContext.Prices.FirstOrDefault(p => p.Id == priceDto.Id);
            price.Text = priceDto.Text;

            price.ValueStr = priceDto.ValueStr;
            price.WeightStr = priceDto.WeightStr;
            price.StoreId = priceDto.StoreId;

            PriceParseStrValues(price);

            DbContext.SaveChanges();
        }

        public void CreatePrice(PriceDto priceDto)
        {
            if (priceDto == null)
            {
                throw new ArgumentException("price");
            }
            
            var price = new Price
            {
                Text = priceDto.Text,
                ValueStr = priceDto.ValueStr,
                WeightStr = priceDto.WeightStr,
                StoreId = priceDto.StoreId,
                DateCreated = DateTime.UtcNow,
            };

            PriceParseStrValues(price);

            DbContext.Prices.Add(price);
            DbContext.SaveChanges();
        }

		public IQueryable<WeighCommonDto> GetWeighCommon()
	    {
		    return DbContext.vwWeighCommons.Where(w => w.IsActive)
				.OrderBy(w=>w.SortId).ThenBy(w=>w.Value)
			    .Select(w => new WeighCommonDto {Name = w.Name, Value = w.Value});
	    }

	    private static void PriceParseStrValues(Price price)
        {
            decimal priceValue;
            if (decimal.TryParse(price.ValueStr, out priceValue))
            {
                price.Value = priceValue;
            }
            else
            {
	            price.Value = 0;
            }

            decimal priceWeight;
            if (decimal.TryParse(price.WeightStr, out priceWeight))
            {
                if (priceWeight > 5)
                {
                    priceWeight = priceWeight/1000;
                }
                price.Weight = priceWeight;
            }
            else
            {
	            price.Weight = 0;
            }
        }

        public void Dispose()
        {
            if (this.dbContext != null)
            {
                this.dbContext.Dispose();
                this.dbContext = null;
            }
        }
    }
}