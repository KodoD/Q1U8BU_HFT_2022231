using Microsoft.AspNetCore.Mvc;
using Q1U8BU_HFT_2022231.Logic;
using Q1U8BU_HFT_2022231.Models;
using System.Collections.Generic;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Q1U8BU_HFT_2022231.Endpoint.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class SalesController : ControllerBase
    {
        ISalesLogic logic;

        public SalesController(ISalesLogic logic)
        {
            this.logic = logic;
        }

        // GET: api/<SalesController>
        [HttpGet]
        public IEnumerable<Sales> ReadAll()
        {
            return this.logic.ReadAll();
        }

        // GET api/<SalesController>/5
        [HttpGet("{id}")]
        public Sales Read(int id)
        {
            return this.logic.Read(id);
        }

        // POST api/<SalesController>
        [HttpPost]
        public void Create([FromBody] Sales value)
        {
            this.logic.Create(value);
        }

        // PUT api/<SalesController>/5
        [HttpPut]
        public void Update([FromBody] Sales value)
        {
            this.logic.Update(value);
        }

        // DELETE api/<SalesController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            this.logic.Delete(id);
        }
    }
}
