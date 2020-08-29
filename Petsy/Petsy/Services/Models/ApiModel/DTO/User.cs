using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using static Petsy.Models.RequestJSON.RequestsJSON;

namespace Petsy.Models.DTO
{
    public class User
    {
        [JsonProperty("Id")]
        public int Id { get; set; }
        [JsonProperty("Name")]
        public string Name { get; set; }        
        [JsonProperty("UID")]
        public string UID { get; set; }        
        [JsonProperty("UrlPhotoLable")]
        public string UrlPhotoLable { get; set; }
        [JsonProperty("TestAmountInCoins")]
        public int TestAmountInCoins { get; set; }
        [JsonIgnore]
        public ICollection<Order> Orders { get; set; }
        [JsonIgnore]
        public ICollection<Pet> Pets { get; set; }
        public User()
        {
            Orders = new List<Order>();
            Pets = new List<Pet>();
        }
    }
}
