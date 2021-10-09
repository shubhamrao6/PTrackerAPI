using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PTrackerAPI.Models;
using PTrackerAPI.Repository;

namespace PTrackerAPI.Services
{
    public interface IPortfolioService
    {
        bool AddPortfolio(Portfolio portfolio);
        bool DeletePortfolio(int pId);
        Portfolio GetPortfolio(int pId);
        List<Portfolio> GetPortfolios();
    }
}
