using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using MongoDB.Driver;

namespace PTrackerAPI.Models
{
    public class DbContext
    {
        MongoClient client;
        IMongoDatabase database;

        public DbContext(IConfiguration configuration)
        {
            client = new MongoClient(configuration.GetConnectionString("MongoConnection"));
            database = client.GetDatabase(configuration.GetSection("MongoDatabase").Value);
        }
        public IMongoCollection<Stock> Stocks => database.GetCollection<Stock>("Stock");
        public IMongoCollection<Portfolio> Portfolios => database.GetCollection<Portfolio>("Portfolio");
    }
}
