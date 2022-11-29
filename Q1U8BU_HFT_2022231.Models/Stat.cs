using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Q1U8BU_HFT_2022231.Models
{
    public class Favorite
    {


        public int ID { get; set; }
        public string Name { get; set; }
        public int Likes{ get; set; }
        public string author { get; set; }

        public override bool Equals(object obj) { 
            if (obj is Favorite) {
                Favorite other = obj as Favorite;
                return this.Name == other.Name && this.ID == other.ID && this.Likes == other.Likes;
            } 
            else { return false; } }

    }
    public class RegularGuest
    {


        public int ID { get; set; }
        public string Name { get; set; }
        public int SpentM { get; set; }

    }
    public class MostWanted
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Count { get; set; }
    }
}
