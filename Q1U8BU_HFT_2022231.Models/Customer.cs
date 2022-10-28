using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Q1U8BU_HFT_2022231.Models
{
    public class Students
    {
        // ID,name,age,
        public int CustomerID { get; set; }
        public int Name { get; set; }
        public int Age { get; set; }
        string con = "[DataLibary]/Diak.mdf;Integrated Security=True";

    }
}
