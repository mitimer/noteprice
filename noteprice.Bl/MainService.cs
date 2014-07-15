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