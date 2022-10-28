using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Q1U8BU_HFT_2022231.Models
{
    internal class Sales
    {
        //SaleID, SaleName,SongID ,CustID,Price, 
        public int SalesID { get; set; }
        public string SaleName { get; set; }
        public int SongID { get; set; }
        public int CustomerID { get; set; }
        public int Price { get; set; }
    }
}
