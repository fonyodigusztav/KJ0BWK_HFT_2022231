﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KJ0BWK_HFT_2022231.Models
{
    public class Owner
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int OwnerID { get; set; }
        [StringLength(30)]
        public string Name { get; set; }
        [Range(0, 8)]
        public int ClubID { get; set; }
        [Range(0, 99)]
        public int Age { get; set; }
        public virtual Club Club { get; set; }
        public virtual ICollection<Club> Clubs { get; set; }
        public Owner()
        {
            Clubs = new HashSet<Club>();
        }
        public Owner(string path)
        {
            string[] split = path.Split('#');
            OwnerID = int.Parse(split[0]);
            Name = split[1];
            ClubID = int.Parse(split[2]);
            Age = int.Parse(split[3]);
            Clubs = new HashSet<Club>();
        }
    }
}
