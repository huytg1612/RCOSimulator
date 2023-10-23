using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace RCOSimulator.Data.ViewModels
{
    public class AccessGroupModel
    {
        public virtual int Id { get; set; }
        [Required]
        public string Name { get; set; }

    }

    public class AccessGroupCreateModel : AccessGroupModel
    {
        [JsonIgnore]
        public override int Id { get => base.Id; set => base.Id = value; }
    }
}
