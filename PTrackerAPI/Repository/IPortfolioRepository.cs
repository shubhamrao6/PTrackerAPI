using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PTrackerAPI.Models;

namespace PTrackerAPI.Repository
{
    public interface IPortfolioRepository
    {
        Portfolio GetPortfolio(int id);
        void AddPortfolio(Portfolio portfolio);
        void UpdatePortfolio(int id, Portfolio portfolio);
        void DeletePortfolio(int id);
        List<Portfolio> GetPortfolios();
    }
}
