using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PTrackerAPI.Models;
using PTrackerAPI.Repository;

namespace PTrackerAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PortfolioController : ControllerBase
    {
        private readonly IPortfolioRepository repo;
        public PortfolioController(IPortfolioRepository _repo)
        {
            repo = _repo;
        }

        [HttpPost]
        public IActionResult AddPortfolio(Portfolio portfolio)
        {
            repo.AddPortfolio(portfolio);
            return Ok("{}");
        }

        [HttpDelete("{id}")]
        public IActionResult DeletePortfolio(int id)
        {
            repo.DeletePortfolio(id);
            return Ok("{}");
        }

        [HttpGet("{id}")]
        public IActionResult GetPortfolio(int id)
        {
            return Ok(repo.GetPortfolio(id));
        }

        [HttpGet]
        public IActionResult GetAllPortfolios()
        {
            return Ok(repo.GetPortfolios());
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, Portfolio portfolio)
        {
            repo.UpdatePortfolio(id, portfolio);
            return Ok("Profile updated successfully");
        }
    }
}
