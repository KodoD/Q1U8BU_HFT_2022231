using Q1U8BU_HFT_2022231.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Q1U8BU_HFT_2022231.Logic.Classes
{
    public class MostWanted
    {
        public int Id{ get; set; }
        public string Name{ get; set; }
        public int Count { get; set; }
        public Author author { get; set; } 
    }
}
