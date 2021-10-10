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
    public class StockController : ControllerBase
    {
        private readonly IStockRepository repo;
        public StockController(IStockRepository _repo)
        {
            repo = _repo;
        }

        [HttpPost]
        public IActionResult AddStock(Stock stock)
        {
            
            return Ok(repo.AddStock(stock));
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteStock(int id)
        {
            repo.DeleteStock(id);
            return Ok("{}");
        }

        [HttpGet("{id}")]
        public IActionResult GetStock(int id)
        {
            return Ok(repo.GetStock(id));
        }

        [HttpGet("portfolio/{pid}")]
        public IActionResult GetStocksByPortfolio(int pid)
        {
            return Ok(repo.GetStocksByPortfolio(pid));
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, Stock stock)
        {
            repo.UpdateStock(id, stock);
            return Ok("{}");
        }
    }
}
