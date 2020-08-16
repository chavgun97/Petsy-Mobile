using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Petsy.Models.DTO
{
    public class User_x
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
        
        [JsonProperty("Orders")]
        public ICollection<Order_x> Orders { get; set; }
       
        [JsonProperty("Pets")]
        public ICollection<Pet_x> Pets { get; set; }

        public User_x()
        {
            Orders = new List<Order_x>();
            Pets = new List<Pet_x>();
        }
    }
}
