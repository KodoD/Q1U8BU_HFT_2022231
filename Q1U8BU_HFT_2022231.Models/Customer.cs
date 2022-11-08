
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Q1U8BU_HFT_2022231.Models
{
    public class Customer
    {
        // ID,name,age,
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CustomerID { get; set; }
        [Required]
        [StringLength(240)]
        public string Name { get; set; }
        [Required]
        [Range(18,99)]
        public virtual ICollection<Sales> Sales { get; set; }


        public int Age { get; set; }
        public Customer()
        {
            Sales = new HashSet<Sales>();

        }


        public Customer(string line)
        {
            string[] parts = line.Split('#');
            CustomerID = int.Parse(parts[0]);
            Name = parts[1];
            Age = int.Parse(parts[2]);
            Sales = new HashSet<Sales>();
        }
    }
}
