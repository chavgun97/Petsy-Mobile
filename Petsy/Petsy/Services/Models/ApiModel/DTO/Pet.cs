using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Petsy.Models.DTO
{
    public class Pet
    {
        [JsonProperty("Id")]
        public int Id { get; set; }

        [JsonProperty("UserId")]
        public int UserId { get; set; }

        [JsonProperty("Name")]
        public string Name { get; set; }
        
        [JsonProperty("Sex")]
        public bool Sex { get; set; }
        [JsonProperty("DateOfBirthday")]
        public DateTime DateOfBirthday { get; set; }
        
        [JsonProperty("UrlPhotoLable")]
        public string UrlPhotoLable { get; set; }
       
        [JsonProperty("Kind")]
        public KindOfPet Kind { get; set; }  
        
        [JsonProperty("Breed")]
        public string Breed { get; set; } 
        
        [JsonProperty("Recommendation")]
        public string Recommendation { get; set; }
       
    }
}
