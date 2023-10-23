using RCOSimulator.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace RCOSimulator.Data.ViewModels
{
    public class LoginModel
    {
        public string Id { get; set; }
        public string System { get; set; }
        public string Lang { get; set; } = "en";
        public string User { get; set; }
        public string Password { get; set; }
        [JsonPropertyName("apitype")]
        public string ApiType { get; set; } = "main";
        [JsonPropertyName("apikey")]
        public string ApiKey { get; set; }
    }

    public class LoginSuccessModel
    {
        [JsonPropertyName("accesstoken")]
        public string AccessToken { get; set; }
    }

    public class LoginErrorModel
    {
        [JsonPropertyName("errorcode")]
        public ResponseStatus ErrorCode { get; set; }
        [JsonPropertyName("friendlymessage")]
        public string FriendlyMessage { get; set; }
        [JsonPropertyName("developermessage")]
        public string DeveloperMessage { get; set; }
        [JsonPropertyName("moreinfo")]
        public string MoreInfo { get; set; }
        [JsonPropertyName("reject")]
        public string Reject { get; set; }
    }
}
