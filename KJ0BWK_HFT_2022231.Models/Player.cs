using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KJ0BWK_HFT_2022231.Models
{
    public class Player
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int PlayerID { get; set; }
        public string Name { get; set; }
        
        [Range(0, 150)]
        public int Age { get; set; }
        [StringLength(3)]
        public string Position { get; set; }
        [Range(0,99)]
        public double Rating{ get; set; }
        public int ClubID { get; set; }
        public virtual Club Club { get; set; }
        public Player()
        {

        }
        public Player(string path)
        {
            string[] split = path.Split('#');
            PlayerID = int.Parse(split[0]);
            Name = split[1];
            Age = int.Parse(split[2]);
            Position = split[3];
            Rating = double.Parse(split[4]);
            ClubID = int.Parse(split[5]);
        }
    }
}
