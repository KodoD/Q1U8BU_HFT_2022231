using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Q1U8BU_HFT_2022231.Models
{
     public class Sales
    {
        //SaleID, SaleName,SongID ,CustID,Price, 
        [System.ComponentModel.DataAnnotations.Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int SalesID { get; set; }
        [StringLength(40)]
        public string SaleName { get; set; }
        [Required]
        public int SongID { get; set; }
        [Required]
        public int CustomerID { get; set; }
        [Required]
        [Range(0,100000)]
        public int Price { get; set; }
        public Sales(string line)
        {
            string[] parts = line.Split('#');
            SalesID=int.Parse(parts[0]);
            SaleName=parts[1];
            SongID=int.Parse(parts[2]);
            CustomerID=int.Parse(parts[3]);
            Price=int.Parse(parts[4]);
        }
    }
}
