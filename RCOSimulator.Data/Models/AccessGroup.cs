using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RCOSimulator.Data.Models
{
    public class AccessGroup
    {
        public AccessGroup() 
        {
        }
        [Key]
        public int Id { get; set; } 
        public string Name { get; set; }
        public virtual ICollection<Card> Cards { get; set; }
    }
}
