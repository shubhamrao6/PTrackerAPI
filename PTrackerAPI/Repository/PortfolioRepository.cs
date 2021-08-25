using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PTrackerAPI.Models;
using MongoDB.Driver;

namespace PTrackerAPI.Repository
{
    public class PortfolioRepository : IPortfolioRepository
    {
        private readonly DbContext db;
        public PortfolioRepository(DbContext _db)
        {
            db = _db;
        }
        public void AddPortfolio(Portfolio portfolio)
        {
            db.Portfolios.InsertOne(portfolio);
        }

        public void DeletePortfolio(int id)
        {
            db.Portfolios.DeleteOne(x => x.Id == id);
        }

        public Portfolio GetPortfolio(int id)
        {
            return db.Portfolios.Find(x => x.Id == id).FirstOrDefault();
        }

        public void UpdatePortfolio(int id, Portfolio portfolio)
        {
            var filter = Builders<Portfolio>.Filter.Where(x => x.Id == id);
            var update = Builders<Portfolio>.Update.Set(x => x.Name, portfolio.Name)
                .Set(x => x.Description, portfolio.Description);
            db.Portfolios.UpdateOne(filter, update);
        }
    }
}
