using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RCOSimulator.Data.Models
{
    public class AccessGroupCard
    {
        [Key] 
        public int Id { get; set; }
        public int CardId { get; set; }
        public int AccessGroupId { get; set; }
    }
}
