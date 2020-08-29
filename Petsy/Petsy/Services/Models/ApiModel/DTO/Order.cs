using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Petsy.Models.DTO
{
    public class Order
    {
        [JsonProperty("Id")]
        public int Id { get; set; }

        [JsonProperty("Name")]
        public string Name { get; set; }

        [JsonProperty("PriseInCoin")]
        public int PriseInCoin { get; set; }
        
        [JsonProperty("Type")]
        public TypeSitter Type { get; set; }
        
        [JsonProperty("DateFrom")]
        public DateTime? From { get; set; }
        
        [JsonProperty("DateTo")]
        public DateTime? To { get; set; }
        
        [JsonProperty("IsActive")]
        public bool IsActive { get; set; }
        
        [JsonProperty("Sitter")]
        public Sitter Sitter { get; set; }
       
        [JsonProperty("Pet")]
        public Pet Pet { get; set; }

        [JsonIgnore]
        public string AddingInfornation { get; set; }
    }
}
