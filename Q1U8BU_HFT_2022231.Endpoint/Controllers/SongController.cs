using Microsoft.AspNetCore.Mvc;
using Q1U8BU_HFT_2022231.Logic;
using Q1U8BU_HFT_2022231.Models;
using System.Collections.Generic;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Q1U8BU_HFT_2022231.Endpoint.Controllers
{
    [Route("api/[controller]")]
    public class SongController : ControllerBase
    {
        ISongLogic logic;

        public SongController(ISongLogic logic)
        {
            this.logic = logic;
        }

        // GET: api/<SongController>
        [HttpGet]
        public IEnumerable<Song> ReadAll()
        {
            return this.logic.ReadAll();
        }

        // GET api/<SongController>/5
        [HttpGet("{id}")]
        public Song Read(int id)
        {
            return this.logic.Read(id);
        }

        // POST api/<SongController>
        [HttpPost]
        public void Create([FromBody] Song value)
        {
            this.logic.Create(value);
        }

        // PUT api/<SongController>/5
        [HttpPut]
        public void Update([FromBody] Song value)
        {
            this.logic.Update(value);
        }

        // DELETE api/<SongController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            this.logic.Delete(id);
        }
    }
}
