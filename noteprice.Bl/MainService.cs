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
            return DbContext.vwStoreStoreSets.Select(StoreDto.SelectExpression);
        }

        public IQueryable<PriceDto> GetPricies(PriceQueryDto query = null)
        {
            return DbContext.vwPriceStores.Select(PriceDto.SelectException);
        }
        
        public PriceDto GetPrice(int id)
        {
            return DbContext.vwPriceStores
                .Where(p => p.PriceId == id)
                .Select(PriceDto.SelectException).FirstOrDefault();
        }

        public void UpdatePrice(PriceDto priceDto)
        {
            var price = DbContext.Prices.Where(p => p.Id == priceDto.Id).FirstOrDefault();
            price.Text = priceDto.Text;
            price.Value = priceDto.Value;
            price.Weight = priceDto.Weight;
            price.Date = priceDto.Date;
            price.StoreId = priceDto.StoreId;
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
                Value = priceDto.Value,
                Weight = priceDto.Weight,
                StoreId = priceDto.StoreId,
            };

            DbContext.Prices.Add(price);
            DbContext.SaveChanges();
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