using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Petsy.Models.DTO
{
    public class Order_x
    {
        [JsonProperty("Id")]
        public int Id { get; set; }

        [JsonProperty("Name")]
        public string Name { get; set; }

        [JsonProperty("PriseInCoin")]
        public int PriseInCoin { get; set; }
        
        [JsonProperty("Type")]
        public TypeSitter_x Type { get; set; }
        
        [JsonProperty("From")]
        public DateTime? From { get; set; }
        
        [JsonProperty("To")]
        public DateTime? To { get; set; }
        
        [JsonProperty("IsActive")]
        public bool IsActive { get; set; }
        
        [JsonProperty("User")]
        public User_x User { get; set; }
        
        [JsonProperty("Sitter")]
        public Sitter_x Sitter { get; set; }
       
        [JsonProperty("Pet")]
        public Pet_x Pet { get; set; }
    }
}
