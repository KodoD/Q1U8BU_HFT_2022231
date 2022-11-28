using Microsoft.AspNetCore.Mvc;
using Q1U8BU_HFT_2022231.Logic;
using Q1U8BU_HFT_2022231.Models;
using System.Collections.Generic;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Q1U8BU_HFT_2022231.Endpoint.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        ICustomerLogic logic;

        public CustomerController(ICustomerLogic logic)
        {
            this.logic = logic;
        }

        // GET: api/<CustomerController>
        [HttpGet]
        public IEnumerable<Customer> ReadAll()
        {
            return this.logic.ReadAll();
        }

        // GET api/<CustomerController>/5
        [HttpGet("{id}")]
        public Customer Read(int id)
        {
            return this.logic.Read(id);
        }

        // POST api/<CustomerController>
        [HttpPost]
        public void Create([FromBody] Customer value)
        {
            this.logic.Create(value);
        }

        // PUT api/<CustomerController>/5
        [HttpPut]
        public void Update([FromBody] Customer value)
        {
            this.logic.Update(value);
        }

        // DELETE api/<CustomerController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            this.logic.Delete(id);
        }
    }
}
