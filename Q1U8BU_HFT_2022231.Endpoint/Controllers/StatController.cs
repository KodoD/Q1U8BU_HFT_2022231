﻿using Microsoft.AspNetCore.Mvc;
using Q1U8BU_HFT_2022231.Logic;
using Q1U8BU_HFT_2022231.Models;
using System.Collections.Generic;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Q1U8BU_HFT_2022231.Endpoint.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class StatController : ControllerBase
    {
        ISongLogic logic;
        ISalesLogic logic2;


        // GET: api/<Stat>
        [HttpGet]
        public IEnumerable<Favorite> Get()
        {
            return this.logic.Favoriterank();
        }

        // GET api/<Stat>/5
        [HttpGet]
        public IEnumerable<Favorite> GetLeastFavorite()
        {
            return this.logic.leastFavoriterank();
        }

        // POST api/<Stat>
        [HttpGet]
        public IEnumerable<MostWanted> GetMostWanted()
        {
            return this.logic2.MostWanted();
        }

        // POST api/<Stat>
        [HttpGet]
        public IEnumerable<MostWanted> GetLeastWanted()
        {
            return this.logic2.LeastWanted();
        }
        // POST api/<Stat>
        [HttpGet]
        public IEnumerable<RegularGuest> GetRegularGuests()
        {
            return this.logic2.RegularGuests();
        }
    }
}