using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using PTrackerAPI.Models;
using System.Linq;
using System.Linq.Expressions;
using MongoDB.Driver;
using MongoDB.Bson;

namespace PTrackerAPI.Repository
{
    public class StockRepository : IStockRepository
    {
        private readonly DbContext db;
        public StockRepository(DbContext _db)
        {
            db = _db;
        }
        public Stock AddStock(Stock stock)
        {
            var documents = db.Stocks.Find(new BsonDocument()).ToList();
            var max_stock_id = 0;
            foreach (Stock s in documents)
            {
                if (s.Id > max_stock_id)
                {
                    max_stock_id = s.Id;
                }

            }
            stock.Id = max_stock_id + 1;
            db.Stocks.InsertOne(stock);
            return stock;
        }

        public void DeleteStock(int id)
        {
            db.Stocks.DeleteOne(x => x.Id == id);
        }

        public Stock GetStock(int id)
        {
            return db.Stocks.Find(x => x.Id == id).FirstOrDefault();
        }

        public List<Stock> GetStocksByPortfolio(int pid)
        {
            return db.Stocks.Find(x => x.PortfolioId == pid).ToList();
        }

        public void UpdateStock(int id, Stock stock)
        {
            var filter = Builders<Stock>.Filter.Where(x => x.Id == id);
            var update = Builders<Stock>.Update.Set(x => x.Symbol, stock.Symbol)
                .Set(x => x.Price, stock.Price)
                .Set(x => x.Quantity, stock.Quantity)
                .Set(x => x.PortfolioId, stock.PortfolioId);
            db.Stocks.UpdateOne(filter, update);
        }
    }
}
