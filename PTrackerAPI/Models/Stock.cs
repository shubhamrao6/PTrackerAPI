using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MongoDB.Bson.Serialization.Attributes;

namespace PTrackerAPI.Models
{
    public class Stock
    {
        [BsonId]
        public int Id { get; set; }
        public string Symbol { get; set; }
        public double Price { get; set; }
        public int Quantity { get; set; }
        public int PortfolioId { get; set; }
    }
}
