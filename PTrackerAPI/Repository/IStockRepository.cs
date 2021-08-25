using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PTrackerAPI.Models;

namespace PTrackerAPI.Repository
{
    public interface IStockRepository
    {
        List<Stock> GetStocksByPortfolio(int pid);
        Stock GetStock(int id);
        void AddStock(Stock stock);
        void UpdateStock(int id, Stock stock);
        void DeleteStock(int id);
    }
}
