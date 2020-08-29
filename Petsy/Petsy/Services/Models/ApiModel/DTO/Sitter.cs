using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Petsy.Models.DTO
{
    public class Sitter
    {
        [JsonProperty("Id")]
        public int Id { get; set; }
        
        [JsonProperty("UID")]
        public string UID { get; set; }
        
        [JsonProperty("UrlPhotoLable")]
        public string UrlPhotoLable { get; set; }
       
        [JsonProperty("Name")]
        public string Name { get; set; }
       
        [JsonProperty("Surname")]
        public string Surname { get; set; }
       
        [JsonProperty("Location")]
        public string Location { get; set; }
       
        [JsonProperty("Reiting")]
        public int Reiting { get; set; } // max 50
        
        [JsonProperty("Types")]
        public TypeSitter[] Types { get; set; }  //заменить на списко медлей
        
        [JsonProperty("KindofPet")]
        public KindOfPet KindofPet { get; set; } //заменить на списко медлей
        
        [JsonProperty("PricePerHourInCoins")]
        public int PricePerHourInCoins { get; set; }
        
        [JsonProperty("PricePerDayInCoins")]
        public int PricePerDayInCoins { get; set; }
       
        [JsonProperty("TestAmountInCoins")]
        public int TestAmountInCoins { get; set; }

        [JsonProperty("OnlineStatus")]
        public bool OnlineStatus { get; set; }
        
        [JsonProperty("Level")]
        public string Level { get; set; }

        [JsonProperty("Description")]
        public String Description { get; set; }

        [JsonIgnore]
        public ICollection<Order> Orders { get; set; }
    }
}
