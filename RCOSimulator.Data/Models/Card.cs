using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RCOSimulator.Data.Models
{
    public class Card
    {
        public Card()
        {
        }

        [Key]
        public int Id { get; set; }
        public int UserId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int Type { get; set; }
        public string CardIdentity { get; set; }
        public byte[] CardIdentityRaw { get; set; }
        public bool IsBlocked { get; set; }
        public bool PinBlocked { get; set; }
        public bool Expired { get; set; }
        public bool Inherituseraccess { get; set; }
        public string Refguid { get; set; }
        public virtual User User { get; set; }
        public virtual ICollection<AccessGroup> AccessGroups { get; set; }
    }
}
