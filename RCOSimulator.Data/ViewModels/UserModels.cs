using Newtonsoft.Json;
using RCOSimulator.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace RCOSimulator.Data.ViewModels
{
    public class UserModel
    {
        public virtual int Id { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string? Address { get; set; }
        public string? City { get; set; }
        public string? Postalcode { get; set; }
        public string? Phone1 { get; set; }
        public string? Phone2 { get; set; }
        public string? Phone3 { get; set; }
        public string Email { get; set; }
        [JsonPropertyName("employmenttext")]
        [JsonRequired]
        public string EmploymentText { get; set; }
        [JsonPropertyName("employmentnumber")]
        public int? EmploymentNumber { get; set; }
        [JsonPropertyName("startdate")]
        public DateTime? StartDate { get; set; }
        [JsonPropertyName("enddate")]
        public DateTime? EndDate { get; set; }
        public UserType Type { get; set; }
    }

    public class UserCreateModel : UserModel
    {
        [System.Text.Json.Serialization.JsonIgnore]
        public override int Id { get => base.Id; set => base.Id = value; }
    }

    public class UserUpdateModel : UserModel
    {
        public override int Id { get => base.Id; set => base.Id = value; }
    }
}
