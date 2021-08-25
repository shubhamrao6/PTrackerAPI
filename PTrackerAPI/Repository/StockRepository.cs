using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using PTrackerAPI.Models;
using System.Linq;
using System.Linq.Expressions;
using MongoDB.Driver;

namespace PTrackerAPI.Repository
{
    public class StockRepository : IStockRepository
    {
        private readonly DbContext db;
        public StockRepository(DbContext _db)
        {
            db = _db;
        }
        public void AddStock(Stock stock)
        {
            db.Stocks.InsertOne(stock);
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
