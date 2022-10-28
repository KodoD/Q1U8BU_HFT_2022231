using Castle.Components.DictionaryAdapter;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Q1U8BU_HFT_2022231.Models
{
    internal class Song
    {
        //
        //songid,name,likes
        [System.ComponentModel.DataAnnotations.Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int SongID { get; set; }
        [Required]
        public string Name { get; set; }
        [Range(1,6)]
        public int Like { get; set; }
        public Song(string line)
        {
            string[] parts = line.Split('#');
            SongID=int.Parse(parts[0]);
            Name=parts[1];
            Like=int.Parse(parts[2]);
        }

    }
}
