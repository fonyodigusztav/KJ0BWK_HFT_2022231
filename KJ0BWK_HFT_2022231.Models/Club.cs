using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace KJ0BWK_HFT_2022231.Models
{
    public class Club
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ClubID { get; set; }
        public string Name { get; set; }
        public string Championship { get; set; }
        [ForeignKey(nameof(Owner))]
        public int OwnerID { get; set; }
        [NotMapped]
        public virtual Owner Owner { get; set; }
        [NotMapped]
        [JsonIgnore]
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
        public override string ToString()
        {
            return $"[{ClubID}] : {Name} (Championship: {Championship} , Owner: {OwnerID} - {Owner.Name})";
        }
    }
}
