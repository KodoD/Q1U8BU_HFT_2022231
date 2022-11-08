using Castle.Core.Resource;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Q1U8BU_HFT_2022231.Models
{
    public class Author
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int AutherId { get; set; }
        public string Name { get; set; }
        public virtual ICollection<Song> Songs{ get; set; }
        public Author()
        {
            Songs = new HashSet<Song>();

        }

        public Author(string line)
        {
            string[] parts = line.Split('#');
            AutherId = int.Parse(parts[0]);
            Name = parts[1];
            Songs = new HashSet<Song>();

        }


    }
}
