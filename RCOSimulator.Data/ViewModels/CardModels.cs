using RCOSimulator.Data.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace RCOSimulator.Data.ViewModels
{
    public class CardModel
    {
        public virtual int Id { get; set; }
        [JsonPropertyName("fkusernumber")]
        public int FkUserNumber { get; set; }
        public string Name { get; set; }
        public CardTypes Type { get; set; }
        [Required]
        [JsonPropertyName("cardidentity")]
        public string CardIdentity { get; set; }
        [JsonPropertyName("cardidentityraw")]
        public virtual byte[] CardIdentityRaw { get; set; }
        [JsonPropertyName("isblocked")]
        public bool IsBlocked { get; set; }
        [JsonPropertyName("pinblocked")]
        public bool PinBlocked { get; set; }
        [JsonPropertyName("expired")]
        public bool Expired { get; set; }
        [JsonPropertyName("inherituseraccess")]
        public bool Inherituseraccess { get; set; }
        public string Refguid { get; set; }
        [JsonPropertyName("user")]
        public virtual UserModel User { get; set; }
        [JsonPropertyName("accessgroups")]
        public virtual List<AccessGroupModel> AccessGroups { get; set; }
    }

    public class CardCreateModel : CardModel
    {
        [JsonIgnore]
        public override int Id { get => base.Id; set => base.Id = value; }
        [JsonIgnore]
        public override byte[]? CardIdentityRaw { get => base.CardIdentityRaw; set => base.CardIdentityRaw = value; }
        [JsonIgnore]
        public override List<AccessGroupModel>? AccessGroups { get => base.AccessGroups; set => base.AccessGroups = value; }
        [JsonIgnore]
        public override UserModel? User { get => base.User; set => base.User = value; }
    }

    public class CardUpdateMode : CardCreateModel
    {

    }
}
