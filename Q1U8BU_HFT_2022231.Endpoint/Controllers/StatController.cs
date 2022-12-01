using Microsoft.AspNetCore.Mvc;
using Q1U8BU_HFT_2022231.Logic;
using Q1U8BU_HFT_2022231.Models;
using System.Collections.Generic;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Q1U8BU_HFT_2022231.Endpoint.Controllers
{
    [Route("[controller]/[action]")]
    [ApiController]
    public class StatController : ControllerBase
    {
        ISongLogic logic;
        ISalesLogic logic2;

        public StatController(ISongLogic logic, ISalesLogic logic2)
        {
            this.logic = logic;
            this.logic2 = logic2;
        }

        [HttpGet]
        public IEnumerable<Favorite> Favorite()
        {
            return this.logic.Favoriterank();
        }

        // POST api/<Stat>
        [HttpGet]
        public IEnumerable<MostWanted> MostWanted()
        {
            return this.logic2.MostWanted();
        }

        // POST api/<Stat>
        [HttpGet]
        public IEnumerable<MostWanted> LeastWanted()
        {
            return this.logic2.LeastWanted();
        }
        // POST api/<Stat>
        [HttpGet]
        public IEnumerable<RegularGuest> RegularGuests()
        {
            return this.logic2.RegularGuests();
        }

        [HttpGet("{id}")]
        public IEnumerable<Customer> WhoBoughtIt(int id)
        {
            return this.logic2.WhoBoughtIt(id);
        }
    }
}
