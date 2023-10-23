using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace RCOSimulator.Data.ViewModels
{
    public static class Constants
    {
        public static readonly string ValidAudience = "Origo";
        public static readonly string ValidIssuer = "RCO";
        public static readonly string Secret = "OrigoTestOrigoTeOrigoTestOrigoTe";
    }

    public class QueryParameters
    {
        public string? Count { get; set; }
        public int? Limit { get; set; }
        public int? Offset { get; set; }
        public string? Include { get; set; }
        public string? Order { get; set; }
    }

    public class CountModel
    {

    }

    public class ListUserModel
    {
        [JsonPropertyName("users")]
        public List<UserModel> Users { get; set; }
        [JsonPropertyName("count")]
        public CountModel Count { get; set; }
    }

    public class ListCardModel
    {
        [JsonPropertyName("cards")]
        public List<CardModel> Cards { get; set; }
        [JsonPropertyName("count")]
        public CountModel Count { get; set; }
    }

    public class ListAccessGroupModel
    {
        [JsonPropertyName("accessgroups")]
        public List<AccessGroupModel> AccessGroups { get; set; }
        [JsonPropertyName("count")]
        public CountModel Count { get; set; }
    }
}
