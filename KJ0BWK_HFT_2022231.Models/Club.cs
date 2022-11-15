using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KJ0BWK_HFT_2022231.Models
{
    public class Club
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ClubID { get; set; }
        [StringLength(3)]
        public string Name { get; set; }
        [StringLength(10)]
        public string Championship { get; set; }
        [Range(0, 8)]
        public int OwnerID { get; set; }
        public virtual Owner Owner { get; set; }
        public virtual ICollection<Player> Players { get; set; }
        //public virtual ICollection<Owner> Owners { get; set; }
        public Club()
        {
            Players = new HashSet<Player>();
            //Owners = new HashSet<Owner>();
        }
        public Club(string path)
        {
            string[] split = path.Split('#');
            ClubID = int.Parse(split[0]);
            Name = split[1];
            Championship = split[2];
            OwnerID = int.Parse(split[3]);
            Players = new HashSet<Player>();
            //Owners = new HashSet<Owner>();
        }
    }
}
