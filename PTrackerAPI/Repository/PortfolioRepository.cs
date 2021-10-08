using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PTrackerAPI.Models;
using MongoDB.Driver;
using MongoDB.Bson;

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
            var documents = db.Portfolios.Find(new BsonDocument()).ToList();
            var max_portfolio_id = 0;
            foreach (Portfolio p in documents)
            {
                if (p.Id > max_portfolio_id)
                {
                    max_portfolio_id = p.Id;
                }

            }
            portfolio.Id = max_portfolio_id + 1;
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

        public List<Portfolio> GetPortfolios()
        {
            return db.Portfolios.Find(x => true).ToList();
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
